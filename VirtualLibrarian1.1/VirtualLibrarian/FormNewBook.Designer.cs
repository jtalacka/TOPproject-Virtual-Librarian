namespace VirtualLibrarian
{
    partial class FormNewBook
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.checkedListBoxGenre = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxISBN = new System.Windows.Forms.TextBox();
            this.textBoxQ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.isbn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Book title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Author: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.Location = new System.Drawing.Point(14, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 20;
            this.label3.Text = "Genres:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(92, 34);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(213, 20);
            this.textBoxTitle.TabIndex = 2;
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(92, 61);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(213, 20);
            this.textBoxAuthor.TabIndex = 3;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(265, 209);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(40, 27);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
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
            this.checkedListBoxGenre.Location = new System.Drawing.Point(94, 122);
            this.checkedListBoxGenre.Name = "checkedListBoxGenre";
            this.checkedListBoxGenre.Size = new System.Drawing.Size(211, 79);
            this.checkedListBoxGenre.Sorted = true;
            this.checkedListBoxGenre.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "ISBN:";
            // 
            // textBoxISBN
            // 
            this.textBoxISBN.Location = new System.Drawing.Point(92, 7);
            this.textBoxISBN.Name = "textBoxISBN";
            this.textBoxISBN.Size = new System.Drawing.Size(213, 20);
            this.textBoxISBN.TabIndex = 1;
            // 
            // textBoxQ
            // 
            this.textBoxQ.Location = new System.Drawing.Point(92, 90);
            this.textBoxQ.Name = "textBoxQ";
            this.textBoxQ.Size = new System.Drawing.Size(49, 20);
            this.textBoxQ.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label5.Location = new System.Drawing.Point(9, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 18);
            this.label5.TabIndex = 24;
            this.label5.Text = "Quantity:";
            // 
            // isbn
            // 
            this.isbn.Location = new System.Drawing.Point(12, 213);
            this.isbn.Name = "isbn";
            this.isbn.Size = new System.Drawing.Size(93, 23);
            this.isbn.TabIndex = 25;
            this.isbn.Text = "search by isbn";
            this.isbn.UseVisualStyleBackColor = true;
            this.isbn.Click += new System.EventHandler(this.isbn_Click);
            // 
            // FormNewBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 247);
            this.Controls.Add(this.isbn);
            this.Controls.Add(this.textBoxQ);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxISBN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkedListBoxGenre);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxAuthor);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormNewBook";
            this.Text = "New Book";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.CheckedListBox checkedListBoxGenre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxISBN;
        private System.Windows.Forms.TextBox textBoxQ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button isbn;
    }
}