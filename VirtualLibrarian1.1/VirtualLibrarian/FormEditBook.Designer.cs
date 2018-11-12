namespace VirtualLibrarian
{
    partial class FormEditBook
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
            this.buttonEdit = new System.Windows.Forms.Button();
            this.textBoxISBN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkedListBoxGenre = new System.Windows.Forms.CheckedListBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGenres = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxQ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(105, 224);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(213, 33);
            this.buttonEdit.TabIndex = 10;
            this.buttonEdit.Text = "Save changes";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // textBoxISBN
            // 
            this.textBoxISBN.Location = new System.Drawing.Point(105, 25);
            this.textBoxISBN.Name = "textBoxISBN";
            this.textBoxISBN.Size = new System.Drawing.Size(213, 20);
            this.textBoxISBN.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label4.Location = new System.Drawing.Point(18, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 50;
            this.label4.Text = "ISBN:";
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
            this.checkedListBoxGenre.Location = new System.Drawing.Point(438, 38);
            this.checkedListBoxGenre.Name = "checkedListBoxGenre";
            this.checkedListBoxGenre.Size = new System.Drawing.Size(181, 94);
            this.checkedListBoxGenre.TabIndex = 6;
            this.checkedListBoxGenre.Click += new System.EventHandler(this.checkedListBoxGenre_Click);
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(105, 106);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(213, 20);
            this.textBoxAuthor.TabIndex = 3;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(105, 65);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(213, 20);
            this.textBoxTitle.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.Location = new System.Drawing.Point(18, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 55;
            this.label3.Text = "Genres:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(18, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 18);
            this.label2.TabIndex = 52;
            this.label2.Text = "Author: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(18, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 51;
            this.label1.Text = "Book title:";
            // 
            // textBoxGenres
            // 
            this.textBoxGenres.Cursor = System.Windows.Forms.Cursors.No;
            this.textBoxGenres.Location = new System.Drawing.Point(105, 185);
            this.textBoxGenres.Name = "textBoxGenres";
            this.textBoxGenres.ReadOnly = true;
            this.textBoxGenres.Size = new System.Drawing.Size(213, 20);
            this.textBoxGenres.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label5.Location = new System.Drawing.Point(348, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 36);
            this.label5.TabIndex = 56;
            this.label5.Text = "Select new \r\ngenres:";
            // 
            // textBoxQ
            // 
            this.textBoxQ.Location = new System.Drawing.Point(105, 146);
            this.textBoxQ.Multiline = true;
            this.textBoxQ.Name = "textBoxQ";
            this.textBoxQ.Size = new System.Drawing.Size(58, 20);
            this.textBoxQ.TabIndex = 4;
            this.textBoxQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label6.Location = new System.Drawing.Point(18, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 18);
            this.label6.TabIndex = 58;
            this.label6.Text = "Quantitty:";
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(438, 146);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(276, 69);
            this.textBoxText.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label7.Location = new System.Drawing.Point(345, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 18);
            this.label7.TabIndex = 60;
            this.label7.Text = "Description:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(438, 231);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(194, 20);
            this.textBox2.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label8.Location = new System.Drawing.Point(348, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 18);
            this.label8.TabIndex = 62;
            this.label8.Text = "Picture:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label9.Location = new System.Drawing.Point(435, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 18);
            this.label9.TabIndex = 63;
            this.label9.Text = "Optional fields to edit";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(638, 230);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(76, 20);
            this.buttonBrowse.TabIndex = 9;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // FormEditBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 273);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxQ);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxGenres);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.textBoxISBN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkedListBoxGenre);
            this.Controls.Add(this.textBoxAuthor);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormEditBook";
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.FormEditBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.TextBox textBoxISBN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox checkedListBoxGenre;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxGenres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxQ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonBrowse;
    }
}