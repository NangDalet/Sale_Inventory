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
    public partial class frmCreateAccount : Form
    {
        public frmCreateAccount()
        {
            InitializeComponent();
        }

        Boolean b;
        int eid = 0;
        string pos = "";
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand com;

        private void FillList()
        {
            string sql = "SELECT * FROM dbo.Getuser()";
            string sql1 = "SELECT * FROM dbo.GETAUSER(" + myOper.EmpID + ")";
            if (myOper.EmpID == 0 || myOper.EmpPos == "Admin")
            {
                da = new SqlDataAdapter(sql, myOper.con);
            }
            else
            {
                da = new SqlDataAdapter(sql1, myOper.con);
                btnNew.Enabled = false;
            }
            // da = new SqlDataAdapter("SELECT * FROM dbo.GETU(" + myOper.EmpID + ",'" + myOper.EmpPos + "')", myOper.con);
            dt = new DataTable();
            da.Fill(dt);
            lstUser.DataSource = null;
            lstUser.Items.Clear();
            lstUser.DataSource = dt;
            lstUser.DisplayMember = "username";
            lstUser.ValueMember = "empID";
        }

        private void frmCreateAccount_Load(object sender, EventArgs e)
        {
            myOper.OnOff(this, false);
            myOper.myConnection();
            FillList();
        }

        private void FillCombo()
        {
            da = new SqlDataAdapter("SELECT * FROM dbo.GetNonUser()", myOper.con);
            dt = new DataTable();
            da.Fill(dt);
            cboEmp.DataSource = null;
            cboEmp.Items.Clear();
            cboEmp.DataSource = dt;
            cboEmp.DisplayMember = "empName";
            cboEmp.ValueMember = "empID";
            cboEmp.Text = null;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "New")
            {
                b = true;
                myOper.OnOff(this, true);
                btnNew.Text = "Cancel";
                btnNew.Image = SaleInventory.Properties.Resources.icons8_close_window_48;
                FillCombo();
            }
            else
            {
                DialogResult re = DialogResult.Yes;
                MessageBox.Show("Do you want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (re == DialogResult.Yes)
                {
                    b = false;
                    myOper.ClearData(this);
                    myOper.OnOff(this, false);
                    btnNew.Text = "New";
                    btnNew.Image = SaleInventory.Properties.Resources.icons8_plus_48;
                    if (myOper.EmpID == 0 || myOper.EmpPos == "Admin")
                        btnNew.Enabled = true;
                    else
                        btnNew.Enabled = false;
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

        private void lstUser_Click(object sender, EventArgs e)
        {
            if (b == true)
                return;

            if (lstUser.Items.Count > 0)
            {
                b = false;
                eid = int.Parse(lstUser.SelectedValue.ToString());
                txtUser.Text = lstUser.Text;
                btnNew.Enabled = true;
                btnNew.Text = "Cancel";
                btnNew.Image = SaleInventory.Properties.Resources.icons8_cancel_48;
                da = new SqlDataAdapter("SELECT empID, empName FROM tbUser WHERE empID=" + eid, myOper.con);
                dt = new DataTable();
                da.Fill(dt);
                cboEmp.DataSource = null;
                cboEmp.Items.Clear();
                cboEmp.DataSource = dt;
                cboEmp.DisplayMember = "empName";
                cboEmp.ValueMember = "empID";
                myOper.OnOff(this, true);
                if (myOper.EmpID != 0)
                {
                    if (eid != 0)
                    {
                        myOper.OnOff(this, true);
                        cboEmp.Enabled = false;
                        btnDelete.Enabled = false;
                        btnNew.Enabled = true;
                        btnNew.Text = "Cancel";
                        btnNew.Image = SaleInventory.Properties.Resources.icons8_cancel_48;
                        return;
                    }
                }
                else
                {
                    if (eid == 0)
                    {
                        myOper.OnOff(this, true);
                        txtUser.Enabled = false;
                        cboEmp.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult re;
            re = MessageBox.Show("Do you want to delete...", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.Yes)
            {
                com = new SqlCommand("DelACC", myOper.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@I", eid);
                com.ExecuteNonQuery();
                MessageBox.Show("Your account was removed...", "Remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillList();
            }
        }

        private void cboEmp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            eid = int.Parse(cboEmp.SelectedValue.ToString());
            da = new SqlDataAdapter("SELECT Pos FROM tbEmployee WHERE empID='" + eid + "'", myOper.con);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                pos = dt.Rows[0][0].ToString();
            txtUser.Focus();
        }

        private void Modify(string X)
        {
            com = new SqlCommand(X, myOper.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@I", eid);
            com.Parameters.AddWithValue("@EN", cboEmp.Text);
            com.Parameters.AddWithValue("@UN", txtUser.Text);
            com.Parameters.AddWithValue("@PW", txtPwd.Text);
            com.Parameters.AddWithValue("@PO", pos);
            com.ExecuteNonQuery();
            com.Dispose();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboEmp.Text.Trim()))
            {
                MessageBox.Show("Please select employee name...", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEmp.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtUser.Text.Trim()))
            {
                MessageBox.Show("Please input user name...", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPwd.Text.Trim()))
            {
                MessageBox.Show("Please input password...", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPwd.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtRePwd.Text.Trim()))
            {
                MessageBox.Show("Please input re-password...", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRePwd.Focus();
                return;
            }
            if (txtPwd.Text != txtRePwd.Text)
            {
                MessageBox.Show("Your password not match with re-password...", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPwd.Text = null;
                txtRePwd.Text = null;
                txtPwd.Focus();
                return;
            }
            else
            {
                if (b == true)
                {
                    Modify("CreatAcc");
                    MessageBox.Show("Your account was created...", "Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Modify("UpdateAcc");
                    MessageBox.Show("Your account was updated...", "Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                myOper.ClearData(this);
                myOper.OnOff(this, false);
                btnNew.Text = "New";
                btnNew.Image = SaleInventory.Properties.Resources.icons8_plus_48;
                FillList();
            }
        }
    }
}
