using ApplicationAPI.ClientAPI;
using NetAPI.Data.Entities;
using NetAPI.Models;
using NetAPI.Models.Enum;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationAPI
{
    public partial class HomeForm : Form
    {

        int pageIndex = 1;
        int pageSize = 10;
        int totalRecords;
        int pageCount;
        AccountViewModel _account;

        public HomeForm(AccountViewModel account)
        {
            _account = account;
            InitializeComponent();
        }

        async Task LoadData()
        {
            if (int.Parse(txtNumber.Text) < 1 || int.Parse(txtNumber.Text) > 20)
                MessageBox.Show("Enter a record number from 1-20", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            pageSize = int.Parse(txtNumber.Text);
            try
            {
                ProductClientAPI productClient = new ProductClientAPI();

                Pagination<ProductViewModel> pagination = await productClient.GetListPaging(txtKeyWord.Text, pageIndex, pageSize);
                // Tạo một BindingSource
                BindingSource bindingSource = new BindingSource();

                // Gán danh sách vào BindingSource
                bindingSource.DataSource = pagination.Items;

                pageCount = pagination.PageCount;
                pageIndex = pagination.PageIndex;

                // Thiết lập DataSource của DataGridView thành BindingSource
                dataProduct.DataSource = bindingSource;

                labelPage.Text = $"page{pageIndex}/{pageCount}";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Check();
        }

        private async void HomeForm_Load(object sender, EventArgs e)
        {
            CheckRole();
            await LoadData();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportProductForm frm = new ImportProductForm();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private async void btnReload_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void dataProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataProduct.Columns["DetailColumn"].Index && e.RowIndex >= 0)
            {
                // Lấy giá trị id từ hàng được nhấp vào
                int id = (int)dataProduct.Rows[e.RowIndex].Cells[1].Value;
                ProductDetailForm frm = new ProductDetailForm(id);
                frm.ShowDialog();
                await LoadData();
            }
        }

        void CheckRole()
        {
            if(_account.Role == Role.USER)
            {
                btnAdd.Enabled = false;
                btnImport.Enabled = false;
            }
            else
            {
                DataGridViewButtonColumn detailColumn = new DataGridViewButtonColumn();
                detailColumn.Name = "DetailColumn";
                detailColumn.HeaderText = "Detail";

                // Thiết lập văn bản cho nút "Detail"
                detailColumn.Text = "Detail";

                // Thiết lập tên cột hiển thị trong danh sách thuộc tính
                detailColumn.DataPropertyName = "DetailColumn";

                // Thiết lập kiểu hiển thị của cột
                detailColumn.UseColumnTextForButtonValue = true;

                // Thêm cột vào DataGridView
                dataProduct.Columns.Insert(0, detailColumn);
            }
        }

        void Check()
        {
            if (pageIndex <= 1)
            {
                btnPrevious.Enabled = false;
            }
            else btnPrevious.Enabled = true;


            if (pageIndex >= pageCount)
            {
                btnNext.Enabled = false;
            }
            else btnNext.Enabled = true;
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            pageIndex++;
            await LoadData();
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            pageIndex--;
            await LoadData();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            AddProductForm frm = new AddProductForm();
            frm.ShowDialog();
            await LoadData();
        }
    }
}
