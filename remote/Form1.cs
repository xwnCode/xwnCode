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
    public partial class Form1 : Form
    {
        private AxMSTSCLib.AxMsRdpClient7 rdpc = null;
        private DateTime observeTime;
        public Form1()
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
            //处理断开连接
        }


        public void Disconnect()
        {
            try
            {
                if (rdpc.Connected == 1)
                {
                    rdpc.Disconnect();
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
            rdpc.AdvancedSettings5.ClearTextPassword ="qwerty@123456";
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
            Form2 fr2 = new Form2();
            fr2.Show();
           // OnCreateControlMsg();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // DateTime observeTime = DateTime.Parse(" 2023-11-22 22:45:30 "); // 倒计时日期
            DateTime now = DateTime.Now;     // 当前时间
            int hmh = ( now.Hour-observeTime.Hour) * 3600 + ( now.Minute-observeTime.Minute ) * 60 + (now.Second-observeTime.Second );
            //TimeSpan ts = dtime.Subtract(now);     // 两个时间之差
            if (hmh > 60)
            {
                Disconnect();
            }
        }
    }
}
