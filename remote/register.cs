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
   
    public partial class register : Form
    {

        public static Vline.Model.BUSI_User m_user = new Vline.Model.BUSI_User();
       public  Vline.BLL.BUSI_User b_user = new Vline.BLL.BUSI_User();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请输入用户名");
                return;
            }
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码");
                return;
            }
         
            List<Vline.Model.BUSI_User> list_user = b_user.GetModelList("UserZH='"+textBox1.Text.Trim()+ "' and PassWord='"+textBox2.Text+"' ");
            if (list_user.Count > 0)
            {
                m_user = list_user[0];

                Mainauditing main = new Mainauditing();
                main.Show();
                this.Hide();
              
            }
            else {
                MessageBox.Show("请输入正确的用户名和密码！");
                return;
            }
        }
    }
}
