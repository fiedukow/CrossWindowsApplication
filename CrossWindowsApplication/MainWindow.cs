using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace CrossWindowsApplication
{
    public partial class MainWindow : Form
    {
        private int childFormNumber = 0;

        public MainWindow()
        {
            InitializeComponent();
            currentDocument = new Document();
            filterBox.DataSource = Enum.GetValues(typeof(FilterType));
            filterBox.SelectedIndex = 0;
            addListView();
            dontFilterMark = false;
        }

        public void setFilterInCombo(FilterType filter)
        {
            filterBox.SelectedIndex = (int) filter;
        }

        public void setBooksInViewNumber(int nr)
        {
            StatusBarLabel.Text = "Showing: " + nr + " books";
        }

        public void fillBooks(BookView view)
        {
            currentDocument.fillBooks(view);
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.dat)|*.dat|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                FileStream fs = new FileStream(FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                Document oldDocument = currentDocument;
                currentDocument = (Document)bf.Deserialize(fs);
                currentDocument.initViews();
                oldDocument.killThemAll();
                addListView();
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.dat)|*.dat|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
                currentDocument.save(FileName);
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
            filterBox.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        public Document CurrentDocument
        {
            set { this.currentDocument = value; }
            get { return this.currentDocument; }
        }

        private Document currentDocument;

        public void setBookManagmentOptionsEnabled(bool enable)
        {
            RemoveBookButton.Enabled = enable;
            ModifyBookButton.Enabled = enable;
            removeBookToolStripMenuItem.Enabled = enable;
            editBookToolStripMenuItem.Enabled = enable;
        }

        public bool removeView(BookView bw)
        {
            return currentDocument.removeView(bw);
        }

        void addTreeView()
        {
            BookView newView = new BookTreeView(this);
            newView.MdiParent = this;
            currentDocument.addView(newView);
            newView.Show();
        }

        void addListView()
        {
            BookView newView = new BookListView(this);
            newView.MdiParent = this;
            currentDocument.addView(newView);
            newView.Show();
        }

        private void AddTreeViewButton_Click(object sender, EventArgs e)
        {
            addTreeView();
        }

        private void AddListViewButton_Click(object sender, EventArgs e)
        {
            addListView();
        }

        private void dodajWidokListyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addListView();
        }

        private void dodajWidokDrzewaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTreeView();
        }

        public void addBook()
        {
            BookDetailsWindow bd = new BookDetailsWindow();
            bd.ShowDialog();
            if (bd.IsBookAccepted)
                currentDocument.addBook(bd.buildBook());

            if(((BookView)ActiveMdiChild) != null)
                ((BookView)ActiveMdiChild).activated();
        }

        public void modifyBook()
        {
            BookView bw = (BookView) ActiveMdiChild;
            if(bw == null)
                return;
            Book toMod = bw.getCurrentlySelected();
            if (toMod == null)
                return;

            BookDetailsWindow bd = new BookDetailsWindow(toMod);
            bd.ShowDialog();
            if (bd.IsBookAccepted)
            {
                bd.fillBook(toMod);
                currentDocument.updateBook(toMod);
            }

            bw.activated();
        }

        public void removeBook()
        {
            BookView bw = (BookView)ActiveMdiChild;
            if (bw == null)
                return;
            Book toRm = bw.getCurrentlySelected();
            if (toRm == null)
                return;          
            currentDocument.removeBook(toRm);

            bw.activated();
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            addBook();
        }

        private void ModifyBookButton_Click(object sender, EventArgs e)
        {
            modifyBook();
        }

        private void RemoveBookButton_Click(object sender, EventArgs e)
        {
            removeBook();
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addBook();
        }

        private void editBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modifyBook();
        }

        private void removeBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeBook();
        }

        private void MainWindow_MdiChildActivate(object sender, EventArgs e)
        {
            BookView bw = (BookView)ActiveMdiChild;
            if (bw == null)
                return;
            dontFilterMark = (bw.Filter != (FilterType)filterBox.SelectedIndex);
            bw.activated();
        }

        private void filterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dontFilterMark == true)
            {
                dontFilterMark = false;
                return;
            }
            BookView bw = (BookView)ActiveMdiChild;
            if (bw == null)
                return;
            bw.filterItems((FilterType)filterBox.SelectedIndex);
        }

        private bool dontFilterMark;

    }
}
