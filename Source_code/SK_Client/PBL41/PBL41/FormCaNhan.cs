using PBL41.Client;
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
        bool isCancel = true;
        public FormCaNhan()
        {
            InitializeComponent();
            // Cài đặt thuộc tính pictureBox
            //pictureAvt.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void butChangePass_Click(object sender, EventArgs e)
        {
            panelChangePass.Visible = true;
            txtUser.Text = InfUser.instance.User;
        }

        private void butConfirm_Click(object sender, EventArgs e)
        {

            if ((txtOldPass.Text != InfUser.instance.PassWord) || (txtOldPass.Text == "") || (txtNewPass.Text == ""))
            {
                MessageBox.Show("Thông tin chua chinh xac", "Lỗi thông tin", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                ChatClient.instance.SendAcc(txtUser.Text, txtNewPass.Text);
                panelChangePass.Visible = false;

            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLG lg = new FormLG();
            lg.Show();
        }

        //private void butAdd_Click(object sender, EventArgs e)
        //{
        //if (result == DialogResult.OK)
        //{
        //    Lấy hình ảnh
        //   Image img = Image.FromFile(openFileDialog1.FileName);
        //    Gán ảnh
        //    pictureAvt.Image = img;
        //}

        //OpenFileDialog dlg = new OpenFileDialog();
        //if (dlg.ShowDialog() == DialogResult.OK)
        //{
        //    //string fileName;
        //    //fileName = dlg.FileName;
        //    //MessageBox.Show(fileName);
        //    Image img = Image.FromFile(dlg.FileName);
        //    pictureAvt.Image = img;
        //}
        //dlg.Title = "C# Căn bản chấm Com";
        //dlg.InitialDirectory = @"C:pathtofile";
        //dlg.Filter = "All files (*.*)|*.*|All files(*.*) | *.* ";
        //dlg.FilterIndex = 1;
        //dlg.RestoreDirectory = true;
        //}
        private void txtUser2_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "User")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }
        private void txtUser2_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "User";
                txtUser.ForeColor = Color.Gray;
            }
        }


        private void txtOldPass_Leave(object sender, EventArgs e)
        {
            if (txtOldPass.Text == "")
            {
                txtOldPass.Text = "Old Pass";
                txtOldPass.ForeColor = Color.Gray;
            }
        }

        private void txtOldPass_Enter(object sender, EventArgs e)
        {
            if (txtOldPass.Text == "Old Pass")
            {
                txtOldPass.Text = "";
                txtOldPass.ForeColor = Color.Black;
            }
        }

        private void txtNewPass_Leave(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "")
            {
                txtNewPass.Text = "New Pass";
                txtNewPass.ForeColor = Color.Gray;
            }
        }

        private void txtNewPass_Enter(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "New Pass")
            {
                txtNewPass.Text = "";
                txtNewPass.ForeColor = Color.Black;
            }
        }
    }
}
