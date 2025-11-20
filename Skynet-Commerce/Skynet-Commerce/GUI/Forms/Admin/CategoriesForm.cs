using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Skynet_Commerce.GUI.UserControls;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class CategoriesForm : Form
    {
        public CategoriesForm()
        {
            InitializeComponent();
            LoadDummyData();
        }

        private void LoadDummyData()
        {
            var categories = new List<dynamic>
            {
                new { Id="CAT-001", Name="Electronics", Total="1234", Sub="8" },
                new { Id="CAT-002", Name="Fashion", Total="2456", Sub="12" },
                new { Id="CAT-003", Name="Home & Garden", Total="987", Sub="6" },
                new { Id="CAT-004", Name="Sports", Total="654", Sub="5" },
                new { Id="CAT-005", Name="Beauty & Health", Total="1567", Sub="9" },
                new { Id="CAT-006", Name="Books & Media", Total="432", Sub="4" }
            };

            _flowPanel.Controls.Clear();

            foreach (var cat in categories)
            {
                var row = new UcCategoryRow();
                row.SetData(cat.Id, cat.Name, cat.Total, cat.Sub);
                _flowPanel.Controls.Add(row);
            }
        }
    }
}