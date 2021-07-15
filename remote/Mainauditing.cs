﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace remote
{
    public partial class Mainauditing : Form
    {
        Vline.BLL.BUSI_applyDetail b_detail = new Vline.BLL.BUSI_applyDetail();
        Vline.Model.BUSI_applyDetail m_detail = new Vline.Model.BUSI_applyDetail();
        Vline.Model.BUSI_User m_user = Login.m_user;
        public Mainauditing()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //不是序号列和标题列时才执行
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                //checkbox 勾上
                if ((bool)dataGridView1.Rows[e.RowIndex].Cells[0].EditedFormattedValue == true)
                {
                    //选中改为不选中
                    this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = false;
                }
                else
                {
                    //不选中改为选中
                    this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }

        }
        private void BindData()
        {
            //m_detail.
            List<Vline.Model.BUSI_applyDetail> list_detail = b_detail.GetModelList("sqrid=" + m_user.id + "");
            dataGridView1.DataSource = list_detail;


        }
        private void 申请_Click(object sender, EventArgs e)
        {
            Apply app = new Apply();
            app.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells[0].EditedFormattedValue == true)
                {
                    m_detail=b_detail.GetModel(Convert .ToInt32( dataGridView1.Rows[i].Cells["id"].Value));
                    m_detail.state = "已审核";
                    b_detail.Update(m_detail);
                }
            }
            MessageBox.Show("审核成功");
            BindData();
        }
    }
}