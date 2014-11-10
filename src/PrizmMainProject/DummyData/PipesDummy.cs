﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizmMain.DummyData
{
    public class PipesDummy
    {
        private int pipeNumber;
        private string status;
        private string manufacturer;
        private string size;
        private string heatNumber;
        private string weldingDate;
        private string internalCoatingDate;
        private string externalCoatingDate;

        public int PipeNumber
        {
            get { return this.pipeNumber; }
            set { this.pipeNumber = value; }
        }

        public string Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set { this.manufacturer = value; }
        }
        public string Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        public string HeatNumber
        {
            get { return this.heatNumber; }
            set { this.heatNumber = value; }
        }

        public string WeldingDate
        {
            get { return this.weldingDate; }
            set { this.weldingDate = value; }
        }

        public string InternalCoatingDate
        {
            get { return this.internalCoatingDate; }
            set { this.internalCoatingDate = value; }
        }
        public string ExternalCoatingDate
        {
            get { return this.externalCoatingDate; }
            set { this.externalCoatingDate = value; }
        }
    }
}