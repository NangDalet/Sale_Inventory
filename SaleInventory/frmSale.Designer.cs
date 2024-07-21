namespace SaleInventory
{
    partial class frmSale
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lswSale = new System.Windows.Forms.ListView();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProID = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.cboPro = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCate = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNewSup = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtCusCon = new System.Windows.Forms.TextBox();
            this.cboCus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCusID = new System.Windows.Forms.TextBox();
            this.dtpSale = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSaleID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRateInKh = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRateDollar = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtExDollar = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtExchangeKh = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTotalKh = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1190, 75);
            this.panel1.TabIndex = 63;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Khmer OS Muol", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1187, 74);
            this.label13.TabIndex = 0;
            this.label13.Text = "ពត៌មានអំពីការលក់ទំនិញ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Yellow;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(829, 763);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 35);
            this.label12.TabIndex = 62;
            this.label12.Text = "តម្លៃសរុប($)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(967, 759);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(210, 44);
            this.txtTotal.TabIndex = 61;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.White;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Black;
            this.btnRemove.Image = global::SaleInventory.Properties.Resources.icons8_remove_48;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(959, 390);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(210, 52);
            this.btnRemove.TabIndex = 64;
            this.btnRemove.Text = "Remove Item";
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemove.UseVisualStyleBackColor = false;
            // 
            // lswSale
            // 
            this.lswSale.FullRowSelect = true;
            this.lswSale.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lswSale.HideSelection = false;
            this.lswSale.Location = new System.Drawing.Point(12, 448);
            this.lswSale.Name = "lswSale";
            this.lswSale.Size = new System.Drawing.Size(1166, 254);
            this.lswSale.TabIndex = 35;
            this.lswSale.UseCompatibleStateImageBehavior = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label11.Location = new System.Drawing.Point(22, 348);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(188, 36);
            this.label11.TabIndex = 60;
            this.label11.Text = "លេខកូដទំនិញ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProID
            // 
            this.txtProID.Location = new System.Drawing.Point(22, 390);
            this.txtProID.Name = "txtProID";
            this.txtProID.Size = new System.Drawing.Size(188, 44);
            this.txtProID.TabIndex = 59;
            this.txtProID.TextChanged += new System.EventHandler(this.txtProID_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Image = global::SaleInventory.Properties.Resources.icons8_save_48;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(959, 332);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(210, 52);
            this.btnAdd.TabIndex = 58;
            this.btnAdd.Text = "Add New Item";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label10.Location = new System.Drawing.Point(600, 348);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 36);
            this.label10.TabIndex = 57;
            this.label10.Text = "តម្លៃ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(600, 390);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(154, 44);
            this.txtPrice.TabIndex = 56;
            this.txtPrice.Tag = "*";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label9.Location = new System.Drawing.Point(440, 348);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 36);
            this.label9.TabIndex = 55;
            this.label9.Text = "បរិមាណ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(440, 390);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(154, 44);
            this.txtQty.TabIndex = 54;
            // 
            // cboPro
            // 
            this.cboPro.FormattingEnabled = true;
            this.cboPro.Location = new System.Drawing.Point(216, 390);
            this.cboPro.Name = "cboPro";
            this.cboPro.Size = new System.Drawing.Size(218, 44);
            this.cboPro.TabIndex = 53;
            this.cboPro.SelectionChangeCommitted += new System.EventHandler(this.cboPro_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label8.Location = new System.Drawing.Point(216, 348);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 36);
            this.label8.TabIndex = 52;
            this.label8.Text = "ឈ្មោះទំនិញ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCate
            // 
            this.cboCate.Enabled = false;
            this.cboCate.FormattingEnabled = true;
            this.cboCate.Location = new System.Drawing.Point(760, 390);
            this.cboCate.Name = "cboCate";
            this.cboCate.Size = new System.Drawing.Size(188, 44);
            this.cboCate.TabIndex = 51;
            this.cboCate.Tag = "*";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(760, 348);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 36);
            this.label7.TabIndex = 50;
            this.label7.Text = "ប្រភេទទំនិញ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNewSup
            // 
            this.btnNewSup.BackColor = System.Drawing.Color.White;
            this.btnNewSup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewSup.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewSup.ForeColor = System.Drawing.Color.Black;
            this.btnNewSup.Image = global::SaleInventory.Properties.Resources.icons8_plus_48;
            this.btnNewSup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewSup.Location = new System.Drawing.Point(533, 185);
            this.btnNewSup.Name = "btnNewSup";
            this.btnNewSup.Size = new System.Drawing.Size(190, 56);
            this.btnNewSup.TabIndex = 49;
            this.btnNewSup.Tag = "*";
            this.btnNewSup.Text = "New Customer";
            this.btnNewSup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewSup.UseVisualStyleBackColor = false;
            this.btnNewSup.Click += new System.EventHandler(this.btnNewSup_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::SaleInventory.Properties.Resources.icons8_close_window_48;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1012, 201);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 52);
            this.btnClose.TabIndex = 48;
            this.btnClose.Tag = "*";
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::SaleInventory.Properties.Resources.icons8_save_48;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1012, 143);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 52);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.White;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.Black;
            this.btnNew.Image = global::SaleInventory.Properties.Resources.icons8_plus_48;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(1012, 85);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(119, 52);
            this.btnNew.TabIndex = 46;
            this.btnNew.Tag = "*";
            this.btnNew.Text = "New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtCusCon
            // 
            this.txtCusCon.Location = new System.Drawing.Point(725, 83);
            this.txtCusCon.Multiline = true;
            this.txtCusCon.Name = "txtCusCon";
            this.txtCusCon.Size = new System.Drawing.Size(281, 94);
            this.txtCusCon.TabIndex = 45;
            this.txtCusCon.Tag = "";
            // 
            // cboCus
            // 
            this.cboCus.FormattingEnabled = true;
            this.cboCus.Location = new System.Drawing.Point(246, 238);
            this.cboCus.Name = "cboCus";
            this.cboCus.Size = new System.Drawing.Size(281, 44);
            this.cboCus.TabIndex = 44;
            this.cboCus.SelectionChangeCommitted += new System.EventHandler(this.cboCus_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 36);
            this.label6.TabIndex = 43;
            this.label6.Text = "ឈ្មោះអតិថិជន";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(606, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 36);
            this.label5.TabIndex = 42;
            this.label5.Text = "ទំនាក់ទំនង";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label4.Font = new System.Drawing.Font("Khmer OS Muol", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1157, 39);
            this.label4.TabIndex = 41;
            this.label4.Text = "ពត៌មានលំអិត";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 36);
            this.label3.TabIndex = 40;
            this.label3.Text = "លេខសំគាល់អតិថិជន";
            // 
            // txtCusID
            // 
            this.txtCusID.Enabled = false;
            this.txtCusID.Location = new System.Drawing.Point(246, 185);
            this.txtCusID.Name = "txtCusID";
            this.txtCusID.Size = new System.Drawing.Size(281, 44);
            this.txtCusID.TabIndex = 39;
            this.txtCusID.Tag = "*";
            // 
            // dtpSale
            // 
            this.dtpSale.CustomFormat = "dd/MM/yyyy";
            this.dtpSale.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSale.Location = new System.Drawing.Point(246, 135);
            this.dtpSale.Name = "dtpSale";
            this.dtpSale.Size = new System.Drawing.Size(281, 44);
            this.dtpSale.TabIndex = 38;
            this.dtpSale.ValueChanged += new System.EventHandler(this.dtpSale_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 36);
            this.label2.TabIndex = 37;
            this.label2.Text = "កាលបរិច្ឆេទលក់";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 36);
            this.label1.TabIndex = 36;
            this.label1.Text = "លេខវិក័យបត្រ";
            // 
            // txtSaleID
            // 
            this.txtSaleID.Enabled = false;
            this.txtSaleID.Location = new System.Drawing.Point(246, 85);
            this.txtSaleID.Name = "txtSaleID";
            this.txtSaleID.Size = new System.Drawing.Size(281, 44);
            this.txtSaleID.TabIndex = 34;
            this.txtSaleID.Tag = "*";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Yellow;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(16, 712);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(185, 35);
            this.label14.TabIndex = 66;
            this.label14.Text = "លុយទទួលបាន(៛)";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRateInKh
            // 
            this.txtRateInKh.Enabled = false;
            this.txtRateInKh.Location = new System.Drawing.Point(205, 708);
            this.txtRateInKh.Name = "txtRateInKh";
            this.txtRateInKh.Size = new System.Drawing.Size(210, 44);
            this.txtRateInKh.TabIndex = 65;
            this.txtRateInKh.TextChanged += new System.EventHandler(this.txtRateInKh_TextChanged);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Yellow;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(14, 763);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(183, 35);
            this.label15.TabIndex = 68;
            this.label15.Text = "លុយទទួលបាន($)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRateDollar
            // 
            this.txtRateDollar.Enabled = false;
            this.txtRateDollar.Location = new System.Drawing.Point(205, 759);
            this.txtRateDollar.Name = "txtRateDollar";
            this.txtRateDollar.Size = new System.Drawing.Size(210, 44);
            this.txtRateDollar.TabIndex = 67;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Yellow;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(421, 763);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(185, 35);
            this.label16.TabIndex = 72;
            this.label16.Text = "លុយអាប់($)";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtExDollar
            // 
            this.txtExDollar.Enabled = false;
            this.txtExDollar.Location = new System.Drawing.Point(612, 759);
            this.txtExDollar.Name = "txtExDollar";
            this.txtExDollar.Size = new System.Drawing.Size(210, 44);
            this.txtExDollar.TabIndex = 71;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Yellow;
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(421, 712);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(185, 35);
            this.label17.TabIndex = 70;
            this.label17.Text = "លុយអាប់(៛)";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtExchangeKh
            // 
            this.txtExchangeKh.Enabled = false;
            this.txtExchangeKh.Location = new System.Drawing.Point(612, 708);
            this.txtExchangeKh.Name = "txtExchangeKh";
            this.txtExchangeKh.Size = new System.Drawing.Size(210, 44);
            this.txtExchangeKh.TabIndex = 69;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Yellow;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(828, 712);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(133, 35);
            this.label18.TabIndex = 74;
            this.label18.Text = "តម្លៃសរុប(៛)";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalKh
            // 
            this.txtTotalKh.Location = new System.Drawing.Point(968, 708);
            this.txtTotalKh.Name = "txtTotalKh";
            this.txtTotalKh.ReadOnly = true;
            this.txtTotalKh.Size = new System.Drawing.Size(210, 44);
            this.txtTotalKh.TabIndex = 73;
            // 
            // frmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1186, 809);
            this.ControlBox = false;
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtTotalKh);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtExDollar);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtExchangeKh);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtRateDollar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtRateInKh);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lswSale);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtProID);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.cboPro);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboCate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnNewSup);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtCusCon);
            this.Controls.Add(this.cboCus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCusID);
            this.Controls.Add(this.dtpSale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSaleID);
            this.Font = new System.Drawing.Font("Khmer OS System", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "frmSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSale";
            this.Load += new System.EventHandler(this.frmSale_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListView lswSale;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProID;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.ComboBox cboPro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNewSup;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtCusCon;
        private System.Windows.Forms.ComboBox cboCus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCusID;
        private System.Windows.Forms.DateTimePicker dtpSale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSaleID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRateInKh;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRateDollar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtExDollar;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtExchangeKh;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtTotalKh;
    }
}