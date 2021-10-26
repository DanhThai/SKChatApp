using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL41
{
    public partial class FormCaNhan : Form
    {
        public FormCaNhan()
        {
            InitializeComponent();
            // Cài đặt thuộc tính pictureBox
            pictureAvt.SizeMode = PictureBoxSizeMode.Zoom;    
        }
        private void butChangePass_Click(object sender, EventArgs e)
        {
            panelChangePass.Visible = true;
        }

        private void butConfirm_Click(object sender, EventArgs e)
        {
            if(txtUser2.Text == "" || txtPass2.Text == "" || txtConfirm2.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin", "Lỗi thông tin", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                panelChangePass.Visible = false;
            }     
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            //if (result == DialogResult.OK)
            //{
            //    Lấy hình ảnh
            //   Image img = Image.FromFile(openFileDialog1.FileName);
            //    Gán ảnh
            //    pictureAvt.Image = img;
            //}

            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //string fileName;
                //fileName = dlg.FileName;
                //MessageBox.Show(fileName);
                Image img = Image.FromFile(dlg.FileName);
                pictureAvt.Image = img;
            }
            //dlg.Title = "C# Căn bản chấm Com";
            //dlg.InitialDirectory = @"C:pathtofile";
            //dlg.Filter = "All files (*.*)|*.*|All files(*.*) | *.* ";
            //dlg.FilterIndex = 1;
            //dlg.RestoreDirectory = true;
        }
        private void txtUser2_Enter(object sender, EventArgs e)
        {
            if (txtUser2.Text == "User")
            {
                txtUser2.Text = "";
                txtUser2.ForeColor = Color.Black;
            }
        }
        private void txtUser2_Leave(object sender, EventArgs e)
        {
            if (txtUser2.Text == "")
            {
                txtUser2.Text = "User";
                txtUser2.ForeColor = Color.Gray;
            }
        }
        private void txtPass2_Enter(object sender, EventArgs e)
        {
            if (txtPass2.Text == "Pass")
            {
                txtPass2.Text = "";
                txtPass2.ForeColor = Color.Gray;
            }
        }
        private void txtPass2_Leave(object sender, EventArgs e)
        {
            if (txtPass2.Text == "")
            {
                txtPass2.Text = "Pass";
                txtPass2.ForeColor = Color.Gray;
            }
        }
        private void txtConfirm2_Enter(object sender, EventArgs e)
        {
            if (txtConfirm2.Text == "ConfirmPass")
            {
                txtConfirm2.Text = "";
                txtConfirm2.ForeColor = Color.Gray;
            }
        }
        private void txtConfirm2_Leave(object sender, EventArgs e)
        {
            if (txtConfirm2.Text == "")
            {
                txtConfirm2.Text = "ConfirmPass";
                txtConfirm2.ForeColor = Color.Gray;
            }
        }

    }
}
