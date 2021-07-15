using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vline;


namespace remote
{
    public partial class Apply  : Form
    {
        Vline.BLL.DIC_TIME b_time = new Vline.BLL.DIC_TIME();
        Vline.Model.DIC_TIME m_time = new Vline.Model.DIC_TIME();

        Vline.BLL.BUSI_applyDetail b_detail = new Vline.BLL.BUSI_applyDetail();
        Vline.Model.BUSI_applyDetail m_detail = new Vline.Model.BUSI_applyDetail();

        Vline.Model.BUSI_User m_user = Login.m_user;

        public Apply()
        {
            InitializeComponent();
        }

        private void BindData()
        {
            label3.Text = m_user.UserName;
            List<Vline.Model.BUSI_applyDetail> list_detail = b_detail.GetModelList("sqDate='" + dateTimePicker1.Value + "'");

            List<Vline.Model.DIC_TIME> list_time = b_time.GetModelList("1=1");
            List<Vline.Model.DIC_TIME> list_time2 = new List<Vline.Model.DIC_TIME>();



            //checkedListBox1.Refresh();

            for (int i = 0; i < list_time.Count; i++)
            {

                foreach (Vline.Model.BUSI_applyDetail p_detail in list_detail)
                {

                    if (list_time[i].Describle == p_detail.Describle)
                    {

                        list_time2.Add(list_time[i]);
                        list_time.RemoveAt(i);
                    }
                    //else
                    //{
                    //    list_time3.Add(p_time);
                    //}
                }
            }
            checkedListBox1.DataSource = list_time;
            this.checkedListBox1.DisplayMember = "Describle";

            this.checkedListBox1.ValueMember = "id";
            //checkedListBox1.Visible = false;
            //int h =0;
            //foreach (Vline.Model.DIC_TIME p_tt in list_time)
            //{
                
            //CheckBox chkbox = new CheckBox();
            //    chkbox.Text = p_tt.Describle;
            //    chkbox.Location = new Point(6,7+ h * 17);
            //    groupBox2.Controls.Add(chkbox);
            //    h++;
        
            //}


            listBox1.DataSource = list_time2;
            this.listBox1.DisplayMember = "Describle";

            this.listBox1.ValueMember = "id";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            BindData();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           CheckedListBox.CheckedItemCollection list_chk = checkedListBox1.CheckedItems;
            //先获取申请的时间段，再判断所选择的时间段里面是否已经被人给申请
            foreach (Vline.Model.DIC_TIME chk in list_chk)
            {
                List<Vline.Model.BUSI_applyDetail> list_count= b_detail.GetModelList("sqDate='" + dateTimePicker1.Value + "' and Describle='"+chk.Describle+"'");
                if (list_count.Count > 0)
                {
                    MessageBox.Show("时间段"+chk.Describle + "已被别人申请，请重新选择");
                   
                    //BindData();
                  
                    return;
                }
            }
            //此时进行保存
            foreach (Vline.Model.DIC_TIME chk in list_chk)
            {
                m_detail.sqDate = dateTimePicker1.Value;
                m_detail.timeId = chk.id;
                m_detail.sqrid = m_user.id;
                m_detail.sqrsm = m_user.Detail;
                m_detail.sqrName = m_user.UserName;
                m_detail.startTime = chk.startTime;
                m_detail.endTime = chk.endTime;
                m_detail.Describle = chk.Describle;
                m_detail.state = "审核中";
                b_detail.Add(m_detail);
               // m_detail.sqrid=
            }
            MessageBox.Show("保存成功！");
        }

        private void Apply_Load(object sender, EventArgs e)
        {
            label3.Text = m_user.UserName;
        }

        //远程连接核心方法


    }
}
