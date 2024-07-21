using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using Microsoft.Reporting.WinForms;

namespace SaleInventory
{
    public partial class frmSale : Form
    {
        public frmSale()
        {
            InitializeComponent();
        }

        decimal Total = 0;
        Boolean b = false;
        SqlCommand com;
        int CusID;

        private void frmSale_Load(object sender, EventArgs e)
        {
            myOper.myConnection();
            myOper.OnOff(this, false);
            txtCusID.Text = "Auto Number";
            txtSaleID.Text = "Auto Number";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "New")
            {
                myOper.OnOff(this, true);
                myOper.ClearData(this);
                btnNew.Text = "Cancel";
                btnNew.Image = SaleInventory.Properties.Resources.icons8_cancel_48;
                dtpSale.Focus();
                SendKeys.Send("%{DOWN}");
                myOper.FillCbo(cboCus, "cusID", "cusName", "tbCustomer");
                myOper.FillCbo(cboCate, "catID", "category", "tbCategory");
                myOper.FillCbo(cboPro, "proID", "proName", "tbProduct");
                lswSale.Clear();
                lswSale.View = View.Details;
                lswSale.Columns.Add("Product ID", 200);
                lswSale.Columns.Add("Product Name", 350);
                lswSale.Columns.Add("Quantity", 200);
                lswSale.Columns.Add("Unit Price", 200);
                lswSale.Columns.Add("Amount", 220);
                Total = 0;
            }
            else
            {
                DialogResult re = DialogResult.Yes;
                MessageBox.Show("DO you want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (re == DialogResult.Yes)
                {
                    txtPrice.Clear();
                    txtCusID.Clear();
                    txtCusID.Text = "Auto Number";
                    txtCusCon.Clear();
                    myOper.ClearData(this);
                    myOper.OnOff(this, false);
                    btnNew.Text = "New";
                    btnNew.Image = SaleInventory.Properties.Resources.icons8_plus_48;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult re;
            re = MessageBox.Show("Do you want to close?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.Yes)
            {
                this.Hide();

                frmMain ma = new frmMain();
                ma.ShowDialog();

                this.Close();
            }
        }

        private void dtpSale_ValueChanged(object sender, EventArgs e)
        {
            dtpSale.CustomFormat = "dd-MM-yyyy";
            cboCus.DroppedDown = true;
        }

        private void btnNewSup_Click(object sender, EventArgs e)
        {
            
            if(btnNewSup.Text=="New Customer")
            {
                b = true;
                txtCusID.Text = "Auto Number";
                cboCus.Text = null;
                cboCus.Focus();
                txtCusCon.Enabled = true;
                btnNewSup.Text = "Old Customer";
                btnNewSup.Image = SaleInventory.Properties.Resources.icons8_male_user_48;
            }
            else
            {
                b = false;
                btnNewSup.Text="New Customer";
            }
        }
        private void txtProID_TextChanged(object sender, EventArgs e)
        {
            com = new SqlCommand("SELECT catID, sup FROM tbProduct WHERE proID='" + txtProID.Text + "'", myOper.con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cboCate.SelectedValue = int.Parse(dr[0].ToString());
                    cboPro.SelectedValue = txtProID.Text;
                    txtPrice.Text = dr[1].ToString();
                    cboPro.Enabled = false;
                    txtQty.Focus();
                }
            }
            else
            {
                cboCate.Text = null;
                cboPro.Text = null;

            }
            dr.Dispose();
            com.Dispose();
        }

        private void cboCus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CusID = int.Parse(cboCus.SelectedValue.ToString());
            com = new SqlCommand("SELECT cusID, cusContact FROM tbCustomer WHERE cusID=" + CusID, myOper.con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                txtCusID.Text = dr[0].ToString();
                txtCusCon.Text = dr[1].ToString();
                txtQty.Text = "1";
                txtProID.Focus();
            }
            com.Dispose();
            dr.Dispose();
        }

        private void cboPro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtProID.Text = cboPro.SelectedValue.ToString();
            txtProID.Enabled = false;
            txtQty.Text = "1";
            txtQty.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal amount, s, TotalKh;
        
            ListViewItem item;
            string[] arr = new string[7];
            arr[0] = txtProID.Text;
            arr[1] = cboPro.Text;
            arr[2] = txtQty.Text;
            s = decimal.Parse(txtPrice.Text);
            arr[3] = string.Format("{0:c}", decimal.Parse(txtPrice.Text));
            amount = decimal.Parse(txtQty.Text) * decimal.Parse(txtPrice.Text);
            arr[4] = string.Format("{0:c}", amount);
            arr[5] = cboCate.Text;
            arr[6] = cboCate.SelectedValue.ToString();
            item = new ListViewItem(arr);
            lswSale.Items.Add(item);
            Total = Total + amount;
            txtTotal.Text = string.Format("{0:c}", Total);
            txtPrice.Text = string.Format("{0:c}", decimal.Parse(txtPrice.Text));

            TotalKh = Total * 4100;
            txtTotalKh.Text = string.Format("{0:c}", TotalKh);

            //Clear Data
            txtPrice.Clear();
            txtProID.Clear();
            cboPro.Text = null;
            txtQty.Clear();
            cboCate.Text = null;
            myOper.OnOff(this,true);
            txtProID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtMaster = new DataTable();
            dtMaster.Columns.Add("saleDate", typeof(DateTime));
            dtMaster.Columns.Add("empID", typeof(string));
            dtMaster.Columns.Add("empName", typeof(string));
            dtMaster.Columns.Add("cusID", typeof(int));
            dtMaster.Columns.Add("cusName", typeof(string));
            dtMaster.Columns.Add("cusCon", typeof(string));
            dtMaster.Columns.Add("sTotal", typeof(float));
            DateTime sd = dtpSale.Value;
            if (b == true)
                CusID = 0;
            string cn = cboCus.Text;
            string cc = txtCusCon.Text;
            dtMaster.Rows.Add(sd, myOper.EmpID, myOper.EmpName, CusID, cn, cc, Total);

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("proID", typeof(string));
            dtDetail.Columns.Add("proName", typeof(string));
            dtDetail.Columns.Add("qty", typeof(int));
            dtDetail.Columns.Add("up", typeof(float));

            DataTable dtInvoice = new DataTable();
            dtInvoice.Columns.Add("proID", typeof(string));
            dtInvoice.Columns.Add("proName", typeof(string));
            dtInvoice.Columns.Add("qty", typeof(int));
            dtInvoice.Columns.Add("price", typeof(float));
            dtInvoice.Columns.Add("amount", typeof(float));
            foreach (ListViewItem item in lswSale.Items)
            {
                string pid = item.Text;
                string pn = item.SubItems[1].Text;
                int q = int.Parse(item.SubItems[2].Text);
                var un = decimal.Parse(item.SubItems[3].Text, NumberStyles.Currency);
                dtDetail.Rows.Add(pid, pn, q, un);
                dtInvoice.Rows.Add(pid, pn, q, un,q*un);
            }
            com = new SqlCommand("InsertSale", myOper.con);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter();
            par1.ParameterName = "@SM";
            par1.SqlDbType = SqlDbType.Structured;
            par1.Value = dtMaster;
            com.Parameters.Add(par1);
            SqlParameter par2 = new SqlParameter();
            par2.ParameterName = "@SD";
            par2.SqlDbType = SqlDbType.Structured;
            par2.Value = dtDetail;
            com.Parameters.Add(par2);

            com.Parameters.Add("@sid", SqlDbType.Int).Direction = ParameterDirection.Output; //@sid is out put
            com.Parameters.Add("@cid", SqlDbType.Int).Direction = ParameterDirection.Output; //@cid is out put
            com.ExecuteNonQuery();
            //Master
            var saleID = int.Parse(com.Parameters["@sid"].Value.ToString());

            if (b == true)
                CusID = int.Parse(com.Parameters["@cid"].Value.ToString());
            else
                CusID = int.Parse(txtCusID.Text);

            frmRptInvoice RptInvoice = new frmRptInvoice(); //1
            RptInvoice.Vinv.ProcessingMode = ProcessingMode.Local; //2
            LocalReport lRpt = RptInvoice.Vinv.LocalReport; //3
            lRpt.DisplayName = "rptInvoice.rdlc"; //4
            lRpt.DataSources.Clear(); //5

            ReportDataSource rds = new ReportDataSource("dsInvoice", dtInvoice); //6
            lRpt.DataSources.Add(rds); //7

            ReportParameter p1 = new ReportParameter("InvNo",string.Format("{0:000000}", saleID.ToString())); //8
            lRpt.SetParameters(p1);

            ReportParameter p2 = new ReportParameter("InvDate", dtpSale.Value.ToString("dd-MM-yyyy HH:MM:ss")); //9
            lRpt.SetParameters(p2);

            ReportParameter p3 = new ReportParameter("EmpID", myOper.EmpID.ToString()); //10
            lRpt.SetParameters(p3);

            ReportParameter p4 = new ReportParameter("CusID", CusID.ToString()); //11
            lRpt.SetParameters(p4);

            ReportParameter p5 = new ReportParameter("CusName", cboCus.Text); //12
            lRpt.SetParameters(p5);

            ReportParameter p6 = new ReportParameter("Total", txtTotal.Text); //13
            lRpt.SetParameters(p6);

            RptInvoice.Show();
            RptInvoice.Vinv.RefreshReport();

            myOper.ClearData(this);
            lswSale.Items.Clear();
            btnNew.Text = "New";
            btnNew.Image = SaleInventory.Properties.Resources.icons8_plus_48;
        }

        private void txtRateInKh_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
