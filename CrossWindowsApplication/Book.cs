﻿using System;
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
            ListViewItem result = new ListViewItem(title);
            result.SubItems.AddRange(new String[] { author, releaseDate.ToString("dd MMM yyyy"), type.ToString() });            
            result.Tag = this;           
            return result;
        }

        public void updateTagedListViewItem(ListViewItem it)
        {
            it.Tag = this;
            it.Text = title;
            it.SubItems.Clear();
            it.SubItems.AddRange(new String[] { author, releaseDate.ToString("dd MMM yyyy"), type.ToString() });            
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
            tn.Nodes.Clear();
            tn.Nodes.Add(new TreeNode("Author: " + author));
            tn.Nodes.Add(new TreeNode("Released: " + releaseDate.ToString("dd MMM yyyy")));
            tn.Nodes.Add(new TreeNode("Type: " + type.ToString()));
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

        protected String title;
        protected String author;
        protected DateTime releaseDate;
        protected BookType type;
    }
}
