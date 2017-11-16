using System;
using HtmlAgilityPack;

namespace AGENT_NEW
{
    public class IbetFunction : IFunction
    {
        HttpHelper http;
        private string message = "";
        string key, username, password, usd, hesocom;
        Database db;
        double WinLose;
        string UrlIbetMain;
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
            http = new HttpHelper();
            string UrlIbet = "https://www.b8ag.com";
            string LoginName = username;
            string Pass = "lucky6868@";
            //string Code = "790790";
            string detecas_token = "";
            string data = http.Fetch(UrlIbet, HttpHelper.HttpMethod.Get, null, null);
            string code = Util.HtmlGetAttributeValue(data, "value", "//input[@id='code']");
            if (code == "")
            {
                message = "error code";
                return;
            }
            string password = mylib.hc(Pass, code);

            data = http.Fetch(UrlIbet + "/", HttpHelper.HttpMethod.Post, UrlIbet, "hidLanguage=en-US&txtUserName=" + LoginName + " &txtPassWord=" + password + "&code=" + code);
            string errorMessage = Util.HtmlGetInnerText(data, "//div[@id='errmsg']");
            if (!errorMessage.Contains("Wrong username/nickname or password"))
            {
                if (!errorMessage.Contains("Account closed. Please contact your administrator"))
                {
                    data = http.Fetch(UrlIbet + "/Customer/SignIn/Flow", HttpHelper.HttpMethod.Get, UrlIbet, null);
                    //Thread.Sleep(5000);
                    detecas_token = Util.HtmlGetAttributeValue(data, "value", "//input[@id='detecas-token']");
                    detecas_token = Util.EscapeDataString(detecas_token);
                    UrlIbetMain = http.FetchResponseUri(UrlIbet + "/Customer/SignIn/Flow", HttpHelper.HttpMethod.Post, UrlIbet + "/Customer/SignIn/Flow", "detecas-token=" + detecas_token);
                    UrlIbetMain = UrlIbetMain.Replace("/site-main/", "");
                    string data_site_main = http.Fetch(UrlIbetMain + "/site-main/", HttpHelper.HttpMethod.Get, UrlIbetMain + "/Customer/SignIn/Flow", null);
                    //string data_Credit = http.Fetch(UrlIbetMain + "/ex-main/_MemberInfo/CreditBalance/CreditTransfer.aspx?custid=27029908&amt=9,000&username=DT7A0A2030&roleId={RoleId}", HttpHelper.HttpMethod.Get, UrlIbetMain + "/site-main/", null);
                    string data_CreditBalanceList = http.Fetch(UrlIbetMain + "/ex-main/_MemberInfo/CreditBalance/CreditBalanceList.aspx", HttpHelper.HttpMethod.Get, UrlIbetMain + "/site-main/", null);
                    if (data_CreditBalanceList == "")
                    {
                        message = "error request";
                    }
                    else
                    {
                        message = "Login Success";
                    }
                }
                else
                {
                    message = "Account closed. Please contact your administrator";
                }
            }
            else
            {
                message = "Wrong username/nickname or password";
            }
        }
        public void WinLoseWeek()
        {
            string FromDate = GetFirstDay();
            string ToDate = GetLastDay();

            string WinLoseToday = http.Fetch(UrlIbetMain + "/site-reports/winlossdetail/member", HttpHelper.HttpMethod.Get, UrlIbetMain + "/site-main/", null);
            string CustId = Util.HtmlGetAttributeValue(WinLoseToday, "value", "//input[@id='CustId']");
            string CustName = Util.HtmlGetAttributeValue(WinLoseToday, "value", "//input[@id='CustName']");
            string WinLoseRangeDate = http.Fetch(UrlIbetMain + "/site-reports/winlossdetail/member?IsFilterVisible=true&IsHistoricReport=false&IsStackMode=false&IsDescendingSort=false&SortPropertyName=CustName&CustId=" + CustId + "&CustName=" + CustName + "&BreadcrumbLevelJson=%5B%7B%27CustId%27%3A25420724%2C%27CustName%27%3A%27BC96611%27%2C%27CustLevelId%27%3A2%7D%5D&CustLevelId=2&UserSelectedProductIds=1%2C2%2C3%2C4%2C5%2C6%2C8%2C12%2C21%2C22%2C23%2C24&FromDate=" + FromDate + "&ToDate=" + ToDate + "&UserSelectedDateRangeOption=7&PageIndex=undefined&PageSize=undefined", HttpHelper.HttpMethod.Get, UrlIbetMain + "/site-reports/winlossdetail/member", null);
            string[] arr_WinLoseData = WinLoseRangeDate.Split(new string[] { "data-custname=\"" }, StringSplitOptions.None);
            string str_username = "";
            string str_com = "";
            string str_winlose = "";
            double com = 0; double win = 0;
            for (int i = 1; i < arr_WinLoseData.Length; i++)
            {
                string username = arr_WinLoseData[i].Split('"')[0];
                //if (cb_All.Checked == false && username.IndexOf("ZA8U23890") == -1) continue;
                str_username += username + ",";
                str_com += Util.HtmlGetInnerText(arr_WinLoseData[i], "//td[@class='hidden-stack-mode col-gross-com']").Replace("\r\n", "").Replace(",", "").Trim() + ",";
                str_winlose += Util.HtmlGetInnerText(arr_WinLoseData[i], "//td[@class='hidden-stack-mode col-member-winloss ']").Replace("\r\n", "").Replace(",", "").Trim() + ",";
            }
            for (int i = 0; i < str_username.Split(',').Length - 1; i++)
            {
                string username = str_username.Split(',')[i];
                com += double.Parse(str_com.Split(',')[i]);
                win += double.Parse(str_winlose.Split(',')[i]);
            }
            WinLose = Math.Round((com * double.Parse(hesocom) + win) * double.Parse(usd), 0);
            //message = "Com:" + com.ToString() + " WinLose:" + win.ToString() + ".Total:" + WinLose.ToString() + " VND";
            message = WinLose.ToString() + " VND";
        }
        public void Transfer()
        {
            
        }
        public IbetFunction(string key, string username, string password, string usd)
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
