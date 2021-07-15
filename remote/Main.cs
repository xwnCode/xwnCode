using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace remote
{
    public partial class Main : Form
    {
        Vline.BLL.BUSI_applyDetail b_detail = new Vline.BLL.BUSI_applyDetail();
        Vline.Model.BUSI_applyDetail m_detail = new Vline.Model.BUSI_applyDetail();
        Vline.Model.BUSI_User m_user = Login.m_user;
        public Main()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 申请_Click(object sender, EventArgs e)
        {
            Apply app = new Apply();
            app.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //m_detail.
            List<Vline.Model.BUSI_applyDetail> list_detail = b_detail.GetModelList("sqrid="+m_user.id+"");
            dataGridView1.DataSource = list_detail;
            
        }
    }
}
