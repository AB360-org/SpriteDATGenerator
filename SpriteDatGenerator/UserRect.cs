using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ImageInfo = SpriteDatGenerator.MainForm.ImageInfo;

namespace UserRectDemo
{
    public class UserRect 
    {        
        private PictureBox mPictureBox;
        public Rectangle rect;
        public bool allowDeformingDuringMovement=false ;
        private bool mIsClick=false;
        private bool mMove=false;        
        private int oldX;
        private int oldY;
        private int sizeNodeRect= 5;
        private Bitmap mBmp=null;
        private PosSizableRect nodeSelected = PosSizableRect.None;
        private int angle = 30;
        public bool orangeFalsePurpleTrue;

        
        private enum PosSizableRect
        {            
            UpMiddle,
            LeftMiddle,
            LeftBottom,
            LeftUp,
            RightUp,
            RightMiddle,
            RightBottom,
            BottomMiddle,
            None

        };

        public UserRect(Rectangle r)
        {
            rect = r;
            mIsClick = false;
        }

        public void Draw(Graphics g)
        {
            if (orangeFalsePurpleTrue)
            {
                using (Pen pen1 = new Pen(Color.Purple, 2))
                {
                    g.DrawRectangle(pen1, rect);
                }
                using (Pen pen2 = new Pen(Color.FromArgb(21, 255, 0), 2))
                {
                    pen2.DashPattern = new float[] { 5, 5 };
                    g.DrawRectangle(pen2, rect);
                }
            }
            else
            {
                using (Pen pen1 = new Pen(Color.Blue, 2))
                {
                    g.DrawRectangle(pen1, rect);
                }
                using (Pen pen2 = new Pen(Color.Orange, 2))
                {
                    pen2.DashPattern = new float[] { 5, 5 };
                    g.DrawRectangle(pen2, rect);
                }
            }
            

            foreach (PosSizableRect pos in Enum.GetValues(typeof(PosSizableRect)))
            {
                using (Pen pen1 = new Pen(Color.Black, 2))
                {
                    g.DrawRectangle(pen1, GetRect(pos));
                }
                using (Pen pen2 = new Pen(Color.White, 2))
                {
                    pen2.DashPattern = new float[] { 5, 5 };
                    g.DrawRectangle(pen2, GetRect(pos));
                }
            }
            
        }

        public void Deletus(PictureBox d) //DELETUS THE RECTANGLUS
        {
            rect = new Rectangle(0,0,0,0);
            rect.Location = new Point(-10, -10);
            SetPictureBox(d);
            
        }

        public void SetBitmapFile(string filename)
        {
            this.mBmp = new Bitmap(filename);
        }

        public void SetBitmap(Bitmap bmp)
        {
            this.mBmp = bmp;
        }

        public void SetPictureBox(PictureBox p)
        {
            this.mPictureBox = p;
            mPictureBox.MouseDown +=new MouseEventHandler(mPictureBox_MouseDown);
            mPictureBox.MouseUp += new MouseEventHandler(mPictureBox_MouseUp);
            mPictureBox.MouseMove += new MouseEventHandler(mPictureBox_MouseMove);            
            mPictureBox.Paint += new PaintEventHandler(mPictureBox_Paint);
        }

        private void mPictureBox_Paint(object sender, PaintEventArgs e)
        {
            
            try
            {
                Draw(e.Graphics);
            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.Message);
            }
            
        }

        private void mPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mIsClick = true;

            nodeSelected = PosSizableRect.None;
            nodeSelected = GetNodeSelectable(e.Location);
                
