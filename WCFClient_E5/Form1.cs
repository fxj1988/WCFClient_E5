using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFClient_E5.ServiceReference1;

namespace WCFClient_E5
{
    public partial class Form1 : Form
    {
        private static ServiceContractClient client { set; get; }
        private static Accounts userInfo { set; get; }
        private static GroupBox gb { set; get; }
        private static PropertyInfo[] propertyInfos { set { } get { return T.GetProperties(); } }
        private static Type T { set { } get { return userInfo.GetType(); } }
        private string order { set; get; }

        public Form1()
        {
            InitializeComponent();
            client = new ServiceContractClient();
            labTime.Text += client.GetDateTime().ToShortTimeString();
            gb = new GroupBox();
            txtTime.Text = "100";
        }
        #region 已完成的方法
        //按钮—获得所有的用户信息
        private void btnConWcf_Click(object sender, EventArgs e)
        {
            var allUserInfos = client.GetAllUserInfos();
            this.dataGridView1.DataSource = allUserInfos;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                if (!this.dataGridView1.Columns[i].ToString().Contains("login"))
                {
                    this.dataGridView1.Columns[i].Visible = false;
                }
            }
        }
        //按钮—根据ID获得账号信息
        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(()=> {
                userInfo = client.GetAUserInfo(Convert.ToInt32(txtID.Text));
                GetTextBox(userInfo);
            });
        }
        //按钮—并行登陆测试
        private void parallelLoginTest_Click(object sender, EventArgs e)
        {
            while (true)
            {
                Task.Factory.StartNew(() =>
                {
                    Accounts userInfo = client.Login();
                    OrderMethods orderMethod = new OrderMethods();
                    string loginResult = orderMethod.LoginTest(userInfo.loginAppleId, userInfo.loginPassword);
                    userInfo.remarks = loginResult;
                    userInfo.cookies += "a|";
                    client.EditUserInfo(userInfo);
                });
            }
        }
        //按钮—异步登陆测试
        private void asyGetUserInfo_Click(object sender, EventArgs e)
        {
            AsyncLoginTest();
        }  
        //编辑用户信息
        private void btnEditUserInfo_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string a = null;
            string b = null;
            foreach (Control item in gb.Controls)
            {

                if (item is TextBox & item.Tag.ToString().Contains("name"))
                {
                    a = item.Text;
                }
                else if (item is TextBox & item.Tag.ToString().Contains("value"))
                {
                    b = item.Text;
                }
                if (a != null & b != null)
                {
                    dic.Add(a, b);
                    a = null;
                    b = null;
                }
            }
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                foreach (var item in dic)
                {
                    if (item.Key == propertyInfos[i].Name)
                    {
                        PropertyInfo propertyInfo = propertyInfos[i];
                        try
                        {
                            propertyInfo.SetValue(userInfo, item.Value);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            client.EditUserInfo(userInfo);
        }      
        // 把userInfo映射成表以textBox的方式显示出来
        private void GetTextBox(Accounts userInfo)
        {
            Task.Factory.StartNew(() =>
            {
                this.Invoke(new Action(() =>
                {
                    gb.Dispose();
                    gb = new GroupBox();
                    int x = 40;
                    int y = 80;
                    gb.Width = 900;
                    gb.Height = 900;
                    this.Controls.Add(gb);
                    for (int i = 0; i < propertyInfos.Length; i++)
                    {
                        TextBox tbname = new TextBox();
                        tbname.Tag = "name";
                        tbname.Text = propertyInfos[i].Name;
                        tbname.Location = new Point(x, y);
                        tbname.Width = 130;
                        tbname.Height = 20;
                        gb.Controls.Add(tbname);
                        TextBox tbValue = new TextBox();
                        tbValue.Tag = "value";
                        try { tbValue.Text = propertyInfos[i].GetValue(userInfo).ToString(); }
                        catch { }
                        tbValue.Location = new Point(x + 130, y);
                        tbValue.Width = 200;
                        tbValue.Height = 20;
                        gb.Controls.Add(tbValue);
                        y += 20;
                    }
                }));
            });
        }
        // 登陆测试
        private void LoginTest()
        {
            Accounts userInfo = client.Login();
            OrderMethods orderMethod = new OrderMethods();
            string loginResult = orderMethod.LoginTest(userInfo.loginAppleId, userInfo.loginPassword);
            userInfo.remarks += loginResult;
            client.EditUserInfo(userInfo);
            GetTextBox(userInfo);
        }
        //得到服务器命令
        private void labHostState_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem((a) =>
            {
                while (true)
                {
                    this.Invoke(new Action(() =>
                    {
                        order = client.GetOrderAsync().Result;
                        labHostStatus.Text = order;
                        if (order == "同步登录" | order == "登录")
                        {
                            labHostStatus.Text = "同步登录中";
                            LoginTest();
                        }
                        else if (order == "异步登录")
                        {
                            labHostStatus.Text = "异步登录中";
                            AsyncLoginTest();
                        }
                    }));
                    Thread.Sleep(3000);
                }
            });
        }
        //数据库写入随机地址
        private void btnRdmAddr_Click(object sender, EventArgs e)
        {
            Accounts[] userInfos = client.GetAllUserInfos();
                Parallel.ForEach(userInfos,(userInfo) =>
                {   
                    userInfo.shippingUserFistName = RandomAddr.getFirstName();
                    userInfo.shippingUserLastName = RandomAddr.getLastName();
                    userInfo.daytimePhoneAreaCode = "010";
                    if (userInfo.ID % 2 == 0)
                    {
                        userInfo.daytimePhone = RandomAddr.GetTel("170");
                    }
                    else
                    {
                        userInfo.daytimePhone = RandomAddr.GetTel("171");
                    }
                    userInfo.shippingUserStreet1 = RandomAddr.getStreet1FT() + "更";
                    userInfo.shippingUserStreet2 = RandomAddr.getRoomNumber() + RandomAddr.GetSubject();
                    userInfo.district = "丰台区";
                    userInfo.postalCode = "101171";
                    client.EditUserInfo(userInfo);
                });         
        }
        //异步执行登陆测试
        delegate void delegateTryAsyncLoginTest();
        private void AsyncLoginTest()
        {
            delegateTryAsyncLoginTest asyncDelegate = new delegateTryAsyncLoginTest(LoginTest);
            asyncDelegate.BeginInvoke(new AsyncCallback(asyncResult =>
            {
                AsyncResult result = (AsyncResult)asyncResult;
                delegateTryAsyncLoginTest getOriginalDelegate = (delegateTryAsyncLoginTest)result.AsyncDelegate;//获得原委托
                getOriginalDelegate.EndInvoke(result);//执行原委托的EndInvoke方法，获得LoginTest方法执行后的结果
            }), null);
        }
        #endregion

        private void btnBuyPhone_Click(object sender, EventArgs e)
        {
            string path = @"..\Log";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fullPath = Path.GetFullPath(path + DateTime.Now.ToString("yyyyMMdd") + ".txt");
            SpinLock slock = new SpinLock(false);
            SpinLock slock2 = new SpinLock(false);
            OrderMethods orderMethods=  new OrderMethods();
            while (true)
            {
                Accounts userInfo = client.GetAUserInfo(new Random().Next(6542));
                userInfo.remarks = "下单中";
                userInfo = orderMethods.BuyPhone(userInfo, Convert.ToInt32(txtTime.Text));
                client.EditUserInfo(userInfo);
                using (FileStream fr = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite, 1024, true))
                {
                    fr.Position = fr.Length;
                    byte[] buffer = Encoding.UTF8.GetBytes(userInfo.ID + userInfo.remarks + "\r\n");
                    Task.Factory.FromAsync(fr.BeginWrite, fr.EndWrite, buffer, 0, buffer.Length, null);
                }
                #region Parallel
                //Parallel.For(0, Convert.ToInt32(txtParNumber.Text), (i) =>
                //{
                //    bool lockTaken = false;
                //    bool lockTaken2 = false;
                //    try
                //    {
                //        slock.Enter(ref lockTaken);
                //        userInfo = entityService.Accounts.Where((u) => u.remarks == null).FirstOrDefault();
                //        userInfo.remarks = "下单中";
                //        entityService.Entry(userInfo).State = EntityState.Modified;
                //        entityService.SaveChanges();
                //    }
                //    finally 
                //    {
                //        if (lockTaken)
                //        {
                //            slock.Exit(false);  
                //        };
                //    }
                //    userInfo = new iPhone7().BuyPhone(userInfo, Convert.ToInt32(txtTime.Text));
                //    try
                //    {
                //        slock2.Enter(ref lockTaken2);
                //        entityService.Entry(userInfo).State = EntityState.Modified;
                //        entityService.SaveChanges();
                //        //异步写入
                //        using (FileStream fr = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite, 1024, true))
                //        {
                //            fr.Position = fr.Length;
                //            byte[] buffer = Encoding.UTF8.GetBytes(userInfo.ID + userInfo.remarks + "\r\n");
                //            Task.Factory.FromAsync(fr.BeginWrite, fr.EndWrite, buffer, 0, buffer.Length, null);
                //        }
                //    }
                //    finally
                //    {
                //        if (lockTaken2)
                //        {
                //            slock2.Exit(false);
                //        };
                //    }
                //});
                #endregion
            }
        }
    }
}
