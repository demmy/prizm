﻿using Data.DAL.Mill;
using DevExpress.Mvvm.DataAnnotations;
using Domain.Entity.Mill;
using PrizmMain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizmMain.Forms.Spool
{
    public class SpoolSearchCommand : ICommand
    {
        readonly IPipeRepository repo;
        readonly SpoolViewModel viewModel;
        readonly IUserNotify notify;

        public SpoolSearchCommand(SpoolViewModel viewModel, IPipeRepository repo,IUserNotify notify)
        {
            this.viewModel = viewModel;
            this.repo = repo;
            this.notify = notify;
        }

        [Command(UseCommandManager = false)]
        public void Execute() 
        {
            viewModel.Pipe = repo.GetByNumber(viewModel.PipeNumber);
            viewModel.ModifiableView.IsModified = false;
        }


        public bool CanExecute()
        {
            return true;
        }

        public virtual bool IsExecutable { get; set; }
    }
}
