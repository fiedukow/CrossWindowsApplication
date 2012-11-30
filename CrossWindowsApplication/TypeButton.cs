using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;


namespace CrossWindowsApplication
{
    public class TypeButton : Button
    {
        public TypeButton() 
        {            
            Text = "";
            this.Click += new System.EventHandler(this.swap);
            setCurrentImage();
        }

        public TypeButton(BookType begin)
            : this()
        {
            current = begin;
            this.Width = 482;
            this.Height = 114;
            setCurrentImage();
        }

        void swap(object sender, EventArgs e)
        {            
            int c = ((int)current+1)%3;
            current = (BookType)c;
            setCurrentImage();
        }

        void setCurrentImage()
        {
            Bitmap bmp;
            switch (current)
            {
                case BookType.FANTASY:
                    bmp = Properties.Resources.FANTASY;
                    break;
                case BookType.LEARNING:
                    bmp = Properties.Resources.LEARNING;
                    break;
                case BookType.UNKNOWN:
                default:
                    bmp = Properties.Resources.UNKNOWN;
                    break;
            }

            BackgroundImage = (System.Drawing.Image)(bmp);           
        }

        public void safeSetCurrent(BookType newType)
        {
            current = newType;
            setCurrentImage();
        }

        [EditorAttribute(typeof(TypeButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Category("Moje kontrolki")]
        [BrowsableAttribute(true)]
        public BookType CurrentType
        {
            get { return current; }
            set { current = value; setCurrentImage(); }
        }

        BookType current;
    }
}
