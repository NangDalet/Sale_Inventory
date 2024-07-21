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
using Microsoft.Reporting.WinForms;
using System.Globalization;

namespace SaleInventory
{
    public partial class frmSaleReport : Form
    {
        public frmSaleReport()
        {
            InitializeComponent();
        }

        SqlDataAdapter da;
        SqlCommand com;
        DataTable dt;
        string eid = null;
        string cid = "0";
        DateTime dsa;
        DateTime dso;

        private void frmSaleReport_Load(object sender, EventArgs e)
        {
            myOper.OnOff(this, false);
            myOper.myConnection();
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "New")
            {
                da = new SqlDataAdapter("SELECT empID, empName FROM tbEmployee WHERE pos='Seller'",myOper.con);
                dt = new DataTable();
                da.Fill(dt);
                cboEmp.DataSource = null;
                cboEmp.Items.Clear();
                cboEmp.DataSource = dt;
                cboEmp.DisplayMember = "empName";
                cboEmp.ValueMember = "empID";
                cboEmp.Enabled = true;
                cboEmp.Text = null;
                myOper.OnOff(this, true);
                myOper.ClearData(this);
                btnNew.Text = "Cancel";
                btnNew.Image = SaleInventory.Properties.Resources.icons8_cancel_48;
                dtpStop.Value = dtpStart.Value;
            }
            else
            {
                DialogResult re = DialogResult.Yes;
                MessageBox.Show("Do you want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (re == DialogResult.Yes)
                {
                    myOper.ClearData(this);
                    lswSaleReport.Items.Clear();
                    myOper.OnOff(this, false);
                    btnNew.Text = "New";
                    btnNew.Image = SaleInventory.Properties.Resources.icons8_plus_48;
                }
            }
        }

        private void cboEmp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            eid = cboEmp.SelectedValue.ToString();
            cboCus.Enabled = true;
            btnShow.Enabled = true;
            da = new SqlDataAdapter("SELECT DISTINCT cusID, cusName FROM tbSale WHERE empID='" + eid + "'", myOper.con);
            dt = new DataTable();
            da.Fill(dt);
            cboCus.DataSource = null;
            cboCus.Items.Clear();
            cboCus.DataSource = dt;
            cboCus.DisplayMember = "cusName";
            cboCus.ValueMember = "cusID";
            cboCus.Text = null;
            cid = "0";
        }
        private void cboCus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cid = cboCus.SelectedValue.ToString();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            dsa = dtpStart.Value;
            dso = dtpStop.Value;
            lswSaleReport.Clear();
            lswSaleReport.View = View.Details;
            lswSaleReport.Columns.Add("Sale ID", 100);
            lswSaleReport.Columns.Add("Sale Date", 200);
            lswSaleReport.Columns.Add("Customer Name", 150);
            lswSaleReport.Columns.Add("Product ID", 150);
            lswSaleReport.Columns.Add("Product Name", 150);
            lswSaleReport.Columns.Add("Quantity", 100);
            lswSaleReport.Columns.Add("Price", 120);
            lswSaleReport.Columns.Add("Amount", 180);
            if (dsa > dso)
            {
                MessageBox.Show("Invalid date...");
                return;
            }
            else
            {
                com = new SqlCommand("SaleReport", myOper.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EI",eid);
                com.Parameters.AddWithValue("@CI",cid);
                com.Parameters.AddWithValue("@SA",dsa);
                com.Parameters.AddWithValue("@SO",dso);
                com.ExecuteNonQuery();
                da = new SqlDataAdapter();
                da.SelectCommand = com;
                dt = new DataTable();
                da.Fill(dt);
                string[] arr = new string[8];
                ListViewItem item;
                for(int i=0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    arr[0] = string.Format("{0:00000}", row[0].ToString()); //sale ID
                    arr[1] = row[1].ToString(); //sale Date
                    arr[2] = row[2].ToString(); //customer id
                    arr[3] = row[3].ToString(); //product id
                    arr[4] = row[4].ToString(); //product name
                    arr[5] = row[5].ToString(); //quantity
                    arr[6] = string.Format("{0:c}", decimal.Parse(row[6].ToString())); //price
                    arr[7] = string.Format("{0:c}", decimal.Parse(row[7].ToString())); //amount
                    item = new ListViewItem(arr);
                    lswSaleReport.Items.Add(item);
                    btnPreview.Enabled = true;
                }
                foreach (ListViewItem list in lswSaleReport.Items)
                {
                    if ((list.Index % 2) == 0)
                        list.BackColor = Color.White;
                    else
                        list.BackColor = Color.LightBlue;
                }
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            dtpStop.Value = dtpStart.Value;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            frmRptSaleStatement rss = new frmRptSaleStatement();
            rss.Vsale.ProcessingMode = ProcessingMode.Local;
            LocalReport lRpt = rss.Vsale.LocalReport;
            lRpt.DisplayName = "rptSaleStatement.rdlc";
            lRpt.DataSources.Clear();

            DataTable dtss = new DataTable();
            dtss.Columns.Add("saleID", typeof(string));
            dtss.Columns.Add("saleDate", typeof(string));
            dtss.Columns.Add("cusName", typeof(string));
            dtss.Columns.Add("proID", typeof(string));
            dtss.Columns.Add("proName", typeof(string));
            dtss.Columns.Add("qty", typeof(string));
            dtss.Columns.Add("price", typeof(string));
            dtss.Columns.Add("amount", typeof(string));

            decimal t = 0;
            foreach(ListViewItem item in lswSaleReport.Items)
            {
                string sid = item.Text;
                string sdate = string.Format("{0:dd-MM-yyyy}", item.SubItems[1].Text);
                string cus = item.SubItems[2].Text;
                string pid = item.SubItems[3].Text;
                string pn = item.SubItems[4].Text;
                string q = item.SubItems[5].Text;
                string pr = item.SubItems[6].Text;
                string am = item.SubItems[7].Text;
                t = t + decimal.Parse(item.SubItems[7].Text, NumberStyles.Currency);
                dtss.Rows.Add(sid, sdate, cus, pid, pn, q, pr, am);
            }
            ReportDataSource rds = new ReportDataSource("dsSaleStatement",dtss);
            lRpt.DataSources.Add(rds);

            ReportParameter p1 = new ReportParameter("EmpID", eid);
            lRpt.SetParameters(p1);

            ReportParameter p2 = new ReportParameter("EmpName", cboEmp.Text);
            lRpt.SetParameters(p2);

            if (cboCus.Text != null)
            {
                ReportParameter p3 = new ReportParameter("CusName", cboCus.Text);
                lRpt.SetParameters(p3);
            }
            else
            {
                ReportParameter p3 = new ReportParameter("CusName", "N/A");
                lRpt.SetParameters(p3);
            }
            ReportParameter p4 = new ReportParameter("begin", dtpStart.Value.ToString("dd-MM-yyyy"));
            lRpt.SetParameters(p4);

            ReportParameter p5 = new ReportParameter("end", dtpStart.Value.ToString("dd-MM-yyyy"));
            lRpt.SetParameters(p5);

            ReportParameter p6 = new ReportParameter("Total", string.Format("{0:c}",t.ToString()));
            lRpt.SetParameters(p6);

            rss.Show();
            rss.Vsale.RefreshReport();
        }
    }
}
