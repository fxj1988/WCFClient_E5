using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManagerIndependence
{
    public partial class OrderManagerIndependence : Form
    {
        private static DbContext db { set; get; }
        private static DbSet<Accounts> dbSet { set; get; }
        SpinLock slock = new SpinLock(false);
        SpinLock slock2 = new SpinLock(false);
        public OrderManagerIndependence()
        {
            InitializeComponent();
        }

        private void OrderManagerIndependence_Load(object sender, EventArgs e)
        {
            db = new E5_2680V2_Entities();
            dbSet = db.Set<Accounts>();

        }

        //返回用于登陆的用户信息
        public Accounts Login()
        {
            Accounts userInfo = dbSet.Where((u) => u.remarks != "登录成功" & u.remarks != "ID被禁用" & u.remarks != "正在尝试登录" & u.remarks != "未知错误").FirstOrDefault();
            userInfo.remarks = "正在尝试登录";
            db.Entry<Accounts>(userInfo).State = EntityState.Modified;
            db.SaveChanges();
            return userInfo;
        }

        private void btnBuyPhone_Click(object sender, EventArgs e)
        {
            int begin = Convert.ToInt32(txtOrderBegin.Text);
            int end = Convert.ToInt32(txtOrderEnd.Text);
            List<Accounts> userInfos = dbSet.Where(u => u.remarks == null & u.ID > begin & u.ID <= end).ToList();
            Parallel.ForEach(userInfos, (userInfo) =>
            {
                userInfo = new OrderMethods().BuyPhone(userInfo);
                bool lockTaken = false;
                try
                {
                    slock.Enter(ref lockTaken);
                    db.Entry<Accounts>(userInfo).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch { }
                finally
                {
                    if (lockTaken)
                    {
                        slock.Exit(false);
                    }
                }
            });

            //bool lockTaken2 = false;
            //try
            //{
            //    slock2.Enter(ref lockTaken2);
            //    //异步写入
            //    using (FileStream fr = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite, 1024, true))
            //    {
            //        fr.Position = fr.Length;
            //        byte[] buffer = Encoding.UTF8.GetBytes(userInfo.ID + userInfo.remarks + "\r\n");
            //        Task.Factory.FromAsync(fr.BeginWrite, fr.EndWrite, buffer, 0, buffer.Length, null);
            //    }
            //}
            //finally
            //{
            //    if (lockTaken2)
            //    {
            //        slock2.Exit(false);
            //    };
            //}

        }
    }
}
