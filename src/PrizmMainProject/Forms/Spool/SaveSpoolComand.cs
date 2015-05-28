﻿using Prizm.Data.DAL.Construction;
using Prizm.Data.DAL.Mill;
using DevExpress.Mvvm.DataAnnotations;
using Prizm.Main.Commands;
using Prizm.Main.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prizm.Main.Properties;
using DevExpress.Mvvm.POCO;
using Prizm.Main.Security;
using Ninject;
using Prizm.Main.Languages;
using Prizm.Data.DAL;
using Prizm.Domain.Entity.Construction;
using Prizm.Data.DAL.ADO;
using Prizm.Domain.Entity;

namespace Prizm.Main.Forms.Spool
{
    public class SaveSpoolCommand : ICommand
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(SaveSpoolCommand));
        readonly IDuplicateNumberRepository repo = new DuplicateNumberRepository();
        readonly ISpoolRepositories repos;
        readonly SpoolViewModel viewModel;
        readonly IUserNotify notify;
        readonly ISecurityContext ctx;
        private int numberOfOperationWithoutInspectors = 0;
        public event RefreshVisualStateEventHandler RefreshVisualStateEvent = delegate { };

        public SaveSpoolCommand(SpoolViewModel viewModel, ISpoolRepositories repos, IUserNotify notify, ISecurityContext ctx)
        {
            this.viewModel = viewModel;
            this.repos = repos;
            this.notify = notify;
            this.ctx = ctx;
        }

        [Command(UseCommandManager = false)]
        public void Execute()
        {
            if (!viewModel.InspectionTestResults.All(x => x.Date.IsValid()))
            {
                notify.ShowInfo(Program.LanguageManager.GetString(StringResources.WrongDate),
                    Program.LanguageManager.GetString(StringResources.Message_ErrorHeader));
                log.Warn("Date limits not valid!");
                return;
            }

            var duplicateNumber = repo.GetAllActiveDuplicateEntityByNumber(viewModel.Spool.Number).Distinct(new DuplicateNumberEntityComparer()).ToList();

            if (duplicateNumber != null && duplicateNumber.Count > 0)
            {
                DuplicateNumberEntityType translateFirstElement = (DuplicateNumberEntityType)Enum.Parse(typeof(DuplicateNumberEntityType),
                         duplicateNumber[0].EntityType);
                String result = viewModel.localizedAllPartType[(int)((object)translateFirstElement) - 1];

                for (int i = 1; i <= duplicateNumber.Count - 1; i++)
                {
                    DuplicateNumberEntityType translate = (DuplicateNumberEntityType)Enum.Parse(typeof(DuplicateNumberEntityType),
                         duplicateNumber[i].EntityType);
                    result = result + ", " + viewModel.localizedAllPartType[(int)((object)translate) - 1];
                }

                notify.ShowInfo(
                  string.Concat(Program.LanguageManager.GetString(StringResources.DuplicateEntity_Message) + result),
                  Program.LanguageManager.GetString(StringResources.DuplicateEntity_MessageHeader));
                viewModel.SpoolNumber = string.Empty;

            }
            else
            {
                if (viewModel.Spool.Length != 0)
                {
                    if (viewModel.CanCut)
                    {
                        foreach (InspectionTestResult t in viewModel.InspectionTestResults)
                        {
                            if (t.Status != PartInspectionStatus.Pending && t.Inspectors.Count <= 0)
                            {
                                numberOfOperationWithoutInspectors++;
                            }
                        }

                        if (numberOfOperationWithoutInspectors == 0)
                        {
                            try
                            {
                                viewModel.Pipe.ToExport = true;
                                viewModel.Pipe.IsCutOnSpool = true;
                                viewModel.Spool.Number = viewModel.Spool.Number.ToUpper();
                                viewModel.Spool.InspectionStatus = viewModel.Spool.GetPartInspectionStatus();
                                repos.BeginTransaction();
                                repos.PipeRepo.SaveOrUpdate(viewModel.Pipe);
                                repos.SpoolRepo.SaveOrUpdate(viewModel.Spool);

                                var filesViewModel = viewModel.FilesFormViewModel;

                                //saving attached existingDocuments
                                bool fileCopySuccess = true;
                                if (null != filesViewModel)
                                {
                                    filesViewModel.FileRepo = repos.FileRepo;
                                    viewModel.FilesFormViewModel.Item = viewModel.Spool.Id;
                                    if (!viewModel.FilesFormViewModel.TrySaveFiles(viewModel.Pipe))
                                    {
                                        fileCopySuccess = false;
                                        repos.Rollback();
                                    }
                                }

                                if (fileCopySuccess)
                                {
                                    repos.Commit();
                                }

                                repos.PipeRepo.Evict(viewModel.Pipe);
                                repos.SpoolRepo.Evict(viewModel.Spool);

                                if (fileCopySuccess)
                                {
                                    if (null != filesViewModel)
                                    {
                                        filesViewModel.DetachFileEntities();
                                    }

                                    notify.ShowNotify(
                                        Program.LanguageManager.GetString(StringResources.Spool_CutSpoolFromPipe),
                                        Program.LanguageManager.GetString(StringResources.Spool_CutSpoolFromPipeHeader));

                                    log.Info(string.Format("The entity #{0}, id:{1} has been saved in DB.",
                                        viewModel.Spool.Number,
                                        viewModel.Spool.Id));


                                }
                                else
                                {
                                    notify.ShowError(Program.LanguageManager.GetString(StringResources.ExternalFiles_NotCopied),
                                                     Program.LanguageManager.GetString(StringResources.ExternalFiles_NotCopied_Header));
                                    log.Info(string.Format("File for entity #{0}, id:{1} hasn't been saved ",
                                        viewModel.Spool.Number,
                                        viewModel.Spool.Id));
                                }

                                viewModel.ModifiableView.IsModified = false;

                                string oldPipeNumber = viewModel.Pipe.Number;
                                viewModel.NewSpool();
                                viewModel.ModifiableView.Id = viewModel.Spool.Id;
                                viewModel.PipeNumber = oldPipeNumber;
                                RefreshVisualStateEvent();
                            }
                            catch (RepositoryException ex)
                            {
                                log.Error(ex.Message);
                                notify.ShowFailure(ex.InnerException.Message, ex.Message);
                            }
                        }
                        else
                        {
                            notify.ShowError(
                          Program.LanguageManager.GetString(StringResources.SelectInspectorsForTestResult),
                            Program.LanguageManager.GetString(StringResources.SelectInspectorsForTestResultHeader));
                            viewModel.ModifiableView.IsEditMode = true;
                        }
                    }
                    else
                    {
                        notify.ShowError(
                             Program.LanguageManager.GetString(StringResources.Spool_SpoolLengtBigerThenPipeLength),
                             Program.LanguageManager.GetString(StringResources.Spool_CutSpoolFromPipeHeader));
                        viewModel.ModifiableView.IsEditMode = true;
                        numberOfOperationWithoutInspectors = 0;
                    }
                }
                else
                {
                    notify.ShowError(
                          Program.LanguageManager.GetString(StringResources.Spool_NullSpoolLength),
                             Program.LanguageManager.GetString(StringResources.Spool_CutSpoolFromPipeHeader));
                    viewModel.ModifiableView.IsEditMode = true;
                }
            }
        }

        public bool CanExecute()
        {
            return viewModel.ModifiableView.IsEditMode
                && viewModel.SpoolIsActive
                && !string.IsNullOrEmpty(viewModel.PipeNumber)
                && ctx.HasAccess(viewModel.IsNew
                    ? global::Domain.Entity.Security.Privileges.CreateSpool
                    : global::Domain.Entity.Security.Privileges.EditSpool);
        }
    }
}
