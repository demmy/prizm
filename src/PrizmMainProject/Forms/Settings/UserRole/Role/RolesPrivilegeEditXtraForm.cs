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
using DevExpress.XtraEditors.Controls;
using PrizmMain.DummyData;

namespace PrizmMain.Forms
{
    public partial class RolesPrivilegeEditXtraForm : DevExpress.XtraEditors.XtraForm
    {
        public RolesPrivilegeEditXtraForm()
        {
            InitializeComponent();

            var repo = new RolesDummy();
            var allPrivs = repo.GetAllPrivileges().ToArray();

            priveleges.Items.AddRange(allPrivs);
        }

        public RolesPrivilegeEditXtraForm(bool isNew)
        {
            InitializeComponent();
            if (isNew)
            {
                return;
            }

            roleEdit.Properties.ReadOnly = true;
            var repository = new PrizmMain.DummyData.RolesDummy();
            var allPrivileges = repository.GetAllPrivileges();
            var role = repository.GetRole(0);

            CheckedListBoxItem[] items = new CheckedListBoxItem[allPrivileges.Count];

            for (int i = 0; i < allPrivileges.Count; i++)
            {
                items[i] = new CheckedListBoxItem(allPrivileges[i].Description, (i % 2 == 0)?true:false);
            }

            priveleges.Items.AddRange(items);
            roleEdit.Text = role.Name;

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}