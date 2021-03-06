﻿using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraEditors;
using Prizm.Domain.Entity.Mill;
using Ninject;
using Prizm.Main.Commands;
using Prizm.Main.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prizm.Main.Languages;
using Prizm.Main.Security;
using Prizm.Domain.Entity.SimpleReleaseNote;
using Prizm.Data.DAL;

namespace Prizm.Main.Forms.ReleaseNote.NewEdit
{
    public class ShipReleaseNoteCommand : ICommand
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ShipReleaseNoteCommand));

        private readonly IReleaseNoteRepositories repos;
        private readonly ReleaseNoteViewModel viewModel;
        private readonly IUserNotify notify;
        private readonly ISecurityContext ctx;

        public event RefreshVisualStateEventHandler RefreshVisualStateEvent = delegate { };

        [Inject]
        public ShipReleaseNoteCommand(ReleaseNoteViewModel viewModel, IReleaseNoteRepositories repo, IUserNotify notify, ISecurityContext ctx)
        {
            this.viewModel = viewModel;
            this.repos = repo;
            this.notify = notify;
            this.ctx = ctx;
        }

        [Command(UseCommandManager = false)]
        public void Execute()
        {
            try
            {
                bool noPipe = false;

                foreach(SimpleRailcar r in viewModel.ReleaseNote.Railcars)
                {
                    if(r.Pipes.Count == 0)
                    {
                        noPipe = true;
                    }
                }

                if(noPipe)
                {
                    notify.ShowError(Program.LanguageManager.GetString(StringResources.ReleaseNoteNewEdit_PipesAbsent),
                        Program.LanguageManager.GetString(StringResources.Message_ErrorHeader));
                    return;
                }

                if(!noPipe)
                {
                    foreach(SimpleRailcar r in viewModel.Railcars)
                    {
                        r.IsShipped = true;
                        foreach(var pipe in r.Pipes)
                        {
                            pipe.Status = PipeMillStatus.Shipped;

                            pipe.ToExport = true;
                        }
                    }
                    viewModel.Shipped = true;
                    notify.ShowSuccess(Program.LanguageManager.GetString(StringResources.ReleaseNoteNewEdit_Shipped) + " #" + viewModel.ReleaseNote.Number,
                        Program.LanguageManager.GetString(StringResources.Alert_InfoHeader));

                    log.Info(string.Format("Shipment is successful. Release Note #{0}, id:{1}.",
                        viewModel.ReleaseNote.Number,
                        viewModel.ReleaseNote.Id));

                    viewModel.SaveCommand.Execute();
                }

                RefreshVisualStateEvent();
            }
            catch(RepositoryException ex)
            {
                log.Warn(this.GetType().Name + " | " + ex.ToString());
                notify.ShowWarning(Program.LanguageManager.GetString(StringResources.Notification_Error_Db_Message),
            Program.LanguageManager.GetString(StringResources.Notification_Error_Db_Header));
            }
        }

        public bool CanExecute()
        {
            return !viewModel.Shipped
                && !string.IsNullOrWhiteSpace(viewModel.Number)
                && viewModel.ReleaseNotePipes.Count > 0
                && ctx.HasAccess(global::Domain.Entity.Security.Privileges.EditReleaseNote);
        }
    }
}
