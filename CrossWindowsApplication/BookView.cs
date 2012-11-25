using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public enum FilterType { ALL, BEFORE, AFTER };

namespace CrossWindowsApplication
{
    public abstract class BookView : Form
    {
        public BookView(Form parent)
        {
            this.parent = parent;
            this.filter = FilterType.ALL;
        }

        public abstract void addBook(Book toAdd);
        public abstract void removeBook(Book toRemove);
        public abstract void updateBook(Book toUpdate);
        public abstract void activated();
        public abstract void close();
        public abstract Book getCurrentlySelected();
        public abstract void filterItems(FilterType newFiler);

        public FilterType Filter
        {
            get { return this.filter; }
            set { this.filter = value; }
        }

        protected Form parent;
        protected FilterType filter;
    }
}
