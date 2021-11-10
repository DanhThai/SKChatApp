using Friend;
using PBL41.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PBL41
{
    public partial class MainForm : Form
    {
        private delegate void SafeCallDelegate(string text);
        private static List<ListMessage> listMS;
        public MainForm()
        {
            InitializeComponent();
            listMS = new List<ListMessage>();

            setDgv();

            Thread th = new Thread(() => ReceiveMsg());
            th.IsBackground = true;
            th.Start();
        }
        public void setDgv()
        {
            List<friend> l = ChatClient.instance.getList();

            foreach (friend i in l)
            {
                ListMessage lms = new ListMessage(i.ID);
                listMS.Add(lms);
            }
            dgvFriend.DataSource = l;
            dgvFriend.Columns["ID"].Visible = false;
            dgvFriend.Columns["IP"].Visible = false;
            dgvFriend.Columns["UpdateIP"].Visible = false;
            dgvFriend.Columns["Name"].ReadOnly = true;
            lbName.Text = dgvFriend.Rows[0].Cells["Name"].Value.ToString();
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        public void setListview(string msg)
        {
            if (LViewMessage.InvokeRequired)
            {
                var d = new SafeCallDelegate(setListview);
                LViewMessage.Invoke(d, new object[] { msg });
            }
            else
            {
                string[] str = msg.Split(new string[] { " #send: " }, StringSplitOptions.None);
                string id = dgvFriend.SelectedRows[0].Cells["ID"].Value.ToString();
                string name = dgvFriend.SelectedRows[0].Cells["Name"].Value.ToString();
                if (id.Equals(str[0]))
                {
                    LViewMessage.Items.Add(name + ": " + str[1]);
                }
                foreach (ListMessage i in listMS)
                {
                    if(i.ID==Convert.ToInt32( str[0]))
                    {
                        Console.WriteLine(str[1]);
                        i.addMessage(name + ": " + str[1]);
                        break;
                    }    
                       
                }                                 
            }


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
            if (dgvFriend.SelectedRows.Count == 1)
            {
                string msg;
                bool upIp= (bool)dgvFriend.SelectedRows[0].Cells["UpdateIP"].Value;
                int id = (int)dgvFriend.SelectedRows[0].Cells["ID"].Value;
                if (upIp)
                {
                    string ip = dgvFriend.SelectedRows[0].Cells["IP"].Value.ToString();
                    msg = "#IP: " + ip + " #msg: " + txtMessage.Text;
                }
                else
                {
                    
                    msg = "#ID: " + id +" #msg: "+ txtMessage.Text;
                }                                                   
                string s = "Tôi : " + txtMessage.Text + "\n";
                LViewMessage.Items.Add(s);             
                ChatClient.instance.SendMsg(msg);
                // add message into list massage
                foreach(ListMessage i in listMS)
                {
                    if (i.ID == id)
                    {
                        i.addMessage(s);
                        break;
                    }                       
                }
            }
        }
        public void ReceiveMsg()
        {
           
            try
            {
                string msg = "";
                while (true)
                {
                    msg = ChatClient.instance.ReceiveMsg();
                    if (msg == null)
                    {
                        continue;
                    }
                    else
                    {
                        if(msg.Contains("#UpdateIP"))
                        {
                            setDgv();
                        }   
                        else
                            setListview(msg);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void butVideo_Click(object sender, EventArgs e)
        {
            FormCall f = new FormCall();
            f.Show();
        }       

        private void dgvFriend_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dgvFriend.SelectedRows[0].Cells["ID"].Value;
            lbName.Text= dgvFriend.SelectedRows[0].Cells["Name"].Value.ToString();
            LViewMessage.Items.Clear();
            foreach (ListMessage i in listMS)
            {
                if (i.ID == id)
                {
                    foreach (string j in i.getMessage())
                        LViewMessage.Items.Add(j);
                    break;
                }
            }
        }
    }
}
