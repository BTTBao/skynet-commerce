using System;
using System.Drawing;
using System.Windows.Forms;

namespace Skynet_Commerce.GUI.UserControls
{
    public partial class UcInfoCard : UserControl
    {
        public UcInfoCard()
        {
            InitializeComponent();
        }

        public void SetData(string title, string value, string percent, bool isIncrease)
        {
            _lblTitle.Text = title;
            _lblValue.Text = value;
            _btnPercent.Text = percent;

            if (isIncrease)
                _btnPercent.ForeColor = Color.FromArgb(34, 197, 94); // Green
            else
                _btnPercent.ForeColor = Color.FromArgb(239, 68, 68); // Red
        }
    }
}