﻿using DevExpress.Mvvm.DataAnnotations;
using Prizm.Domain.Entity.Mill;
using Prizm.Main.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizm.Main.Forms.Settings
{
    public class ExtractCategoriesCommand : ICommand
    {
        readonly ISettingsRepositories repos;
        readonly SettingsViewModel viewModel;
        readonly IUserNotify notify;

        public event RefreshVisualStateEventHandler RefreshVisualStateEvent = delegate { };

        public ExtractCategoriesCommand(
            SettingsViewModel viewModel, 
            ISettingsRepositories repos, 
            IUserNotify notify)
        {
            this.viewModel = viewModel;
            this.repos = repos;
            this.notify = notify;
        }

        [Command(UseCommandManager = false)]
        public void Execute()
        {
            viewModel.CategoryTypes
                = new BindingList<Category>(repos.СategoryRepo.GetAll());
        }


        public bool CanExecute()
        {
            return true;
        }

    }
}
