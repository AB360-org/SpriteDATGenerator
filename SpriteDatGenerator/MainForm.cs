using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using UserRectDemo; //Credit to zebulon75018 for this

namespace SpriteDatGenerator
{
    public partial class MainForm : Form
    {
        UserRect rect;
        public MainForm()
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\extras"))
            {
                MessageBox.Show("Hey hey hey! You either deleted the extras folder or you ran this program without extracting.\nPlease restor it.", "Missing resources.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            InitializeComponent();
            image.Paint += new PaintEventHandler(this.pictureBox1_Paint);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        Form frm2 = new OriginForm();
        Form frm3 = new HelpForm();
        Form frm4 = new CreditsAndAbout();

        public static class ImageInfo
        {
            public static int length;
            public static int width;
            public static int zoom = 1;
            public static bool usingDivide = false;
            public static bool makingSprite;
            public static decimal mouseX;
            public static decimal mouseY;
        }
        public static class DatInfo
        {
            public static int numSprites;
            public static string spriteName;
            public static int fileSize;
            public static string headerHex = ""; //Inital data that contains the header, information about the file, and the sprite's name
            public static string spritesHex = ""; //Contains information regarding the sprites in a template like manner
            public static byte[] fileData;
            public static string rectangles = ""; //Information about all the rectangles (Used in project files)
            public static string fullFileName = ""; //The path to the imaged used (Used in project files)
            public static Dictionary<int, UserRect> rectangleList = new Dictionary<int, UserRect>(); //Contains rectangles by ID and their size (Used in zooming)
        }

        public static class TwoWayData //For any information that needs to be mutally access from all forms
        {
            public static int rectL;
            public static int rectH;
            public static Image selectedSprite;
            public static string CreditsOrAbout;
            public static char keyPressed;
        }

        private void darkTheme_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(36, 36, 36);
            MouseX.ForeColor = Color.White;
            MouseY.ForeColor = Color.White;
            spriteNameLabel.ForeColor = Color.White;
            scalefactor.ForeColor = Color.White;
            frm2.BackColor = Color.FromArgb(36, 36, 36);
            frm2.Refresh();
            frm3.BackColor = Color.FromArgb(36, 36, 36);
            frm3.Refresh();
            frm4.BackColor = Color.FromArgb(36, 36, 36);
            frm4.Refresh();
        }

        private void lightTheme_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
            MouseX.ForeColor = Color.Black;
            MouseY.ForeColor = Color.Black;
            spriteNameLabel.ForeColor = Color.Black;
            scalefactor.ForeColor = Color.Black;
            frm2.BackColor = Color.LightGray;
            frm2.Refresh();
            frm3.BackColor = Color.LightGray;
            frm3.Refresh();
            frm4.BackColor = Color.LightGray;
            frm4.Refresh();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PNG Images|*.png";
            openFileDialog1.Title = "Browse for your sprite sheet";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
        }

        public void UpdateZoom(int zoom)
        {
            image.Width = ImageInfo.usingDivide ? (int)(image.Image.Width / zoom) : (int)(image.Image.Width * zoom);
            image.Height = ImageInfo.usingDivide ? (int)(image.Image.Height / zoom) : (int)(image.Image.Height * zoom);
        }

