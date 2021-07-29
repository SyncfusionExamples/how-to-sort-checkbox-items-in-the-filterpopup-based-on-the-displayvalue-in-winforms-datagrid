using SfDataGrid_Demo;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Drawing;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.Data.Extensions;
using System.Collections.Generic;
using Syncfusion.WinForms.DataGrid.GridFiltering;
using Syncfusion.DataSource;

namespace SfDataGrid_Demo
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : Form
    {

        /// <summary>
        /// Initializes the new instance for the Form.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            sfDataGrid1.DataSource = new OrderInfoCollection().OrderDetails;

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "OrderID", HeaderText = "Order ID" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ProductName", HeaderText = "Product Name" });
            sfDataGrid1.Columns.Add(new GridNumericColumn() { MappingName = "NoOfOrders", HeaderText = "No Of Orders" });
            sfDataGrid1.Columns.Add(new GridComboBoxColumn()
            {
                MappingName = "ShipCityID",
                HeaderText = "Ship City",
                DisplayMember = "ShipCityName",
                ValueMember = "ShipCityID",
                SortMode = Syncfusion.Data.DataReflectionMode.Display,
                DataSource = new OrderInfoCollection().CityList
            });

            this.sfDataGrid1.FilterPopupShown += OnSfDataGrid_FilterPopupShown;
        }
        private void OnSfDataGrid_FilterPopupShown(object sender, Syncfusion.WinForms.DataGrid.Events.FilterPopupShownEventArgs e)
        {
            if (e.Column.MappingName == "ShipCityID")
            {
                e.Control.CheckListBox.View.SortDescriptors.Add(new SortDescriptor()
                {
                    PropertyName = "DisplayText",
                    Direction = ListSortDirection.Ascending,
                });
            }
        }
    }
}
