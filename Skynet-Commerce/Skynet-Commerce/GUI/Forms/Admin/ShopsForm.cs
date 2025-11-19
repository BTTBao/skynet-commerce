using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Skynet_Commerce.GUI.UserControls;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class ShopsForm : Form
    {
        public ShopsForm()
        {
            InitializeComponent();
            LoadPendingShops();
            LoadActiveShops();
        }

        private void LoadPendingShops()
        {
            var pendingList = new List<dynamic>
            {
                new { Id="SHOP-P01", Name="TechGadgets Pro", Owner="Alice Johnson", Email="alice@tech.com", Date="2025-11-15" },
                new { Id="SHOP-P02", Name="Fashion Fusion", Owner="Bob Smith", Email="bob@fashion.com", Date="2025-11-16" },
                new { Id="SHOP-P03", Name="Home Essentials", Owner="Carol White", Email="carol@home.com", Date="2025-11-17" }
            };

            _pendingContainer.Controls.Clear();
            foreach (var shop in pendingList)
            {
                var row = new UcPendingShopRow();
                row.SetData(shop.Id, shop.Name, shop.Owner, shop.Email, shop.Date);
                _pendingContainer.Controls.Add(row);
            }
        }

        private void LoadActiveShops()
        {
            var activeList = new List<dynamic>
            {
                new { Id="SHOP-001", Name="TechStore", Owner="John Doe", Rate="4.8", Prod="234", Status="Active" },
                new { Id="SHOP-002", Name="Fashion Hub", Owner="Jane Smith", Rate="4.6", Prod="456", Status="Active" },
                new { Id="SHOP-003", Name="HomeDecor", Owner="Mike Johnson", Rate="4.9", Prod="189", Status="Active" },
                new { Id="SHOP-004", Name="Sports World", Owner="Tom Brown", Rate="4.7", Prod="312", Status="Active" },
                new { Id="SHOP-005", Name="Beauty Shop", Owner="Emily Davis", Rate="4.5", Prod="267", Status="Suspended" },
                new { Id="SHOP-006", Name="Electronics Plus", Owner="David Lee", Rate="4.8", Prod="421", Status="Active" }
            };

            _activeContainer.Controls.Clear();
            foreach (var shop in activeList)
            {
                var row = new UcActiveShopRow();
                row.SetData(shop.Id, shop.Name, shop.Owner, shop.Rate, shop.Prod, shop.Status);
                _activeContainer.Controls.Add(row);
            }
        }

    }
}