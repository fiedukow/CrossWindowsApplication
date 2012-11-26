using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace CrossWindowsApplication
{
    [Serializable]
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

        public bool removeView(BookView bw)
        {
            if (views.Count > 1)
            {
                views.Remove(bw);
                return true;
            }
            return false;
        }

        public void initViews()
        {
            views = new List<BookView>();
        }

        public void killThemAll()
        {
            foreach (BookView bw in views)
                bw.killWin();
        }

        public void save(String fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }

        List<Book> books;

        [NonSerialized]
        List<BookView> views;
    }
}
