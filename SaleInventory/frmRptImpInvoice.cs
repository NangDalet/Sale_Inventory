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
    public partial class frmRptImpInvoice : Form
    {
        public frmRptImpInvoice()
        {
            InitializeComponent();
        }

        private void frmRptImpInvoice_Load(object sender, EventArgs e)
        {
            VinvImp.SetDisplayMode(DisplayMode.PrintLayout);
            VinvImp.ZoomMode = ZoomMode.Percent;
            VinvImp.ZoomPercent = 100;
        }
    }
}
