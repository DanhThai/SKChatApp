
namespace PBL41
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbLogout = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbMyName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.butFriend = new CustomButton.VBButton();
            this.butSet = new CustomButton.VBButton();
            this.butMess = new CustomButton.VBButton();
            this.pnMain = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new CustomButton.VBButton();
            this.panelMes = new System.Windows.Forms.Panel();
            this.btnAdd = new CustomButton.VBButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvFriend = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.LViewMessage = new System.Windows.Forms.ListView();
            this.lbName = new System.Windows.Forms.Label();
            this.butSend = new CustomButton.VBButton();
            this.butVideo = new CustomButton.VBButton();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.vbButton2 = new CustomButton.VBButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnMain.SuspendLayout();
            this.panelMes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFriend)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.lbLogout);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lbMyName);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.butFriend);
            this.panel1.Controls.Add(this.butSet);
            this.panel1.Controls.Add(this.butMess);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 615);
            this.panel1.TabIndex = 0;
            // 
            // lbLogout
            // 
            this.lbLogout.AutoSize = true;
            this.lbLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.lbLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogout.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbLogout.Location = new System.Drawing.Point(21, 485);
            this.lbLogout.Name = "lbLogout";
            this.lbLogout.Size = new System.Drawing.Size(76, 20);
            this.lbLogout.TabIndex = 44;
            this.lbLogout.Text = "Log Out";
            this.lbLogout.Click += new System.EventHandler(this.lbLogOut_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(123, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1, 615);
            this.label7.TabIndex = 43;
            // 
            // lbMyName
            // 
            this.lbMyName.AutoSize = true;
            this.lbMyName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lbMyName.Font = new System.Drawing.Font("Modern No. 20", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMyName.ForeColor = System.Drawing.Color.Snow;
            this.lbMyName.Location = new System.Drawing.Point(24, 31);
            this.lbMyName.Name = "lbMyName";
            this.lbMyName.Size = new System.Drawing.Size(86, 34);
            this.lbMyName.TabIndex = 7;
            this.lbMyName.Text = "Le A";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 100);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // butFriend
            // 
            this.butFriend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.butFriend.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.butFriend.BackgroundImage = global::PBL41.Properties.Resources.teamuser;
            this.butFriend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butFriend.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.butFriend.BorderRadius = 10;
            this.butFriend.BorderSize = 0;
            this.butFriend.FlatAppearance.BorderSize = 0;
            this.butFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butFriend.ForeColor = System.Drawing.Color.White;
            this.butFriend.Location = new System.Drawing.Point(30, 255);
            this.butFriend.Name = "butFriend";
            this.butFriend.Size = new System.Drawing.Size(51, 52);
            this.butFriend.TabIndex = 6;
            this.butFriend.TextColor = System.Drawing.Color.White;
            this.butFriend.UseVisualStyleBackColor = false;
            this.butFriend.Click += new System.EventHandler(this.butFriend_Click);
            // 
            // butSet
            // 
            this.butSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.butSet.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.butSet.BackgroundImage = global::PBL41.Properties.Resources.setting;
            this.butSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butSet.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.butSet.BorderRadius = 10;
            this.butSet.BorderSize = 0;
            this.butSet.FlatAppearance.BorderSize = 0;
            this.butSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSet.ForeColor = System.Drawing.Color.Black;
            this.butSet.Location = new System.Drawing.Point(30, 372);
            this.butSet.Name = "butSet";
            this.butSet.Size = new System.Drawing.Size(51, 53);
            this.butSet.TabIndex = 5;
            this.butSet.TextColor = System.Drawing.Color.Black;
            this.butSet.UseVisualStyleBackColor = false;
            this.butSet.Click += new System.EventHandler(this.butSet_Click);
            // 
            // butMess
            // 
            this.butMess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.butMess.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.butMess.BackgroundImage = global::PBL41.Properties.Resources.mes1;
            this.butMess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butMess.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.butMess.BorderRadius = 10;
            this.butMess.BorderSize = 0;
            this.butMess.FlatAppearance.BorderSize = 0;
            this.butMess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMess.ForeColor = System.Drawing.Color.Transparent;
            this.butMess.Location = new System.Drawing.Point(30, 148);
            this.butMess.Name = "butMess";
            this.butMess.Size = new System.Drawing.Size(51, 57);
            this.butMess.TabIndex = 3;
            this.butMess.TextColor = System.Drawing.Color.Transparent;
            this.butMess.UseVisualStyleBackColor = false;
            this.butMess.Click += new System.EventHandler(this.butMess_Click);
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.pnMain.Controls.Add(this.label5);
            this.pnMain.Controls.Add(this.txtSearch);
            this.pnMain.Controls.Add(this.btnSearch);
            this.pnMain.Controls.Add(this.panelMes);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMain.Location = new System.Drawing.Point(126, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(293, 615);
            this.pnMain.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(69, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 2);
            this.label5.TabIndex = 15;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(69, 17);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(221, 33);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.Text = "Search";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnSearch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnSearch.BackgroundImage = global::PBL41.Properties.Resources.loop;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSearch.BorderRadius = 13;
            this.btnSearch.BorderSize = 0;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnSearch.Location = new System.Drawing.Point(17, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 47);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panelMes
            // 
            this.panelMes.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelMes.Controls.Add(this.btnAdd);
            this.panelMes.Controls.Add(this.label2);
            this.panelMes.Controls.Add(this.label4);
            this.panelMes.Controls.Add(this.dgvFriend);
            this.panelMes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMes.Location = new System.Drawing.Point(0, 68);
            this.panelMes.Name = "panelMes";
            this.panelMes.Size = new System.Drawing.Size(293, 547);
            this.panelMes.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAdd.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.btnAdd.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAdd.BorderRadius = 20;
            this.btnAdd.BorderSize = 0;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(60, 477);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(144, 58);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "Add Friend";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAddFriend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(77, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "List Friend";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(-3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 3);
            this.label4.TabIndex = 16;
            // 
            // dgvFriend
            // 
            this.dgvFriend.AllowUserToAddRows = false;
            this.dgvFriend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFriend.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFriend.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvFriend.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.dgvFriend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFriend.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFriend.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFriend.ColumnHeadersHeight = 40;
            this.dgvFriend.ColumnHeadersVisible = false;
            this.dgvFriend.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.OldLace;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFriend.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFriend.GridColor = System.Drawing.Color.Indigo;
            this.dgvFriend.Location = new System.Drawing.Point(0, 58);
            this.dgvFriend.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.dgvFriend.Name = "dgvFriend";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFriend.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFriend.RowHeadersVisible = false;
            this.dgvFriend.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFriend.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFriend.RowTemplate.DividerHeight = 1;
            this.dgvFriend.RowTemplate.Height = 100;
            this.dgvFriend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFriend.Size = new System.Drawing.Size(290, 418);
            this.dgvFriend.TabIndex = 0;
            this.dgvFriend.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFriend_CellClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.LViewMessage);
            this.panel3.Controls.Add(this.lbName);
            this.panel3.Controls.Add(this.butSend);
            this.panel3.Controls.Add(this.butVideo);
            this.panel3.Controls.Add(this.txtMessage);
            this.panel3.Controls.Add(this.vbButton2);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(524, 615);
            this.panel3.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(1, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1, 613);
            this.label11.TabIndex = 42;
            // 
            // LViewMessage
            // 
            this.LViewMessage.BackColor = System.Drawing.Color.White;
            this.LViewMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LViewMessage.HideSelection = false;
            this.LViewMessage.Location = new System.Drawing.Point(0, 68);
            this.LViewMessage.Name = "LViewMessage";
            this.LViewMessage.ShowItemToolTips = true;
            this.LViewMessage.Size = new System.Drawing.Size(524, 487);
            this.LViewMessage.TabIndex = 2;
            this.LViewMessage.TileSize = new System.Drawing.Size(380, 40);
            this.LViewMessage.UseCompatibleStateImageBehavior = false;
            this.LViewMessage.View = System.Windows.Forms.View.Tile;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbName.Location = new System.Drawing.Point(200, 25);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(72, 25);
            this.lbName.TabIndex = 6;
            this.lbName.Text = "Name";
            // 
            // butSend
            // 
            this.butSend.BackColor = System.Drawing.Color.CornflowerBlue;
            this.butSend.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.butSend.BackgroundImage = global::PBL41.Properties.Resources.plane;
            this.butSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butSend.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.butSend.BorderRadius = 10;
            this.butSend.BorderSize = 0;
            this.butSend.FlatAppearance.BorderSize = 0;
            this.butSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSend.ForeColor = System.Drawing.Color.Wheat;
            this.butSend.Location = new System.Drawing.Point(458, 556);
            this.butSend.Name = "butSend";
            this.butSend.Size = new System.Drawing.Size(67, 55);
            this.butSend.TabIndex = 5;
            this.butSend.TextColor = System.Drawing.Color.Wheat;
            this.butSend.UseVisualStyleBackColor = false;
            this.butSend.Click += new System.EventHandler(this.butSend_Click);
            // 
            // butVideo
            // 
            this.butVideo.BackColor = System.Drawing.Color.CornflowerBlue;
            this.butVideo.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.butVideo.BackgroundImage = global::PBL41.Properties.Resources.video;
            this.butVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butVideo.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.butVideo.BorderRadius = 10;
            this.butVideo.BorderSize = 0;
            this.butVideo.FlatAppearance.BorderSize = 0;
            this.butVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butVideo.ForeColor = System.Drawing.Color.White;
            this.butVideo.Location = new System.Drawing.Point(449, 12);
            this.butVideo.Name = "butVideo";
            this.butVideo.Size = new System.Drawing.Size(63, 50);
            this.butVideo.TabIndex = 4;
            this.butVideo.TextColor = System.Drawing.Color.White;
            this.butVideo.UseVisualStyleBackColor = false;
            this.butVideo.Click += new System.EventHandler(this.butVideo_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(4, 556);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(453, 59);
            this.txtMessage.TabIndex = 1;
            // 
            // vbButton2
            // 
            this.vbButton2.BackColor = System.Drawing.Color.White;
            this.vbButton2.BackgroundColor = System.Drawing.Color.White;
            this.vbButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.vbButton2.BorderRadius = 10;
            this.vbButton2.BorderSize = 0;
            this.vbButton2.FlatAppearance.BorderSize = 0;
            this.vbButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton2.ForeColor = System.Drawing.Color.White;
            this.vbButton2.Location = new System.Drawing.Point(616, 611);
            this.vbButton2.Name = "vbButton2";
            this.vbButton2.Size = new System.Drawing.Size(95, 77);
            this.vbButton2.TabIndex = 0;
            this.vbButton2.TextColor = System.Drawing.Color.White;
            this.vbButton2.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(419, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(524, 615);
            this.panel4.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 615);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnMain.ResumeLayout(false);
            this.pnMain.PerformLayout();
            this.panelMes.ResumeLayout(false);
            this.panelMes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFriend)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Panel panel3;
        private CustomButton.VBButton butMess;
        private CustomButton.VBButton butSet;
        private CustomButton.VBButton butFriend;
        private System.Windows.Forms.Panel panelMes;
        private System.Windows.Forms.DataGridView dgvFriend;
        private System.Windows.Forms.TextBox txtMessage;
        private CustomButton.VBButton vbButton2;
        private CustomButton.VBButton butVideo;
        private CustomButton.VBButton butSend;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private CustomButton.VBButton btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label4;
        private CustomButton.VBButton btnAdd;
        private System.Windows.Forms.Label lbMyName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListView LViewMessage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbLogout;
    }
}