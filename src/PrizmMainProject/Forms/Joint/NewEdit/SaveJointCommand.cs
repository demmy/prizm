﻿using Data.DAL;
using DevExpress.Mvvm.DataAnnotations;
using PrizmMain.Commands;
using PrizmMain.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.POCO;

namespace PrizmMain.Forms.Joint.NewEdit
{
    public class SaveJointCommand : ICommand
    {
        private readonly IConstructionRepository repo;
        private readonly JointNewEditViewModel viewModel;
        private readonly IUserNotify notify;

        public SaveJointCommand(IConstructionRepository repo, JointNewEditViewModel viewModel, IUserNotify notify)
        {
            this.repo = repo;
            this.viewModel = viewModel;
            this.notify = notify;
        }

        [Command(UseCommandManager = false)]
        public void Execute()
        {
            if (viewModel.Joint.LoweringDate == DateTime.MinValue)
            {
                viewModel.Joint.LoweringDate = null;
            }
            var j = repo.RepoJoint.GetActiveByNumber(viewModel.Joint);
            foreach (var joint in j)
            {
                repo.RepoJoint.Evict(joint);
            }
            if (j != null && j.Count > 0)
            {
                notify.ShowInfo(
                    string.Concat(Resources.DLG_JOINT_DUPLICATE, viewModel.Number),
                    Resources.DLG_JOINT_DUPLICATE_HEADER);
                viewModel.Number = string.Empty;
            }
            else
            {
                try
                {
                    repo.BeginTransaction();
                    repo.RepoJoint.SaveOrUpdate(viewModel.Joint);
                    repo.Commit();
                    repo.RepoJoint.Evict(viewModel.Joint);
                    viewModel.ModifiableView.IsModified = false;
                    notify.ShowNotify(
                        string.Concat(Resources.DLG_JOINT_SAVED, viewModel.Number),
                        Resources.DLG_JOINT_SAVED_HEADER);
                }
                catch (RepositoryException ex)
                {
                    notify.ShowFailure(ex.InnerException.Message, ex.Message);
                }
            }
        }

        public virtual bool IsExecutable { get; set; }

        protected virtual void OnIsExecutableChanged()
        {
            this.RaiseCanExecuteChanged(x => x.Execute());
        }

        public bool CanExecute()
        {
             bool condition = !string.IsNullOrEmpty(viewModel.Number) && viewModel.FirstElement!=null && viewModel.SecondElement !=null;
             return condition;
        }
    }
}
