﻿namespace SCM
{
    partial class Form16
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form16));
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scm_mainDataSet3 = new SCM.scm_mainDataSet3();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pinvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scm_mainDataSet7 = new SCM.scm_mainDataSet7();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.supplierTableAdapter = new SCM.scm_mainDataSet3TableAdapters.supplierTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.itemmasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scm_mainDataSet4 = new SCM.scm_mainDataSet4();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.item_masterTableAdapter = new SCM.scm_mainDataSet4TableAdapters.item_masterTableAdapter();
            this.pinvoiceTableAdapter = new SCM.scm_mainDataSet7TableAdapters.pinvoiceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scm_mainDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinvoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scm_mainDataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemmasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scm_mainDataSet4)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox10
            // 
            this.textBox10.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierBindingSource, "supplier_id", true));
            this.textBox10.Enabled = false;
            this.textBox10.Location = new System.Drawing.Point(566, 46);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 20);
            this.textBox10.TabIndex = 60;
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataMember = "supplier";
            this.supplierBindingSource.DataSource = this.scm_mainDataSet3;
            // 
            // scm_mainDataSet3
            // 
            this.scm_mainDataSet3.DataSetName = "scm_mainDataSet3";
            this.scm_mainDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.pinvoiceBindingSource;
            this.comboBox1.DisplayMember = "pinvoice_no";
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(82, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // pinvoiceBindingSource
            // 
            this.pinvoiceBindingSource.DataMember = "pinvoice";
            this.pinvoiceBindingSource.DataSource = this.scm_mainDataSet7;
            // 
            // scm_mainDataSet7
            // 
            this.scm_mainDataSet7.DataSetName = "scm_mainDataSet7";
            this.scm_mainDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox2
            // 
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox2.Location = new System.Drawing.Point(82, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Invoice No:";
            // 
            // supplierTableAdapter
            // 
            this.supplierTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(498, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Supplier ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 273);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Delivery Date:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 20);
            this.label12.TabIndex = 31;
            this.label12.Text = "Hello, ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(59, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 20);
            this.label14.TabIndex = 32;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 237);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Total Price:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(14, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Order Date:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(71, 234);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 20);
            this.label17.TabIndex = 33;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(82, 124);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(158, 165);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Kg";
            // 
            // textBox9
            // 
            this.textBox9.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox9.Enabled = false;
            this.textBox9.Location = new System.Drawing.Point(271, 162);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 20);
            this.textBox9.TabIndex = 6;
            this.textBox9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox9_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(14, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Chalan No:";
            // 
            // textBox6
            // 
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox6.Location = new System.Drawing.Point(82, 162);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(74, 20);
            this.textBox6.TabIndex = 5;
            this.textBox6.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox6_KeyUp);
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(425, 273);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Description:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(8, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Weight/Pkg:";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(82, 270);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker3.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(25, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Rate/Kg:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(407, 158);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(79, 13);
            this.label19.TabIndex = 27;
            this.label19.Text = "Supplier Name:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(432, 196);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 13);
            this.label20.TabIndex = 28;
            this.label20.Text = "Company:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(211, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Invoice Date:";
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.DataSource = this.supplierBindingSource;
            this.comboBox2.DisplayMember = "supplier_name";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.ItemHeight = 13;
            this.comboBox2.Location = new System.Drawing.Point(492, 155);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(174, 21);
            this.comboBox2.TabIndex = 15;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(288, 46);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // textBox8
            // 
            this.textBox8.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox8.Location = new System.Drawing.Point(492, 270);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(174, 20);
            this.textBox8.TabIndex = 16;
            // 
            // textBox7
            // 
            this.textBox7.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemmasterBindingSource, "rate", true));
            this.textBox7.Location = new System.Drawing.Point(82, 200);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 7;
            this.textBox7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
            // 
            // itemmasterBindingSource
            // 
            this.itemmasterBindingSource.DataMember = "item_master";
            this.itemmasterBindingSource.DataSource = this.scm_mainDataSet4;
            // 
            // scm_mainDataSet4
            // 
            this.scm_mainDataSet4.DataSetName = "scm_mainDataSet4";
            this.scm_mainDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierBindingSource, "supplier_company_name", true));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(492, 193);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 20);
            this.textBox1.TabIndex = 61;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(566, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 26);
            this.button1.TabIndex = 17;
            this.button1.Text = "Save Invoice";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(214, 165);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "Total Pkg:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox11);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dateTimePicker3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 351);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(607, 127);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 17);
            this.radioButton3.TabIndex = 14;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Both";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(544, 127);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(56, 17);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.Text = "Excise";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(492, 127);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(46, 17);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.Text = "VAT";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(432, 129);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(54, 13);
            this.label23.TabIndex = 71;
            this.label23.Text = "Calculate:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(373, 237);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(20, 13);
            this.label22.TabIndex = 69;
            this.label22.Text = "Kg";
            // 
            // textBox11
            // 
            this.textBox11.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox11.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemmasterBindingSource, "excise", true));
            this.textBox11.Location = new System.Drawing.Point(610, 85);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(56, 20);
            this.textBox11.TabIndex = 11;
            this.textBox11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox11_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(564, 88);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 13);
            this.label21.TabIndex = 67;
            this.label21.Text = "Excise:";
            // 
            // textBox5
            // 
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemmasterBindingSource, "vat", true));
            this.textBox5.Location = new System.Drawing.Point(492, 85);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(56, 20);
            this.textBox5.TabIndex = 10;
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(455, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "VAT:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(271, 234);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 8;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(199, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 64;
            this.label8.Text = "Total Weight:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(424, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "Supplier Of:";
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.supplierBindingSource, "item_name", true));
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(492, 231);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(174, 20);
            this.textBox3.TabIndex = 63;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.itemmasterBindingSource;
            this.comboBox3.DisplayMember = "item_name";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(492, 193);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(174, 21);
            this.comboBox3.TabIndex = 70;
            this.comboBox3.Visible = false;
            // 
            // item_masterTableAdapter
            // 
            this.item_masterTableAdapter.ClearBeforeFill = true;
            // 
            // pinvoiceTableAdapter
            // 
            this.pinvoiceTableAdapter.ClearBeforeFill = true;
            // 
            // Form16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SCM.Properties.Resources.attitude_free_3_1280x720_1;
            this.ClientSize = new System.Drawing.Size(686, 351);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form16";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Purchase Invoice";
            this.Load += new System.EventHandler(this.Form16_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scm_mainDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinvoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scm_mainDataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemmasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scm_mainDataSet4)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private scm_mainDataSet3 scm_mainDataSet3;
        private System.Windows.Forms.BindingSource supplierBindingSource;
        private SCM.scm_mainDataSet3TableAdapters.supplierTableAdapter supplierTableAdapter;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox11;
        public System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox5;
        private scm_mainDataSet4 scm_mainDataSet4;
        private System.Windows.Forms.BindingSource itemmasterBindingSource;
        private SCM.scm_mainDataSet4TableAdapters.item_masterTableAdapter item_masterTableAdapter;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private scm_mainDataSet7 scm_mainDataSet7;
        private System.Windows.Forms.BindingSource pinvoiceBindingSource;
        private SCM.scm_mainDataSet7TableAdapters.pinvoiceTableAdapter pinvoiceTableAdapter;

    }
}