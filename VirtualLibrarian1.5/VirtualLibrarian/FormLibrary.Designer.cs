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
            this.buttonManageLibrary = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.checkedListBoxGenre = new System.Windows.Forms.CheckedListBox();
            this.listBoxMain = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.takebook = new System.Windows.Forms.Button();
            this.buttonMore = new System.Windows.Forms.Button();
            this.buttonSort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(246, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome to the Virtual Library";
            // 
            // buttonTakenBooks
            // 
            this.buttonTakenBooks.Location = new System.Drawing.Point(139, 375);
            this.buttonTakenBooks.Name = "buttonTakenBooks";
            this.buttonTakenBooks.Size = new System.Drawing.Size(97, 41);
            this.buttonTakenBooks.TabIndex = 2;
            this.buttonTakenBooks.Text = "Taken books";
            this.buttonTakenBooks.UseVisualStyleBackColor = true;
            this.buttonTakenBooks.Click += new System.EventHandler(this.buttonTakenBooks_Click_1);
            // 
            // buttonReccomend
            // 
            this.buttonReccomend.Location = new System.Drawing.Point(242, 375);
            this.buttonReccomend.Name = "buttonReccomend";
            this.buttonReccomend.Size = new System.Drawing.Size(126, 41);
            this.buttonReccomend.TabIndex = 3;
            this.buttonReccomend.Text = "Book recommendations";
            this.buttonReccomend.UseVisualStyleBackColor = true;
            this.buttonReccomend.Click += new System.EventHandler(this.buttonReccomend_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(295, 51);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(101, 25);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search books";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(275, 20);
            this.textBox1.TabIndex = 5;
            // 
            // buttonAccSettings
            // 
            this.buttonAccSettings.Location = new System.Drawing.Point(374, 375);
            this.buttonAccSettings.Name = "buttonAccSettings";
            this.buttonAccSettings.Size = new System.Drawing.Size(101, 41);
            this.buttonAccSettings.TabIndex = 6;
            this.buttonAccSettings.Text = "Account settings";
            this.buttonAccSettings.UseVisualStyleBackColor = true;
            this.buttonAccSettings.Click += new System.EventHandler(this.buttonAccSettings_Click);
            // 
            // buttonGenre
            // 
            this.buttonGenre.Location = new System.Drawing.Point(574, 54);
            this.buttonGenre.Name = "buttonGenre";
            this.buttonGenre.Size = new System.Drawing.Size(94, 25);
            this.buttonGenre.TabIndex = 8;
            this.buttonGenre.Text = "Search genre";
            this.buttonGenre.UseVisualStyleBackColor = true;
            this.buttonGenre.Click += new System.EventHandler(this.buttonGenre_Click);
            // 
            // buttonManageLibrary
            // 
            this.buttonManageLibrary.Location = new System.Drawing.Point(678, 375);
            this.buttonManageLibrary.Name = "buttonManageLibrary";
            this.buttonManageLibrary.Size = new System.Drawing.Size(136, 41);
            this.buttonManageLibrary.TabIndex = 10;
            this.buttonManageLibrary.Text = "Manage library and reader accounts";
            this.buttonManageLibrary.UseVisualStyleBackColor = true;
            this.buttonManageLibrary.Click += new System.EventHandler(this.buttonManageLibrary_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(481, 375);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(52, 41);
            this.buttonLogOut.TabIndex = 11;
            this.buttonLogOut.Text = "Log out";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // checkedListBoxGenre
            // 
            this.checkedListBoxGenre.FormattingEnabled = true;
            this.checkedListBoxGenre.Items.AddRange(new object[] {
            "Adventure",
            "Art",
            "Children\'s",
            "Drama",
            "Encyclopedias",
            "Fantasy",
            "Health",
            "History",
            "Horror",
            "Mystery",
            "Philosophy",
            "Poetry",
            "Romance",
            "Science-fiction",
            "Travel"});
            this.checkedListBoxGenre.Location = new System.Drawing.Point(678, 54);
            this.checkedListBoxGenre.Name = "checkedListBoxGenre";
            this.checkedListBoxGenre.Size = new System.Drawing.Size(136, 139);
            this.checkedListBoxGenre.Sorted = true;
            this.checkedListBoxGenre.TabIndex = 15;
            // 
            // listBoxMain
            // 
            this.listBoxMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.listBoxMain.FormattingEnabled = true;
            this.listBoxMain.ItemHeight = 18;
            this.listBoxMain.Location = new System.Drawing.Point(12, 95);
            this.listBoxMain.Name = "listBoxMain";
            this.listBoxMain.Size = new System.Drawing.Size(656, 274);
            this.listBoxMain.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "ISBN --- Title --- Author --- Genres";
            // 
            // takebook
            // 
            this.takebook.BackColor = System.Drawing.SystemColors.Control;
            this.takebook.Location = new System.Drawing.Point(678, 344);
            this.takebook.Margin = new System.Windows.Forms.Padding(2);
            this.takebook.Name = "takebook";
            this.takebook.Size = new System.Drawing.Size(136, 26);
            this.takebook.TabIndex = 18;
            this.takebook.Text = "Take book";
            this.takebook.UseVisualStyleBackColor = false;
            this.takebook.Visible = false;
            this.takebook.Click += new System.EventHandler(this.takebook_Click);
            // 
            // buttonMore
            // 
            this.buttonMore.Location = new System.Drawing.Point(12, 375);
            this.buttonMore.Name = "buttonMore";
            this.buttonMore.Size = new System.Drawing.Size(121, 41);
            this.buttonMore.TabIndex = 19;
            this.buttonMore.Text = "More about the book";
            this.buttonMore.UseVisualStyleBackColor = true;
            this.buttonMore.Click += new System.EventHandler(this.buttonMore_Click);
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(402, 51);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(73, 25);
            this.buttonSort.TabIndex = 20;
            this.buttonSort.Text = "Sort by title";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Visible = false;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // FormLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 422);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.buttonMore);
            this.Controls.Add(this.takebook);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxMain);
            this.Controls.Add(this.checkedListBoxGenre);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.buttonManageLibrary);
            this.Controls.Add(this.buttonGenre);
            this.Controls.Add(this.buttonAccSettings);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonReccomend);
            this.Controls.Add(this.buttonTakenBooks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Button buttonManageLibrary;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.CheckedListBox checkedListBoxGenre;
        private System.Windows.Forms.ListBox listBoxMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button takebook;
        private System.Windows.Forms.Button buttonMore;
        private System.Windows.Forms.Button buttonSort;
    }
}