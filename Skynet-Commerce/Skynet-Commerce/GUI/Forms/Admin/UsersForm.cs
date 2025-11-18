using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Skynet_Commerce.GUI.UserControls;

namespace Skynet_Commerce.GUI.Forms
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
            LoadDummyData();
        }

        private void LoadDummyData()
        {
            // Giả lập dữ liệu giống hệt trong ảnh
            var users = new List<dynamic>
            {
                new { Id="USR-001", Name="John Doe", Email="john@example.com", Phone="+1234567890", Role="Buyer", Status="Active" },
                new { Id="USR-002", Name="Jane Smith", Email="jane@example.com", Phone="+1234567891", Role="Seller", Status="Active" },
                new { Id="USR-003", Name="Mike Johnson", Email="mike@example.com", Phone="+1234567892", Role="Buyer", Status="Active" },
                new { Id="USR-004", Name="Sarah Wilson", Email="sarah@example.com", Phone="+1234567893", Role="Seller", Status="Banned" }, // Banned row
                new { Id="USR-005", Name="Tom Brown", Email="tom@example.com", Phone="+1234567894", Role="Admin", Status="Active" },
                new { Id="USR-006", Name="Emily Davis", Email="emily@example.com", Phone="+1234567895", Role="Buyer", Status="Active" },
                new { Id="USR-007", Name="David Lee", Email="david@example.com", Phone="+1234567896", Role="Seller", Status="Active" },
                new { Id="USR-008", Name="Lisa Garcia", Email="lisa@example.com", Phone="+1234567897", Role="Buyer", Status="Active" }
            };

            _userListContainer.Controls.Clear();

            foreach (var user in users)
            {
                var row = new UcUserRow();
                row.SetData(user.Id, user.Name, user.Email, user.Phone, user.Role, user.Status);
                _userListContainer.Controls.Add(row);
            }
        }
    }
}