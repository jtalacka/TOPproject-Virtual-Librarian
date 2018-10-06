namespace VirtualLibrarian
{
    partial class FormLibSys
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
            this.listBoxMain = new System.Windows.Forms.ListBox();
            this.textBoxBook = new System.Windows.Forms.TextBox();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxReader = new System.Windows.Forms.TextBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonSearchReader = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonSearchBook = new System.Windows.Forms.Button();
            this.buttonTake = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxMain
            // 
            this.listBoxMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.listBoxMain.FormattingEnabled = true;
            this.listBoxMain.ItemHeight = 18;
            this.listBoxMain.Location = new System.Drawing.Point(12, 92);
            this.listBoxMain.Name = "listBoxMain";
            this.listBoxMain.Size = new System.Drawing.Size(730, 256);
            this.listBoxMain.TabIndex = 17;
            // 
            // textBoxBook
            // 
            this.textBoxBook.Location = new System.Drawing.Point(12, 54);
            this.textBoxBook.Name = "textBoxBook";
            this.textBoxBook.Size = new System.Drawing.Size(242, 20);
            this.textBoxBook.TabIndex = 20;
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(204, 18);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(50, 25);
            this.buttonDel.TabIndex = 19;
            this.buttonDel.Text = "Delete";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Visible = false;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(97, 18);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(45, 25);
            this.buttonAdd.TabIndex = 21;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Visible = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxReader
            // 
            this.textBoxReader.Location = new System.Drawing.Point(497, 54);
            this.textBoxReader.Name = "textBoxReader";
            this.textBoxReader.Size = new System.Drawing.Size(245, 20);
            this.textBoxReader.TabIndex = 24;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(148, 18);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(50, 25);
            this.buttonEdit.TabIndex = 26;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Visible = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonSearchReader
            // 
            this.buttonSearchReader.Location = new System.Drawing.Point(408, 53);
            this.buttonSearchReader.Name = "buttonSearchReader";
            this.buttonSearchReader.Size = new System.Drawing.Size(83, 20);
            this.buttonSearchReader.TabIndex = 27;
            this.buttonSearchReader.Text = "Search reader";
            this.buttonSearchReader.UseVisualStyleBackColor = true;
            this.buttonSearchReader.Click += new System.EventHandler(this.buttonSearchReader_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(580, 18);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(77, 25);
            this.buttonReturn.TabIndex = 28;
            this.buttonReturn.Text = "Return book";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Visible = false;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // buttonSearchBook
            // 
            this.buttonSearchBook.Location = new System.Drawing.Point(260, 54);
            this.buttonSearchBook.Name = "buttonSearchBook";
            this.buttonSearchBook.Size = new System.Drawing.Size(84, 20);
            this.buttonSearchBook.TabIndex = 29;
            this.buttonSearchBook.Text = "Search book";
            this.buttonSearchBook.UseVisualStyleBackColor = true;
            this.buttonSearchBook.Click += new System.EventHandler(this.buttonSearchBook_Click);
            // 
            // buttonTake
            // 
            this.buttonTake.Location = new System.Drawing.Point(497, 18);
            this.buttonTake.Name = "buttonTake";
            this.buttonTake.Size = new System.Drawing.Size(77, 25);
            this.buttonTake.TabIndex = 30;
            this.buttonTake.Text = "Give book";
            this.buttonTake.UseVisualStyleBackColor = true;
            this.buttonTake.Visible = false;
            this.buttonTake.Click += new System.EventHandler(this.buttonTake_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 26);
            this.label1.TabIndex = 31;
            this.label1.Text = "Manage library \r\n      catalog";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(663, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 26);
            this.label2.TabIndex = 32;
            this.label2.Text = "Manage reader\r\n     accounts";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "ISBN --- Title --- Author --- Genres";
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(696, 354);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(45, 23);
            this.buttonExit.TabIndex = 34;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(500, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Username --- Name --- Surname --- Email --- Adress";
            // 
            // FormLibSys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 383);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTake);
            this.Controls.Add(this.buttonSearchBook);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.buttonSearchReader);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.textBoxReader);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxBook);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.listBoxMain);
            this.Name = "FormLibSys";
            this.Text = "Library system";
//            this.Load += new System.EventHandler(this.FormLibSys_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMain;
        private System.Windows.Forms.TextBox textBoxBook;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxReader;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonSearchReader;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonSearchBook;
        private System.Windows.Forms.Button buttonTake;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label4;
    }
}