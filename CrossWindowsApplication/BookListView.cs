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
    public partial class BookListView : BookView
    {
        public BookListView(Form parent)
            : base(parent)
        {
            InitializeComponent();
            ((MainWindow)parent).fillBooks(this);
        }

        public override void addBook(Book toAdd)
        {
            bookView.Items.Add(toAdd.produceTagedListViewItem());
        }

        public override void removeBook(Book toRemove)
        {
            if (toRemove == null)
                return;

            foreach (ListViewItem it in bookView.Items)
                if (it.Tag == toRemove)
                {
                    bookView.Items.Remove(it);
                    return;
                }
        }

        public override void updateBook(Book toUpdate)
        {
            foreach (ListViewItem it in bookView.Items)
                if (it.Tag == toUpdate)
                {
                    toUpdate.updateTagedListViewItem(it);
                    return;
                }
        }

        public override void activated()
        {
            //send to parten with options are enabled
        }

        public override void close()
        {
            //check if it is not last window
            //delete from parent
        }

        public override Book getCurrentlySelected()
        {
            if (bookView.SelectedItems.Count <= 0)
                return null;

            return (Book) bookView.SelectedItems[0].Tag;
        }
    }
}
