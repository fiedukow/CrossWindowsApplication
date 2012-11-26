using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public enum BookType { UNKNOWN, FANTASY, LEARNING };

namespace CrossWindowsApplication
{
    [Serializable]
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
            ListViewItem result = new ListViewItem(title);
            result.SubItems.AddRange(new String[] { author, releaseDate.ToString("dd MMM yyyy"), type.ToString() });            
            result.Tag = this;           
            return result;
        }

        public void updateTagedListViewItem(ListViewItem it)
        {
            it.Tag = this;
            it.Text = title;
            it.SubItems[1].Text = author;
            it.SubItems[2].Text = releaseDate.ToString("dd MMM yyyy");
            it.SubItems[3].Text = type.ToString();
        }

        public TreeNode produceTagedTreeNode()
        {
            TreeNode result = new TreeNode(title);
            result.Nodes.Add(new TreeNode("Author: " + author));
            result.Nodes.Add(new TreeNode("Released: " + releaseDate.ToString("dd MMM yyyy")));
            result.Nodes.Add(new TreeNode("Type: " + type.ToString()));
            result.Tag = this;
            return result;
        }

        public void updateTagedTreeNode(TreeNode tn)
        {
            tn.Tag = this;
            tn.Text = title;
            tn.Nodes[0].Text = "Author: " + author;
            tn.Nodes[1].Text = "Released: " + releaseDate.ToString("dd MMM yyyy");
            tn.Nodes[2].Text = "Type: " + type.ToString();            
        }

        public String Title
        {
            set { this.title = value; }
            get { return this.title; }
        }

        public String Author
        {
            set { this.author = value; }
            get { return this.author; }
        }

        public DateTime ReleaseDate
        {
            set { this.releaseDate = value; }
            get { return this.releaseDate; }
        }

        public BookType Type
        {
            set { this.type = value; }
            get { return this.type; }
        }

        public bool isInFilter(FilterType filter)
        {
            if (filter == FilterType.ALL)
                return true;
            if (filter == FilterType.AFTER)
                return releaseDate > new DateTime(2012, 11, 20);
            if (filter == FilterType.BEFORE)
                return releaseDate < new DateTime(2012, 11, 20);

            return false;
        }

        protected String title;
        protected String author;
        protected DateTime releaseDate;
        protected BookType type;
    }
}
