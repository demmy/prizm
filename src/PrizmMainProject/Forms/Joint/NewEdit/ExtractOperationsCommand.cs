﻿using DevExpress.Mvvm.DataAnnotations;
using Domain.Entity.Setup;
using PrizmMain.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizmMain.Forms.Joint.NewEdit
{
    public class ExtractOperationsCommand : ICommand
    {
        readonly IConstructionRepository repo;
        readonly JointNewEditViewModel viewModel;

        public ExtractOperationsCommand(IConstructionRepository repo, JointNewEditViewModel viewModel)
        {
            this.repo = repo;
            this.viewModel = viewModel;
        }

        [Command(UseCommandManager = false)]
        public void Execute()
        {
            var controlOperations = repo.RepoJointOperation.GetControlOperations();
            viewModel.ControlOperations = new BindingList<JointOperation>(controlOperations);
            var repairOperations = repo.RepoJointOperation.GetRepairOperations();
            viewModel.RepairOperations = new BindingList<JointOperation>(repairOperations);
        }

        public bool CanExecute()
        {
            return true;
        }
        public virtual bool IsExecutable { get; set; }
    }
}
