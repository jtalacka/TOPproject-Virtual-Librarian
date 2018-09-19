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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonGenre = new System.Windows.Forms.Button();
            this.buttonManageReaderAcc = new System.Windows.Forms.Button();
            this.buttonManageLibrary = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.checkedListBoxGenre = new System.Windows.Forms.CheckedListBox();
            this.listBoxMain = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(193, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome to the Virtual Library";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "Taken books";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(135, 291);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 41);
            this.button2.TabIndex = 3;
            this.button2.Text = "Book recommendations";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(293, 39);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(101, 25);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search books";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(275, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "enter book tittle, author...";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(268, 291);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 41);
            this.button4.TabIndex = 6;
            this.button4.Text = "Account settings";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // buttonGenre
            // 
            this.buttonGenre.Location = new System.Drawing.Point(438, 39);
            this.buttonGenre.Name = "buttonGenre";
            this.buttonGenre.Size = new System.Drawing.Size(94, 25);
            this.buttonGenre.TabIndex = 8;
            this.buttonGenre.Text = "Search genre";
            this.buttonGenre.UseVisualStyleBackColor = true;
            this.buttonGenre.Click += new System.EventHandler(this.buttonGenre_Click);
            // 
            // buttonManageReaderAcc
            // 
            this.buttonManageReaderAcc.Location = new System.Drawing.Point(548, 288);
            this.buttonManageReaderAcc.Name = "buttonManageReaderAcc";
            this.buttonManageReaderAcc.Size = new System.Drawing.Size(126, 41);
            this.buttonManageReaderAcc.TabIndex = 9;
            this.buttonManageReaderAcc.Text = "Manage reader accounts";
            this.buttonManageReaderAcc.UseVisualStyleBackColor = true;
            // 
            // buttonManageLibrary
            // 
            this.buttonManageLibrary.Location = new System.Drawing.Point(548, 241);
            this.buttonManageLibrary.Name = "buttonManageLibrary";
            this.buttonManageLibrary.Size = new System.Drawing.Size(126, 41);
            this.buttonManageLibrary.TabIndex = 10;
            this.buttonManageLibrary.Text = "Manage library";
            this.buttonManageLibrary.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(375, 291);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(52, 41);
            this.button8.TabIndex = 11;
            this.button8.Text = "Log out";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxGenre
            // 
            this.checkedListBoxGenre.FormattingEnabled = true;
            this.checkedListBoxGenre.Items.AddRange(new object[] {
            "Science fiction",
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
            "Poetry",
            "History",
            "Encyclopedias"});
            this.checkedListBoxGenre.Location = new System.Drawing.Point(539, 42);
            this.checkedListBoxGenre.Name = "checkedListBoxGenre";
            this.checkedListBoxGenre.Size = new System.Drawing.Size(136, 184);
            this.checkedListBoxGenre.TabIndex = 15;
            // 
            // listBoxMain
            // 
            this.listBoxMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.listBoxMain.FormattingEnabled = true;
            this.listBoxMain.ItemHeight = 20;
            this.listBoxMain.Location = new System.Drawing.Point(12, 81);
            this.listBoxMain.Name = "listBoxMain";
            this.listBoxMain.Size = new System.Drawing.Size(520, 204);
            this.listBoxMain.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Title --- Author --- Genres";
            // 
            // FormLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 341);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxMain);
            this.Controls.Add(this.checkedListBoxGenre);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.buttonManageLibrary);
            this.Controls.Add(this.buttonManageReaderAcc);
            this.Controls.Add(this.buttonGenre);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonGenre;
        private System.Windows.Forms.Button buttonManageReaderAcc;
        private System.Windows.Forms.Button buttonManageLibrary;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckedListBox checkedListBoxGenre;
        private System.Windows.Forms.ListBox listBoxMain;
        private System.Windows.Forms.Label label3;
    }
}