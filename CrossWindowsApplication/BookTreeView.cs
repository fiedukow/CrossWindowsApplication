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
            ((MainWindow)parent).fillBooks(this);            
        }

        public override void addBook(Book toAdd)
        {
            if (toAdd.isInFilter(Filter))
                bookView.Nodes.Add(toAdd.produceTagedTreeNode());
        }

        public override void removeBook(Book toRemove)
        {
            if (toRemove == null)
                return;

            foreach (TreeNode ti in bookView.Nodes)
                if (ti.Tag == toRemove)
                {
                    bookView.Nodes.Remove(ti);
                    return;
                }
        }

        public override void updateBook(Book toUpdate)
        {
            foreach (TreeNode it in bookView.Nodes)
                if (it.Tag == toUpdate)
                {
                    if (!toUpdate.isInFilter(Filter))
                    {
                        removeBook(toUpdate);
                        return;
                    }
                    toUpdate.updateTagedTreeNode(it);
                    return;
                }
            if(toUpdate.isInFilter(Filter))
                addBook(toUpdate);
        }

        public override void activated()
        {
            ((MainWindow)parent).setBookManagmentOptionsEnabled(bookView.SelectedNode != null);
            ((MainWindow)parent).setBooksInViewNumber(bookView.Nodes.Count);
            ((MainWindow)parent).setFilterInCombo(Filter);
        }

        public override void close()
        {
            //check if it is not last window
            //delete from parent
        }

        public override Book getCurrentlySelected()
        {
            TreeNode tn = bookView.SelectedNode;

            if (tn == null)
                return null;

            if (tn.Parent != null)
                tn = tn.Parent;

            return (Book) tn.Tag;
        }

        private void bookView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            activated();
        }

        private void BookTreeView_FormClosing(object sender, FormClosingEventArgs e)
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
            bookView.Nodes.Clear();            
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
                editToolStripMenuItem.Enabled = (bookView.SelectedNode != null);
                removeToolStripMenuItem.Enabled = (bookView.SelectedNode != null);
                contextMenu.Show(Cursor.Position);
            }
        }
    }
}
