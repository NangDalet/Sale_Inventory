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
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }

        SqlDataAdapter da;
        SqlCommand com;
        DataTable dt;
        string catID="0";
        Boolean b;

        private void LoadData()
        {
            da = new SqlDataAdapter("SELECT * FROM dbo.GetCategory()", myOper.con);
            dt = new DataTable();
            da.Fill(dt);
            lswCate.Clear();
            lswCate.View = View.Details;
            //Add column Header
            lswCate.Columns.Add("ID", 95);
            lswCate.Columns.Add("Category", 295);
            //Load data from table into lisview
            string[] arr = new string[2];
            ListViewItem item;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                arr[0] = dr[0].ToString();
                arr[1] = dr[1].ToString();
                item = new ListViewItem(arr);
                lswCate.Items.Add(item);
            } 
            //Alternative color
            foreach(ListViewItem list in lswCate.Items)
            {
                if ((list.Index % 2) == 0)
                    list.BackColor = Color.White;
                else
                    lswCate.BackColor = Color.LightBlue;
            }
            dt.Dispose();
            da.Dispose();
        }
        private void frmCategory_Load(object sender, EventArgs e)
        {
            myOper.OnOff(this, false);
            myOper.myConnection();
            txtCatID.Text = "Auto Number";
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
                txtCate.Focus();
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
            DialogResult re = DialogResult.Yes;
            re = MessageBox.Show("Do you want to close?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.Yes)
            {
                this.Hide();

                frmMain ma = new frmMain();
                ma.ShowDialog();

                this.Close();
            }
        }
        private void Modify(string X)
        {
            com = new SqlCommand(X, myOper.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@i", int.Parse(catID.ToString()));
            com.Parameters.AddWithValue("@c", txtCate.Text);
            com.ExecuteNonQuery();
            com.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCate.Text.Trim()))
            {
                MessageBox.Show("Please input category...", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCate.Focus();
                return;
            }
            if (b == true)
            {
                Modify("InsertCategory");
                MessageBox.Show("Your record was saved...", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Modify("UpdateCategory");
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
            btnNew.Image = SaleInventory.Properties.Resources.icons8_plus_48;
            myOper.OnOff(this, true);
            txtCate.Focus();
            btnEdit.Enabled = false;
        }

        private void lswCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lswCate.SelectedItems.Count > 0)
            {
                ListViewItem item = lswCate.SelectedItems[0]; //row
                catID = item.SubItems[0].Text; //column
                txtCate.Text = item.SubItems[1].Text; //column category
                btnEdit.Enabled = true;
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            com = new SqlCommand("SCat", myOper.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@c", txtSearch.Text);

            da = new SqlDataAdapter();
            da.SelectCommand = com;
            dt = new DataTable();
            da.Fill(dt);
            lswCate.Clear();
            lswCate.View = View.Details;
            lswCate.Columns.Add("ID", 95);
            lswCate.Columns.Add("Category", 300);
            
            string[] arr = new string[2];           

            ListViewItem item;
            for(int i=0; i < dt.Rows.Count;i++)
            {
                DataRow row = dt.Rows[i];
                arr[0] = row[0].ToString();
                arr[1] = row[1].ToString();

                item = new ListViewItem(arr);
                lswCate.Items.Add(item);
            }
        }
    }
}
