namespace ApplicationAPI
{
    partial class ProductDetailForm
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
            btnCancel = new Button();
            btnSave = new Button();
            groupBox1 = new GroupBox();
            ckbStatus = new CheckBox();
            label5 = new Label();
            txtPrice = new TextBox();
            txtDescription = new TextBox();
            txtName = new TextBox();
            cmbCategory = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnDelete = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(638, 424);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Close";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 424);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(220, 46);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save change";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ckbStatus);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(cmbCategory);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 406);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Product Infomation";
            // 
            // ckbStatus
            // 
            ckbStatus.AutoSize = true;
            ckbStatus.Location = new Point(192, 359);
            ckbStatus.Name = "ckbStatus";
            ckbStatus.Size = new Size(108, 36);
            ckbStatus.TabIndex = 10;
            ckbStatus.Text = "active";
            ckbStatus.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 360);
            label5.Name = "label5";
            label5.Size = new Size(78, 32);
            label5.TabIndex = 9;
            label5.Text = "Status";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(192, 314);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(551, 39);
            txtPrice.TabIndex = 8;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(192, 148);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(551, 160);
            txtDescription.TabIndex = 7;
            // 
            // txtName
            // 
            txtName.Location = new Point(192, 103);
            txtName.Name = "txtName";
            txtName.Size = new Size(551, 39);
            txtName.TabIndex = 6;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(192, 57);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(551, 40);
            cmbCategory.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 317);
            label4.Name = "label4";
            label4.Size = new Size(65, 32);
            label4.TabIndex = 3;
            label4.Text = "Price";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 151);
            label3.Name = "label3";
            label3.Size = new Size(135, 32);
            label3.TabIndex = 2;
            label3.Text = "Description";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 106);
            label2.Name = "label2";
            label2.Size = new Size(163, 32);
            label2.TabIndex = 1;
            label2.Text = "Product name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 60);
            label1.Name = "label1";
            label1.Size = new Size(110, 32);
            label1.TabIndex = 0;
            label1.Text = "Category";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Salmon;
            btnDelete.Location = new Point(238, 424);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 46);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // ProductDetailForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 491);
            Controls.Add(btnDelete);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProductDetailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProductDetailForm";
            Load += ProductDetailForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCancel;
        private Button btnSave;
        private GroupBox groupBox1;
        private TextBox txtPrice;
        private TextBox txtDescription;
        private TextBox txtName;
        private ComboBox cmbCategory;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckBox ckbStatus;
        private Label label5;
        private Button btnDelete;
    }
}