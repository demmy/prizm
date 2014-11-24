﻿using Data.DAL.Hibernate;
using Data.DAL.Mill;
using Data.DAL.Setup;
using NHibernate;
using Ninject;
using PrizmMain.Forms.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizmMain.Forms.PipeMill
{
    public class MillRepository : IMillRepository
    {
        private readonly IPipeRepository repoPipe;
        private readonly IPlateRepository repoPlate;
        private readonly IHeatRepository repoHeat;
        private readonly IWeldRepository repoWeld;
        private readonly IMillPipeSizeTypeRepository repoPipeType;
        private readonly IPurchaseOrderRepository repoPurchaseOrder;
        private readonly IWelderRepository welderRepo;

        private readonly ISession session;

        [Inject]
        public MillRepository(ISession session)
        {
            this.session = session;
            this.repoPipe = new PipeRepository(session);
            this.repoPlate = new PlateRepository(session);
            this.repoHeat = new HeatRepository(session);
            this.repoWeld = new WeldRepository(session);
            this.repoPipeType = new MillPipeSizeTypeRepository(session);
            this.repoPurchaseOrder = new PurchaseOrderRepository(session);
            this.welderRepo = new WelderRepository(session);
        }

        public void Commit()
        {
            session.Transaction.Commit();
        }

        public void BeginTransaction()
        {
            session.BeginTransaction();
        }

        public void Dispose()
        {
            session.Dispose();
        }

        public IPipeRepository RepoPipe
        {
            get { return repoPipe; }
        }

        public IPlateRepository RepoPlate
        {
            get { return repoPlate; }
        }

        public IHeatRepository RepoHeat
        {
            get { return repoHeat; }
        }

        public IWeldRepository RepoWeld
        {
            get { return repoWeld; }
        }

        public IMillPipeSizeTypeRepository RepoPipeType
        {
            get { return repoPipeType; }
        }

        public IPurchaseOrderRepository RepoPurchaseOrder
        {
            get { return repoPurchaseOrder; }
        }


        public IWelderRepository WelderRepo
        {
           get { return welderRepo; }
        }
    }
}