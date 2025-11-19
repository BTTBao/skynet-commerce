using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Skynet_Commerce.GUI.UserControls;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
            LoadDummyData();
        }

        private void LoadDummyData()
        {
            var orders = new List<dynamic>
            {
                new { Id="#ORD-2341", Buyer="John Doe", Shop="TechStore", Items="2", Amount="$234.50", Date="2025-11-15", Status="Completed" },
                new { Id="#ORD-2342", Buyer="Jane Smith", Shop="Fashion Hub", Items="1", Amount="$189.99", Date="2025-11-16", Status="Processing" },
                new { Id="#ORD-2343", Buyer="Mike Johnson", Shop="HomeDecor", Items="3", Amount="$456.00", Date="2025-11-16", Status="Pending" },
                new { Id="#ORD-2344", Buyer="Sarah Wilson", Shop="TechStore", Items="1", Amount="$99.99", Date="2025-11-17", Status="Completed" },
                new { Id="#ORD-2345", Buyer="Tom Brown", Shop="Fashion Hub", Items="2", Amount="$324.50", Date="2025-11-17", Status="Shipped" },
                new { Id="#ORD-2346", Buyer="Emily Davis", Shop="Sports World", Items="1", Amount="$89.99", Date="2025-11-17", Status="Processing" }
            };

            _flowPanel.Controls.Clear();

            foreach (var o in orders)
            {
                var row = new UcOrderRow();
                row.SetData(o.Id, o.Buyer, o.Shop, o.Items, o.Amount, o.Date, o.Status);
                _flowPanel.Controls.Add(row);
            }
        }
    }
}