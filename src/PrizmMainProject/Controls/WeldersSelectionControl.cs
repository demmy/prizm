﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Prizm.Domain.Entity;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using Prizm.Main.Languages;

namespace Prizm.Main.Controls
{
   public partial class WeldersSelectionControl : UserControl
   {
       private bool checkNotActiveSelection;
       public DateTime weldDate = DateTime.Now.Date;
      public WeldersSelectionControl()
      {
         InitializeComponent();
      }

      public BindingSource DataSource
      {
         get
         {
            return gridControlWelders.DataSource as BindingSource;
         }
         set
         {
            gridControlWelders.DataSource = value;
         }
      }

      public IList<Welder> SelectedWelders
      {
         get
         {
            IList<Welder> result = new List<Welder>();
            int[] selected = gridViewWelders.GetSelectedRows();

            foreach (int idx in selected)
            {
               Welder w = DataSource[gridViewWelders.GetDataSourceRowIndex(idx)] as Welder;
                result.Add(w);
            }

            return result;
         }
      }

      public void ClearSelection()
      {
         gridViewWelders.ClearSelection();
      }

      public void SelectWelders(IList<Welder> welders)
      {
          this.checkNotActiveSelection = false;
         gridViewWelders.ClearSelection();

         foreach (Welder w in welders)
         {
            int rowHandle = gridViewWelders.GetRowHandle(DataSource.IndexOf(w));
            gridViewWelders.SelectRow(rowHandle);
         }
         this.checkNotActiveSelection = true;
      }

      private void gridViewWelders_RowCellStyle(object sender, RowCellStyleEventArgs e)
      {
          GridView v = sender as GridView;
          var data = v.GetRow(e.RowHandle) as Welder;
          if (data != null)
          {
              if (!data.IsActive)
              {
                  e.Appearance.ForeColor = Color.Gray;
              }
              if (data.Certificate.ExpirationDate <= weldDate.Date && data.IsActive)
              {
                  e.Appearance.ForeColor = Color.Red;
              }

          }
      }

      private void gridViewWelders_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
      {
          colLastName.Caption = Program.LanguageManager.GetString(StringResources.LastNameColumn);
          colFirstName.Caption = Program.LanguageManager.GetString(StringResources.FirstNameColumn);
          colMiddleName.Caption = Program.LanguageManager.GetString(StringResources.MiddleNameColumn);

          if (this.checkNotActiveSelection)
          {
              GridView v = sender as GridView;
              int t = v.SelectedRowsCount;
              if (t == v.DataRowCount)
              {
                  for (int i = 0; i < v.SelectedRowsCount; i++)
                  {
                      var data = v.GetRow(i) as Welder;
                      if (!data.IsActive)
                      {
                          v.UnselectRow(i);
                      }
                  }
              }
              else
              {
                  var data = v.GetRow(e.ControllerRow) as Welder;
                  if (data != null && !data.IsActive)
                  {
                      v.UnselectRow(e.ControllerRow);
                  }
              }
          }
      }

      private void WeldersSelectionControl_Load(object sender, EventArgs e)
      {
          // for first load of this control
          colLastName.Caption = Program.LanguageManager.GetString(StringResources.LastNameColumn);
          colFirstName.Caption = Program.LanguageManager.GetString(StringResources.FirstNameColumn);
          colMiddleName.Caption = Program.LanguageManager.GetString(StringResources.MiddleNameColumn);
      }
   }
}
