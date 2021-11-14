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
        private delegate void SafeCallDelegateLV(string text);
        private delegate void SafeCallDelegateDgv();
        private static List<ListMessage> listMS;
        public MainForm()
        {
            InitializeComponent();
            dgvFriend.Height = 380;
            txtSearch.ReadOnly = true;
            listMS = new List<ListMessage>();

            setDgv();

            Thread th = new Thread(() => ReceiveMsg());
            th.IsBackground = true;
            th.Start();
        }
        public void setDgv()
        {
            List<friend> l = ChatClient.instance.getListFriend();

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

        public void setDgvFriend()
        {
            if (dgvFriend.InvokeRequired)
            {
                var d = new SafeCallDelegateDgv(setDgvFriend);
                dgvFriend.Invoke(d);
            }
            else
            {
                List<friend> listFr = ChatClient.instance.checkFriend();
                
                if (listFr.Count <1)              
                    MessageBox.Show("Không tìm thấy bạn bè");
                dgvFriend.DataSource = listFr;
                dgvFriend.Columns["ID"].Visible = false;
                dgvFriend.Columns["IP"].Visible = false;
                dgvFriend.Columns["UpdateIP"].Visible = false;
                dgvFriend.Columns["Name"].ReadOnly = true;
            }    

        }
        public void setListview(string msg)
        {
            if (LViewMessage.InvokeRequired)
            {
                var d = new SafeCallDelegateLV(setListview);
                LViewMessage.Invoke(d, new object[] { msg });
            }
            else
            {
                string[] str = msg.Split(new string[] { " #send: " }, StringSplitOptions.None);
                Console.WriteLine(str[0]);
                string id = dgvFriend.SelectedRows[0].Cells["ID"].Value.ToString();
                string name = dgvFriend.SelectedRows[0].Cells["Name"].Value.ToString();
                if (id.Equals(str[0]))
                {
                    LViewMessage.Items.Add(name + ": " + str[1]);
                }
                foreach (ListMessage i in listMS)
                {
                    if(i.ID==Convert.ToInt32(str[0]))
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
            dgvFriend.Height = 380;
            btnAdd.Visible = false;
            setDgv();
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
            txtMessage.Text = "";
        }
        private void butFriend_Click(object sender, EventArgs e)
        {
            dgvFriend.Height = 320;
            dgvFriend.DataSource = null;
            btnAdd.Visible = true;
            txtSearch.ReadOnly = false;
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (dgvFriend.SelectedRows.Count == 1)
            {
                dgvFriend.Height = 484;
                btnAdd.Visible = false;
                int id = (int)dgvFriend.SelectedRows[0].Cells["ID"].Value;
                string ip = dgvFriend.SelectedRows[0].Cells["IP"].Value.ToString();
                string name = dgvFriend.SelectedRows[0].Cells["Name"].Value.ToString();

                friend fr = new friend(id, ip, name);
                ChatClient.instance.addFriend(fr);
                setDgv();
            }
            else
                MessageBox.Show("Chỉ được chọn 1 người");
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != null)
            {
                ChatClient.instance.SendSearch(txtSearch.Text);                             
            }
            else
                MessageBox.Show("Hãy nhập tên tìm kiếm");
        }
        public void ReceiveMsg()
        {         
            try
            {
                string msg = "";
                while (true)
                {
                    msg = ChatClient.instance.ReceiveMsg();
                    Console.WriteLine(msg);
                    if (msg == null)
                    {
                        continue;
                    }
                       
                    else if(msg.Contains("#UpdateIP:"))
                    {
                        
                        setDgv();  
                        
                    }
                    else if(msg.Contains("#Search"))
                    {
                        
                        setDgvFriend();
                    }
                    else
                        setListview(msg);
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
        private void lbLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
    }
}
