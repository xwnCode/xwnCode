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
    public partial class Form2 : Form
    {
        Vline.BLL.BUSI_OperateHistory b_history = new Vline.BLL.BUSI_OperateHistory();
        Vline.Model.BUSI_OperateHistory m_history = new Vline.Model.BUSI_OperateHistory();
        Vline.Model.BUSI_applyDetail m_detail = Mainauditing.m_detail;
        Vline.Model.BUSI_User m_user = Login.m_user;
        private AxMSTSCLib.AxMsRdpClient7 rdpc = null;
        private DateTime observeTime;
        int OperateMinute = 0;
        public Form2()
        {
            InitializeComponent();
        
        }
        protected void OnCreateControl()
        {
           
        }
        //远程连接核心方法

        protected void OnCreateControlMsg()
        {
            rdpc = new AxMSTSCLib.AxMsRdpClient7();
            rdpc.OnDisconnected += new AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEventHandler(rdpc_OnDisconnected);
            this.Controls.Add(rdpc);
            rdpc.Dock = DockStyle.Fill;
            rdpc.BringToFront();
            Machine mc = new Machine();

            Connect(mc);
            observeTime = DateTime.Now;
            timer1.Start();

        }

        void rdpc_OnDisconnected(object sender, AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEvent e)
        {
            //处理断开连接,计入历史记录表

           
            this.Dispose();
            this.Close();
        }

       
        public void Disconnect()
        {
            try
            {
                if (rdpc.Connected == 1)
                {
                    rdpc.Disconnect();
                  
                    MessageBox.Show("可操控时间到期！");
                }
            }
            catch (Exception)
            {

            }

        }

        private void SetRdpClientProperties(Machine parMachine)
        {
            //rdpc.Server = parMachine.MachineName;
            //rdpc.AdvancedSettings2.RDPPort = parMachine.Port;
            //rdpc.UserName = parMachine.UserName;
            //rdpc.Domain = parMachine.DomainName;
            //if (parMachine.Password != "")
            //{
            //    rdpc.AdvancedSettings5.ClearTextPassword = parMachine.Password;
            //}
            //rdpc.AdvancedSettings5.RedirectDrives = parMachine.ShareDiskDrives;
            //rdpc.AdvancedSettings5.RedirectPrinters = parMachine.SharePrinters;
            //rdpc.ColorDepth = (int)parMachine.ColorDepth;


            rdpc.Server = "47.110.143.175";
            rdpc.AdvancedSettings2.RDPPort = 3389;
            rdpc.UserName = "Administrator";
            //rdpc.Domain = parMachine.DomainName;
            //if (parMachine.Password != "")
            //{
            //    rdpc.AdvancedSettings5.ClearTextPassword = parMachine.Password;
            //}
            rdpc.AdvancedSettings5.ClearTextPassword = "qwerty@123456";
            rdpc.AdvancedSettings5.RedirectDrives = true;
            rdpc.AdvancedSettings5.RedirectPrinters = true;
            //rdpc.ColorDepth = (int)parMachine.ColorDepth;
        }

        public void Connect(Machine parMachine)
        {
            SetRdpClientProperties(parMachine);
            rdpc.Connect();
        


        }

        //远程主机配置
        [Serializable()]
        public class Machine
        {
            private string _RemoteDesktopConnectionName;
            public string RemoteDesktopConnectionName
            {
                get { return _RemoteDesktopConnectionName; }
                set { _RemoteDesktopConnectionName = value; }
            }

            private string _MachineName;
            public string MachineName
            {
                get { return _MachineName; }
                set { _MachineName = value; }
            }
            private string _DomainName;
            public string DomainName
            {
                get { return _DomainName; }
                set { _DomainName = value; }
            }

            private string _UserName;
            public string UserName
            {
                get { return _UserName; }
                set { _UserName = value; }
            }

            private string _Password;
            public string Password
            {
                get { return _Password; }
                set { _Password = value; }
            }

            private bool _AutoConnect;
            public bool AutoConnect
            {
                get { return _AutoConnect; }
                set { _AutoConnect = value; }
            }

            private bool _ShareDiskDrives;
            public bool ShareDiskDrives
            {
                get { return _ShareDiskDrives; }
                set { _ShareDiskDrives = value; }
            }

            private bool _SharePrinters;
            public bool SharePrinters
            {
                get { return _SharePrinters; }
                set { _SharePrinters = value; }
            }

            private bool _SavePassword;
            public bool SavePassword
            {
                get { return _SavePassword; }
                set { _SavePassword = value; }
            }

            private Colors _ColorDepth;
            public Colors ColorDepth
            {
                get { return _ColorDepth; }
                set { _ColorDepth = value; }
            }

            public int Port
            {
                get
                {
                    return _Port;
                }

                set
                {
                    _Port = value;
                }
            }

            private int _Port;


            public enum Colors
            {
                HighColor15 = 15,
                HighColor16 = 16,
                Color256 = 8,
                TrueColor = 24
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // DateTime observeTime = DateTime.Parse(" 2023-11-22 22:45:30 "); // 倒计时日期
            DateTime now = DateTime.Now;     // 当前时间
           
            //TimeSpan ts = dtime.Subtract(now);     // 两个时间之差
            if (now.Hour < Convert.ToInt32(m_detail.endTime) && now.Hour >= Convert.ToInt32(m_detail.startTime))
            {
                OperateMinute = (now.Hour - observeTime.Hour) * 60 + (now.Minute - observeTime.Minute);
            }
            else {
                Disconnect();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            OnCreateControlMsg();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("你确定要退出程序吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                m_history.startTime = observeTime.ToString();
                m_history.endTime = DateTime.Now.ToString();
                m_history.OperateTime = OperateMinute.ToString();
                m_history.OperateDate = DateTime.Now;
                m_history.applyDetailId = m_detail.id;
                m_history.userid = m_user.id;
                b_history.Add(m_history);
               
            }
            else
            {
                e.Cancel = true;
            }


            
        }
    }
}
