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
    public partial class BookDetailsWindow : Form
    {
        public BookDetailsWindow()
        {
            InitializeComponent();
        }

        public BookDetailsWindow(String title, String author, DateTime date, int typeId)
        {
            InitializeComponent();
            TitleBox.Text = title;
            AuthorBox.Text = author;
            RelCal.SetDate(date);
            TypeBox.SelectedIndex = typeId;
        }

        public BookDetailsWindow(Book book)
        {
            InitializeComponent();
            TitleBox.Text = book.Title;
            AuthorBox.Text = book.Author;
            RelCal.SetDate(book.ReleaseDate);
            TypeBox.SelectedIndex = (int) book.Type;
        }

        public Book buildBook()
        {
            return new Book(TitleBox.Text, AuthorBox.Text, RelCal.SelectionStart, (BookType) TypeBox.SelectedIndex);
        }

        public void fillBook(Book book)
        {
            book.Title = TitleBox.Text;
            book.Author = AuthorBox.Text;
            book.ReleaseDate = RelCal.SelectionStart;
            book.Type = (BookType) TypeBox.SelectedIndex;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
