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
using System.Data;

namespace SaleInventory
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        SqlDataAdapter da;
        DataTable dt;
        SqlCommand com;
        Boolean b;
        string CatID = "0";

        private void FillList()
        {
            da = new SqlDataAdapter("SELECT proID, proName FROM tbProduct", myOper.con);
            dt = new DataTable();
            da.Fill(dt);
            lstProduct.DataSource = null;
            lstProduct.Items.Clear();
            lstProduct.DataSource = dt;
            lstProduct.DisplayMember = "proName";
            lstProduct.ValueMember = "proID";
        }
        private void frmProduct_Load(object sender, EventArgs e)
        {
            myOper.myConnection();
            myOper.OnOff(this, false);
            myOper.FillCbo(cboCate, "catID", "category", "tbCategory");
            cboCate.Text = null;
            FillList();   
        }

        private void lstProduct_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtProID.Text = lstProduct.SelectedValue.ToString();
            txtProName.Text = lstProduct.Text;
            com = new SqlCommand("SELECT * FROM tbProduct WHERE proID='" + txtProID.Text + "'", myOper.con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                txtQty.Text = dr[2].ToString();
                txtUpis.Text = dr[3].ToString();
                txtSUP.Text = dr[4].ToString();
                cboCate.SelectedValue = int.Parse(dr[5].ToString());
            }
            com.Dispose();
            dr.Dispose();
            btnEdit.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                b = false;
                btnEdit.Text = "Cancel";
                btnEdit.Image = SaleInventory.Properties.Resources.icons8_cancel_48;
                myOper.OnOff(this, true);
                txtProName.Focus();
            }
            else
            {
                DialogResult re = DialogResult.Yes;
                re = MessageBox.Show("Do you want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                myOper.ClearData(this);
                myOper.OnOff(this, false);
                btnEdit.Text = "Edit";
                btnEdit.Image = SaleInventory.Properties.Resources.icons8_edit_property_48;
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            com = new SqlCommand("SProByName", myOper.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@n", txtSearch.Text);
            da = new SqlDataAdapter();
            da.SelectCommand = com;
            dt = new DataTable();
            da.Fill(dt);
            lstProduct.DataSource = dt;

            if (dt.Rows.Count < 1)
            {
                com = new SqlCommand("SProByID", myOper.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@s", txtSearch.Text);

                da = new SqlDataAdapter();
                da.SelectCommand = com;
                dt = new DataTable();
                da.Fill(dt);
                lstProduct.DataSource = dt;
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

        private void Modify(string X)
        {
            com = new SqlCommand(X, myOper.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@i", txtProID.Text);
            com.Parameters.AddWithValue("@n", txtProName.Text);
            com.Parameters.AddWithValue("@u", txtSUP.Text);
            //com.Parameters.AddWithValue("@c", int.Parse(CatID));
            com.ExecuteNonQuery();
            com.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProName.Text.Trim()))
            {
                MessageBox.Show("Please input Product's Name...", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSUP.Text.Trim()))
            {
                MessageBox.Show("Please input Price...", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSUP.Focus();
                return;
            }
            if (cboCate == null)
            {
                MessageBox.Show("Please input Category...", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboCate.Focus();
                return;
            }
            Modify("UpdatePro");
            MessageBox.Show("Your record was Updated...", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            myOper.ClearData(this);
            myOper.OnOff(this, false);
            btnEdit.Text = "Edit";
            btnEdit.Image = SaleInventory.Properties.Resources.icons8_edit_property_48;
            txtProID.Clear();
            txtUpis.Clear();
            txtQty.Clear();
        }
    }
}