        private void importButton_Click(object sender, EventArgs e) //Import an image into the canvas
        {
            MouseWheel += ZoomIn;
            if (string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                MessageBox.Show("Please select an image first!", "No image selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                imagePanel.AutoScroll = true;
                DatInfo.fileSize = 0;
                DatInfo.numSprites = 0;
                ImageInfo.makingSprite = false;
                DatInfo.spriteName = openFileDialog1.SafeFileName;
                DatInfo.fullFileName = openFileDialog1.FileName;
                image.Image = Image.FromFile(openFileDialog1.FileName);
                
                UpdateZoom(ImageInfo.zoom);
            }
        }

        private void pictureBoxMouseGet(object sender, MouseEventArgs e) //Get some data regarding the mouse
        {
            MouseX.Text = "X: " + e.X / ImageInfo.zoom;
            MouseY.Text = "Y: " + e.Y / ImageInfo.zoom;
            ImageInfo.mouseX = e.X;
            ImageInfo.mouseY = e.Y;
        }

        private void updateBox(object sender, MouseEventArgs e)
        {
            if (!ImageInfo.makingSprite) //When the picturebox is clicked, make a new rectangle
            {
                DatInfo.rectangleList[DatInfo.numSprites] = new UserRect(new Rectangle((int)ImageInfo.mouseX, (int)ImageInfo.mouseY, 96, 96));
                //rect = new UserRect(new Rectangle((int)ImageInfo.mouseX, (int)ImageInfo.mouseY, 96, 96));
                DatInfo.rectangleList[DatInfo.numSprites].SetPictureBox(this.image);
                ImageInfo.makingSprite = true;
                spriteNameBox.Visible = true;
                spriteNameLabel.Visible = true;
                spriteNameBox.Text = "";
                commitSelection.Visible = true;
                image.Refresh();

            }
        }

        private Image CropImage(Image img, Rectangle rect)
        {
            return ((Bitmap)img).Clone(rect, img.PixelFormat);
        }


        private void commit(object sender, EventArgs e) //Record the data of the current rectangle and save it for when it comes time to generate.
        {
            if (!string.IsNullOrEmpty(spriteNameBox.Text))
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you're content with this selection for your sprite?\nOnce you click yes, anything you do to the rectangle will not be recorded and instead a new rectangle will be used for another sprite.", "Commit selection?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        ImageInfo.makingSprite = false;

                        //Change rectangle colour to show it's been commited
                        DatInfo.rectangleList[DatInfo.numSprites].orangeFalsePurpleTrue = true;
                        DatInfo.rectangleList[DatInfo.numSprites].SetPictureBox(image);


                        //Get the infomation in hexidecimal (Thanks to Keymil Animations for finding how this data is written)

                        //Get values
                        int spriteXint = (int)Math.Ceiling((decimal)(DatInfo.rectangleList[DatInfo.numSprites].rect.X / ImageInfo.zoom));
                        int spriteYint = (int)Math.Ceiling((decimal)(DatInfo.rectangleList[DatInfo.numSprites].rect.Y / ImageInfo.zoom));
                        int spriteWidthint = (int)Math.Ceiling((decimal)(DatInfo.rectangleList[DatInfo.numSprites].rect.Width / ImageInfo.zoom));
                        int spriteHeightint = (int)Math.Ceiling((decimal)(DatInfo.rectangleList[DatInfo.numSprites].rect.Height / ImageInfo.zoom));

                        TwoWayData.rectL = spriteWidthint;
                        TwoWayData.rectH = spriteHeightint;

                        //Convert to hex strings
                        string spriteX = spriteXint.ToString("X4");
                        string spriteY = spriteYint.ToString("X4");
                        string spriteWidth = spriteWidthint.ToString("X4");
                        string spriteHeight = spriteHeightint.ToString("X4");
                        string spriteName = spriteNameBox.Text;
                        string spriteNameLength = spriteNameBox.Text.Length.ToString("X4");
                        var spriteNameHex = string.Join("", spriteName.Select(c => String.Format("{0:X2}", Convert.ToInt32(c))));


                        //Reset origin for each sprite
                        OriginForm.Origin.XORG = "";
                        OriginForm.Origin.YORG = "";
                        TwoWayData.selectedSprite = CropImage(image.Image, new Rectangle(spriteXint, spriteYint, spriteWidthint, spriteHeightint));
                        this.Visible = false;
                        while (OriginForm.Origin.XORG == "" || OriginForm.Origin.YORG == "")
                        {
                            frm2.ShowDialog();
                        }
                        this.Visible = true;
                        string spriteOriginX = OriginForm.Origin.XORG;
                        string spriteOriginY = OriginForm.Origin.YORG;
                        MessageBox.Show("Your sprite has been successfully added with the following details:\nName: " + spriteName + "\nLocation: (" + spriteXint + "," + spriteYint + ")\nWidth: " + spriteWidthint + "\nHeight: " + spriteHeightint + "\n\nYou may now create another sprite.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        spriteNameBox.Visible = false;
                        spriteNameLabel.Visible = false;
                        commitSelection.Visible = false;
                        DatInfo.numSprites++;

                        DatInfo.rectangles = DatInfo.rectangles + "\n" + spriteXint + "," + spriteYint + "," + spriteWidthint + "," + spriteHeightint;

                        DatInfo.spritesHex = DatInfo.spritesHex + spriteNameLength + spriteNameHex + spriteX + spriteY + spriteWidth + spriteHeight + spriteOriginX + spriteOriginY;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "No image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show("You must import an image before trying to create sprites!", "No image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            else
            {
                MessageBox.Show("You have not given your sprite a name, please specify one.\n\nIt is also recommeneded to use underscores ( _ ) instead \nof spaces (   ).", "No name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static byte[] StringToByteArray(string hex) //Credit to JaredPar for this function
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public void saveSequence()
        {
            saveFileDialog1.Filter = "Angry Birds Sprite DAT Generator Project files|*.sdg";
            saveFileDialog1.Title = "Save your project file to open later";
            saveFileDialog1.FileName = "";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                try
                {
                    File.WriteAllText(saveFileDialog1.FileName, "This file was generated by Angry Birds Sprite DAT Generator. If you're going to modify it, please make sure you ABSOLUTELY know what you're doing. Here's a hint: Editing the rectangle data wont change the DAT itself, but the hex data will. So open up HxD and pop that puppy right in there!\n-Begin File Name Data-\n" + DatInfo.fullFileName + "\n" + DatInfo.spriteName + "\n-End File Name Data-\n" + "-Begin Hex Data-\n" + DatInfo.numSprites + "\n" + DatInfo.spritesHex + "\n-End Hex Data-\n-Begin Rectangle Data-" + DatInfo.rectangles + "\n-End Rectangle Data-"); //Writes all the information necessary to reconstruct it in the editor

                }
                catch
                {
                    MessageBox.Show("You cannot save a project until you have created some sprites.", "No sprites", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void fart(object sender, KeyPressEventArgs e)
        {
            TwoWayData.keyPressed = e.KeyChar;
            if (ActiveControl != spriteNameBox)
            {
                try
                {
                    if (e.KeyChar == (char)Keys.F || e.KeyChar == 'f')
                    {
                        Random random = new Random();
                        SoundPlayer simpleSound = new SoundPlayer(Directory.GetCurrentDirectory() + "\\extras\\sfx\\fart00" + random.Next(1, 4) + ".wav");
                        simpleSound.Play();
                    }
                }
                catch
                {
                    MessageBox.Show("How dare you delete the fart sounds! Enjoy a \"FUCK YOU!\" from me!\n\nFUCK YOU!", "FUCK YOU!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand);
                }
                if (e.KeyChar == (char)Keys.S || e.KeyChar == 's')
                {
                    saveSequence();
                }
                if (e.KeyChar == (char)Keys.D || e.KeyChar == 'd')
                {
                    deleteBtn_Click("1", EventArgs.Empty);
                }
                if (e.KeyChar == (char)Keys.L || e.KeyChar == 'l')
                {
                    loadBtn_Click("1", EventArgs.Empty);
                }
                if (e.KeyChar == (char)Keys.R || e.KeyChar == 'r')
                {
                    restartBtn_Click("1", EventArgs.Empty);

                }
            }



        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Sprite sheet DAT files|*.dat";
            saveFileDialog1.Title = "Give a file name for your DAT";
            saveFileDialog1.FileName = "";
            saveFileDialog1.ShowDialog();
            try
            {
                if (saveFileDialog1.FileName != "")
                {
                    DialogResult dialogResult = MessageBox.Show("Because of how DATs work, they require the name of the PNG file used in the DAT file itself. If one were to change the name of the PNG file, the DAT file would be rendered useless, this message is to let you know to NOT change the name of the PNG file after you click 'OK'.\nTake care! :)", "Friendly reminder", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        DatInfo.fileSize = 22 + DatInfo.spriteName.Length + (DatInfo.spritesHex.Length / 2); //Important for file header
                        DatInfo.headerHex = (DatInfo.fileSize - 8).ToString("X8") /* Bytes -8 */ + "53505254" + (DatInfo.fileSize - 16).ToString("X8") /* Bytes -16 */ + "0001" + (DatInfo.spriteName.Length).ToString("X4") + string.Join("", (DatInfo.spriteName).Select(c => String.Format("{0:X2}", Convert.ToInt32(c))));
                        DatInfo.fileData = StringToByteArray("4B413344" + DatInfo.headerHex + DatInfo.numSprites.ToString("X4") + DatInfo.spritesHex);
                        File.WriteAllBytes(saveFileDialog1.FileName, DatInfo.fileData);
                    }

                }
            }
            catch
            {
                MessageBox.Show("You cannot generate a DAT file until you have created some sprites.", "No sprites", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }



        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            frm3.ShowDialog();
        }

        private void creditsButton_Click(object sender, EventArgs e)
        {
            TwoWayData.CreditsOrAbout = "Credits";
            frm4.Refresh();
            frm4.ShowDialog();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            TwoWayData.CreditsOrAbout = "About";
            frm4.Refresh();
            frm4.ShowDialog();
        }

        private void CloseButtonPressed(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        static decimal closestNumber(decimal n, decimal m) //Borrowed from rectangle script, modified to take more specific numbers as input
        {
            // find the quotient
            decimal q = n / m;

            // 1st possible closest number
            decimal n1 = m * q;

            // 2nd possible closest number
            decimal n2 = (n * m) > 0 ? (m * (q + 1)) : (m * (q - 1));

            // if true, then n1 is the required closest number
            if (Math.Abs(n - n1) < Math.Abs(n - n2))

                return n1;

            // else n2 is the required closest number

            return n2;


            //Credit to Sam007 for this function
        }

        private void restartBtn_Click(object sender, EventArgs e) //Copied from the Keyboard code
        {
            var result = MessageBox.Show("Are you sure you want to restart? You will lose any progress you haven't saved.", "Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(0);
            }
        }

        private void loadBtn_Click(object sender, EventArgs e) //Copied from the Keyboard code
        {
            MouseWheel += ZoomIn;
            openFileDialog1.Filter = "Angry Birds Sprite DAT Generator Project files|*.sdg";
            openFileDialog1.Title = "Browse for your project file";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                try
                {
                    int counter = 0;
                    string line;
                    string mode = ""; //Variable that determines what type of data we're reading
                    int spriteIncrease = 0;

                    // Read the file and display it line by line.  
                    System.IO.StreamReader file =
                        new System.IO.StreamReader(openFileDialog1.FileName);
                    while ((line = file.ReadLine()) != null)
                    {
                        //Set mode
                        if (line == "-Begin File Name Data-")
                        {
                            mode = "filename";
                        }
                        if (line == "-Begin Hex Data-")
                        {
                            mode = "hex";
                        }
                        if (line == "-Begin Rectangle Data-")
                        {
                            mode = "rectangle";
                        }
                        if (line.Contains("End") && counter != 2 && counter != 3)
                        {
                            mode = "";
                        }
                        //Make action based on mode
                        if (mode == "filename")
                        {
                            if (counter == 2)
                            {
                                DatInfo.fullFileName = line;
                                image.Image = Image.FromFile(DatInfo.fullFileName);  //Import the image
                                UpdateZoom(ImageInfo.zoom);
                            }
                            if (counter == 3)
                            {
                                DatInfo.spriteName = line; //Set the sprite name
                            }
                        }
                        if (mode == "hex")
                        {
                            if (counter == 6)
                            {
                                DatInfo.numSprites = int.Parse(line); //Set the number of sprites
                            }
                            if (counter == 7)
                            {
                                DatInfo.spritesHex = line; //Set the main sprite data
                            }
                        }
                        if (mode == "rectangle" && line != "-Begin Rectangle Data-" && line != "-End Rectangle Data-")
                        {
                            int rectX = int.Parse(line.Split(",")[0]);
                            int rectY = int.Parse(line.Split(",")[1]);
                            int rectL = int.Parse(line.Split(",")[2]);
                            int rectW = int.Parse(line.Split(",")[3]);
                            DatInfo.rectangles = DatInfo.rectangles + "\n" + rectX + "," + rectY + "," + rectL + "," + rectW;
                            DatInfo.rectangleList[spriteIncrease] = new UserRect(new Rectangle(rectX * ImageInfo.zoom, rectY * ImageInfo.zoom, rectL * ImageInfo.zoom, rectW * ImageInfo.zoom)); //Load rectangles
                            DatInfo.rectangleList[spriteIncrease].orangeFalsePurpleTrue = true; //Show that the rectangles are the ones from before
                            DatInfo.rectangleList[spriteIncrease].SetPictureBox(this.image);
                            spriteIncrease++;
                        }
                        counter++;
                    }

                    file.Close();
                    // Suspend the screen.  
                }
                catch
                {
                    MessageBox.Show("The project file is not valid.", "Invalid file", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e) //Copied from Keyboard code
        {
            saveSequence();
        }

        private void unknownBtn_Click(object sender, EventArgs e) //Copied from Keyboard code
        {
            try
            {
                Random random = new Random();
                SoundPlayer simpleSound = new SoundPlayer(Directory.GetCurrentDirectory() + "\\extras\\sfx\\fart00" + random.Next(1, 4) + ".wav");
                simpleSound.Play();
            }
            catch
            {
                MessageBox.Show("How dare you delete the fart sounds! Enjoy a \"FUCK YOU!\" from me!\n\nFUCK YOU!", "FUCK YOU!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete the current rectangle?", "Delete rectangle", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DatInfo.rectangleList[DatInfo.numSprites].Deletus(deletedRectanglesHolder);
                    ImageInfo.makingSprite = false;
                    spriteNameBox.Visible = false;
                    spriteNameLabel.Visible = false;
                    commitSelection.Visible = false;
                    image.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("There is no rectangle to delete.", "No rectangle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        

        public void ZoomIn(object sender, MouseEventArgs e)
        {
                if (e.Delta > 0)
                {
                    grow_Click("1", EventArgs.Empty);
                }
                else
                {
                    shrink_Click("1", EventArgs.Empty);
                }
            
        }
        private void grow_Click(object sender, EventArgs e) //New code, zooms up on the image
        {
            if (scalefactor.Text == "16" && ImageInfo.usingDivide == false)
            {
                MessageBox.Show("Woah woah woah! That's way too big, you don't need to zoom in so much!\nEven 16x16 images are huge at this point.", "Slow down there pal!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (ImageInfo.zoom == 1 && ImageInfo.usingDivide == true)
                {
                    ImageInfo.usingDivide = false;
                    ImageInfo.zoom *= 2;
                }
                else if (ImageInfo.zoom != 1 && ImageInfo.usingDivide == true)
                {
                    ImageInfo.zoom /= 2;
                }
                else
                {
                    ImageInfo.zoom *= 2;
                }
                if (ImageInfo.zoom == 0)
                {
                    ImageInfo.zoom = 2;
                }
                scalefactor.Text = ImageInfo.zoom.ToString();
                try
                {
                    try
                    {
                        image.Image = Image.FromFile(DatInfo.fullFileName);
                        UpdateZoom(ImageInfo.zoom);
                        for (int i = 0; i < DatInfo.rectangleList.Count; i++)
                        {
                            DatInfo.rectangleList[i].rect.X = DatInfo.rectangleList[i].rect.X * 2;
                            DatInfo.rectangleList[i].rect.Y = DatInfo.rectangleList[i].rect.Y * 2;
                            DatInfo.rectangleList[i].rect.Width = DatInfo.rectangleList[i].rect.Width * 2;
                            DatInfo.rectangleList[i].rect.Height = DatInfo.rectangleList[i].rect.Height * 2;
                            //MessageBox.Show(DatInfo.rectangleList[i].rect.X + " " + DatInfo.rectangleList[i].rect.Y + " " + DatInfo.rectangleList[i].rect.Width + " " + DatInfo.rectangleList[i].rect.Height);
                        }
                    }
                    catch (OutOfMemoryException)
                    {
                        MessageBox.Show("Whoops! There's not enough memory to zoom any more.\nTry closing some programs and try again.", "Out of memory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (System.ArgumentException)
                    {
                        if (string.IsNullOrEmpty(openFileDialog1.FileName))
                        {
                            MessageBox.Show("Please import an image before scaling!", "No image imported", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ImageInfo.zoom = 1;
                            scalefactor.Text = "1";
                        }
                        else
                        {
                            MessageBox.Show("This image has no reason to be zoomed in so much, and because of this, you do not have enough memory", "Out of memory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ImageInfo.zoom = 8;
                            scalefactor.Text = "8";
                            image.Image = Image.FromFile(DatInfo.fullFileName);
                            UpdateZoom(ImageInfo.zoom);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An unrecognized error occured. Error reported from .NET is: " + ex.GetType().FullName, "Something happened", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch
                {

                }
            }



        }

        private void shrink_Click(object sender, EventArgs e) //New code, zooms out of the image
        {
            bool stopZoomWarning = false;
            bool Zoomout = true;
            if (scalefactor.Text == "32" && ImageInfo.usingDivide == true)
            {
                MessageBox.Show("Woah woah woah! That's way too small, you don't need to zoom out so much!\nAny smaller and you wouldn't be able to see the image anymore.", "Slow down there pal!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\extras\\conf\\config.txt"))
                {
                    if (File.ReadAllText(Directory.GetCurrentDirectory() + "\\extras\\conf\\config.txt").Contains("stopZoomWarning = true"))
                    {
                        stopZoomWarning = true;
                    }

                }
                if (ImageInfo.zoom == 1 && ImageInfo.usingDivide == false)
                {
                    if (stopZoomWarning == false)
                    {
                        DialogResult result = MessageBox.Show("Zooming out smaller than 100% is not recommended to do unless you're working on a single, giant sprite.\nZooming out smaller than 100% can mess up your sprite sheet depending on the length and width of your rectangles\nUnless you're making a large 2K-4K sprite, DO NOT zoom out smaller than 100%.\nYou have been warned.\n\nYes = Continue without seeing this warning again\nNo = Continue, but see this warning again after reopening the program\nCancel = Stop the zoom out operation", "CAUTION", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            File.WriteAllText(Directory.GetCurrentDirectory() + "\\extras\\conf\\config.txt", "stopZoomWarning = true");
                            ImageInfo.usingDivide = true;
                            ImageInfo.zoom *= 2;
                            stopZoomWarning = true;
                        }
                        else if (result == DialogResult.No)
                        {
                            ImageInfo.usingDivide = true;
                            ImageInfo.zoom *= 2;
                            stopZoomWarning = true;
                        }
                        else
                        {
                            Zoomout = false;
                        }
                    }
                    else
                    {
                        ImageInfo.usingDivide = true;
                        ImageInfo.zoom *= 2;
                    }

                }
                else if (ImageInfo.zoom != 1 && ImageInfo.usingDivide == true)
                {
                    ImageInfo.zoom *= 2;
                }
                else
                {
                    ImageInfo.zoom /= 2;
                }
                if (ImageInfo.zoom == 0)
                {
                    ImageInfo.zoom = 2;
                }
                scalefactor.Text = ImageInfo.zoom.ToString();
                if (Zoomout)
                {
                    try
                    {
                        image.Image = Image.FromFile(DatInfo.fullFileName);
                        UpdateZoom(ImageInfo.zoom);
                    }
                    catch (OutOfMemoryException)
                    {
                        MessageBox.Show("Whoops! There's not enough memory to zoom any more.\nTry closing some programs and try again.", "Out of memory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (System.ArgumentException)
                    {
                        MessageBox.Show("Please import an image before scaling!", "No image imported", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ImageInfo.zoom = 1;
                        scalefactor.Text = "1";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An unrecognized error occured. Error reported from .NET is:" + ex.GetType().FullName, "Something happened", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    for (int i = 0; i < DatInfo.rectangleList.Count; i++)
                    {
                        DatInfo.rectangleList[i].rect.X = DatInfo.rectangleList[i].rect.X / 2;
                        DatInfo.rectangleList[i].rect.Y = DatInfo.rectangleList[i].rect.Y / 2;
                        DatInfo.rectangleList[i].rect.Width = DatInfo.rectangleList[i].rect.Width / 2;
                        DatInfo.rectangleList[i].rect.Height = DatInfo.rectangleList[i].rect.Height / 2;
                    }
                }
            }
        }
    }
}
