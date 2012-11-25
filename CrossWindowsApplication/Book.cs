using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public enum BookType { UNKNOWN, CRIME, COMMEDY, SF, FANTASY };

namespace CrossWindowsApplication
{
    public class Book
    {
        public Book(String title, String author, DateTime releaseDate, BookType type = BookType.UNKNOWN)
        {
            this.title = title;
            this.author = author;
            this.releaseDate = releaseDate;
            this.type = type;
        }

        public ListViewItem produceTagedListViewItem()
        {
            ListViewItem result = new ListViewItem();
            result.Tag = this;
            return result;
        }

        public TreeNode produceTagedTreeNode()
        {
            TreeNode result = new TreeNode();
            result.Tag = this;
            return result;
        }

        protected String title;
        protected String author;
        protected DateTime releaseDate;
        protected BookType type;
    }
}
