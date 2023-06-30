
namespace SpriteDatGenerator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.imagePanel = new System.Windows.Forms.Panel();
            this.image = new System.Windows.Forms.PictureBox();
            this.categories = new System.Windows.Forms.PictureBox();
            this.darkTheme = new System.Windows.Forms.Button();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.unknownBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.restartBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.creditsButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.MouseY = new System.Windows.Forms.Label();
            this.MouseX = new System.Windows.Forms.Label();
            this.lightTheme = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.spriteNameLabel = new System.Windows.Forms.Label();
            this.spriteNameBox = new System.Windows.Forms.TextBox();
            this.commitSelection = new System.Windows.Forms.Button();
            this.deletedRectanglesHolder = new System.Windows.Forms.PictureBox();
            this.grow = new System.Windows.Forms.Button();
            this.shrink = new System.Windows.Forms.Button();
            this.scalefactor = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categories)).BeginInit();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deletedRectanglesHolder)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagePanel
            // 
            this.imagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePanel.AutoScroll = true;
            this.imagePanel.Controls.Add(this.image);
            this.imagePanel.Location = new System.Drawing.Point(119, 12);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(1321, 774);
            this.imagePanel.TabIndex = 0;
            // 
            // image
            // 
            this.image.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("image.BackgroundImage")));
            this.image.Location = new System.Drawing.Point(3, 3);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(1806, 951);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            this.image.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.image.MouseDown += new System.Windows.Forms.MouseEventHandler(this.updateBox);
            this.image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMouseGet);
            // 
            // categories
            // 
            this.categories.BackColor = System.Drawing.Color.Transparent;
            this.categories.Image = ((System.Drawing.Image)(resources.GetObject("categories.Image")));
            this.categories.Location = new System.Drawing.Point(0, 0);
            this.categories.Name = "categories";
            this.categories.Size = new System.Drawing.Size(109, 743);
            this.categories.TabIndex = 1;
            this.categories.TabStop = false;
            // 
            // darkTheme
            // 
            this.darkTheme.BackColor = System.Drawing.Color.DarkGray;
            this.darkTheme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.darkTheme.Location = new System.Drawing.Point(6, 63);
            this.darkTheme.Name = "darkTheme";
            this.darkTheme.Size = new System.Drawing.Size(75, 23);
            this.darkTheme.TabIndex = 2;
            this.darkTheme.Text = "Dark";
            this.darkTheme.UseVisualStyleBackColor = false;
            this.darkTheme.Click += new System.EventHandler(this.darkTheme_Click);
            // 
            // sidePanel
            // 
            this.sidePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sidePanel.AutoScroll = true;
            this.sidePanel.Controls.Add(this.unknownBtn);
            this.sidePanel.Controls.Add(this.deleteBtn);
            this.sidePanel.Controls.Add(this.restartBtn);
            this.sidePanel.Controls.Add(this.loadBtn);
            this.sidePanel.Controls.Add(this.saveBtn);
            this.sidePanel.Controls.Add(this.helpButton);
            this.sidePanel.Controls.Add(this.aboutButton);
            this.sidePanel.Controls.Add(this.creditsButton);
            this.sidePanel.Controls.Add(this.generateButton);
            this.sidePanel.Controls.Add(this.importButton);
            this.sidePanel.Controls.Add(this.browseButton);
            this.sidePanel.Controls.Add(this.MouseY);
            this.sidePanel.Controls.Add(this.MouseX);
            this.sidePanel.Controls.Add(this.lightTheme);
            this.sidePanel.Controls.Add(this.darkTheme);
            this.sidePanel.Controls.Add(this.categories);
            this.sidePanel.Location = new System.Drawing.Point(1, 13);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(112, 743);
            this.sidePanel.TabIndex = 3;
            // 
            // unknownBtn
            // 
            this.unknownBtn.BackColor = System.Drawing.Color.DarkGray;
            this.unknownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.unknownBtn.Location = new System.Drawing.Point(6, 594);
            this.unknownBtn.Name = "unknownBtn";
            this.unknownBtn.Size = new System.Drawing.Size(75, 23);
            this.unknownBtn.TabIndex = 16;
            this.unknownBtn.Text = "???";
            this.unknownBtn.UseVisualStyleBackColor = false;
            this.unknownBtn.Click += new System.EventHandler(this.unknownBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.DarkGray;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteBtn.Location = new System.Drawing.Point(6, 559);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 15;
            this.deleteBtn.Text = "Delete rect.";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // restartBtn
            // 
            this.restartBtn.BackColor = System.Drawing.Color.DarkGray;
            this.restartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.restartBtn.Location = new System.Drawing.Point(6, 523);
            this.restartBtn.Name = "restartBtn";
            this.restartBtn.Size = new System.Drawing.Size(75, 23);
            this.restartBtn.TabIndex = 14;
            this.restartBtn.Text = "Restart";
            this.restartBtn.UseVisualStyleBackColor = false;
            this.restartBtn.Click += new System.EventHandler(this.restartBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.BackColor = System.Drawing.Color.DarkGray;
            this.loadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadBtn.Location = new System.Drawing.Point(6, 488);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(75, 23);
            this.loadBtn.TabIndex = 13;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = false;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.DarkGray;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveBtn.Location = new System.Drawing.Point(6, 453);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 12;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.Color.DarkGray;
            this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.helpButton.Location = new System.Drawing.Point(6, 709);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 23);
            this.helpButton.TabIndex = 11;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.BackColor = System.Drawing.Color.DarkGray;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.aboutButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.aboutButton.Location = new System.Drawing.Point(6, 681);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(75, 23);
            this.aboutButton.TabIndex = 10;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = false;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // creditsButton
            // 
            this.creditsButton.BackColor = System.Drawing.Color.DarkGray;
            this.creditsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.creditsButton.Location = new System.Drawing.Point(6, 653);
            this.creditsButton.Name = "creditsButton";
            this.creditsButton.Size = new System.Drawing.Size(75, 23);
            this.creditsButton.TabIndex = 9;
            this.creditsButton.Text = "Credits";
            this.creditsButton.UseVisualStyleBackColor = false;
            this.creditsButton.Click += new System.EventHandler(this.creditsButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.BackColor = System.Drawing.Color.DarkGray;
            this.generateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.generateButton.Location = new System.Drawing.Point(6, 418);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 8;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // importButton
            // 
            this.importButton.BackColor = System.Drawing.Color.DarkGray;
            this.importButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.importButton.Location = new System.Drawing.Point(6, 383);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 7;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = false;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.BackColor = System.Drawing.Color.DarkGray;
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.browseButton.Location = new System.Drawing.Point(6, 348);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 6;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = false;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // MouseY
            // 
            this.MouseY.AutoSize = true;
            this.MouseY.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MouseY.ForeColor = System.Drawing.Color.White;
            this.MouseY.Location = new System.Drawing.Point(11, 276);
            this.MouseY.Name = "MouseY";
            this.MouseY.Size = new System.Drawing.Size(22, 21);
            this.MouseY.TabIndex = 5;
            this.MouseY.Text = "Y:";
            // 
            // MouseX
            // 
            this.MouseX.AutoSize = true;
            this.MouseX.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MouseX.ForeColor = System.Drawing.Color.White;
            this.MouseX.Location = new System.Drawing.Point(11, 230);
            this.MouseX.Name = "MouseX";
            this.MouseX.Size = new System.Drawing.Size(22, 21);
            this.MouseX.TabIndex = 4;
            this.MouseX.Text = "X:";
            // 
            // lightTheme
            // 
            this.lightTheme.BackColor = System.Drawing.Color.DarkGray;
            this.lightTheme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lightTheme.Location = new System.Drawing.Point(6, 108);
            this.lightTheme.Name = "lightTheme";
            this.lightTheme.Size = new System.Drawing.Size(75, 23);
            this.lightTheme.TabIndex = 3;
            this.lightTheme.Text = "Light";
            this.lightTheme.UseVisualStyleBackColor = false;
            this.lightTheme.Click += new System.EventHandler(this.lightTheme_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "PNG Images|*.png";
            this.openFileDialog1.Title = "Browse for your sprite sheet";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Sprite sheet DAT files|*.dat";
            this.saveFileDialog1.Title = "Give a file name for your DAT";
            // 
            // spriteNameLabel
            // 
            this.spriteNameLabel.AutoSize = true;
            this.spriteNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.spriteNameLabel.ForeColor = System.Drawing.Color.White;
            this.spriteNameLabel.Location = new System.Drawing.Point(86, 13);
            this.spriteNameLabel.Name = "spriteNameLabel";
            this.spriteNameLabel.Size = new System.Drawing.Size(97, 21);
            this.spriteNameLabel.TabIndex = 4;
            this.spriteNameLabel.Text = "Sprite name:";
            this.spriteNameLabel.Visible = false;
            // 
            // spriteNameBox
            // 
            this.spriteNameBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.spriteNameBox.Location = new System.Drawing.Point(179, 10);
            this.spriteNameBox.Name = "spriteNameBox";
            this.spriteNameBox.Size = new System.Drawing.Size(447, 29);
            this.spriteNameBox.TabIndex = 5;
            this.spriteNameBox.Visible = false;
            // 
            // commitSelection
            // 
            this.commitSelection.BackColor = System.Drawing.Color.DarkGray;
            this.commitSelection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.commitSelection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.commitSelection.Location = new System.Drawing.Point(632, 10);
            this.commitSelection.Name = "commitSelection";
            this.commitSelection.Size = new System.Drawing.Size(228, 29);
            this.commitSelection.TabIndex = 12;
            this.commitSelection.Text = "Commit Selection";
            this.commitSelection.UseVisualStyleBackColor = false;
            this.commitSelection.Visible = false;
            this.commitSelection.Click += new System.EventHandler(this.commit);
            // 
            // deletedRectanglesHolder
            // 
            this.deletedRectanglesHolder.Location = new System.Drawing.Point(874, 24);
            this.deletedRectanglesHolder.Name = "deletedRectanglesHolder";
            this.deletedRectanglesHolder.Size = new System.Drawing.Size(27, 32);
            this.deletedRectanglesHolder.TabIndex = 14;
            this.deletedRectanglesHolder.TabStop = false;
            this.deletedRectanglesHolder.Visible = false;
            // 
            // grow
            // 
            this.grow.BackColor = System.Drawing.Color.DarkGray;
            this.grow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grow.BackgroundImage")));
            this.grow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grow.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grow.Location = new System.Drawing.Point(3, 3);
            this.grow.Name = "grow";
            this.grow.Size = new System.Drawing.Size(30, 30);
            this.grow.TabIndex = 15;
            this.grow.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.grow.UseVisualStyleBackColor = false;
            this.grow.Click += new System.EventHandler(this.grow_Click);
            // 
            // shrink
            // 
            this.shrink.BackColor = System.Drawing.Color.DarkGray;
            this.shrink.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("shrink.BackgroundImage")));
            this.shrink.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.shrink.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.shrink.Location = new System.Drawing.Point(51, 3);
            this.shrink.Name = "shrink";
            this.shrink.Size = new System.Drawing.Size(30, 30);
            this.shrink.TabIndex = 16;
            this.shrink.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.shrink.UseVisualStyleBackColor = false;
            this.shrink.Click += new System.EventHandler(this.shrink_Click);
            // 
            // scalefactor
            // 
            this.scalefactor.ForeColor = System.Drawing.Color.White;
            this.scalefactor.Location = new System.Drawing.Point(32, 6);
            this.scalefactor.Name = "scalefactor";
            this.scalefactor.Size = new System.Drawing.Size(20, 23);
            this.scalefactor.TabIndex = 17;
            this.scalefactor.Text = "1";
            this.scalefactor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel.Controls.Add(this.grow);
            this.bottomPanel.Controls.Add(this.spriteNameLabel);
            this.bottomPanel.Controls.Add(this.shrink);
            this.bottomPanel.Controls.Add(this.spriteNameBox);
            this.bottomPanel.Controls.Add(this.scalefactor);
            this.bottomPanel.Controls.Add(this.commitSelection);
            this.bottomPanel.Controls.Add(this.deletedRectanglesHolder);
            this.bottomPanel.Location = new System.Drawing.Point(1, 792);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1430, 42);
            this.bottomPanel.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1443, 837);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.sidePanel);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AB360 Angry Birds Sprite DAT Generator HD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseButtonPressed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fart);
            this.imagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categories)).EndInit();
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deletedRectanglesHolder)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.PictureBox categories;
        private System.Windows.Forms.Button darkTheme;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Button lightTheme;
        private System.Windows.Forms.Label MouseY;
        private System.Windows.Forms.Label MouseX;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button creditsButton;
        private System.Windows.Forms.Label spriteNameLabel;
        private System.Windows.Forms.TextBox spriteNameBox;
        private System.Windows.Forms.Button commitSelection;
        private System.Windows.Forms.PictureBox deletedRectanglesHolder;
        private System.Windows.Forms.Button unknownBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button restartBtn;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button grow;
        private System.Windows.Forms.Button shrink;
        private System.Windows.Forms.Label scalefactor;
        private System.Windows.Forms.Panel bottomPanel;
    }
}

