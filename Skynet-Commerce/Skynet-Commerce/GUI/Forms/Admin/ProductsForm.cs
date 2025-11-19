using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Skynet_Commerce.GUI.UserControls;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
            LoadDummyData();
        }

        private void LoadDummyData()
        {
            var products = new List<dynamic>
            {
                new { Name="Wireless Headphones", Id="PRD-001", Shop="TechStore", Cat="Electronics", Price="$129.99", Stock=45, Status="Active" },
                new { Name="Summer Dress", Id="PRD-002", Shop="Fashion Hub", Cat="Fashion", Price="$49.99", Stock=23, Status="Active" },
                new { Name="Modern Armchair", Id="PRD-003", Shop="HomeDecor", Cat="Furniture", Price="$299.00", Stock=12, Status="Active" },
                new { Name="Smartphone Case", Id="PRD-004", Shop="TechStore", Cat="Electronics", Price="$19.99", Stock=156, Status="Active" },
                new { Name="Running Shoes", Id="PRD-005", Shop="Sports World", Cat="Sports", Price="$89.99", Stock=0, Status="Out of Stock" }, // Stock 0
                new { Name="Leather Wallet", Id="PRD-006", Shop="Fashion Hub", Cat="Accessories", Price="$39.99", Stock=67, Status="Hidden" } // Hidden
            };

            _flowPanel.Controls.Clear();

            foreach (var p in products)
            {
                var row = new UcProductRow();
                row.SetData(p.Name, p.Id, p.Shop, p.Cat, p.Price, p.Stock, p.Status);
                // Thêm margin nhỏ giữa các dòng nếu cần, dù Paint line đã giúp phân cách
                // row.Margin = new Padding(0, 0, 0, 5); 
                _flowPanel.Controls.Add(row);
            }
        }
    }
}