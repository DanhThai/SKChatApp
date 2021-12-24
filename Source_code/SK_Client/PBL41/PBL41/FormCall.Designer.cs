namespace PBL41
{
    partial class FormCall
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
            this.lbMe = new System.Windows.Forms.Label();
            this.lbYou = new System.Windows.Forms.Label();
            this.btnStopMicro = new CustomButton.VBButton();
            this.btnStartMicro = new CustomButton.VBButton();
            this.butCancel = new CustomButton.VBButton();
            this.pictureBoxMe = new System.Windows.Forms.PictureBox();
            this.pictureBoxFriend = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMe
            // 
            this.lbMe.AutoSize = true;
            this.lbMe.BackColor = System.Drawing.Color.White;
            this.lbMe.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMe.Location = new System.Drawing.Point(344, 21);
            this.lbMe.Name = "lbMe";
            this.lbMe.Size = new System.Drawing.Size(120, 31);
            this.lbMe.TabIndex = 2;
            this.lbMe.Text = "NameMe";
            // 
            // lbYou
            // 
            this.lbYou.AutoSize = true;
            this.lbYou.BackColor = System.Drawing.Color.White;
            this.lbYou.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYou.Location = new System.Drawing.Point(560, 21);
            this.lbYou.Name = "lbYou";
            this.lbYou.Size = new System.Drawing.Size(127, 31);
            this.lbYou.TabIndex = 2;
            this.lbYou.Text = "NameYou";
            // 
            // btnStopMicro
            // 
            this.btnStopMicro.BackColor = System.Drawing.Color.Gainsboro;
            this.btnStopMicro.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.btnStopMicro.BackgroundImage = global::PBL41.Properties.Resources.StopMicro;
            this.btnStopMicro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStopMicro.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnStopMicro.BorderRadius = 10;
            this.btnStopMicro.BorderSize = 0;
            this.btnStopMicro.FlatAppearance.BorderSize = 0;
            this.btnStopMicro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopMicro.ForeColor = System.Drawing.Color.White;
            this.btnStopMicro.Location = new System.Drawing.Point(421, 521);
            this.btnStopMicro.Margin = new System.Windows.Forms.Padding(25);
            this.btnStopMicro.Name = "btnStopMicro";
            this.btnStopMicro.Size = new System.Drawing.Size(64, 65);
            this.btnStopMicro.TabIndex = 1;
            this.btnStopMicro.TextColor = System.Drawing.Color.White;
            this.btnStopMicro.UseVisualStyleBackColor = false;
            this.btnStopMicro.Click += new System.EventHandler(this.btnStopMicro_Click);
            // 
            // btnStartMicro
            // 
            this.btnStartMicro.BackColor = System.Drawing.Color.Gainsboro;
            this.btnStartMicro.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.btnStartMicro.BackgroundImage = global::PBL41.Properties.Resources.micro;
            this.btnStartMicro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartMicro.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnStartMicro.BorderRadius = 10;
            this.btnStartMicro.BorderSize = 0;
            this.btnStartMicro.FlatAppearance.BorderSize = 0;
            this.btnStartMicro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartMicro.ForeColor = System.Drawing.Color.White;
            this.btnStartMicro.Location = new System.Drawing.Point(421, 521);
            this.btnStartMicro.Margin = new System.Windows.Forms.Padding(25);
            this.btnStartMicro.Name = "btnStartMicro";
            this.btnStartMicro.Size = new System.Drawing.Size(64, 65);
            this.btnStartMicro.TabIndex = 1;
            this.btnStartMicro.TextColor = System.Drawing.Color.White;
            this.btnStartMicro.UseVisualStyleBackColor = false;
            this.btnStartMicro.Click += new System.EventHandler(this.btnStartMicro_Click);
            // 
            // butCancel
            // 
            this.butCancel.BackColor = System.Drawing.Color.Tomato;
            this.butCancel.BackgroundColor = System.Drawing.Color.Tomato;
            this.butCancel.BackgroundImage = global::PBL41.Properties.Resources.Call1;
            this.butCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.butCancel.BorderRadius = 10;
            this.butCancel.BorderSize = 0;
            this.butCancel.FlatAppearance.BorderSize = 0;
            this.butCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCancel.ForeColor = System.Drawing.Color.White;
            this.butCancel.Location = new System.Drawing.Point(535, 521);
            this.butCancel.Margin = new System.Windows.Forms.Padding(25);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(64, 65);
            this.butCancel.TabIndex = 1;
            this.butCancel.TextColor = System.Drawing.Color.White;
            this.butCancel.UseVisualStyleBackColor = false;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // pictureBoxMe
            // 
            this.pictureBoxMe.BackgroundImage = global::PBL41.Properties.Resources.nen;
            this.pictureBoxMe.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxMe.Name = "pictureBoxMe";
            this.pictureBoxMe.Size = new System.Drawing.Size(483, 481);
            this.pictureBoxMe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMe.TabIndex = 0;
            this.pictureBoxMe.TabStop = false;
            // 
            // pictureBoxFriend
            // 
            this.pictureBoxFriend.BackgroundImage = global::PBL41.Properties.Resources.Uchiha_Sasuke1;
            this.pictureBoxFriend.Location = new System.Drawing.Point(535, 12);
            this.pictureBoxFriend.Name = "pictureBoxFriend";
            this.pictureBoxFriend.Size = new System.Drawing.Size(483, 481);
            this.pictureBoxFriend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFriend.TabIndex = 0;
            this.pictureBoxFriend.TabStop = false;
            // 
            // FormCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1030, 625);
            this.Controls.Add(this.lbYou);
            this.Controls.Add(this.lbMe);
            this.Controls.Add(this.btnStopMicro);
            this.Controls.Add(this.btnStartMicro);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.pictureBoxMe);
            this.Controls.Add(this.pictureBoxFriend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormCall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCall";
            this.Load += new System.EventHandler(this.FormCall_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFriend;
        private System.Windows.Forms.PictureBox pictureBoxMe;
        private CustomButton.VBButton butCancel;
        private System.Windows.Forms.Label lbMe;
        private System.Windows.Forms.Label lbYou;
        private CustomButton.VBButton btnStartMicro;
        private CustomButton.VBButton btnStopMicro;
    }
}