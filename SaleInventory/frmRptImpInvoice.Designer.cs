namespace SaleInventory
{
    partial class frmRptImpInvoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.VinvImp = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsImpInvoice = new SaleInventory.dsImpInvoice();
            this.dtImpInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsImpInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtImpInvoiceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // VinvImp
            // 
            this.VinvImp.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsImpInvoice";
            reportDataSource1.Value = this.dtImpInvoiceBindingSource;
            this.VinvImp.LocalReport.DataSources.Add(reportDataSource1);
            this.VinvImp.LocalReport.ReportEmbeddedResource = "SaleInventory.rptImpInvoice.rdlc";
            this.VinvImp.Location = new System.Drawing.Point(0, 0);
            this.VinvImp.Name = "VinvImp";
            this.VinvImp.Size = new System.Drawing.Size(924, 462);
            this.VinvImp.TabIndex = 0;
            // 
            // dsImpInvoice
            // 
            this.dsImpInvoice.DataSetName = "dsImpInvoice";
            this.dsImpInvoice.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtImpInvoiceBindingSource
            // 
            this.dtImpInvoiceBindingSource.DataMember = "dtImpInvoice";
            this.dtImpInvoiceBindingSource.DataSource = this.dsImpInvoice;
            // 
            // frmRptImpInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 462);
            this.Controls.Add(this.VinvImp);
            this.Name = "frmRptImpInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRptImpInvoice";
            this.Load += new System.EventHandler(this.frmRptImpInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsImpInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtImpInvoiceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource dtImpInvoiceBindingSource;
        private dsImpInvoice dsImpInvoice;
        public Microsoft.Reporting.WinForms.ReportViewer VinvImp;
    }
}