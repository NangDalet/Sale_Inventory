using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleInventory
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = myOper.EmpName;
            lblDate.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            if (myOper.EmpPos == "Admin" && myOper.EmpID != 0)
                return;
            else if (myOper.EmpPos == "Seller")
            {
                btnImp.Enabled = false;
                btnImpRe.Enabled = false;
                btnEmp.Enabled = false;
                btnSup.Enabled = false;
                btnPro.Enabled = false;
                btnCate.Enabled = false;
            }else if (myOper.EmpPos == "Stockman")
            {
                btnEmp.Enabled = false;
                btnCus.Enabled = false;
                btnSale.Enabled = false;
                btnSaleRe.Enabled = false;
            }
            else
            {
                btnImp.Enabled = false;
                btnImpRe.Enabled = false;
                btnSup.Enabled = false;
                btnPro.Enabled = false;
                btnCus.Enabled = false;
                btnSale.Enabled = false;
                btnSaleRe.Enabled = false;
                btnCate.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void btnAccSetting_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmCreateAccount acc = new frmCreateAccount();
            acc.ShowDialog();

            this.Close();
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmEmployee emp = new frmEmployee();
            emp.ShowDialog();

            this.Close();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmSale sale = new frmSale();
            sale.ShowDialog();

            this.Close();
        }
        private void btnImp_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmImport imp = new frmImport();
            imp.ShowDialog();

            this.Close();
        }

        private void btnImpRe_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmImportReport imr = new frmImportReport();
            imr.ShowDialog();

            this.Close();
        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmSupplier sup = new frmSupplier();
            sup.ShowDialog();

            this.Close();
        }

        private void btnCus_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmCustomer cus = new frmCustomer();
            cus.ShowDialog();

            this.Close();
        }

        private void btnCate_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmCategory cate = new frmCategory();
            cate.ShowDialog();

            this.Close();
        }

        private void btnPro_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmProduct pro = new frmProduct();
            pro.ShowDialog();

            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmLogin log = new frmLogin();
            log.ShowDialog();

            this.Close();
        }

        private void btnSaleRe_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmSaleReport saleRe = new frmSaleReport();
            saleRe.ShowDialog();

            this.Close();
        }
    }
}
