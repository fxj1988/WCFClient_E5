using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using WCFClient_E5.ServiceReference1;

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

        public Accounts BuyPhone(Accounts userInfo, int timeInterval=500)
        {
            string[] iPhone_x = {"x","5.8","64","silver", "MQA62CH","1", "IPHONEX_GSM" };

            #region 参数和初始
            HttpHelper http = new HttpHelper();
            string id = HttpUtility.UrlEncode(userInfo.loginAppleId);
            string pwd = HttpUtility.UrlEncode(userInfo.loginPassword);
            string cookie = "";
            string iphone = iPhone_x[0];
            string size = iPhone_x[1];
            string gb = iPhone_x[2];
            string col = iPhone_x[3];
            string product = iPhone_x[4];
            string screensize = size.Replace('.', '_');
            string quantity = iPhone_x[5];
            string IPHONEX_GSM = iPhone_x[6];
            string url_product = string.Format(@"https://www.apple.com/cn/shop/buy-iphone/iphone-{0}?product={1}/A", iphone, product);
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36";
            //https://www.apple.com/cn/shop/buy-iphone/iphone-x/MQA62CH/A?product=MQA62CH%2FA&purchaseOption=fullPrice&step=select&atbtoken=6a8207ac1f4d564c6696649f9c87c3d22d7dc8c1&complete=true&dimensionCapacity=64gb&dimensionColor=silver&dimensionScreensize=5_8inch&part=IPHONEX_GSM&add-to-cart=add-to-cart
            #endregion

            #region cn/shop/buy-iphone/iphone-x/MQA62CH/A 
            HttpResult result = new HttpResult();
            HttpItem item = new HttpItem()
            {
                URL = url_product,
                Method = "POST",
                Accept = "*/*",
                Host = "www.apple.com",
                UserAgent = userAgent,
                KeepAlive = true,
                ContentType = "application/x-www-form-urlencoded"
            };
            item.Header.Add("Accept-Encoding:br, gzip, deflate");
            item.Header.Add("Accept-Language:zh-Hans-CN;q=1");
            var result_product = http.GetHtml(item);
            cookie = http.GetCookie(result_product.Cookie, cookie);
            #endregion

            #region shop/beacon/atb 得到atbtoken
            string url_atb = "https://www.apple.com/cn/shop/beacon/atb";
            item.Cookie = cookie;
            item.URL = url_atb;
            item.Referer = url_product;
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
            string para_atb_token = Regex.Match(result.Cookie, "as_atb=(.+?);").Groups[1].ToString().Split('|')[2];  
            #endregion

            #region add-to-cart 添加到购物袋
            string url_add_to_cart = string.Format(@" https://www.apple.com/cn/shop/buy-iphone/iphone-{0}/{1}/A?product={1}%2FA&purchaseOption=fullPrice&step=select&atbtoken={2}&complete=true&dimensionCapacity={3}gb&dimensionColor={4}&dimensionScreensize={5}inch&part={6}&add-to-cart=add-to-cart", iphone, product, para_atb_token, gb, col, screensize, IPHONEX_GSM);
            item.Cookie = cookie;
            item.URL = url_add_to_cart;
            item.Referer = url_product;
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
            #endregion

            #region 访问/shop/bag得到cart-items-item/x-aos-stk/
            string url_bag= @"https://www.apple.com/cn/shop/bag";
            item.Cookie = cookie;
            item.Referer = url_product + "&step=attach";
            item.URL = url_bag;
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
            string html_bag = result.Html;
            Match match_cart_item = Regex.Match(html_bag, @"cart-items-item-([-a-z0-9]{10,50})""");
            string para_cart_item = match_cart_item.Groups[1].Value;
            Match match_stk = Regex.Match(html_bag, @"x-aos-stk"".""(.+?)""");
            string para_stk = match_stk.Groups[1].Value;
            #endregion      
            
            #region checkout_now?_a=checkout&_m=shoppingCart  
            string url_checkout_shoppingCart = @"https://www.apple.com/cn/shop/bagx/checkout_now?_a=checkout&_m=shoppingCart";
            string data_checkout_shoppingCart = string.Format("shoppingCart.items.item-{0}.isIntentToGift=false&shoppingCart.items.item-{1}.quantity={2}&shoppingCart.actions.fcscounter=&shoppingCart.actions.fcsdata=", para_cart_item, para_cart_item,quantity);
            item.Cookie = cookie;
            item.URL = url_checkout_shoppingCart;
            item.Referer = url_bag;
            item.Header.Add("x-aos-stk:" + para_stk);
            item.Header.Add("X-Requested-With:XMLHttpRequest");
            item.Header.Add("x-aos-model-page:cart");
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
            string html_checkout_shoppingCart = result.Html;

            Match match_checkout_shoppingCart = Regex.Match(html_checkout_shoppingCart, @"url"":""(https:.+?)""}");
            string url_corat = match_checkout_shoppingCart.Groups[1].Value;
            char chr = url_corat[14];
            string host = "secure" + chr + ".store.apple.com";
            string url_host = @"https://" + host;
            Match match_s = Regex.Match(url_corat, "s=.+?&");
            string para_s = match_s.Value;
            #endregion

            #region 得到登录要用的参数para_aos_stk                 
            item.Cookie = cookie;
            item.URL = url_corat;
            item.Referer = url_bag;
            item.Host = host;
            item.Method= "GET";
            item.Header.Add("Upgrade-Insecure-Requests:1");
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
            string html_corat = result.Html;
            Match match_aos_stk= Regex.Match(html_corat.Replace(" ",""), @"aos-stk"",""value"":""(.+?)""");
            string para_aos_stk = match_aos_stk.Groups[1].Value;
            string url_sign_in = string.Format("https://{0}/cn/shop/sentryx/sign_in", host);
            #region PostData
            string data_sign_in = string.Format("login-appleId={0}&login-password={1}&aos-stk={2}&aywysya=.ta44j1d7lY5BNvcKyAdMUDFBpBeA0fUm0NUbNiqUU8jA2Q3wL6k03x0.5EwHXXTSHCSPmtd0wVYPIG_qvoPfybYb5EvYTrYesR2fQnH3BCb12qgXK_Pmtd0SHp815LyjaY2.rINj.rIN4WzcjftckcKyAd65hz74WySXvOxwawgCgIlNU.3Io3.Nzl998tp7ppfAaZ6m1CdC5MQjGejuTDRNziCvTDfWkDhjC7FkqR7EPm8LKfAaZ4pzUVRE_xUC54b_H_jWRqNBLyOtJJIqSI6KUMnGWpwoNSUC56MnGW87gq1HACVdZVW.4ELJd_MurJhBR.uMukAm4.f282pvEodUW2RdZVjp.3Nve_jV2pNk0ug97SIilkUf.j7J1gBZEMezH_z2ASFQ_BZ4yeVrNW5BQYTrYetvqU1j8xiDyCY5DtOGY5BNBoqw37lYfs.0V3&fdcBrowserData=%257B%2522U%2522%253A%2522Mozilla%252F5.0%2520(Windows%2520NT%252010.0%253B%2520Win64%253B%2520x64)%2520AppleWebKit%252F537.36%2520(KHTML%252C%2520like%2520Gecko)%2520Chrome%252F68.0.3440.106%2520Safari%252F537.36%2522%252C%2522L%2522%253A%2522zh-CN%2522%252C%2522Z%2522%253A%2522GMT%252B08%253A00%2522%252C%2522V%2522%253A%25221.0%2522%257D&_a=login.sign&c=aHR0cHM6Ly93d3cuYXBwbGUuY29tL2NuL3Nob3AvYmFnfDFhb3M0MzYxMjI5OWRhYjE0YWM3OThkYzk4NTMyZjE1MWUzZTZhMTMzMThj&_fid=si&r=SXYD4UDAPXU7P7KXF&{3}&t=SXYD4UDAPXU7P7KXF&up=true", id, pwd, para_aos_stk, para_s);
            #endregion
            #endregion

            #region 登录成功后得到para_pltn
            item.Cookie = cookie;
            item.URL = url_sign_in;
            item.Referer = url_corat;
            item.Method = "POST";
            item.Postdata = data_sign_in;
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
           string html_sign_in = result.Html;
            //登录成功后得到pltn,cookie:as_cn和跳转的网址
            Match match_para_pltn = Regex.Match(html_sign_in, @"pltn"":""(.+?)""");
            string para_pltn = match_para_pltn.Groups[1].Value;
            Match match_checkout_start = Regex.Match(html_sign_in, @"(https:.+?)""");
            string url_checkout_start = match_checkout_start.Groups[1].Value;
            //登录失败得不到pltn，跳转到：https://www.apple.com/cn/shop
            if (url_checkout_start != url_host + "/cn/shop/checkout/start")
            {
                userInfo.remarks = "未知登录失败";
                return userInfo;
            }
            #endregion

            #region /checkout/start得到sessionID
            item.Cookie = cookie;
            item.URL = url_checkout_start;
            item.Postdata = "pltn=" + para_pltn;
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
            string html_checkout_start = result.Html;                    
            Match match_sessionID = Regex.Match(html_checkout_start, @"sessionID[\s\S]+?value=""(.+?)""");
            string  para_sessionID = match_sessionID.Groups[1].Value;
            Thread.Sleep(timeInterval);
            #endregion

            #region /checkout 提交pltn，sessionID
            string url_checkout = url_host + "/cn/shop/checkout";
            string url_checkoutx = url_host + "/cn/shop/checkoutx";
            string data_checkout = string.Format("pltn={0}&v=on&sessionID={1}",para_pltn,para_sessionID);
            item.Cookie = cookie;
            item.URL = url_checkout;
            item.Referer =url_checkout_start;
            item.Method = "POST";
            item.Postdata = data_checkout;
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
           // string html_checkout = result.Html;
            Thread.Sleep(timeInterval);
            #endregion

            #region /cn/shop/checkoutx 提交sessionID，cart-item-
            string data_checkoutx_first = string.Format("sessionID={0}&cart-item-{1}-delivery-deliveryLocationType=A8&_a=cart.cont&_fid=co&_m=cart",para_sessionID,para_cart_item);
            item.Cookie = cookie;
            item.URL = url_checkoutx;
            item.Referer = url_checkout;
            item.Method = "POST";
            item.Postdata = data_checkoutx_first;
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);        
            Thread.Sleep(timeInterval);
            #endregion

            #region /cn/shop/checkoutx点击继续发送地址信息
            string data_checkoutx_second = string.Format("sessionID={0}&shipping-user-lastName={1}&shipping-user-firstName={2}&shipping-user-daytimePhoneAreaCode={3}&shipping-user-daytimePhone={4}&shipping-user-state={5}&shipping-user-city={6}&shipping-user-district={7}&shipping-user-street={8}&shipping-user-street2={9}&shipping-user-postalCode=&shipping-user-emailAddress={10}&shipping-user-mobilePhone={11}&state={12}&keyPath=shipping.address&city={13}&shipping-save-as-default=false&_a=ship.cont&_fid=co",
                para_sessionID,
                HttpUtility.UrlEncode(userInfo.shippingUserLastName).ToUpper(),
                HttpUtility.UrlEncode(userInfo.shippingUserFistName).ToUpper(),
                userInfo.daytimePhoneAreaCode,
                userInfo.daytimePhone,
                HttpUtility.UrlEncode("北京").ToUpper(),
                HttpUtility.UrlEncode("北京").ToUpper(),
                HttpUtility.UrlEncode(userInfo.district).ToUpper(),
                HttpUtility.UrlEncode(userInfo.shippingUserStreet1).ToUpper(),
                HttpUtility.UrlEncode(userInfo.shippingUserStreet2).ToUpper(),
                id,
                userInfo.daytimePhone,
                HttpUtility.UrlEncode("北京").ToUpper(),
                HttpUtility.UrlEncode("北京").ToUpper()
                );
            item.Cookie = cookie;
            item.URL = url_checkoutx;
            item.Postdata = data_checkoutx_second;
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
            Thread.Sleep(timeInterval);
            #endregion

            #region /cn/shop/checkoutx 选择付款方式bankOption=Alipay，点击继续
            string data_checkoutx_third = string.Format("sessionID={0}&undefined=&bankOption=Alipay&_a=bill.cont&_fid=co",para_sessionID);
            item.Cookie = cookie;
            item.Postdata = data_checkoutx_third;
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
            Thread.Sleep(timeInterval);
            #endregion

            #region /cn/shop/checkoutx 选择发票方式和电子邮件地址点击继续
            string data_checkoutx_fourth = string.Format("sessionID={0}&invoice-user-invoiceEmailAddress-emailAddress={1}&invoice-form-options-selection=none&_a=invoice.cont&_fid=co", para_sessionID, id);
            item.Cookie = cookie;
            item.Postdata = data_checkoutx_fourth;
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
            Thread.Sleep(timeInterval);
            #endregion

            #region 点击继续同意苹果条款和条件。
            
            string data_checkoutx_fifth = string.Format("sessionID={0}&accept=true&acceptAppleTnc=false&_a=terms.cont&_fid=co",
            para_sessionID);
            item.Cookie = cookie;
            item.Postdata = data_checkoutx_fifth;
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
            Thread.Sleep(timeInterval);
            #endregion

            #region 点击立即下订单提交aywysya
            string data_checkoutx_sixth = string.Format("aywysya=.ta44j1d7lY5BNvcKyAdMUDFBpBeA0fUm0NUbNiqUU8jA2Q3wL6k03x0.5EwHXXTSHCSPmtd0wVYPIG_qvoPfybYb5EvYTrYesR2fQnH3BCb12qgXK_Pmtd0SHp815LyjaY2.rINj.rIN4WzcjftckcKyAd65hz74WySXvOxwawgCgIlNU.3Io3.Nzl998tp7ppfAaZ6m1CdC5MQjGejuTDRNziCvTDfWkDhjC7FkqR7EPm8LKfAaZ4pzUVRE_xUC54b_H_jWRqNBLyOtJJIqSI6KUMnGWpwoNSUC56MnGW87gq1HACVdZVW.4ELJd_MurJhBR.uMukAm4.f282pvEodUW2RdZVjp.3Nve_jV2pNk0ug97SIilkUf.j7J1gBZEMezH_z2ASFQ_BZ4yeVrNW5BQYTrYetvqU1j8xiDyCY5DtOGY5BNBoqw37lYfs.0V3&sessionID={0}&promo-code=&_a=po&_fid=co",
               para_sessionID);
            item.Cookie = cookie;
            item.Postdata = data_checkoutx_sixth;
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
            Thread.Sleep(timeInterval);
            #endregion

            #region /checkout/status "点击立即下订单”后跳转到：checkout/status
            string url_checkout_status = url_host + "/cn/shop/checkout/status";
            item.Cookie = cookie;
            item.URL = url_checkout_status;
            item.Method = "GET";
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
            Thread.Sleep(timeInterval);
            #endregion

            #region /checkoutx/status
            string url_checkoutx_status=url_host + "/cn/shop/checkoutx/status";
            item.Cookie = cookie;
            item.URL = url_checkoutx_status;
            item.Referer =url_checkout_status;
            item.Method = "POST";
            item.Postdata = "_a=status&_fid=co&_m=common";
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
            string html_checkoutx_status = result.Html;
            if (html_checkoutx_status.Contains(@"/cn/shop/checkoutx/status?"))
            {
                item.Cookie = cookie;
                item.URL = url_checkoutx_status;
                item.Referer = url_checkoutx_status;
                item.Method = "GET";             
                result = http.GetHtml(item);
                cookie = http.GetCookie(result.Cookie, cookie);
                Thread.Sleep(1500);
            }
            else if (html_checkoutx_status.Contains(@"sorry_message/auth_lock"))
            {
                userInfo.remarks = "auth_lock";
                return userInfo;
            }
            Thread.Sleep(timeInterval);
            #endregion

            #region /cn/shop/checkout/thankyou 跳转到thankyou,现在为你的订单付款页面
            string url_checkout_thankyou = url_host + "/cn/shop/checkout/thankyou";
            item.Cookie = cookie;
            item.URL = url_checkout_thankyou;
            item.Referer =url_checkoutx_status;
            item.Method = "GET";
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
            string html_checkout_thankyou = result.Html;
            if (!html_checkout_thankyou.Contains("谢谢您"))
            {
                userInfo.remarks = "第一次thankyou页面失败";
                return userInfo;
            }
            #endregion

            #region 点击现在支付 第二次访问thankyou
            string url_checkoutx_thankyou = url_host + "/cn/shop/checkoutx/thankyou";
            item.Cookie = cookie;
            item.URL = url_checkoutx_thankyou;
            item.Referer = url_checkout_thankyou;
            item.Method = "POST";
            item.Postdata = "_a=paynow&_fid=co";
            result = http.GetHtml(item);
            cookie = http.GetCookie(result.Cookie, cookie);
            string html_checkoutx_thankyou = result.Html;
            #endregion

            Match matchAlipay = Regex.Match(html_checkoutx_thankyou, @"(https.+?)""");
            string url_alipay = matchAlipay.Groups[1].Value;
            Match match_alipay = Regex.Match(url_alipay, "W[0-9]{9}");
            userInfo.w1 = size + "/" + gb + "/" + col + "/" + match_alipay.Value;
            userInfo.remarks = "待付款";
            userInfo.w1detail = url_alipay.Replace("待付款:", "");
            return userInfo;
        }
    }
}
