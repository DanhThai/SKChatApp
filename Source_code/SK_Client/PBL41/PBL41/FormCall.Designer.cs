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
            this.butCancel = new CustomButton.VBButton();
            this.pictureBoxFriend = new System.Windows.Forms.PictureBox();
            this.pictureBoxMe = new System.Windows.Forms.PictureBox();
            this.lbMe = new System.Windows.Forms.Label();
            this.lbYou = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMe)).BeginInit();
            this.SuspendLayout();
            // 
            // butCancel
            // 
            this.butCancel.BackColor = System.Drawing.Color.Red;
            this.butCancel.BackgroundColor = System.Drawing.Color.Red;
            this.butCancel.BackgroundImage = global::PBL41.Properties.Resources.Call1;
            this.butCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.butCancel.BorderRadius = 10;
            this.butCancel.BorderSize = 0;
            this.butCancel.FlatAppearance.BorderSize = 0;
            this.butCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCancel.ForeColor = System.Drawing.Color.White;
            this.butCancel.Location = new System.Drawing.Point(446, 421);
            this.butCancel.Margin = new System.Windows.Forms.Padding(25);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(74, 72);
            this.butCancel.TabIndex = 1;
            this.butCancel.TextColor = System.Drawing.Color.White;
            this.butCancel.UseVisualStyleBackColor = false;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // pictureBoxFriend
            // 
            this.pictureBoxFriend.BackgroundImage = global::PBL41.Properties.Resources.nen;
            this.pictureBoxFriend.Location = new System.Drawing.Point(3, 0);
            this.pictureBoxFriend.Name = "pictureBoxFriend";
            this.pictureBoxFriend.Size = new System.Drawing.Size(404, 417);
            this.pictureBoxFriend.TabIndex = 0;
            this.pictureBoxFriend.TabStop = false;
            this.pictureBoxFriend.Click += new System.EventHandler(this.pictureBoxFriend_Click);
            // 
            // pictureBoxMe
            // 
            this.pictureBoxMe.BackgroundImage = global::PBL41.Properties.Resources.Uchiha_Sasuke1;
            this.pictureBoxMe.Location = new System.Drawing.Point(574, 0);
            this.pictureBoxMe.Name = "pictureBoxMe";
            this.pictureBoxMe.Size = new System.Drawing.Size(402, 417);
            this.pictureBoxMe.TabIndex = 0;
            this.pictureBoxMe.TabStop = false;
            // 
            // lbMe
            // 
            this.lbMe.AutoSize = true;
            this.lbMe.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMe.Location = new System.Drawing.Point(585, 9);
            this.lbMe.Name = "lbMe";
            this.lbMe.Size = new System.Drawing.Size(86, 23);
            this.lbMe.TabIndex = 2;
            this.lbMe.Text = "NameMe";
            // 
            // lbYou
            // 
            this.lbYou.AutoSize = true;
            this.lbYou.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYou.Location = new System.Drawing.Point(316, 9);
            this.lbYou.Name = "lbYou";
            this.lbYou.Size = new System.Drawing.Size(80, 20);
            this.lbYou.TabIndex = 2;
            this.lbYou.Text = "NameYou";
            // 
            // FormCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 564);
            this.Controls.Add(this.lbYou);
            this.Controls.Add(this.lbMe);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.pictureBoxFriend);
            this.Controls.Add(this.pictureBoxMe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCall";
            this.Text = "FormCall";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMe;
        private System.Windows.Forms.PictureBox pictureBoxFriend;
        private CustomButton.VBButton butCancel;
        private System.Windows.Forms.Label lbMe;
        private System.Windows.Forms.Label lbYou;
    }
}