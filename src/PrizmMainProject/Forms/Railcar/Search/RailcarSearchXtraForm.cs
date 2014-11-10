﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PrizmMain.DummyData;

namespace PrizmMain.Forms
{
    public partial class RailcarSearchXtraForm : DevExpress.XtraEditors.XtraForm
    {
        public RailcarSearchXtraForm()
        {
            InitializeComponent();
            certificateNumber.Text = "7635356";
            railcarNumber.Text = "15";
            destination.Text = "Trans Gas LLC";
            shippedDate.Text = "16.10.2014";
            DateTime date = DateTime.Now;

            BindingList<RailcarsDummy> railcarsList = new BindingList<RailcarsDummy>();
            railcarsList.Add(new RailcarsDummy { RailcarNumber = 151415, Status = "ready", DeliveryDate = date, ShippedDate = date });
            railcarsList.Add(new RailcarsDummy { RailcarNumber = 161241, Status = "ready", DeliveryDate = date, ShippedDate = date }); 
            railcarsList.Add(new RailcarsDummy { RailcarNumber = 925747, Status = "cancel", DeliveryDate = date, ShippedDate = date });
            railcarsList.Add(new RailcarsDummy { RailcarNumber = 247481, Status = "ready", DeliveryDate = date, ShippedDate = date });
            railcarList.DataSource = railcarsList;
        }
    }
}