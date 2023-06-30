using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpriteDatGenerator
{
    public partial class CreditsAndAbout : Form
    {
        public CreditsAndAbout()
        {
            InitializeComponent();
        }

        private void AdjustColor(object sender, PaintEventArgs e)
        {
            if (MainForm.TwoWayData.CreditsOrAbout == "Credits")
            {
                this.Text = "Credits!";
                creditsPanel.Visible = true;
                AboutPanel.Visible = false;
            }
            else
            {
                this.Text = "About";
                creditsPanel.Visible = false;
                AboutPanel.Visible = true;
            }
            if (this.BackColor == Color.FromArgb(36, 36, 36))
            {
                this.ForeColor = Color.White;
            }
            else
            {
                this.ForeColor = Color.Black;
            }
        }
    }
}
