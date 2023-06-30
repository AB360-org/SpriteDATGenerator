using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RectData = SpriteDatGenerator.MainForm.TwoWayData;

namespace SpriteDatGenerator
{
    public partial class OriginForm : Form
    {
        public static class Origin //This way we can access the origin point specified from the other form
        {
            public static string XORG = "";
            public static string YORG = "";
        }
        public OriginForm()
        {
            InitializeComponent();
        }



        private void TopLeftButton_Click(object sender, EventArgs e)
        {
            Origin.XORG = "0000";
            Origin.YORG = "0000";
            this.Close();
        }

        private void TopCenterButton_Click(object sender, EventArgs e)
        {
            Origin.XORG = (RectData.rectL / 2).ToString("X4");
            Origin.YORG = "0000";
            this.Close();
        }

        private void TopRightButton_Click(object sender, EventArgs e)
        {
            Origin.XORG = RectData.rectL.ToString("X4");
            Origin.YORG = "0000";
            this.Close();
        }

        private void LeftCenterButton_Click(object sender, EventArgs e)
        {
            Origin.XORG = "0000";
            Origin.YORG = (RectData.rectH / 2).ToString("X4");
            this.Close();
        }

        private void CenterButton_Click(object sender, EventArgs e)
        {
            Origin.XORG = (RectData.rectL / 2).ToString("X4");
            Origin.YORG = (RectData.rectH / 2).ToString("X4");
            this.Close();
        }

        private void RightCenterButton_Click(object sender, EventArgs e)
        {
            Origin.XORG = RectData.rectL.ToString("X4");
            Origin.YORG = (RectData.rectH / 2).ToString("X4");
            this.Close();
        }

        private void BottomLeftButton_Click(object sender, EventArgs e)
        {
            Origin.XORG = "0000";
            Origin.YORG = RectData.rectH.ToString("X4");
            this.Close();
        }

        private void BottomCenterButton_Click(object sender, EventArgs e)
        {
            Origin.XORG = (RectData.rectL / 2).ToString("X4");
            Origin.YORG = RectData.rectH.ToString("X4");
            this.Close();
        }

        private void BottomRightButton_Click(object sender, EventArgs e)
        {
            Origin.XORG = RectData.rectL.ToString("X4");
            Origin.YORG = RectData.rectH.ToString("X4");
            this.Close();
        }

        private void CustomButton_Click(object sender, EventArgs e)
        {
            choosingPanel.Visible = false;
            customOriginPanel.Visible = true;
            chooseOriginImage.Image = RectData.selectedSprite;
            customOriginPanel.AutoScroll = true;
            labelForCheckMark.Visible = true;
            checkBox.Visible = true;
            backToMainOrigins.Visible = true;

        }

        private void themeUpdate(object sender, PaintEventArgs e)
        {
            if (this.BackColor == Color.FromArgb(36, 36, 36))
            {
                Information.ForeColor = Color.White;
                labelForCheckMark.ForeColor = Color.White;
                XandYlabel.ForeColor = Color.White;
            }
            else
            {
                Information.ForeColor = Color.Black;
                labelForCheckMark.ForeColor = Color.Black;
                XandYlabel.ForeColor = Color.Black;
            }
        }

        private void setCustomOrigin(object sender, MouseEventArgs e)
        {
            Origin.XORG = (e.X/MainForm.ImageInfo.zoom).ToString("X4");
            Origin.YORG = (e.Y/ MainForm.ImageInfo.zoom).ToString("X4");
            XandYlabel.Visible = true;
            XandYlabel.Text = "X: " + e.X / MainForm.ImageInfo.zoom + " Y: " + e.Y / MainForm.ImageInfo.zoom;
            
        }

        private void checkBox_Click(object sender, EventArgs e)
        {
            if (Origin.XORG != "" && Origin.YORG != "")
            {
                customOriginPanel.Visible = false;
                choosingPanel.Visible = true;
                XandYlabel.Visible = false;
                labelForCheckMark.Visible = false;
                checkBox.Visible = false;
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to choose a point first!", "No origin point selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backToMainOrigins_Click(object sender, EventArgs e) //Does the opposite of clicking "I want to choose a custom origin point
        {
            choosingPanel.Visible = true;
            customOriginPanel.Visible = false;
            labelForCheckMark.Visible = false;
            checkBox.Visible = false;
            backToMainOrigins.Visible = false;
        }
    }
}
