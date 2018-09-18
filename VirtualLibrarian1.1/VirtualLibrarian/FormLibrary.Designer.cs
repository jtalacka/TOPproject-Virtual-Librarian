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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonManageReaderAcc = new System.Windows.Forms.Button();
            this.buttonManageLibrary = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
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
            this.buttonSearch.Location = new System.Drawing.Point(249, 39);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(101, 25);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search books";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 20);
            this.textBox1.TabIndex = 5;
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 68);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(520, 214);
            this.textBox2.TabIndex = 7;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(438, 39);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 25);
            this.button5.TabIndex = 8;
            this.button5.Text = "Search genre";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // buttonManageReaderAcc
            // 
            this.buttonManageReaderAcc.Location = new System.Drawing.Point(538, 241);
            this.buttonManageReaderAcc.Name = "buttonManageReaderAcc";
            this.buttonManageReaderAcc.Size = new System.Drawing.Size(126, 41);
            this.buttonManageReaderAcc.TabIndex = 9;
            this.buttonManageReaderAcc.Text = "Manage reader accounts";
            this.buttonManageReaderAcc.UseVisualStyleBackColor = true;
            // 
            // buttonManageLibrary
            // 
            this.buttonManageLibrary.Location = new System.Drawing.Point(538, 194);
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
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(538, 43);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(136, 19);
            this.checkedListBox1.TabIndex = 15;
            // 
            // FormLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 341);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.buttonManageLibrary);
            this.Controls.Add(this.buttonManageReaderAcc);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox2);
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonManageReaderAcc;
        private System.Windows.Forms.Button buttonManageLibrary;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}