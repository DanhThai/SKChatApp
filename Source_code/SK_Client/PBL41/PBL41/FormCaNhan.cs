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
            if(txtUser.Text == "" || txtPass.Text == "" || txtConfirm.Text == "")
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

    }
}
