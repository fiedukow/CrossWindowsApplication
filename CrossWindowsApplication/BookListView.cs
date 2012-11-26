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
            if (toAdd.isInFilter(Filter))
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
            ((MainWindow)parent).setBookManagmentOptionsEnabled(bookView.SelectedItems.Count > 0);
            ((MainWindow)parent).setBooksInViewNumber(bookView.Items.Count);
            ((MainWindow)parent).setFilterInCombo(Filter);
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

        private void bookView_SelectedIndexChanged(object sender, EventArgs e)
        {
            activated();
        }

        private void BookListView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (killWinFlag)
                return;

            if (((MainWindow)parent).removeView(this))                         
                return;

            if (e.CloseReason != CloseReason.UserClosing)
                return;

            e.Cancel = true;
        }

        public override void filterItems(FilterType newFiler)
        {
            Filter = newFiler;
            bookView.Items.Clear();
            ((MainWindow)parent).fillBooks(this);
            activated();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((MainWindow)parent).addBook();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((MainWindow)parent).removeBook();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((MainWindow)parent).modifyBook();
        }

        private void bookView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                editToolStripMenuItem.Enabled = bookView.FocusedItem != null;
                removeToolStripMenuItem.Enabled = bookView.FocusedItem != null;
                contexMenu.Show(Cursor.Position);
            }
        }
    }
}
