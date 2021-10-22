
namespace PBL41
{
    partial class FormFriend
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
            this.panelGroup = new System.Windows.Forms.Panel();
            this.dataGrvFr = new System.Windows.Forms.DataGridView();
            this.butCreate = new CustomButton.VBButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panelGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrvFr)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGroup
            // 
            this.panelGroup.BackColor = System.Drawing.SystemColors.GrayText;
            this.panelGroup.Controls.Add(this.dataGrvFr);
            this.panelGroup.Controls.Add(this.butCreate);
            this.panelGroup.Controls.Add(this.label2);
            this.panelGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelGroup.Location = new System.Drawing.Point(0, 1);
            this.panelGroup.Name = "panelGroup";
            this.panelGroup.Size = new System.Drawing.Size(289, 547);
            this.panelGroup.TabIndex = 3;
            // 
            // dataGrvFr
            // 
            this.dataGrvFr.BackgroundColor = System.Drawing.SystemColors.GrayText;
            this.dataGrvFr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrvFr.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.dataGrvFr.Location = new System.Drawing.Point(-1, 106);
            this.dataGrvFr.Name = "dataGrvFr";
            this.dataGrvFr.RowHeadersWidth = 51;
            this.dataGrvFr.RowTemplate.Height = 24;
            this.dataGrvFr.Size = new System.Drawing.Size(290, 374);
            this.dataGrvFr.TabIndex = 3;
            // 
            // butCreate
            // 
            this.butCreate.BackColor = System.Drawing.Color.AliceBlue;
            this.butCreate.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.butCreate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.butCreate.BorderRadius = 20;
            this.butCreate.BorderSize = 0;
            this.butCreate.FlatAppearance.BorderSize = 0;
            this.butCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCreate.ForeColor = System.Drawing.Color.Black;
            this.butCreate.Location = new System.Drawing.Point(71, 486);
            this.butCreate.Name = "butCreate";
            this.butCreate.Size = new System.Drawing.Size(125, 58);
            this.butCreate.TabIndex = 2;
            this.butCreate.Text = "Create Group";
            this.butCreate.TextColor = System.Drawing.Color.Black;
            this.butCreate.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GrayText;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(70, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "List Friend";
            // 
            // FormFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(289, 548);
            this.Controls.Add(this.panelGroup);
            this.Name = "FormFriend";
            this.Text = "FormFriend";
            this.panelGroup.ResumeLayout(false);
            this.panelGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrvFr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGroup;
        private System.Windows.Forms.Label label2;
        private CustomButton.VBButton butCreate;
        private System.Windows.Forms.DataGridView dataGrvFr;
    }
}