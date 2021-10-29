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
        public MainForm()
        {
            InitializeComponent();

            Thread th = new Thread(() => ReceiveMsg());
            th.IsBackground = true;
            th.Start();

            List<string> l = ChatClient.instance.getList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            foreach (string i in l)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = i;
                dt.Rows.Add(dr);
            }
            dgvMess.DataSource = dt;
            setDgv();
        }
        public void setDgv()
        { 
            dgvMess.Columns[0].ReadOnly = true;
            //dgvMess.Rows.Add("Thảo");
            //dgvMess.Rows.Add("Minh");
            //dgvMess.Rows.Add("Băng");
            //dgvMess.Rows.Add("Tuyên");
            //dgvMess.Rows.Add("Torres");
            
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
                for (int i = 0; i < dgvMess.Rows.Count; i++)
                {
                    string s = dgvMess.Rows[i].Cells["Name"].Value.ToString();
                    if (str[0].Equals(s))
                    {
                        LViewMessage.Items.Add(s + " : " + str[1] + "\n");
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
            if (dgvMess.SelectedRows.Count == 1)
            {

                string name = dgvMess.SelectedRows[0].Cells["Name"].Value.ToString();

                string s = "Tôi : " + txtMessage.Text + "\n";
                LViewMessage.Items.Add(s);
                //setListview(s);
                ChatClient.instance.SendMsg(name + " #msg: " + txtMessage.Text);
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
                        Console.WriteLine(msg);
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
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if(txtSearch.Text == "Search")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                txtSearch.Text = "Search";
                txtSearch.ForeColor = Color.Gray;
            }
        }

    }
}
