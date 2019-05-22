using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test6_ENTITY_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal productDal = new ProductDal();

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = productDal.GetAll();
        }

        private void SearchProducts( string key)
        {
            //dgwProducts.DataSource = productDal.GetAll().Where(p => p.Name.Contains(key)).ToList();
            dgwProducts.DataSource = productDal.GetByName(key).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            productDal.Add(new Product
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            });
            LoadProducts();
            MessageBox.Show("added");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            productDal.Update(new Product {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            
        });
            LoadProducts();
            MessageBox.Show("Updated");
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxName.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPrice.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmount.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            productDal.Delete(new Product
            {
                Id=Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("deleted !");
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(tbxSearch.Text);

        }
    }
}
// QEYD : entity-de  sql connectionu appconfigde yaziriq