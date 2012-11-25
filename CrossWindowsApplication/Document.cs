using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossWindowsApplication
{
    public class Document
    {
        public Document()
        {
            books = new List<Book>();
            views = new List<BookView>();
        }

        ~Document()
        {
            foreach(BookView bv in views)
                bv.close();
        }

        public void addBook(Book toAdd)
        {
            books.Add(toAdd);
            foreach(BookView bv in views)
                bv.addBook(toAdd);
        }

        public void removeBook(Book toRemove)
        {
            books.Remove(toRemove);
            foreach(BookView bv in views)
                bv.removeBook(toRemove);
        }

        public void updateBook(Book toUpdate)
        {
            foreach(BookView bv in views)
                bv.updateBook(toUpdate);
        }

        public void addView(BookView bv)
        {
            views.Add(bv);
        }

        public void fillBooks(BookView view)
        {
            foreach (Book book in books)
                view.addBook(book);
        }


        List<Book> books;
        List<BookView> views;
    }
}
