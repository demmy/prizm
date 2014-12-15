﻿using Data.DAL.Construction;
using Data.DAL.Mill;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using Domain.Entity.Construction;
using Domain.Entity.Mill;
using Ninject;
using PrizmMain.Commands;
using PrizmMain.Documents;
using PrizmMain.Forms.PipeMill;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizmMain.Forms.Spool
{
    public class SpoolViewModel : ViewModelBase, IDisposable
    {
        private readonly ISpoolRepository repoSpool;
        private readonly IPipeRepository repoPipe;
        readonly ICommand searchCommand;
        readonly ICommand cutCommand;
        readonly ICommand saveCommand;
        public string pipeNumber;
        public string spoolNumber;
        public int pipeLength;
        public int spoolLength;
        readonly IUserNotify notify;
        private IModifiable modifiableView;
        public Domain.Entity.Construction.Spool Spool { get; set; }
        public BindingList<Pipe> allPipes { get; set; }

        [Inject]
        public SpoolViewModel(IPipeRepository repoPipe, ISpoolRepository repoSpool, IUserNotify notify)
        {
            this.repoPipe = repoPipe;
            this.repoSpool = repoSpool;
            this.notify=notify;

            searchCommand = ViewModelSource.Create<EditPipeForCutCommand>(
              () => new EditPipeForCutCommand(this, repoPipe, notify));

            cutCommand = ViewModelSource.Create<CutSpoolCommand>(
             () => new CutSpoolCommand(this, repoPipe, repoSpool,notify));

            saveCommand = ViewModelSource.Create<SaveSpoolCommand>(
            () => new SaveSpoolCommand(this, repoSpool, notify));

            allPipes = new BindingList<Pipe>();

            foreach (Pipe p in repoSpool.GetAvailablePipes()) 
            {
                allPipes.Add(p);
            }
            Spool = new Domain.Entity.Construction.Spool();
            Spool.Pipe = new Pipe();
            Pipe = new Pipe();
            
            
        }

        public string SpoolNumber
        {
            get { return Spool.Number; }
            set
            {
                if (value != Spool.Number)
                {
                    Spool.Number = value;
                    RaisePropertyChanged("SpoolNumber");
                }
            }
        }

        public string PipeNumber
        {
            get
            {
                return Spool.PipeNumber;
            }
            set
            {
                if (value != Spool.PipeNumber)
                {
                    Spool.PipeNumber = value;

                    StringBuilder number = new StringBuilder();
                    int spoolNumber = repoSpool.GetAllSpoolFromPipe(Spool.PipeNumber).Count + 1;
                    number.Append(Spool.PipeNumber + "/" + spoolNumber.ToString());
                    Spool.Number = number.ToString();

                    RaisePropertyChanged("PipeNumber");
                }
            }
        }

        public Pipe SpoolPipe
        {
            get { return Spool.Pipe;}
            set
            {
                if (value != Spool.Pipe)
                {
                    Spool.Pipe = value;
                    this.PipeWeight = Pipe.ChangePipeWeight(Pipe.WallThickness, Pipe.Diameter, Pipe.Length);
                    RaisePropertyChanged("PipeNumber");
                }
            }
        }

        // TODO: fixed if pipe number was wrong
        public int PipeLength
        {
            get
            {
                return Pipe.Length;
            }
            set
            {
                if (value != Pipe.Length)
                {
                    Pipe.Length = value;                    
                    this.PipeWeight = Pipe.ChangePipeWeight(Pipe.WallThickness, Pipe.Diameter, Pipe.Length);
                    RaisePropertyChanged("PipeLength");

                    //RaisePropertyChanged("PipeWeight");
                }
            }
        }

        public float PipeWeight
        {
            get
            {
                return Pipe.Weight;
            }
            set
            {
                if (value != Pipe.Weight)
                {
                    Pipe.Weight = value;
                    RaisePropertyChanged("PipeWeight");
                }
            }
        }

        public int SpoolLength
        {
            get { return Spool.Length; }
            set
            {
                if (value != Spool.Length)
                {
                    Spool.Length = value;
                    Pipe.Length = Pipe.Length - Spool.Length;
                    Pipe.RecalculateWeight();
                    RaisePropertyChanged("SpoolLength");
                }
            }
        }

        public Pipe Pipe
        {
            get { return Spool.Pipe; }
            set
            {
                if (value != Spool.Pipe)
                {
                    Spool.Pipe = value;
                    RaisePropertyChanged("SpoolLength");
                }
            }
        }

        public Documents.IModifiable ModifiableView
        {
            get
            {
                return modifiableView;
            }
            set
            {
                modifiableView = value;
            }
        }

        public bool IsNotActive
        {
            get { return Spool.IsNotActive; }
            set
            {
                if (value != Spool.IsNotActive)
                {
                    Spool.IsNotActive = value;
                    RaisePropertyChanged("IsNotActive");
                }
            }
        }

        public void Dispose()
        {
            repoPipe.Dispose();
            repoSpool.Dispose();
            ModifiableView = null;
        }

        #region ---- Commands ----
        public ICommand SearchCommand
        {
            get { return searchCommand; }
        }

        public ICommand CutCommand
        {
            get { return cutCommand; }
        }

        public ICommand SaveCommand
        {
            get { return saveCommand; }
        }
        #endregion
    }
}