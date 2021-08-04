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

      
        Vline.BLL.BUSI_OperateHistory b_history = new Vline.BLL.BUSI_OperateHistory();
        Vline.Model.BUSI_OperateHistory m_history= new Vline.Model.BUSI_OperateHistory();
        Vline.Model.BUSI_User m_user = Login.m_user;
        DataTable dtHistory = new DataTable();
        DateTime LastTime=Convert .ToDateTime("1900-1-1");
        public Apply()
        {
            InitializeComponent();
        }
        private bool IsApply()
        {
            //判断七日内申请的是否有操作，还是浪费了没有使用
            bool istrue = true;
            string sql ="select sqDate,(select count(*) from BUSI_OperateHistory where OperateDate=sqDate and userid=" + m_user.id + " )  as js   from BUSI_applyDetail where DateDiff(dd,sqDate,'" + dateTimePicker1.Value+ "')<=7  and DateDiff(dd,sqDate,'" + dateTimePicker1.Value + "')>=0 and sqdate<GETDATE() and sqrid="+m_user.id+"";
            DataSet dsHis = Maticsoft.DBUtility.DbHelperSQL.Query(sql);
            if (dsHis != null && dsHis.Tables.Count > 0)//表为空的话代表其七天内没有申请记录，可以直接申请，不需要赋值
            {
                dtHistory = dsHis.Tables[0];
                foreach (DataRow dr in dtHistory.Rows)
                {
                    if (dr["js"].ToString() == "0")
                    {
                        DateTime currentTime = Convert.ToDateTime(dr["sqDate"]);
                        if (LastTime < currentTime)
                        {
                            LastTime = currentTime;
                        }
                        istrue = false;
                    }
                }
            }       
            return istrue;
          
        }
        private void BindData()
        {
            label3.Text = m_user.UserName;
            //筛选选择的日期是否符合申请条件select *  from BUSI_applyDetail where DateDiff(dd,sqDate,'2021-8-2')<=7  and DateDiff(dd,sqDate,'2021-8-2')>=0 and sqdate<GETDATE() and sqrid=1
            if (IsApply())
            {
                //checkedListBox1.Refresh();
                List<Vline.Model.BUSI_applyDetail> list_detail = b_detail.GetModelList("sqDate='" + dateTimePicker1.Value + "'");
                List<Vline.Model.DIC_TIME> list_time = b_time.GetModelList("1=1");
                List<Vline.Model.DIC_TIME> list_time2 = new List<Vline.Model.DIC_TIME>();
                for (int i = 0; i < list_time.Count; i++)
                {

                    foreach (Vline.Model.BUSI_applyDetail p_detail in list_detail)
                    {

                        if (list_time[i].Describle == p_detail.Describle)
                        {

                            list_time2.Add(list_time[i]);
                            list_time.RemoveAt(i);
                        }
                    }
                }
                checkedListBox1.DataSource = list_time;
                this.checkedListBox1.DisplayMember = "Describle";
                this.checkedListBox1.ValueMember = "id";
                listBox1.DataSource = list_time2;
                this.listBox1.DisplayMember = "Describle";
                this.listBox1.ValueMember = "id";
            }
            else {
                if (LastTime.ToString() != "1900-1-1")
                {
                    DateTime dateApply = LastTime.AddDays(7);
                    MessageBox.Show("系统检测因前期申请没有及时使用，请申请"+dateApply+"日后的日期");
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            BindData();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //先判断七日内已经申请了几次，次数不可超过两次
            int count = b_detail.GetRecordCount("DateDiff(dd,sqDate,'"+dateTimePicker1.Value+ "')<=7  and DateDiff(dd,sqDate,'" + dateTimePicker1.Value + "')>=0  and sqrid="+m_user.id+"");
            if (count < 2)
            {
                CheckedListBox.CheckedItemCollection list_chk = checkedListBox1.CheckedItems;
                if (list_chk.Count + count > 2)
                {
                    MessageBox.Show("七日内已经申请了"+count+"次，只可勾选"+(2-count)+"项");
                }
                else { 
                //先获取申请的时间段，再判断所选择的时间段里面是否已经被人给申请
                foreach (Vline.Model.DIC_TIME chk in list_chk)
                {
                    List<Vline.Model.BUSI_applyDetail> list_count = b_detail.GetModelList("sqDate='" + dateTimePicker1.Value + "' and Describle='" + chk.Describle + "'");
                    if (list_count.Count > 0)
                    {
                        MessageBox.Show("时间段" + chk.Describle + "已被别人申请，请重新选择");

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
                    m_detail.state = "已审核";
                    b_detail.Add(m_detail);
                    // m_detail.sqrid=
                }
                MessageBox.Show("保存成功！");
                }
            }
            else {
                MessageBox.Show("七日内申请次数已经达到了2次，请选择其他日期");
            }
        }

        private void Apply_Load(object sender, EventArgs e)
        {
            label3.Text = m_user.UserName;
        }

        //远程连接核心方法


    }
}
