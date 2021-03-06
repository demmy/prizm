﻿using DevExpress.Mvvm.DataAnnotations;
using Prizm.Data.DAL;
using Prizm.Main.Commands;
using Prizm.Main.Common;
using Prizm.Main.Properties;
using Prizm.Main.Forms.ExternalFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prizm.Main.Languages;

namespace Prizm.Main.Forms.ExternalFile
{
    public class ViewFileCommand : ICommand
    {
        private readonly IFileRepository repo;
        private readonly ExternalFilesViewModel viewModel;
        private readonly IUserNotify notify;

        public event RefreshVisualStateEventHandler RefreshVisualStateEvent = delegate { };

        public ViewFileCommand(IFileRepository repo, ExternalFilesViewModel viewModel, IUserNotify notify)
        {
            this.repo = repo;
            this.viewModel = viewModel;
            this.notify = notify;
        }

        [Command(UseCommandManager = false)]
        public void Execute()
        {

            string sourceFile = Path.Combine(Directories.TargetPath, viewModel.SelectedFile.NewName);
            string tempFile = Path.Combine(Directories.TargetPathForView, Guid.NewGuid() + viewModel.SelectedFile.FileName.Substring(viewModel.SelectedFile.FileName.LastIndexOf('.')));

            if(!Directory.Exists(Directories.TargetPathForView))
            {
                Directory.CreateDirectory(Directories.TargetPathForView);
                DirectoryInfo directoryInfo = new DirectoryInfo(Directories.TargetPathForView);
                directoryInfo.Attributes |= FileAttributes.Hidden;
            }

            if(File.Exists(sourceFile))
            {
                File.Copy(sourceFile, tempFile);
                System.Diagnostics.Process.Start(tempFile);
            }
        }

        public bool CanExecute()
        {
            return viewModel.SelectedFile.NewName != null;
        }
    }
}
