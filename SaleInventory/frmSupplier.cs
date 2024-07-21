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

namespace SaleInventory
{
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        SqlDataAdapter da;
        DataTable dt;
        SqlCommand com;
        Boolean b;
        string SupID = "0";


        private void LoadData()
        {
            da = new SqlDataAdapter("SELECT*FROM dbo.GetSupplier()", myOper.con);
            dt = new DataTable();
            da.Fill(dt);
            lswSup.Clear();
            lswSup.View = View.Details;
            //add column header
            lswSup.Columns.Add("ID",70 );
            lswSup.Columns.Add("Supplier's name", 170);
            lswSup.Columns.Add("Contact", 150);

            //Load data from datatable into listview
            string[] arr = new string[3];
            ListViewItem item;
            for (int i = 0; i < dt.Rows.Count; i++) {
                DataRow dr = dt.Rows[i];
                arr[0] = dr[0].ToString();
                arr[1] = dr[1].ToString();
                arr[2] = dr[2].ToString();
                item = new ListViewItem(arr);
                lswSup.Items.Add(item);
            }
            //Alternative color
            foreach (ListViewItem list in lswSup.Items)
            {
                if ((list.Index % 2) == 0)
                    list.BackColor = Color.White;
                else
                    lswSup.BackColor = Color.LightBlue;
            }
            dt.Dispose();
            da.Dispose();
       }
        private void frmSupplier_Load(object sender, EventArgs e)
        {
            myOper.OnOff(this, false);
            myOper.myConnection();
            txtSupID.Text = "Auto Number";
            LoadData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "New")
            {
                b = true;
                myOper.OnOff(this, true);
                btnNew.Text = "Cancel";
                btnNew.Image = SaleInventory.Properties.Resources.icons8_cancel_48;
                btnEdit.Enabled = false;
                txtSupplier.Focus();
            }
            else
            {
                DialogResult re = DialogResult.Yes;
                re = MessageBox.Show("Do you want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (re == DialogResult.Yes)
                {
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

        private void Modify(String X)
        {
            com = new SqlCommand(X, myOper.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@i", int.Parse(SupID.ToString()));
            com.Parameters.AddWithValue("@s", txtSupplier.Text);
            com.Parameters.AddWithValue("@c", txtSupCon.Text);
            com.ExecuteNonQuery();
            com.Dispose();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSupplier.Text.Trim()))
            {
                MessageBox.Show("Please input Supplier...", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplier.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSupCon.Text.Trim()))
            {
                MessageBox.Show("Please input Contact...", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupCon.Focus();
                return;
            }
            if (b == true)
            {
                Modify("InsertSupplier");
                MessageBox.Show("Your record was saved...", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Modify("UpdateSupplier");
                MessageBox.Show("Your record was updated...", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadData();
            myOper.ClearData(this);
            myOper.OnOff(this, false);
            btnNew.Text = "New";
            btnNew.Image = SaleInventory.Properties.Resources.icons8_plus_48;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            b = false;
            btnNew.Text = "Cancel";
            btnNew.Image = SaleInventory.Properties.Resources.icons8_cancel_48;
            myOper.OnOff(this, true);
            txtSupplier.Focus();
            btnEdit.Enabled = false;
        }

        private void lswSup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lswSup.SelectedItems.Count > 0)
            {
                ListViewItem item = lswSup.SelectedItems[0]; //row
                SupID = item.SubItems[0].Text; //column
                txtSupplier.Text = item.SubItems[1].Text; //column 
                txtSupCon.Text = item.SubItems[2].Text; //column
                btnEdit.Enabled = true;
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            com = new SqlCommand("SearchSup", myOper.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@s", txtSearch.Text);
            da = new SqlDataAdapter();
            da.SelectCommand = com;
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                com = new SqlCommand("SSupByCon", myOper.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@n", txtSearch.Text);
                da = new SqlDataAdapter();
                da.SelectCommand = com;
                dt = new DataTable();
                da.Fill(dt);
            }
            lswSup.Clear();
            lswSup.View = View.Details;
            lswSup.Columns.Add("ID", 70);
            lswSup.Columns.Add("Supplier'name", 170);
            lswSup.Columns.Add("Contact", 150);

            string[] arr = new string[3];

            ListViewItem item;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                arr[0] = row[0].ToString();
                arr[1] = row[1].ToString();
                arr[2] = row[2].ToString();

                item = new ListViewItem(arr);
                lswSup.Items.Add(item);
            }
        }
    }
}
