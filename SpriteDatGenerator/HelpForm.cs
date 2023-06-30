using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SpriteDatGenerator
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        public static class Tutorials
        {
            public static string[][] tutorials = new string[][]
            {
            new string[] { "This tutorial will teach you how to make any of the following images:\nBird, pig, block or, ui button.\nClick Next to continue.", "Start by browsing for the image you want to use, and then press 'Import'.\nIf you'd like to use the example image, it is located at \\extras\\img\\examples\\bird_pig_block_button.png", "Click on the screen to add a square, resize the square so it captures the area of the image you want.", "Assign a name for your sprite, and then press the 'Commit Selection' button.", "If you are happy with the selection, press the 'Yes' button.","Since birds, pigs, blocks, and buttons all use the same origin setting, press the big 'Center' button, but before you do, please go to the next slide.","There is an exception to this rule if your bird (or pig) has a unique shape, such as hal. If that's the case, please select, 'I want to use a custom origin point'. You will then get an interface like in the image above, but with your own sprite. All you have to do is click on where the center of the bird's body is. That way, they roll on the ground correctly.","Once you have selected your origin, you will see this dialog, which means your sprite has been sucessfully made.","Repeat this process for the remaining parts of the image you want to turn into sprites.","Once you have done that, head over to the side and press the 'Generate' button.","Choose where to save your DAT file and give it a name.","You will see a dialog like this. It is a reminder that you agree to not rename the PNG file you used in making the DAT so you don't break it. Press 'OK'.","Congratulations! You've now created a DAT file that can be used for birds, pigs, blocks, and ui buttons!"},
            new string[] { "This tutorial will teach you how to make any of the following images:\nParallax themes, or skies.", "Start by browsing for the image you want to use, and then press 'Import'.\nIf you'd like to use the example image, it is located at \\extras\\img\\examples\\parallax_sky.png", "Click on the screen to add a square, resize the square so it's dimensions match that of the theme's parallaxes or sky.","Parallax images and skies are usually very large in size, so take your time when measuring them.","Next, give a name relative to what part of the theme the image is. (You can name it whatever you want, but it's best to give it something you'll be able to remember easier.)\nAfter that, click the 'Commit Selection' button.","If you're happy with your selection, press the 'Yes' button to continue.","In themes, there are two groups, the foreground and the background. The background is the parallax and sky that moves as you scroll accross the canvas. Setting it's origin point is easy, choose the 'Bottom Center' option.","Then there's the foreground, which is the image used to represent the top of the ground, setting it's origin point is more specific, so choose 'I want to use a custom origin point'.","Here's the tricky part: If you have a paint editor like Paint.NET though, this shouldn't be too hard. You'll need to know the length and width of your ground sprite. In this case, it is 482x22.\nDivide the width by 2: 241. So we are looking for a point on X=241, this point is to represent the top of the ground (Not including any extra details on the ground).\nSee the picture above for a better understanding.","Once you have set the origin point, you will see this dialog, which means your sprite has been sucessfully made.","Repeat this process for the remaining parts of the image you want to turn into parallaxes or skies.","Once you have done that, head over to the side and press the 'Generate' button.","Choose where to save your DAT file and give it a name.","You will see a dialog like this. It is a reminder that you agree to not rename the PNG file you used in making the DAT so you don't break it. Press 'OK'.","Congratulations! You've now created a DAT file with your own custom theme!"},
            new string[] { "This tutorial will teach you how to make any of the following images:\nGround textures or mouse pointers.\nNote: These are the ground blocks that you can place in the editor (Not to be confused with theme grounds)", "Start by browsing for the image you want to use, and then press 'Import'.\nIf you'd like to use the example image, it is located at \\extras\\img\\examples\\ground_mouse.png", "Click on the screen to add a square, resize the square so it captures the area of the image you want.", "Assign a name for your sprite, and then press the 'Commit Selection' button.", "If you are happy with the selection, press the 'Yes' button.", "The origin point of mouse pointers and grounds is at the top corner of the sprite, so select the 'Top Left' option.", "Once you have set the origin point, you will see this dialog, which means your sprite has been sucessfully made.","Repeat this process for the remaining parts of the image you want to turn into mouse pointers or solid ground blocks.","Once you have done that, head over to the side and press the 'Generate' button.","Choose where to save your DAT file and give it a name.","You will see a dialog like this. It is a reminder that you agree to not rename the PNG file you used in making the DAT so you don't break it. Press 'OK'.","Congratulations! You've now created a DAT file for a cursor or for solid ground textures!" }
            };
            public static int index = 0; //Page number
            public static int tutorial = 0; //What tutorial
            public static bool goToMenu = false; //If true, next button will send you back to the menu
        }

        private void button1_Click(object sender, EventArgs e) //Start tutorial one
        {
            Tutorials.tutorial = 0;
            Tutorials.index = 0;
            Next.Enabled = true;
            panel1.Visible = false;
            helpPanel.Visible = true;
            tutorialImage.ImageLocation = Directory.GetCurrentDirectory() + "\\extras\\img\\tutorials\\" + Tutorials.tutorial + "\\" + Tutorials.index + ".png";
            description.Text = Tutorials.tutorials[Tutorials.tutorial][Tutorials.index].ToString();
        }

        private void button2_Click(object sender, EventArgs e) //Start tutorial two
        {
            Tutorials.tutorial = 1;
            Tutorials.index = 0;
            Next.Enabled = true;
            panel1.Visible = false;
            helpPanel.Visible = true;
            tutorialImage.ImageLocation = Directory.GetCurrentDirectory() + "\\extras\\img\\tutorials\\" + Tutorials.tutorial + "\\" + Tutorials.index + ".png";
            description.Text = Tutorials.tutorials[Tutorials.tutorial][Tutorials.index].ToString();
        }

        private void button3_Click(object sender, EventArgs e) //Start tutorial three
        {
            Tutorials.tutorial = 2;
            Tutorials.index = 0;
            Next.Enabled = true;
            panel1.Visible = false;
            helpPanel.Visible = true;
            tutorialImage.ImageLocation = Directory.GetCurrentDirectory() + "\\extras\\img\\tutorials\\" + Tutorials.tutorial + "\\" + Tutorials.index + ".png";
            description.Text = Tutorials.tutorials[Tutorials.tutorial][Tutorials.index].ToString();
        }

        private void changeTheme(object sender, PaintEventArgs e)
        {
            
            if(BackColor == Color.LightGray)
            {
                panel1.ForeColor = Color.Black;
                helpPanel.ForeColor = Color.Black;
                description.ForeColor = Color.Black;
            }
            else
            {
                panel1.ForeColor = Color.White;
                helpPanel.ForeColor = Color.White;
                description.ForeColor = Color.White;
            }
        }

        private void Previous_Click(object sender, EventArgs e) //Previous slide
        {
            Tutorials.index--;
            Tutorials.goToMenu = false;
            Next.Text = "Next >";
            if (Tutorials.index == -1)
            {
                helpPanel.Visible = false;
                panel1.Visible = true;
            }
            else
            {
                tutorialImage.ImageLocation = Directory.GetCurrentDirectory() + "\\extras\\img\\tutorials\\" + Tutorials.tutorial + "\\" + Tutorials.index + ".png";
                description.Text = Tutorials.tutorials[Tutorials.tutorial][Tutorials.index].ToString();
                Next.Enabled = true;
            }
            
        }

        private void Next_Click(object sender, EventArgs e) //Next slide
        {
            if (Tutorials.goToMenu == false)
            {
                Tutorials.index++;
                tutorialImage.ImageLocation = Directory.GetCurrentDirectory() + "\\extras\\img\\tutorials\\" + Tutorials.tutorial + "\\" + Tutorials.index + ".png";
                description.Text = Tutorials.tutorials[Tutorials.tutorial][Tutorials.index].ToString();
                if (Tutorials.index + 1 == Tutorials.tutorials[Tutorials.tutorial].Length)
                {
                    Next.Text = "Back <<";
                    Tutorials.goToMenu = true;
                }
            }
            else
            {
                helpPanel.Visible = false;
                panel1.Visible = true;
                Tutorials.index = 0;
                Next.Text = "Next >";
                Tutorials.goToMenu = false;
            }
            
            
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
