namespace Ahmesthete_Firewall_Tutor_Project
{
    partial class Packet
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
            System.Windows.Forms.Button Home;
            System.Windows.Forms.Button Back;
            System.Windows.Forms.Button Check_Packet;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Packet));
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.Decision_Label = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.DATA_BOX = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Source = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PROTOCOL_COMBO_BOX = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DST_PORT_BOX = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DST_IP_BOX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SRC_PORT_BOX = new System.Windows.Forms.TextBox();
            this.SRC_IP_BOX = new System.Windows.Forms.TextBox();
            Home = new System.Windows.Forms.Button();
            Back = new System.Windows.Forms.Button();
            Check_Packet = new System.Windows.Forms.Button();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Home
            // 
            Home.Anchor = System.Windows.Forms.AnchorStyles.None;
            Home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            Home.FlatAppearance.BorderSize = 0;
            Home.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Home.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Home.ForeColor = System.Drawing.Color.WhiteSmoke;
            Home.Location = new System.Drawing.Point(-79, -4);
            Home.Margin = new System.Windows.Forms.Padding(0);
            Home.Name = "Home";
            Home.Size = new System.Drawing.Size(246, 59);
            Home.TabIndex = 41;
            Home.UseVisualStyleBackColor = false;
            Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // Back
            // 
            Back.Anchor = System.Windows.Forms.AnchorStyles.None;
            Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            Back.FlatAppearance.BorderSize = 0;
            Back.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Back.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Back.ForeColor = System.Drawing.Color.WhiteSmoke;
            Back.Location = new System.Drawing.Point(837, 609);
            Back.Margin = new System.Windows.Forms.Padding(0);
            Back.Name = "Back";
            Back.Size = new System.Drawing.Size(177, 50);
            Back.TabIndex = 91;
            Back.Text = "Back";
            Back.UseVisualStyleBackColor = false;
            Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Check_Packet
            // 
            Check_Packet.Anchor = System.Windows.Forms.AnchorStyles.None;
            Check_Packet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            Check_Packet.FlatAppearance.BorderSize = 0;
            Check_Packet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(25)))));
            Check_Packet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Check_Packet.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Check_Packet.ForeColor = System.Drawing.Color.WhiteSmoke;
            Check_Packet.Location = new System.Drawing.Point(378, 611);
            Check_Packet.Margin = new System.Windows.Forms.Padding(90, 120, 0, 0);
            Check_Packet.Name = "Check_Packet";
            Check_Packet.Size = new System.Drawing.Size(189, 50);
            Check_Packet.TabIndex = 90;
            Check_Packet.Text = "Check Packet";
            Check_Packet.UseVisualStyleBackColor = false;
            Check_Packet.Click += new System.EventHandler(this.Check_Packet_Click);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Transparent;
            this.label20.Image = ((System.Drawing.Image)(resources.GetObject("label20.Image")));
            this.label20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label20.Location = new System.Drawing.Point(378, 616);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 41);
            this.label20.TabIndex = 100;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Transparent;
            this.label18.Image = ((System.Drawing.Image)(resources.GetObject("label18.Image")));
            this.label18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label18.Location = new System.Drawing.Point(26, 5);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 43);
            this.label18.TabIndex = 51;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label18);
            this.panel8.Controls.Add(Home);
            this.panel8.Location = new System.Drawing.Point(1280, 611);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(88, 50);
            this.panel8.TabIndex = 98;
            // 
            // Decision_Label
            // 
            this.Decision_Label.AutoSize = true;
            this.Decision_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.Decision_Label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Decision_Label.Location = new System.Drawing.Point(390, 485);
            this.Decision_Label.Name = "Decision_Label";
            this.Decision_Label.Size = new System.Drawing.Size(28, 30);
            this.Decision_Label.TabIndex = 97;
            this.Decision_Label.Text = "...";
            this.Decision_Label.Click += new System.EventHandler(this.Decision_Label_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(399, 404);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 30);
            this.label11.TabIndex = 96;
            this.label11.Text = "Data";
            // 
            // DATA_BOX
            // 
            this.DATA_BOX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.DATA_BOX.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DATA_BOX.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.DATA_BOX.Location = new System.Drawing.Point(565, 404);
            this.DATA_BOX.Name = "DATA_BOX";
            this.DATA_BOX.Size = new System.Drawing.Size(232, 30);
            this.DATA_BOX.TabIndex = 95;
            this.DATA_BOX.TextChanged += new System.EventHandler(this.DATA_BOX_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Location = new System.Drawing.Point(399, 352);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(158, 30);
            this.label15.TabIndex = 94;
            this.label15.Text = "Date and Time";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.dateTimePicker1.Location = new System.Drawing.Point(565, 357);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(232, 22);
            this.dateTimePicker1.TabIndex = 93;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Agency FB", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(614, 740);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(432, 28);
            this.label13.TabIndex = 77;
            this.label13.Text = "Faculty Of Artificial Intelligence - Department Of Cyber Security";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(683, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(311, 33);
            this.label12.TabIndex = 78;
            this.label12.Text = "ENTER PACKET DATA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1188, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 161);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 92;
            this.pictureBox1.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label16.Location = new System.Drawing.Point(46, 489);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 30);
            this.label16.TabIndex = 10;
            this.label16.Text = "Decision";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(46, 405);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 30);
            this.label10.TabIndex = 9;
            this.label10.Text = "Data";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Location = new System.Drawing.Point(46, 352);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 30);
            this.label14.TabIndex = 8;
            this.label14.Text = "Date  Time";
            // 
            // Source
            // 
            this.Source.AutoSize = true;
            this.Source.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.Source.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.Source.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Source.Location = new System.Drawing.Point(46, 79);
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(191, 30);
            this.Source.TabIndex = 1;
            this.Source.Text = "Source‎ IP‎ Address";
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Transparent;
            this.label19.Image = ((System.Drawing.Image)(resources.GetObject("label19.Image")));
            this.label19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label19.Location = new System.Drawing.Point(857, 611);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 43);
            this.label19.TabIndex = 99;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(399, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 30);
            this.label6.TabIndex = 80;
            this.label6.Text = "IP Address:";
            // 
            // PROTOCOL_COMBO_BOX
            // 
            this.PROTOCOL_COMBO_BOX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.PROTOCOL_COMBO_BOX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PROTOCOL_COMBO_BOX.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.PROTOCOL_COMBO_BOX.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.PROTOCOL_COMBO_BOX.FormattingEnabled = true;
            this.PROTOCOL_COMBO_BOX.Items.AddRange(new object[] {
            "UDP",
            "TCP",
            "ICMP"});
            this.PROTOCOL_COMBO_BOX.Location = new System.Drawing.Point(565, 295);
            this.PROTOCOL_COMBO_BOX.Name = "PROTOCOL_COMBO_BOX";
            this.PROTOCOL_COMBO_BOX.Size = new System.Drawing.Size(121, 31);
            this.PROTOCOL_COMBO_BOX.TabIndex = 89;
            this.PROTOCOL_COMBO_BOX.SelectedIndexChanged += new System.EventHandler(this.PROTOCOL_COMBO_BOX_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(399, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 30);
            this.label5.TabIndex = 88;
            this.label5.Text = "Select protocol:";
            // 
            // DST_PORT_BOX
            // 
            this.DST_PORT_BOX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.DST_PORT_BOX.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DST_PORT_BOX.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.DST_PORT_BOX.Location = new System.Drawing.Point(565, 235);
            this.DST_PORT_BOX.Name = "DST_PORT_BOX";
            this.DST_PORT_BOX.Size = new System.Drawing.Size(203, 30);
            this.DST_PORT_BOX.TabIndex = 87;
            this.DST_PORT_BOX.TextChanged += new System.EventHandler(this.DST_PORT_BOX_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(399, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 30);
            this.label9.TabIndex = 86;
            this.label9.Text = "PORT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(46, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 30);
            this.label4.TabIndex = 5;
            this.label4.Text = "Destination‎ IP‎ Address";
            // 
            // DST_IP_BOX
            // 
            this.DST_IP_BOX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.DST_IP_BOX.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DST_IP_BOX.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.DST_IP_BOX.Location = new System.Drawing.Point(566, 187);
            this.DST_IP_BOX.Name = "DST_IP_BOX";
            this.DST_IP_BOX.Size = new System.Drawing.Size(203, 30);
            this.DST_IP_BOX.TabIndex = 85;
            this.DST_IP_BOX.TextChanged += new System.EventHandler(this.DST_IP_BOX_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(46, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Protocol";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(399, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 30);
            this.label8.TabIndex = 84;
            this.label8.Text = "IP Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(46, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Destination PORT";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Source);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 780);
            this.panel1.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(46, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Source‎ PORT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(399, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 30);
            this.label7.TabIndex = 82;
            this.label7.Text = "PORT:";
            // 
            // SRC_PORT_BOX
            // 
            this.SRC_PORT_BOX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.SRC_PORT_BOX.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SRC_PORT_BOX.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.SRC_PORT_BOX.Location = new System.Drawing.Point(566, 130);
            this.SRC_PORT_BOX.Name = "SRC_PORT_BOX";
            this.SRC_PORT_BOX.Size = new System.Drawing.Size(203, 30);
            this.SRC_PORT_BOX.TabIndex = 83;
            this.SRC_PORT_BOX.TextChanged += new System.EventHandler(this.SRC_PORT_BOX_TextChanged);
            // 
            // SRC_IP_BOX
            // 
            this.SRC_IP_BOX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(31)))));
            this.SRC_IP_BOX.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SRC_IP_BOX.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.SRC_IP_BOX.Location = new System.Drawing.Point(566, 77);
            this.SRC_IP_BOX.Name = "SRC_IP_BOX";
            this.SRC_IP_BOX.Size = new System.Drawing.Size(203, 30);
            this.SRC_IP_BOX.TabIndex = 101;
            this.SRC_IP_BOX.TextChanged += new System.EventHandler(this.SRC_IP_BOX_TextChanged);
            // 
            // Packet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1369, 777);
            this.Controls.Add(this.SRC_IP_BOX);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.Decision_Label);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DATA_BOX);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label19);
            this.Controls.Add(Back);
            this.Controls.Add(Check_Packet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PROTOCOL_COMBO_BOX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DST_PORT_BOX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DST_IP_BOX);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SRC_PORT_BOX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Packet";
            this.Text = "Packet";
            this.Load += new System.EventHandler(this.Packet_Load);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label Decision_Label;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox DATA_BOX;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label Source;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox PROTOCOL_COMBO_BOX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DST_PORT_BOX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DST_IP_BOX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox SRC_PORT_BOX;
        private System.Windows.Forms.TextBox SRC_IP_BOX;
    }
}