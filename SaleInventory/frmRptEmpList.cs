using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SaleInventory
{
    public partial class frmRptEmpList : Form
    {
        public frmRptEmpList()
        {
            InitializeComponent();
        }

        private void frmRptEmpList_Load(object sender, EventArgs e)
        {
            VempList.SetDisplayMode(DisplayMode.PrintLayout);
            VempList.ZoomMode = ZoomMode.Percent;
            VempList.ZoomPercent = 100;
        }
    }
}
