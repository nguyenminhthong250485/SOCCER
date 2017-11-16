using System;
using HtmlAgilityPack;

namespace AGENT_NEW
{
    public class SboFunction : IFunction
    {
        HttpHelper http;
        private string message = "", url = "";
        double WinLose;
        string key, username, password, usd, hesocom;
        Database db;
        public void SetUsd(string str_usd)
        {
            usd = str_usd;
        }
        public void SetHeSoCom(string str_hesocom)
        {
            hesocom = str_hesocom;
        }
        public string getMessage()
        {
            return message;
        }
        public double getWinLose()
        {
            return WinLose;
        }
        public void login()
        {
            string data = "";

            string password = "lucky6868@";
            string security_code = "790790";
            url = http.FetchResponseUri("http://123.tek789.com", HttpHelper.HttpMethod.Get, null, null);
            data = http.Fetch(url, HttpHelper.HttpMethod.Get, null, null);
            string _requesttoken = Util.HtmlGetAttributeValue(data, "value", "//input[@name='__RequestVerificationToken']");
            string welcome = http.Fetch(url + "Captcha", HttpHelper.HttpMethod.Post, url, "__RequestVerificationToken=" + Util.EscapeDataString(_requesttoken) + "&username=" + Util.EscapeDataString(username) + "&password=" + Util.EscapeDataString(password) + "&lang=EN&btnSubmit=" + Util.EscapeDataString("Sign In"));
            if (!welcome.Contains("Your login name and password is not valid"))
            {
                if (welcome.Contains("securityCodeForm"))
                {
                    string security_page = http.Fetch(url + "Security/SecurityCode", HttpHelper.HttpMethod.Get, url, null);
                    _requesttoken = Util.HtmlGetAttributeValue(security_page, "value", "//input[@name='__RequestVerificationToken']");
                    string security_message = Util.HtmlGetInnerText(security_page, "//p[contains(text(),'Security Code :')]");
                    char digit1 = security_code[Int16.Parse(security_message.Split('\n')[1].Trim().Substring(0, 1)) - 1];
                    char digit2 = security_code[Int16.Parse(security_message.Split('\n')[2].Trim().Substring(0, 1)) - 1];
                    welcome = http.Fetch(url + "Security/ValidateSecurityCode", HttpHelper.HttpMethod.Post, url + "Security/SecurityCode", "__RequestVerificationToken=" + Util.EscapeDataString(_requesttoken) + "&hiduseDesktop=&hidIsFromSecurityCode=1&FirstChar=" + digit1 + "&SecondChar=" + digit2 + "&btnSubmit=Submit");
                }

                if (!welcome.Contains("Please enter a valid security code"))
                {
                    url = "http://" + Util.GetSubstringByString(Util.HtmlGetAttributeValue(welcome, "action", "//form[@id='f']"), "http://", "welcome.aspx");
                    http.Fetch(url + "welcome.aspx?id=" + Util.HtmlGetAttributeValue(welcome, "value", "//input[@name='id']") + "&key=" + Util.HtmlGetAttributeValue(welcome, "value", "//input[@name='key']") + "&lang=en&useDesktop=no", HttpHelper.HttpMethod.Get, url + "processlogin.aspx", null);
                    http.Fetch(url + "webroot/restricted/tc/en/iom_tc_agent.aspx", HttpHelper.HttpMethod.Get, url + "webroot/restricted/tc/termsconditions.aspx?type=iom_audit", null);
                    http.Fetch(url + "webroot/restricted/tc/termsconditions.aspx", HttpHelper.HttpMethod.Post, url + "webroot/restricted/tc/termsconditions.aspx?type=iom_audit", "agree=1");
                    http.Fetch(url + "webroot/restricted/home.aspx", HttpHelper.HttpMethod.Get, url + "webroot/restricted/tc/termsconditions.aspx?type=iom_audit", null);
                    string hometop = http.Fetch(url + "webroot/restricted/HomeTop.aspx", HttpHelper.HttpMethod.Get, url + "webroot/restricted/home.aspx", null);
                }
            }
            data = http.Fetch(url + "/webroot/restricted/HomeLeft.aspx", HttpHelper.HttpMethod.Get, url + "webroot/restricted/home.aspx", null);
            data = http.Fetch(url + "/webroot/restricted/membermgmt/member_credit.aspx", HttpHelper.HttpMethod.Get, url + "/webroot/restricted/HomeLeft.aspx", null);
            string data_Security = http.Fetch(url + "/webroot/restricted/security/security-code-prompt.aspx", HttpHelper.HttpMethod.Get, url + " /webroot/restricted/HomeLeft.aspx", null);
            HtmlNodeCollection Spans = Util.HtmlGetNodeCollection(data_Security, "//span");
            string digit = "";
            foreach (HtmlNode Span in Spans)
            {
                digit += Span.InnerText[0];
            }
            string HidCK = Util.HtmlGetAttributeValue(data_Security, "value", "//input[@id='HidCK']");
            string digit11 = security_code[Int16.Parse(digit[0].ToString()) - 1].ToString();
            string digit22 = security_code[Int16.Parse(digit[1].ToString()) - 1].ToString();
            string post_data_Security = http.Fetch(url + "/webroot/restricted/security/security-code-prompt.aspx", HttpHelper.HttpMethod.Post, url + "/webroot/restricted/security/security-code-prompt.aspx", "cmd=securityCode&digit1=" + digit11 + "&digit2=" + digit22 + "&HidCK=" + HidCK);
            data = http.Fetch(url + "/webroot/restricted/membermgmt/member_credit.aspx", HttpHelper.HttpMethod.Get, url + "/webroot/restricted/security/security-code-prompt.aspx", null);
            if(data=="")
            {
                message = "error";
            }
            else
            {
                message = "Login Success ";
            }
        }
        public void WinLoseWeek()
        {
            string dayFrom = GetFirstDay();
            string dayTo = GetLastDay();
           
            string data7 = http.Fetch(url + "webroot/restricted/report2/winlost.aspx?P=WL", HttpHelper.HttpMethod.Get, url + "webroot/restricted/HomeLeft.aspx", null);
            string p = data7.Substring(data7.IndexOf("id=\"p\" value=\"") + 14, 2);
            string ek = data7.Substring(data7.IndexOf("id=\"ek\" value=\"") + 15, 1);
            string mode = data7.Substring(data7.IndexOf("name=\"mode\" value=\"") + 19, 1);
            string datawinlost = http.Fetch(url + "webroot/restricted/report2/report_frame.aspx", HttpHelper.HttpMethod.Post, url + "webroot/restricted/report2/winlost.aspx", "p=33&ek=3&mode=1&chart=&ids=&isSplitGamesAndFinancials=&product=0&dpFrom=" + dayFrom + "&dpTo=" + dayTo);
            string[] arr_winlost = datawinlost.Split(new string[] { "])" }, StringSplitOptions.None);

            double com = 0; double win = 0;

            for (int i = 1; i < arr_winlost.Length - 3; i++)
            {
                string winlostmember = arr_winlost[i];
                string username = winlostmember.Split(new string[] { "','" }, StringSplitOptions.None)[3];
                string commission = winlostmember.Split(new string[] { "','" }, StringSplitOptions.None)[5];
                string winlost = winlostmember.Split(new string[] { "','" }, StringSplitOptions.None)[6];
                com += double.Parse(commission.Replace(",", ""));
                win += double.Parse(winlost.Replace(",", ""));
            }
            WinLose = Math.Round((com * double.Parse(hesocom) + win) * double.Parse(usd), 0);
            //message = "Com:" + com.ToString() + " WinLose:" + win.ToString() + ".Total:" + WinLose.ToString() + " VND";
            message = WinLose.ToString() + " VND";
        }
        public void Transfer()
        {
            string data1= http.Fetch(url + "webroot/restricted/transfer/transfer-full-new.aspx", HttpHelper.HttpMethod.Get, url + "webroot/restricted/HomeLeft.aspx", null);
            string data = Util.HtmlGetAttributeValue(data1, "value", "//input[@id='data']");
            string ek = Util.HtmlGetAttributeValue(data1, "value", "//input[@id='ek']");
            string tk = Util.GetSubstringByString(data1, "getElementById('tk').value='", "'").Replace("getElementById('tk').value='", "").Replace("'", "");
            HtmlNodeCollection checkboxs = Util.HtmlGetNodeCollection(data1, "//input[@name='TS_Chk']");
            string str_TS_Chk = "";
            foreach (HtmlNode checkbox in checkboxs)
            {
                HtmlNode tdparent = checkbox.ParentNode;
                string html = tdparent.PreviousSibling.PreviousSibling.OuterHtml;
                if (html.Contains("-"))
                {
                    string TS_Chk = "TS_Chk=" + checkbox.GetAttributeValue("value", "") + "&";
                    str_TS_Chk += TS_Chk;
                }
            }
            
            string db = Util.HtmlGetAttributeValue(data1, "value", "//input[@id='db']");
            string HidCK = Util.HtmlGetAttributeValue(data1, "value", "//input[@id='HidCK']");
            if(str_TS_Chk!="")
            {
                string postdata = "__VIEWSTATE=&Filter=0&data="+data+"&ek="+ek+"&tk="+tk+"&"+str_TS_Chk+"db="+db+"&cmd=u&HidCK="+HidCK;
                string data2 = http.Fetch(url + "webroot/restricted/transfer/transfer-full-new.aspx", HttpHelper.HttpMethod.Post, url + "webroot/restricted/transfer/transfer-full-new.aspx", postdata);
                message = username + " Transfer Success\n";
            }
            else
            {
                message = "";
            }
        }
        public SboFunction(string key,string username, string password, string usd)
        {
            this.key = key;
            this.username = username;
            this.password = password;
            this.usd = usd;
            http = new HttpHelper();
            db = new Database();
        }
        public string GetStrDay(string DayInput)
        {
            string result = "";
            string Month = DayInput.Split('/')[0];
            string Day = DayInput.Split('/')[1];
            string Year = DayInput.Split('/')[2];
            if (Month.Length == 1)
            {
                Month = "0" + Month;
            }
            if (Day.Length == 1)
            {
                Day = "0" + Day;
            }
            result = Month + "/" + Day + "/" + Year;
            return result;
        }
        public string GetFirstDay()
        {
            string result = "";
            int i = 0;
            while (true)
            {
                i += 1;
                DateTime a = DateTime.Today.AddDays(-i);
                if (a.DayOfWeek == DayOfWeek.Monday)
                {
                    result = GetStrDay(a.ToShortDateString());
                    break;
                }
            }
            return result;
        }
        public string GetLastDay()
        {
            string result = "";
            int i = 0;
            while (true)
            {
                DateTime a = DateTime.Today.AddDays(i);
                if (a.DayOfWeek == DayOfWeek.Sunday)
                {
                    result = GetStrDay(a.ToShortDateString());
                    break;
                }
                i += 1;
            }
            return result;
        }
        public string GetToday()
        {
            string result = "";
            DateTime t = DateTime.Now;
            if (t.Hour < 11)
            {
                result = GetStrDay(t.AddDays(-1).ToShortDateString());
            }
            else
            {
                result = GetStrDay(t.ToShortDateString());
            }

            return result;
        }
    }
}
