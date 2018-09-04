using System.Web;

namespace WCFClient_E5
{
  public class OrderMethods
    {
        public string LoginTest(string loginAppleId, string loginPassword)
        {
            HttpHelper http = new HttpHelper();
            string cookie = "";
            string id = HttpUtility.UrlEncode(loginAppleId);
            string pwd = HttpUtility.UrlEncode(loginPassword);
            string appleHost = @"www.apple.com";
            string userAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";
            string aywysya = "Fta44j1dCm_ikMf9bgBNlY6S1jlS9vtm0ad_GNCQyFA2wv4qnvtCsABIlNu1k.GEagdrDy.uLq8vHtksJ8yQswaxkiorehtaW_K98yQswaxkiordnCaa5KMNIwrltCvWSdjIQnI29fg8wQZvQAr6Dy2YUjM6VhXUayE8Vqr.btjYmNChs8sjrnz4v_0jnH8vSPz9Lr6x5ezdstlikjvw2Wwj.rINFTcAkCoq0NUuAfyz.sUAcKyAd65hz74WySXvOxwaw4a8sgS0N.7bnLJvbU.SAQ3xdRsR93zCwTITsMPQpLwnFme_3zCwTITsMPQotanI29fg8yQswaxkiordhtdW_Kq3yCmSh_vYbU0ljrfYkLlEnU6ZkQQVIwrltB5qw3wMvtzXxmVrtd3xihU_AQYyYKUowRsrMxy0kyMoxLd8KMOtJdQsbCa24jaTK43xbJlpM9KVdL75uQ5jaY1HGOg3ZLQ0IFW7.BKENBhyhulHpsdPPgJhTKWbZcPlHps1gJhTKV8NThNdPw_f4AM_N.nkpNdPwygJhT9AL9Lj6xNdPwHagJhTEulHps3CmV_Nv8v26UcjV2pNk0ugKX_flG1LgJhTKWbZcPlHptpf4AM_N1L6fL9Lj4SelHptL.BwCL9LjEf4AMX_KX_flzL9Lj44f4AMYygJhT5ISFQ_09lpvHrpwoNSUC68klY5BSmmY5BNkOdhs7GY6Mk.Dui";
            #region 获得参数c和s、t
            HttpResult resultLogin = new HttpResult();
            HttpResult resultGetC = new HttpResult();
            HttpItem itemGetC = new HttpItem()
            {
                URL = "https://secure.store.apple.com/cn/order/list",
                Method = "GET",
                Accept = "text/html,application/xhtml+xml,*/*",
                Referer = appleHost,
                Host = "secure.store.apple.com",
                UserAgent = userAgent,
                KeepAlive = true,
            };
            itemGetC.Header.Add("Accept-Encoding:gzip, deflate");
            itemGetC.Header.Add("Accept-Language:zh-CN");
            resultGetC = http.GetHtml(itemGetC);
            string urlRst = resultGetC.Header.GetValues("Location")[0];
            string host = urlRst.Substring(0, 15);
            char chr = host[14];
            if (chr == '.')
            {
                host = "secure.store.apple.com";
                chr = char.MinValue;
            }
            else
            {
                host = "secure" + chr + ".store.apple.com";
            }
            int ts = urlRst.IndexOf('?');
            if (ts < 0)
            {
                string urlList = "https://" + host + @"/cn/order/list";
                cookie = http.GetCookie(resultGetC.Cookie, cookie);
                HttpResult resultGetC2 = new HttpResult();
                HttpItem itemGetC2 = new HttpItem()
                {
                    URL = urlList,
                    Method = "GET",
                    Accept = "text/html,application/xhtml+xml,*/*",
                    Host = host,
                    UserAgent = userAgent,
                    KeepAlive = true,
                    Cookie = cookie,
                };
                itemGetC2.Header.Add("Accept-Encoding:gzip, deflate");
                itemGetC2.Header.Add("Accept-Language:zh-CN");
                resultGetC2 = http.GetHtml(itemGetC2);
                urlRst = resultGetC2.Header.GetValues("Location")[0];
                host = urlRst.Substring(0, 15);
                chr = host[14];
                if (chr == '.')
                {
                    host = "secure.store.apple.com";
                }
                else
                {
                    host = "secure" + chr + ".store.apple.com";
                }
                cookie = http.GetCookie(resultGetC2.Cookie, cookie);
            }
            #endregion
            #region Login
            #region PostData
            string postData = string.Format(@"login-appleId={0}&login-password={1}&aywysya={2}&fdcBrowserData=%257B%2522U%2522%253A%2522Mozilla%252F5.0%2520(Windows%2520NT%25206.1%253B%2520WOW64%253B%2520Trident%252F7.0%253B%2520SLCC2%253B%2520.NET%2520CLR%25202.0.50727%253B%2520.NET%2520CLR%25203.5.30729%253B%2520.NET%2520CLR%25203.0.30729%253B%2520Media%2520Center%2520PC%25206.0%253B%2520.NET4.0C%253B%2520.NET4.0E%253B%2520InfoPath.3%253B%2520rv%253A11.0)%2520like%2520Gecko%2522%252C%2522L%2522%253A%2522zh-CN%2522%252C%2522Z%2522%253A%2522GMT%252B08%253A00%2522%252C%2522V%2522%253A%25221.0%2522%257D&_a=login.sign&c=aHR0cHM6Ly93d3cuYXBwbGUuY29tL2NuL3Nob3AvYWNjb3VudC9ob21lfDFhb3NkZWFiZTRhNjJhMDI3MWJkZjkzMjQzYzVjZWYyYTk3MzM1N2JlNDFk&_fid=si&r=SCKFUHKXACXX7DYHYT9JT7JJTAPAXHFKH&s=aHR0cHM6Ly9zZWN1cmUxLnN0b3JlLmFwcGxlLmNvbS9jbi9zaG9wL29yZGVyL2xpc3Q_aGlzdD05MHwxYW9zYmU5ZWEyYjZiOTkwNWNiODAyZjM0YzE5NGVlZTkyOTZmYTA4ZWM3Mw&t=SXYD4UDAPXU7P7KXF", id, pwd, aywysya);
            #endregion
            HttpItem itemLogin = new HttpItem()
            {
                URL = @"https://secure" + chr + @".store.apple.com/cn/shop/sentryx/order/sign_in",
                Method = "POST",
                Accept = "*/*",
                ContentType = "application/x-www-form-urlencoded",
                Referer = urlRst,
                Host = "secure" + chr + ".store.apple.com",
                UserAgent = userAgent,
                Cookie = cookie,
                Postdata = postData,
            };
            itemLogin.Header.Add("Accept-Encoding:gzip, deflate");
            itemLogin.Header.Add("X-Requested-With:XMLHttpRequest");
            itemLogin.Header.Add("Accept-Language:zh-CN");
            resultLogin = http.GetHtml(itemLogin);
            cookie = http.GetCookie(resultLogin.Cookie, cookie);
            string htmlStr = resultLogin.Html;
            #endregion
            if (htmlStr.Contains(@"/cn/shop/order/list?hist=90"))
            {
                return "登录成功";
            }
            else if (htmlStr.Contains("此 Apple ID 已由于安全原因被禁用"))
            {
                return "ID被禁用";
            }
            else
            {
                return "未知错误";
            }
        }
    }
}