            if (rect.Contains(new Point(e.X,e.Y)))
            {
                mMove = true;                            
            }
            oldX = e.X;
            oldY = e.Y;
        }

        private void mPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mIsClick = false;
            mMove = false;            
        }

        static int closestNumber(int n, int m) //This was added as a way to line up the box with the pixels on screen
        {
            // find the quotient
            int q = n / m;

            // 1st possible closest number
            int n1 = m * q;

            // 2nd possible closest number
            int n2 = (n * m) > 0 ? (m * (q + 1)) : (m * (q - 1));

            // if true, then n1 is the required closest number
            if (Math.Abs(n - n1) < Math.Abs(n - n2))
                return n1;

            // else n2 is the required closest number
            return n2;


            //Credit to Sam007 for this function
        }

        private void mPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            ChangeCursor(e.Location);
            if (mIsClick == false)
            {
                return;
            }

            Rectangle backupRect = rect;

            switch (nodeSelected)
            {
                case PosSizableRect.LeftUp:
                    rect.X += closestNumber(e.X, ImageInfo.zoom) - closestNumber(oldX, ImageInfo.zoom);
                    rect.Width -= closestNumber(e.X, ImageInfo.zoom) - closestNumber(oldX, ImageInfo.zoom);                    
                    rect.Y += closestNumber(e.Y, ImageInfo.zoom) - closestNumber(oldY, ImageInfo.zoom);
                    rect.Height -= closestNumber(e.Y, ImageInfo.zoom) - closestNumber(oldY, ImageInfo.zoom);
                    break;
                case PosSizableRect.LeftMiddle:
                    rect.X += closestNumber(e.X, ImageInfo.zoom) - closestNumber(oldX, ImageInfo.zoom);
                    rect.Width -= closestNumber(e.X, ImageInfo.zoom) - closestNumber(oldX, ImageInfo.zoom);
                    break;
                case PosSizableRect.LeftBottom:
                    rect.Width -= closestNumber(e.X, ImageInfo.zoom) - closestNumber(oldX, ImageInfo.zoom);
                    rect.X += closestNumber(e.X, ImageInfo.zoom) - closestNumber(oldX, ImageInfo.zoom);
                    rect.Height += closestNumber(e.Y, ImageInfo.zoom) - closestNumber(oldY, ImageInfo.zoom);
                    break;
                case PosSizableRect.BottomMiddle:
                    rect.Height += closestNumber(e.Y, ImageInfo.zoom) - closestNumber(oldY, ImageInfo.zoom);
                    break;
                case PosSizableRect.RightUp:
                    rect.Width += closestNumber(e.X, ImageInfo.zoom) - closestNumber(oldX, ImageInfo.zoom);
                    rect.Y += closestNumber(e.Y, ImageInfo.zoom) - closestNumber(oldY, ImageInfo.zoom);
                    rect.Height -= closestNumber(e.Y,ImageInfo.zoom) - closestNumber(oldY, ImageInfo.zoom);
                    break;
                case PosSizableRect.RightBottom:
                    rect.Width +=  closestNumber(e.X, ImageInfo.zoom) - closestNumber(oldX, ImageInfo.zoom);
                    rect.Height += closestNumber(e.Y, ImageInfo.zoom) - closestNumber(oldY, ImageInfo.zoom);
                    break;
                case PosSizableRect.RightMiddle:
                    rect.Width += closestNumber(e.X, ImageInfo.zoom) - closestNumber(oldX, ImageInfo.zoom);
                    break;

                case PosSizableRect.UpMiddle:
                    rect.Y += closestNumber(e.Y, ImageInfo.zoom) - closestNumber(oldY, ImageInfo.zoom);
                    rect.Height -= closestNumber(e.Y, ImageInfo.zoom) - closestNumber(oldY, ImageInfo.zoom);
                    break;

                    
                default:
                    if (mMove)
                    {

                            rect.X = closestNumber(e.X - rect.Width/2, ImageInfo.zoom); 
                            rect.Y = closestNumber(e.Y - rect.Height/2, ImageInfo.zoom);
                    }
                    break;
            }
            oldX = e.X;
            oldY = e.Y;

            if (rect.Width < 5 || rect.Height < 5)
            {
                rect = backupRect;
            }

            TestIfRectInsideArea();

            mPictureBox.Invalidate();
        }

        private void TestIfRectInsideArea()
        {
            // Test if rectangle still inside the area.
            if (rect.X < 0) rect.X = 0;
            if (rect.Y < 0) rect.Y = 0;
            if (rect.Width <= 0) rect.Width = 1;
            if (rect.Height <= 0) rect.Height = 1;

            if (rect.X + rect.Width > mPictureBox.Width)
            {
                rect.Width = mPictureBox.Width - rect.X - 1; // -1 to be still show 
                if (allowDeformingDuringMovement == false)
                {
                    mIsClick = false;
                }
            }
            if (rect.Y + rect.Height > mPictureBox.Height)
            {
                rect.Height = mPictureBox.Height - rect.Y - 1;// -1 to be still show 
                if (allowDeformingDuringMovement == false)
                {
                    mIsClick = false;
                }
            }
        }        

        private Rectangle CreateRectSizableNode(int x, int y)
        {
            return new Rectangle(x - sizeNodeRect / 2, y - sizeNodeRect / 2, sizeNodeRect, sizeNodeRect);   
        }

        private Rectangle GetRect(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.LeftUp:
                    return CreateRectSizableNode(rect.X, rect.Y);
                 
                case PosSizableRect.LeftMiddle:
                    return CreateRectSizableNode(rect.X, rect.Y + +rect.Height / 2);                    

                case PosSizableRect.LeftBottom:
                    return CreateRectSizableNode(rect.X, rect.Y +rect.Height);                                   

                case PosSizableRect.BottomMiddle:
                    return CreateRectSizableNode(rect.X  + rect.Width / 2,rect.Y + rect.Height);

                case PosSizableRect.RightUp:
                    return CreateRectSizableNode(rect.X + rect.Width,rect.Y );

                case PosSizableRect.RightBottom:
                    return CreateRectSizableNode(rect.X  + rect.Width,rect.Y  + rect.Height);

                case PosSizableRect.RightMiddle:
                    return CreateRectSizableNode(rect.X  + rect.Width, rect.Y  + rect.Height / 2);

                case PosSizableRect.UpMiddle:
                    return CreateRectSizableNode(rect.X + rect.Width/2, rect.Y);
                default :
                    return new Rectangle();
            }
        }

        private PosSizableRect GetNodeSelectable(Point p)
        {
           foreach (PosSizableRect r in Enum.GetValues(typeof(PosSizableRect)))
            {
                if (GetRect(r).Contains(p))
                {
                    return r;                    
                }
            }
            return PosSizableRect.None;
        }

        private void ChangeCursor(Point p)
        {
            mPictureBox.Cursor = GetCursor(GetNodeSelectable(p));
        }

        /// <summary>
        /// Get cursor for the handle
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private Cursor GetCursor(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.LeftUp:
                    return Cursors.SizeNWSE;               

                case PosSizableRect.LeftMiddle:
                    return Cursors.SizeWE;

                case PosSizableRect.LeftBottom:
                    return Cursors.SizeNESW;

                case PosSizableRect.BottomMiddle:
                    return Cursors.SizeNS;

                case PosSizableRect.RightUp:
                    return Cursors.SizeNESW;

                case PosSizableRect.RightBottom:
                    return Cursors.SizeNWSE;

                case PosSizableRect.RightMiddle:
                    return Cursors.SizeWE;

                case PosSizableRect.UpMiddle:
                    return Cursors.SizeNS;
                default:
                    return Cursors.Default;
            }
        }

    }
}
