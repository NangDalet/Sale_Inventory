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
    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
        }

        //SqlDataAdapter da;
        //DataTable dt;
        SqlCommand com;
        int supID;
        decimal Total = 0;
        Boolean b=false;

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "New")
            {
                myOper.OnOff(this, true);
                myOper.ClearData(this);
                btnNew.Text = "Cancel";
                btnNew.Image = SaleInventory.Properties.Resources.icons8_cancel_48;
                dtpImp.Focus();
                SendKeys.Send("%{DOWN}");
                myOper.FillCbo(cboSup, "supID", "supName", "tbSupplier");
                myOper.FillCbo(cboCate, "catID", "category", "tbCategory");
                myOper.FillCbo(cboPro, "proID", "proName", "tbProduct");
                lswImport.Clear();
                lswImport.View = View.Details;
                lswImport.Columns.Add("Product ID", 110);
                lswImport.Columns.Add("Product Name", 255);
                lswImport.Columns.Add("Quantity", 200);
                lswImport.Columns.Add("Unit Price", 200);
                lswImport.Columns.Add("Amount", 200);
                lswImport.Columns.Add("Category", 200);
                lswImport.Columns.Add("Category ID", 0);

            }
            else
            {
                DialogResult re = DialogResult.Yes;
                re = MessageBox.Show("Do you want to cacel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (re == DialogResult.Yes)
                {
                    myOper.ClearData(this);
                    myOper.OnOff(this, false);
                    txtSupID.Clear();
                    txtsupCon.Clear();
                    lswImport.Items.Clear();
                    Total = 0;
                    btnNew.Text = "New";
                    btnNew.Image = SaleInventory.Properties.Resources.icons8_plus_48;
                }
            }
        }
        private void frmImport_Load(object sender, EventArgs e)
        {
            myOper.myConnection();
            myOper.OnOff(this, false);
            txtImpID.Text = "Auto Number";
            txtSupID.Text = "Auto Number";
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
        private void dtpImp_ValueChanged(object sender, EventArgs e)
        {
            dtpImp.CustomFormat = "dd-MM-yyyy";
            cboSup.DroppedDown = true;
        }

        private void cboSup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            supID = int.Parse(cboSup.SelectedValue.ToString());
            com = new SqlCommand("SELECT supID, supContact FROM tbSupplier WHERE supID=" + supID, myOper.con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                txtSupID.Text = dr[0].ToString();
                txtsupCon.Text = dr[1].ToString();
                txtProID.Focus();
            }
            com.Dispose();
            dr.Dispose();
        }

        private void cboPro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtProID.Text = cboPro.SelectedValue.ToString();
            com = new SqlCommand("SELECT catID FROM tbProduct WHERE proID='" + txtProID.Text + "'", myOper.con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                cboCate.SelectedValue = int.Parse(dr[0].ToString());
            }
            dr.Dispose();
            com.Dispose();
        }

        private void txtProID_TextChanged(object sender, EventArgs e)
        {
            com = new SqlCommand("SELECT catID FROM tbProduct WHERE proID='" + txtProID.Text + "'", myOper.con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cboCate.SelectedValue = int.Parse(dr[0].ToString());
                    cboPro.SelectedValue = txtProID.Text;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal amount, s;
            ListViewItem item;
            string[] arr = new string[7];
            arr[0] = txtProID.Text;
            arr[1] = cboPro.Text;
            arr[2] = txtQty.Text;
            s = decimal.Parse(txtPrice.Text);
            arr[3] = string.Format("{0:c}", txtPrice.Text);
            amount = decimal.Parse(txtQty.Text) * decimal.Parse(txtPrice.Text);
            arr[4] = string.Format("{0:c}", amount);
            arr[5] = cboCate.Text;
            arr[6] = cboCate.SelectedValue.ToString();
            item = new ListViewItem(arr);
            lswImport.Items.Add(item);
            Total = Total + amount;
            txtTotal.Text = string.Format("{0:c}", Total);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult re;
            foreach(ListViewItem item in lswImport.Items)
            {
                if (item.Selected)
                {
                    re = MessageBox.Show("Do you want to remove this item?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (re == DialogResult.Yes)
                    {
                        ListViewItem it = lswImport.SelectedItems[0];
                        lswImport.Items.Remove(item);
                        var a = Decimal.Parse(it.SubItems[4].Text,NumberStyles.Currency);
                        Total = Total - a;
                        txtTotal.Text = string.Format("{0:c}", Total);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtMaster = new DataTable();
            dtMaster.Columns.Add("ImpDate", typeof(DateTime));
            dtMaster.Columns.Add("supID", typeof(int));
            dtMaster.Columns.Add("supName", typeof(string));
            dtMaster.Columns.Add("supCon", typeof(string));
            dtMaster.Columns.Add("empID", typeof(string));
            dtMaster.Columns.Add("empName", typeof(string));
            dtMaster.Columns.Add("Amount", typeof(float));

            DateTime impDate = dtpImp.Value;
            if (b == true)
                supID = 0;
          
            string sn = cboSup.Text; //get supplier name
            string sc = txtsupCon.Text; //get supplier contact

            dtMaster.Rows.Add(impDate, supID, sn, sc, myOper.EmpID, myOper.EmpName ,Total);

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("proID", typeof(string));
            dtDetail.Columns.Add("proName", typeof(string));
            dtDetail.Columns.Add("qty", typeof(int));
            dtDetail.Columns.Add("upis", typeof(float));
            dtDetail.Columns.Add("catID", typeof(int));

            DataTable dtImpInvoice = new DataTable();
            dtImpInvoice.Columns.Add("proID", typeof(string));
            dtImpInvoice.Columns.Add("proName", typeof(string));
            dtImpInvoice.Columns.Add("qty", typeof(int));
            dtImpInvoice.Columns.Add("price", typeof(float));
            dtImpInvoice.Columns.Add("amount", typeof(float));

            foreach (ListViewItem item in lswImport.Items)
            {
                string pid=item.Text; //get product id
                string pn = item.SubItems[1].Text; //get product name
                int q = int.Parse(item.SubItems[2].Text); //get quantity
                var up = decimal.Parse(item.SubItems[3].Text, NumberStyles.Currency); //get unit price
                int ci = int.Parse(item.SubItems[6].Text); //get category
                dtDetail.Rows.Add(pid, pn, q, up, ci);
                dtImpInvoice.Rows.Add(pid, pn, q, up, q*up);
            }
            com = new SqlCommand("InsertImport", myOper.con);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter par1 = new SqlParameter();
            par1.ParameterName = "@IM";
            par1.SqlDbType = SqlDbType.Structured;
            par1.Value = dtMaster;
            com.Parameters.Add(par1);

            SqlParameter par2 = new SqlParameter();
            par2.ParameterName = "@ID";
            par2.SqlDbType = SqlDbType.Structured;
            par2.Value = dtDetail;
            com.Parameters.Add(par2);
         
            com.Parameters.Add("@imid", SqlDbType.Int).Direction = ParameterDirection.Output; //@imid is out put
            com.Parameters.Add("@sid", SqlDbType.Int).Direction = ParameterDirection.Output; //@sid is out put 

            com.ExecuteNonQuery();

            //Master
            var impID = int.Parse(com.Parameters["@imid"].Value.ToString());

            if (b == true)
                supID = int.Parse(com.Parameters["@sid"].Value.ToString());
            else
                supID = int.Parse(txtSupID.Text);

            frmRptImpInvoice RptImpInvoice = new frmRptImpInvoice(); //1
            RptImpInvoice.VinvImp.ProcessingMode = ProcessingMode.Local; //2
            LocalReport lRpt = RptImpInvoice.VinvImp.LocalReport; //3
            lRpt.DisplayName = "rptImpInvoice.rdlc"; //4
            lRpt.DataSources.Clear(); //5
            ReportDataSource rds = new ReportDataSource("dsImpInvoice", dtImpInvoice); //6
            lRpt.DataSources.Add(rds); //7

            ReportParameter p1 = new ReportParameter("InvNo", impID.ToString()); //8
            lRpt.SetParameters(p1);

            ReportParameter p2 = new ReportParameter("InvDate", dtpImp.Value.ToString("dd-MM-yyyy HH:MM:ss")); //9
            lRpt.SetParameters(p2);

            ReportParameter p3 = new ReportParameter("EmpID", myOper.EmpID.ToString()); //10
            lRpt.SetParameters(p3);

            ReportParameter p4 = new ReportParameter("SupID", supID.ToString()); //11
            lRpt.SetParameters(p4);

            ReportParameter p5 = new ReportParameter("SupName",cboSup.Text); //12
            lRpt.SetParameters(p5);

            ReportParameter p6 = new ReportParameter("Total", txtTotal.Text); //13
            lRpt.SetParameters(p6);

            RptImpInvoice.Show();
            RptImpInvoice.VinvImp.RefreshReport();

            // MessageBox.Show(impID.ToString());
            myOper.ClearData(this);
            lswImport.Items.Clear();
            myOper.OnOff(this, false);
            txtSupID.Clear();
            txtsupCon.Clear();
            btnNew.Text = "New";
            btnNew.Image = SaleInventory.Properties.Resources.icons8_plus_48;
        }

        private void btnNewSup_Click(object sender, EventArgs e)
        {
            if(btnNewSup.Text=="New Supplier")
            {
                b = true;
                txtSupID.Text = "Auto Number";
                cboSup.Text = null;
                cboSup.Focus();
                btnNewSup.Text = "Old Supplier";
                txtsupCon.Enabled = true;
                btnNewSup.Image = SaleInventory.Properties.Resources.icons8_male_user_48;
            }
            else
            {
                b = false;
                btnNewSup.Text = "New Supplier";
                btnNewSup.Image= SaleInventory.Properties.Resources.icons8_plus_48;
            }
        }

       
    }
}
