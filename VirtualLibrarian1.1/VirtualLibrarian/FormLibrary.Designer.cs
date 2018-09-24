namespace VirtualLibrarian
{
    partial class FormLibrary
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonTakenBooks = new System.Windows.Forms.Button();
            this.buttonReccomend = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonAccSettings = new System.Windows.Forms.Button();
            this.buttonGenre = new System.Windows.Forms.Button();
            this.buttonManageReaderAcc = new System.Windows.Forms.Button();
            this.buttonManageLibrary = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.checkedListBoxGenre = new System.Windows.Forms.CheckedListBox();
            this.listBoxMain = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.takebook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(257, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome to the Virtual Library";
            // 
            // buttonTakenBooks
            // 
            this.buttonTakenBooks.Location = new System.Drawing.Point(156, 358);
            this.buttonTakenBooks.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTakenBooks.Name = "buttonTakenBooks";
            this.buttonTakenBooks.Size = new System.Drawing.Size(156, 50);
            this.buttonTakenBooks.TabIndex = 2;
            this.buttonTakenBooks.Text = "Taken books";
            this.buttonTakenBooks.UseVisualStyleBackColor = true;
            this.buttonTakenBooks.Click += new System.EventHandler(this.buttonTakenBooks_Click);
            // 
            // buttonReccomend
            // 
            this.buttonReccomend.Location = new System.Drawing.Point(320, 358);
            this.buttonReccomend.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReccomend.Name = "buttonReccomend";
            this.buttonReccomend.Size = new System.Drawing.Size(168, 50);
            this.buttonReccomend.TabIndex = 3;
            this.buttonReccomend.Text = "Book recommendations";
            this.buttonReccomend.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(391, 48);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(135, 31);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search books";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 52);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(365, 22);
            this.textBox1.TabIndex = 5;
            // 
            // buttonAccSettings
            // 
            this.buttonAccSettings.Location = new System.Drawing.Point(496, 358);
            this.buttonAccSettings.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAccSettings.Name = "buttonAccSettings";
            this.buttonAccSettings.Size = new System.Drawing.Size(135, 50);
            this.buttonAccSettings.TabIndex = 6;
            this.buttonAccSettings.Text = "Account settings";
            this.buttonAccSettings.UseVisualStyleBackColor = true;
            this.buttonAccSettings.Click += new System.EventHandler(this.buttonAccSettings_Click);
            // 
            // buttonGenre
            // 
            this.buttonGenre.Location = new System.Drawing.Point(584, 48);
            this.buttonGenre.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGenre.Name = "buttonGenre";
            this.buttonGenre.Size = new System.Drawing.Size(125, 31);
            this.buttonGenre.TabIndex = 8;
            this.buttonGenre.Text = "Search genre";
            this.buttonGenre.UseVisualStyleBackColor = true;
            this.buttonGenre.Click += new System.EventHandler(this.buttonGenre_Click);
            // 
            // buttonManageReaderAcc
            // 
            this.buttonManageReaderAcc.Location = new System.Drawing.Point(732, 358);
            this.buttonManageReaderAcc.Margin = new System.Windows.Forms.Padding(4);
            this.buttonManageReaderAcc.Name = "buttonManageReaderAcc";
            this.buttonManageReaderAcc.Size = new System.Drawing.Size(168, 50);
            this.buttonManageReaderAcc.TabIndex = 9;
            this.buttonManageReaderAcc.Text = "Manage reader accounts";
            this.buttonManageReaderAcc.UseVisualStyleBackColor = true;
            // 
            // buttonManageLibrary
            // 
            this.buttonManageLibrary.Location = new System.Drawing.Point(732, 300);
            this.buttonManageLibrary.Margin = new System.Windows.Forms.Padding(4);
            this.buttonManageLibrary.Name = "buttonManageLibrary";
            this.buttonManageLibrary.Size = new System.Drawing.Size(168, 50);
            this.buttonManageLibrary.TabIndex = 10;
            this.buttonManageLibrary.Text = "Manage library";
            this.buttonManageLibrary.UseVisualStyleBackColor = true;
            this.buttonManageLibrary.Click += new System.EventHandler(this.buttonManageLibrary_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(639, 358);
            this.buttonLogOut.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(69, 50);
            this.buttonLogOut.TabIndex = 11;
            this.buttonLogOut.Text = "Log out";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // checkedListBoxGenre
            // 
            this.checkedListBoxGenre.FormattingEnabled = true;
            this.checkedListBoxGenre.Items.AddRange(new object[] {
            "Science-fiction",
            "Fantasy",
            "Adventure",
            "Mystery",
            "Horror",
            "Drama",
            "Romance",
            "Health",
            "Travel",
            "Children\'s",
            "Art",
            "Philosophy",
            "Poetry",
            "History",
            "Encyclopedias"});
            this.checkedListBoxGenre.Location = new System.Drawing.Point(719, 52);
            this.checkedListBoxGenre.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListBoxGenre.Name = "checkedListBoxGenre";
            this.checkedListBoxGenre.Size = new System.Drawing.Size(180, 225);
            this.checkedListBoxGenre.TabIndex = 15;
            // 
            // listBoxMain
            // 
            this.listBoxMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.listBoxMain.FormattingEnabled = true;
            this.listBoxMain.ItemHeight = 24;
            this.listBoxMain.Location = new System.Drawing.Point(16, 100);
            this.listBoxMain.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMain.Name = "listBoxMain";
            this.listBoxMain.Size = new System.Drawing.Size(692, 244);
            this.listBoxMain.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Title --- Author --- Genres";
            // 
            // takebook
            // 
            this.takebook.BackColor = System.Drawing.SystemColors.Control;
            this.takebook.Location = new System.Drawing.Point(12, 358);
            this.takebook.Name = "takebook";
            this.takebook.Size = new System.Drawing.Size(137, 50);
            this.takebook.TabIndex = 18;
            this.takebook.Text = "Take book";
            this.takebook.UseVisualStyleBackColor = false;
            this.takebook.Click += new System.EventHandler(this.takebook_Click);
            // 
            // FormLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 420);
            this.Controls.Add(this.takebook);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxMain);
            this.Controls.Add(this.checkedListBoxGenre);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.buttonManageLibrary);
            this.Controls.Add(this.buttonManageReaderAcc);
            this.Controls.Add(this.buttonGenre);
            this.Controls.Add(this.buttonAccSettings);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonReccomend);
            this.Controls.Add(this.buttonTakenBooks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLibrary";
            this.Text = "Virtual Library";
            this.Load += new System.EventHandler(this.FormLibrary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonTakenBooks;
        private System.Windows.Forms.Button buttonReccomend;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonAccSettings;
        private System.Windows.Forms.Button buttonGenre;
        private System.Windows.Forms.Button buttonManageReaderAcc;
        private System.Windows.Forms.Button buttonManageLibrary;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.CheckedListBox checkedListBoxGenre;
        private System.Windows.Forms.ListBox listBoxMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button takebook;
    }
}