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
            

            List<string> l = ChatClient.instance.getList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            foreach (string i in l)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = i;
                dt.Rows.Add(dr);
                ListMessage lms = new ListMessage(i);
                listMS.Add(lms);
            }
            dgvFriend.DataSource = dt;
            dgvFriend.Columns[0].ReadOnly = true;


            Thread th = new Thread(() => ReceiveMsg());
            th.IsBackground = true;
            th.Start();
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
                string name = dgvFriend.SelectedRows[0].Cells["Name"].Value.ToString();
                if (name.Equals(str[0]))
                {
                    LViewMessage.Items.Add(str[0] + ": " + str[1]);
                }
                foreach (ListMessage i in listMS)
                {
                    if(i.Name.Equals(str[0]))
                    {
                        i.addMessage(str[0] + ": " + str[1]);
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
                string name = dgvFriend.SelectedRows[0].Cells["Name"].Value.ToString();
                string s = "Tôi : " + txtMessage.Text + "\n";
                LViewMessage.Items.Add(s);             
                ChatClient.instance.SendMsg(name + " #msg: " + txtMessage.Text);
                // add message into list massage
                foreach(ListMessage i in listMS)
                {
                    if (i.Name == name)
                    {
                        i.addMessage(s);
                        break;
                    }                       
                }
            }
        }
        public void ReceiveMsg()
        {
            string msg = "";
            try
            {
                while (true)
                {
                    msg = ChatClient.instance.ReceiveMsg();
                    if (msg == null)
                    {
                        continue;
                    }
                    else
                    {
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
            string name = dgvFriend.SelectedRows[0].Cells["Name"].Value.ToString();
            LViewMessage.Items.Clear();
            foreach (ListMessage i in listMS)
            {
                if (i.Name == name)
                {
                    foreach (string j in i.getMessage())
                        LViewMessage.Items.Add(j);
                    break;
                }
            }
        }
    }
}
