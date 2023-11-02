namespace ApplicationAPI
{
    partial class HomeForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            dataProduct = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categoryNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            priceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            productViewModelBindingSource = new BindingSource(components);
            toolStrip1 = new ToolStrip();
            btnAdd = new ToolStripButton();
            toolStripButton1 = new ToolStripSeparator();
            btnImport = new ToolStripButton();
            btnNext = new ToolStripButton();
            labelPage = new ToolStripLabel();
            btnPrevious = new ToolStripButton();
            toolStripButton7 = new ToolStripSeparator();
            txtNumber = new ToolStripTextBox();
            toolStripButton6 = new ToolStripLabel();
            btnReload = new ToolStripButton();
            toolStripButton2 = new ToolStripSeparator();
            txtKeyWord = new ToolStripTextBox();
            btnSearch = new ToolStripButton();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataProduct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productViewModelBindingSource).BeginInit();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataProduct
            // 
            dataProduct.AllowUserToAddRows = false;
            dataProduct.AllowUserToDeleteRows = false;
            dataProduct.AutoGenerateColumns = false;
            dataProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataProduct.BackgroundColor = SystemColors.Control;
            dataProduct.ColumnHeadersHeight = 46;
            dataProduct.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, categoryNameDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, priceDataGridViewTextBoxColumn, statusDataGridViewCheckBoxColumn });
            dataProduct.DataSource = productViewModelBindingSource;
            dataProduct.Dock = DockStyle.Fill;
            dataProduct.Location = new Point(0, 0);
            dataProduct.Name = "dataProduct";
            dataProduct.ReadOnly = true;
            dataProduct.RowHeadersWidth = 82;
            dataProduct.RowTemplate.Height = 41;
            dataProduct.Size = new Size(1599, 774);
            dataProduct.TabIndex = 0;
            dataProduct.CellContentClick += dataProduct_CellContentClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 10;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryNameDataGridViewTextBoxColumn
            // 
            categoryNameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            categoryNameDataGridViewTextBoxColumn.DataPropertyName = "CategoryName";
            categoryNameDataGridViewTextBoxColumn.HeaderText = "CategoryName";
            categoryNameDataGridViewTextBoxColumn.MinimumWidth = 10;
            categoryNameDataGridViewTextBoxColumn.Name = "categoryNameDataGridViewTextBoxColumn";
            categoryNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 10;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            descriptionDataGridViewTextBoxColumn.MinimumWidth = 10;
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            priceDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            priceDataGridViewTextBoxColumn.HeaderText = "Price";
            priceDataGridViewTextBoxColumn.MinimumWidth = 10;
            priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewCheckBoxColumn
            // 
            statusDataGridViewCheckBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            statusDataGridViewCheckBoxColumn.DataPropertyName = "Status";
            statusDataGridViewCheckBoxColumn.HeaderText = "Status";
            statusDataGridViewCheckBoxColumn.MinimumWidth = 10;
            statusDataGridViewCheckBoxColumn.Name = "statusDataGridViewCheckBoxColumn";
            statusDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // productViewModelBindingSource
            // 
            productViewModelBindingSource.DataSource = typeof(NetAPI.Models.ProductViewModel);
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnAdd, toolStripButton1, btnImport, btnNext, labelPage, btnPrevious, toolStripButton7, txtNumber, toolStripButton6, btnReload, toolStripButton2, txtKeyWord, btnSearch });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1599, 42);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageTransparentColor = Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(93, 36);
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(6, 42);
            // 
            // btnImport
            // 
            btnImport.Image = (Image)resources.GetObject("btnImport.Image");
            btnImport.ImageTransparentColor = Color.Magenta;
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(121, 36);
            btnImport.Text = "Import";
            btnImport.Click += btnImport_Click;
            // 
            // btnNext
            // 
            btnNext.AccessibleName = "btnNext";
            btnNext.Alignment = ToolStripItemAlignment.Right;
            btnNext.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.ImageTransparentColor = Color.Magenta;
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(124, 36);
            btnNext.Text = "next page";
            btnNext.Click += btnNext_Click;
            // 
            // labelPage
            // 
            labelPage.Alignment = ToolStripItemAlignment.Right;
            labelPage.DisplayStyle = ToolStripItemDisplayStyle.Text;
            labelPage.Image = (Image)resources.GetObject("labelPage.Image");
            labelPage.ImageTransparentColor = Color.Magenta;
            labelPage.Name = "labelPage";
            labelPage.Size = new Size(102, 36);
            labelPage.Text = "page1/2";
            // 
            // btnPrevious
            // 
            btnPrevious.AccessibleName = "btnPrevious";
            btnPrevious.Alignment = ToolStripItemAlignment.Right;
            btnPrevious.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnPrevious.Image = (Image)resources.GetObject("btnPrevious.Image");
            btnPrevious.ImageTransparentColor = Color.Magenta;
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(169, 36);
            btnPrevious.Text = "previous page";
            btnPrevious.Click += btnPrevious_Click;
            // 
            // toolStripButton7
            // 
            toolStripButton7.Alignment = ToolStripItemAlignment.Right;
            toolStripButton7.Name = "toolStripButton7";
            toolStripButton7.Size = new Size(6, 42);
            // 
            // txtNumber
            // 
            txtNumber.Alignment = ToolStripItemAlignment.Right;
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(46, 42);
            txtNumber.Text = "10";
            // 
            // toolStripButton6
            // 
            toolStripButton6.Alignment = ToolStripItemAlignment.Right;
            toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton6.Image = (Image)resources.GetObject("toolStripButton6.Image");
            toolStripButton6.ImageTransparentColor = Color.Magenta;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Size = new Size(173, 36);
            toolStripButton6.Text = "record number";
            // 
            // btnReload
            // 
            btnReload.Alignment = ToolStripItemAlignment.Right;
            btnReload.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnReload.Image = (Image)resources.GetObject("btnReload.Image");
            btnReload.ImageTransparentColor = Color.Magenta;
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(90, 36);
            btnReload.Text = "Reload";
            btnReload.Click += btnReload_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(6, 42);
            // 
            // txtKeyWord
            // 
            txtKeyWord.Name = "txtKeyWord";
            txtKeyWord.Size = new Size(300, 42);
            // 
            // btnSearch
            // 
            btnSearch.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSearch.ImageTransparentColor = Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(89, 36);
            btnSearch.Text = "Search";
            // 
            // panel1
            // 
            panel1.Controls.Add(dataProduct);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(1599, 774);
            panel1.TabIndex = 3;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1599, 816);
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomeForm";
            Load += HomeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataProduct).EndInit();
            ((System.ComponentModel.ISupportInitialize)productViewModelBindingSource).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataProduct;
        private BindingSource productViewModelBindingSource;
        private ToolStrip toolStrip1;
        private ToolStripButton btnImport;
        private ToolStripButton btnReload;
        private Panel panel1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoryNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private ToolStripButton btnNext;
        private ToolStripLabel labelPage;
        private ToolStripButton btnPrevious;
        private ToolStripTextBox txtNumber;
        private ToolStripLabel toolStripButton6;
        private ToolStripSeparator toolStripButton7;
        private ToolStripSeparator toolStripButton2;
        private ToolStripTextBox txtKeyWord;
        private ToolStripButton btnSearch;
        private ToolStripButton btnAdd;
        private ToolStripSeparator toolStripButton1;
    }
}