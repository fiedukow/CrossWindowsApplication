namespace CrossWindowsApplication
{
    partial class BookListView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bookView = new System.Windows.Forms.ListView();
            this.TitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReleaseDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contexMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contexMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bookView
            // 
            this.bookView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TitleColumn,
            this.AuthorColumn,
            this.ReleaseDate,
            this.Type});
            this.bookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookView.Location = new System.Drawing.Point(0, 0);
            this.bookView.Name = "bookView";
            this.bookView.Size = new System.Drawing.Size(284, 262);
            this.bookView.TabIndex = 0;
            this.bookView.UseCompatibleStateImageBehavior = false;
            this.bookView.View = System.Windows.Forms.View.Details;
            this.bookView.SelectedIndexChanged += new System.EventHandler(this.bookView_SelectedIndexChanged);
            this.bookView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.bookView_MouseClick);
            // 
            // TitleColumn
            // 
            this.TitleColumn.Text = "Title";
            // 
            // AuthorColumn
            // 
            this.AuthorColumn.Text = "Author";
            // 
            // ReleaseDate
            // 
            this.ReleaseDate.Text = "Release Date";
            // 
            // Type
            // 
            this.Type.Text = "Type";
            // 
            // contexMenu
            // 
            this.contexMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.editToolStripMenuItem});
            this.contexMenu.Name = "contexMenu";
            this.contexMenu.Size = new System.Drawing.Size(118, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // BookListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.bookView);
            this.Name = "BookListView";
            this.Text = "ListView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BookListView_FormClosing);
            this.contexMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView bookView;
        private System.Windows.Forms.ColumnHeader TitleColumn;
        private System.Windows.Forms.ColumnHeader AuthorColumn;
        private System.Windows.Forms.ColumnHeader ReleaseDate;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ContextMenuStrip contexMenu;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}