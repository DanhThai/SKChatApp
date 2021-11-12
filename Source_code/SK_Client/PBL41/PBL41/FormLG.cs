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
            pnSignUp1.Visible = true;
            pnSignUp2.Visible = false;
        }

        private void butLogin2_Click(object sender, EventArgs e)
        {
            panelLG.Visible = true;
            pnSignUp1.Visible = false;

        }
        //an form login, dong mainform -> form login hien
        private void butLogin1_Click(object sender, EventArgs e)
        {

            if (txtUser1.Text == "User" || txtPass1.Text == "Pass")
            {
                MessageBox.Show("Nhập đầy đủ tài khoản, mật khẩu", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {              
                ChatClient.instance.ConnectSV();
                ChatClient.instance.SendLogin(txtUser1.Text, txtPass1.Text);
                bool check = ChatClient.instance.checkLogin();
                if (check)
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
            ChatClient.instance.Disconnect();
            this.Show();
        }

        private void text_Enter(object sender, EventArgs e)
        {
            TextBox a = (TextBox)sender;
            switch (a.Name)
            {
                case "txtUser1":
                    if (txtUser1.Text == "User")
                    {
                        txtUser1.Text = "";
                        txtUser1.ForeColor = Color.Black;
                    }
                    break;
                case "txtPass1":
                    if (txtPass1.Text == "Pass")
                    {
                        txtPass1.Text = "";
                        txtPass1.ForeColor = Color.Black;
                    }
                    break;
                case "txtUser2":
                    if (txtUser2.Text == "User")
                    {
                        txtUser2.Text = "";
                        txtUser2.ForeColor = Color.Black;
                    }
                    break;
                case "txtPass2":
                    if (txtPass2.Text == "Pass")
                    {
                        txtPass2.Text = "";
                        txtPass2.ForeColor = Color.Black;
                    }
                    break;
                case "txtConfirm2":
                    if (txtConfirm2.Text == "ConfirmPass")
                    {
                        txtConfirm2.Text = "";
                        txtConfirm2.ForeColor = Color.Black;
                    }
                    break;
                default: break;
            }
        }
        private void text_Leave(object sender, EventArgs e)
        {
            TextBox a = (TextBox)sender;
            switch (a.Name)
            {
                case "txtUser1":
                    if (txtUser1.Text == "")
                    {
                        txtUser1.Text = "User";
                        txtUser1.ForeColor = Color.Gray;
                    }
                    break;
                case "txtPass1":
                    if (txtPass1.Text == "")
                    {
                        txtPass1.Text = "Pass";
                        txtPass1.ForeColor = Color.Gray;
                    }
                    break;
                case "txtUser2":
                    if (txtUser2.Text == "")
                    {
                        txtUser2.Text = "User";
                        txtUser2.ForeColor = Color.Gray;
                    }
                    break;
                case "txtPass2":
                    if (txtPass2.Text == "")
                    {
                        txtPass2.Text = "Pass";
                        txtPass2.ForeColor = Color.Gray;
                    }
                    break;
                case "txtConfirm2":
                    if (txtConfirm2.Text == "")
                    {
                        txtConfirm2.Text = "ConfirmPass";
                        txtConfirm2.ForeColor = Color.Gray;
                    }
                    break;
                default: break;
            }
        }

        private void lbBack1_Click(object sender, EventArgs e)
        {
            panelLG.Visible = true;
            pnSignUp1.Visible = false;
            pnSignUp2.Visible = false;
        }

        private void lbBack2_Click(object sender, EventArgs e)
        {
            panelLG.Visible = false;
            pnSignUp1.Visible = true;
            pnSignUp2.Visible = false;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            panelLG.Visible = false;
            pnSignUp1.Visible = false;
            pnSignUp2.Visible = true;
        }
    }
}
