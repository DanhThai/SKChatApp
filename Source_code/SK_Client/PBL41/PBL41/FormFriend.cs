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
    public partial class FormFriend : Form
    {
        public FormFriend()
        {
            InitializeComponent();
            setDGV();
        }
        public void setDGV()
        {
            dgvFriend.Columns[0].Width = 25;
            dgvFriend.Rows.Add(false, "Thảo");
            dgvFriend.Rows.Add(false, "Minh");
            dgvFriend.Rows.Add(false, "Băng");
            dgvFriend.Rows.Add(false, "Tuyên");
            dgvFriend.Rows.Add(false, "Torres");
        }

    }
}
