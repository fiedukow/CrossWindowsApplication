namespace CrossWindowsApplication
{
    partial class BookTreeView
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
            this.bookView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // bookView
            // 
            this.bookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookView.Location = new System.Drawing.Point(0, 0);
            this.bookView.Name = "bookView";
            this.bookView.Size = new System.Drawing.Size(284, 262);
            this.bookView.TabIndex = 0;
            // 
            // TreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.bookView);
            this.Name = "TreeView";
            this.Text = "TreeView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView bookView;
    }
}