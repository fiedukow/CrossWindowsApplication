using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrossWindowsApplication
{
    public partial class BookTreeView : BookView
    {
        public BookTreeView(Form parent)
            : base(parent)
        {
            InitializeComponent();
        }

        public override void addBook(Book toAdd)
        {

        }

        public override void removeBook(Book toRemove)
        {

        }

        public override void updateBook(Book toUpdate)
        {

        }

        public override void activated()
        {

        }

        public override void close()
        {

        }
    }
}
