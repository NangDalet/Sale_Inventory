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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        int count = 0;

        private void frmLogin_Load(object sender, EventArgs e)
        {
            myOper.myConnection();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string un = txtUsername.Text.Trim();
            string pw = txtPassword.Text.Trim();

            SqlCommand com = new SqlCommand("UserLogin", myOper.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@uid", un);
            com.Parameters.AddWithValue("@pwd", pw);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com;
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                myOper.EmpID =int.Parse(row[0].ToString());
                myOper.EmpName = row[1].ToString();
                myOper.EmpPos = row[4].ToString();

                this.Hide();

                frmMain ma = new frmMain();
                ma.ShowDialog(); //មានន័យថាវាលោតចេញមក

                this.Close();
            }
            else
            {
                MessageBox.Show("Your UserName And Password incorrect...", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                count++;
            }
            if (count == 3)
            {
                MessageBox.Show("You have logged in incorrect 3 items...", "Bye Bye", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit(); //Project ទាំងមូលត្រូវបានបញ្ចប់
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
