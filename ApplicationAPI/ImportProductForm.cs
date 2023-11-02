using ApplicationAPI.ClientAPI;
using CsvHelper;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
using NetAPI.Data.Entities;
using NetAPI.Models;
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
    public partial class ImportProductForm : Form
    {
        public ImportProductForm()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string csv_filePath = string.Empty;
            OpenFileDialog f_diaglog = new OpenFileDialog();
            f_diaglog.Title = "Open File Dialog";
            f_diaglog.InitialDirectory = @"c:\";
            f_diaglog.Filter = "CSV|*.csv";
            f_diaglog.FilterIndex = 2;
            f_diaglog.RestoreDirectory = true;
            if (f_diaglog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            try
            {
                csv_filePath = f_diaglog.FileName;
                txtPath.Text = Path.GetFullPath(csv_filePath);
                List<ProductRequest> products = GetData(Path.GetFullPath(csv_filePath));
                dataList.DataSource = products;
                MessageBox.Show("Import successful", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public List<ProductRequest> GetData(string filePath)
        {
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                List<ProductRequest> dataList = new List<ProductRequest>();
                // skip the header line
                parser?.ReadLine();

                if (parser is not null)
                {
                    while (!parser.EndOfData)
                    {
                        string[]? fields = parser.ReadFields();
                        if (fields != null)
                        {
                            ProductRequest data = new ProductRequest();
                            data.CategoryId = int.Parse(fields[0]);
                            data.Name = fields[1];
                            data.Description = fields[2];
                            data.Price = decimal.Parse(fields[3]);
                            data.Status = true;
                            dataList.Add(data);
                        }
                    }
                }
                return dataList;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            List<ProductRequest> products = GetData(Path.GetFullPath(txtPath.Text));

            try
            {
                // Khởi tạo đối tượng ProductClientAPI
                ProductClientAPI productClient = new ProductClientAPI();

                // Gọi phương thức GetAccount với yêu cầu đăng nhập
                List<Product> list = await productClient.ImportList(products);
                MessageBox.Show($"Successfully saved {list.Count().ToString()} record", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();
            }
            catch (Exception ex)
            {
                // Xử lý khi có lỗi
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ImportProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}
