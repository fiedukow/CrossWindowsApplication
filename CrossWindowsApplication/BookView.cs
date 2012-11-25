﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrossWindowsApplication
{
    abstract class BookView : Form
    {
        BookView(Form parent)
        {
            this.parent = parent;
        }

        public abstract void addBook(Book toAdd);
        public abstract void removeBook(Book toRemove);
        public abstract void updateBook(Book toUpdate);
        public abstract void activated();
        public abstract void close();

        protected Form parent;
    }
}