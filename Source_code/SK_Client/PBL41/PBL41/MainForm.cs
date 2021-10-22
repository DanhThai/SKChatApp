using PBL41.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL41
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Thread th = new Thread(()=>ReceiveMsg());
            th.IsBackground = true;
            th.Start();
        }

        private void butSet_Click(object sender, EventArgs e)
        {
            FormCaNhan fc = new FormCaNhan();
            fc.TopLevel = false;
            panel4.Controls.Add(fc);
            fc.Dock = DockStyle.Fill;
            fc.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fc.Show();
            panel3.Visible = false;
        }

        private void butMess_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panelMes.Visible = true;
        }
        private void butFriend_Click(object sender, EventArgs e)
        {
            FormFriend fr = new FormFriend();
            fr.TopLevel = false;
            panel2.Controls.Add(fr);
            fr.Dock = DockStyle.Fill;
            fr.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fr.Show();
            panelMes.Visible = false;
        }

        private void butSend_Click(object sender, EventArgs e)
        {

            ChatClient.instance.SendMsg(txtMessage.Text);
            LViewMessage.Items.Add(txtMessage.Text + "\n");
            
        }
        public void ReceiveMsg()
        {
            
            string msg;
            try
            {
                while (true)
                {
                    msg = ChatClient.instance.ReceiveMsg();
                    if (msg == null)
                    {
                        Thread.Sleep(30000);
                        continue;
                    }
                    else
                    {
                        LViewMessage.Items.Add(msg+"\n");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }   
    }
    
}
