﻿using Prizm.Data.DAL;
using Prizm.Domain.Entity.Mill;
using Prizm.Main.Commands;
using Prizm.Main.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizm.Main.Forms.Reports.Mill
{
    public class PreviewReportCommand: ICommand
    {
        readonly IMillReportsRepository repo;
        readonly MillReportsViewModel viewModel;
        readonly IUserNotify notify;
        DataSet data;

        public event RefreshVisualStateEventHandler RefreshVisualStateEvent = delegate { };

        public PreviewReportCommand(MillReportsViewModel viewModel, IMillReportsRepository repo, IUserNotify notify)
        {
            this.viewModel = viewModel;
            this.repo = repo;
            this.notify = notify;
        }

        public void Execute()
        {
            if (viewModel.StartDate > viewModel.EndDate)
            {
                notify.ShowNotify(Resources.AlertFailureReportDate, Resources.AlertFailureReportDateHeader);
            }
            try
            {
                if (viewModel.SelectedReportType == ReportType.ByProducing)
                {
                    data = repo.GetPipes(viewModel.StartDate, viewModel.EndDate);
                    AdditionToTheReport report = new AdditionToTheReport();
                    BindingList<double> counts = repo.CountPipe(viewModel.StartDate, viewModel.EndDate);
                    report.PipesCount = counts[0];
                    report.PipesLength = counts[1];
                    report.PipesWeight = counts[2];
                    report.DataSource = data;
                    report.CreateDocument();
                    viewModel.PreviewSource = report;
                }
                else 
                { 
                    data = repo.GetPipesByStatus(viewModel.StartDate, viewModel.EndDate, viewModel.SearchIds, viewModel.SelectedReportType, viewModel.SearchStatuses, true);
                    MillReportsXtraReport report = new MillReportsXtraReport();
                    report.DataSource = data;
                    report.CreateDocument();
                    viewModel.PreviewSource = report;
                }
            }
            catch (RepositoryException ex)
            {
                notify.ShowFailure(ex.InnerException.Message, ex.Message);
            }
          
        }
   
        public bool CanExecute()
        {
            return true;
        }

    }
}
