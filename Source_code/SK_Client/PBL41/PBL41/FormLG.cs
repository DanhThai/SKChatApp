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
    public partial class FormLG : Form
    {
        public FormLG()
        {
            InitializeComponent(); 
        }

        private void butSignUp1_Click(object sender, EventArgs e)
        {
            panelLG.Visible = false;
            panelSU.Visible = true;
        }

        private void butLogin2_Click(object sender, EventArgs e)
        {
            panelLG.Visible = true;
            panelSU.Visible = false;
        }
        //an form login, dong mainform -> form login hien
        private void butLogin1_Click(object sender, EventArgs e)
        {
            
            if(txtUser1.Text == "" || txtPass1.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ tài khoản, mật khẩu", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                ChatClient.instance.SendLogin(txtUser1.Text, txtPass1.Text);
                string check = ChatClient.instance.ReceiveLogin();
                if(check=="true")
                {
                    MainForm mf = new MainForm();
                    mf.FormClosed += new FormClosedEventHandler(MainForm_Closed);
                    mf.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void MainForm_Closed(Object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        
    }
}
