using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using HtmlAgilityPack;
using System.IO;

namespace AGENT_NEW
{
    public partial class AgentList : UserControl
    {
        Database db;
        DataTable dtSBO, dtIBET;
        Thread tSbo, tIbet;
        public AgentList()
        {
            InitializeComponent();
            db = new Database();
        }

        private void bt_AddAgent_Click(object sender, EventArgs e)
        {
            string str_insert = rtb_InPut.Text;
            int i = 0;
            string result = "";
            foreach (string insert in str_insert.Split('\n'))
            {
                if (insert == "" || insert.Contains("-")) continue;
                i += 1;
                if (db.InsertAgent(insert, i) > 0)
                {
                    result += "Acc " + i.ToString() + ": Add Successful\n";
                }
                else
                {
                    result += "Acc " + i.ToString() + ": Add Fail\n";
                }
            }
            rtb_OutPut.Text = result;
        }

        private void AgentList_Load(object sender, EventArgs e)
        {
            createTableSBO(db.GetAgent("sbo"));
            createTableIBET(db.GetAgent("ibet"));
        }
        private void createTableSBO(DataTable dt, bool status = false, string FilterGroup = "")
        {
            dataGridViewSBO.Columns.Clear();
            dtSBO = new DataTable();
            dtSBO.Columns.Add("key");
            dtSBO.PrimaryKey = new DataColumn[] { dtSBO.Columns["key"] };
            
            dtSBO.Columns.Add("username");
            dtSBO.Columns.Add("usd");
            dtSBO.Columns.Add("com");
            dtSBO.Columns.Add("message");
            dtSBO.Columns.Add("PartnerName");

            int index = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["status"].ToString() == "0" && status == true)
                {
                    continue;
                }
                index++;
                dtSBO.Rows.Add(new Object[] { "sbo" + index, dr["username"], dr["usd"], dr["com"], "", dr["PartnerName"] });
            }

            dataGridViewSBO.DataSource = dtSBO;
            int Width_dataGridView = dataGridViewSBO.Width;

            dataGridViewSBO.Columns["key"].HeaderText = "KEY";
            dataGridViewSBO.Columns["username"].HeaderText = "USERNAME";
            dataGridViewSBO.Columns["usd"].HeaderText = "USD";
            dataGridViewSBO.Columns["com"].HeaderText = "COM";
            dataGridViewSBO.Columns["message"].HeaderText = "MESSAGE";
            dataGridViewSBO.Columns["PartnerName"].HeaderText = "PartnerName";

            dataGridViewSBO.Columns["key"].ReadOnly = true;
            dataGridViewSBO.Columns["username"].ReadOnly = true;
            dataGridViewSBO.Columns["usd"].ReadOnly = true;
            dataGridViewSBO.Columns["com"].ReadOnly = true;
            dataGridViewSBO.Columns["message"].ReadOnly = true;
            dataGridViewSBO.Columns["PartnerName"].ReadOnly = true;

            dataGridViewSBO.Columns["key"].Width = Width_dataGridView * 10 / 100;
            dataGridViewSBO.Columns["username"].Width = Width_dataGridView * 10 / 100;
            dataGridViewSBO.Columns["usd"].Width = Width_dataGridView * 5 / 100;
            dataGridViewSBO.Columns["com"].Width = Width_dataGridView * 5 / 100;
            dataGridViewSBO.Columns["message"].Width = Width_dataGridView * 40 / 100;
            dataGridViewSBO.Columns["PartnerName"].Width = Width_dataGridView * 10 / 100;

            DataGridViewButtonColumn colButtonLogin = new DataGridViewButtonColumn();
            colButtonLogin.HeaderText = "LOGIN";
            colButtonLogin.Name = "login";
            colButtonLogin.Text = "Log";
            colButtonLogin.Width = Width_dataGridView * 5 / 100;
            colButtonLogin.UseColumnTextForButtonValue = true;
            dataGridViewSBO.Columns.Add(colButtonLogin);

            DataGridViewButtonColumn colButtonLoginWeb = new DataGridViewButtonColumn();
            colButtonLoginWeb.HeaderText = "LWEB";
            colButtonLoginWeb.Name = "lweb";
            colButtonLoginWeb.Text = "LWeb";
            colButtonLoginWeb.Width = Width_dataGridView * 5 / 100;
            colButtonLoginWeb.UseColumnTextForButtonValue = true;
            dataGridViewSBO.Columns.Add(colButtonLoginWeb);

            DataGridViewButtonColumn colButtonNew = new DataGridViewButtonColumn();
            colButtonNew.HeaderText = "NEW";
            colButtonNew.Name = "new";
            colButtonNew.Text = "New";
            colButtonNew.Width = Width_dataGridView * 5 / 100;
            colButtonNew.UseColumnTextForButtonValue = true;
            dataGridViewSBO.Columns.Add(colButtonNew);

            foreach (DataGridViewColumn col in dataGridViewSBO.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }


        }
        private void createTableIBET(DataTable dt, bool status = false, string FilterGroup = "")
        {
            dataGridViewIBET.Columns.Clear();
            dtIBET = new DataTable();
            dtIBET.Columns.Add("key");
            dtIBET.PrimaryKey = new DataColumn[] { dtIBET.Columns["key"] };

            dtIBET.Columns.Add("username");
            dtIBET.Columns.Add("usd");
            dtIBET.Columns.Add("com");
            dtIBET.Columns.Add("message");
            dtIBET.Columns.Add("PartnerName");

            int index = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["status"].ToString() == "0" && status == true)
                {
                    continue;
                }
                index++;
                dtIBET.Rows.Add(new Object[] { "ibet" + index, dr["username"], dr["usd"], dr["com"], "", dr["PartnerName"] });
            }

            dataGridViewIBET.DataSource = dtIBET;
            int Width_dataGridView = dataGridViewIBET.Width;

            dataGridViewIBET.Columns["key"].HeaderText = "KEY";
            dataGridViewIBET.Columns["username"].HeaderText = "USERNAME";
            dataGridViewIBET.Columns["usd"].HeaderText = "USD";
            dataGridViewIBET.Columns["com"].HeaderText = "COM";
            dataGridViewIBET.Columns["message"].HeaderText = "MESSAGE";
            dataGridViewIBET.Columns["PartnerName"].HeaderText = "PartnerName";

            dataGridViewIBET.Columns["key"].ReadOnly = true;
            dataGridViewIBET.Columns["username"].ReadOnly = true;
            dataGridViewIBET.Columns["usd"].ReadOnly = true;
            dataGridViewIBET.Columns["com"].ReadOnly = true;
            dataGridViewIBET.Columns["message"].ReadOnly = true;
            dataGridViewSBO.Columns["PartnerName"].ReadOnly = true;

            dataGridViewIBET.Columns["key"].Width = Width_dataGridView * 10 / 100;
            dataGridViewIBET.Columns["username"].Width = Width_dataGridView * 10 / 100;
            dataGridViewIBET.Columns["usd"].Width = Width_dataGridView * 5 / 100;
            dataGridViewIBET.Columns["com"].Width = Width_dataGridView * 5 / 100;
            dataGridViewIBET.Columns["message"].Width = Width_dataGridView * 40 / 100;
            dataGridViewIBET.Columns["PartnerName"].Width = Width_dataGridView * 10 / 100;

            DataGridViewButtonColumn colButtonLogin = new DataGridViewButtonColumn();
            colButtonLogin.HeaderText = "LOGIN";
            colButtonLogin.Name = "login";
            colButtonLogin.Text = "Log";
            colButtonLogin.Width = Width_dataGridView * 5 / 100;
            colButtonLogin.UseColumnTextForButtonValue = true;
            dataGridViewIBET.Columns.Add(colButtonLogin);

            DataGridViewButtonColumn colButtonLoginWeb = new DataGridViewButtonColumn();
            colButtonLoginWeb.HeaderText = "LWEB";
            colButtonLoginWeb.Name = "lweb";
            colButtonLoginWeb.Text = "LWeb";
            colButtonLoginWeb.Width = Width_dataGridView * 5 / 100;
            colButtonLoginWeb.UseColumnTextForButtonValue = true;
            dataGridViewIBET.Columns.Add(colButtonLoginWeb);

            DataGridViewButtonColumn colButtonNew = new DataGridViewButtonColumn();
            colButtonNew.HeaderText = "NEW";
            colButtonNew.Name = "new";
            colButtonNew.Text = "New";
            colButtonNew.Width = Width_dataGridView * 5 / 100;
            colButtonNew.UseColumnTextForButtonValue = true;
            dataGridViewIBET.Columns.Add(colButtonNew);

            foreach (DataGridViewColumn col in dataGridViewIBET.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void bt_WinLoseWeek_Click(object sender, EventArgs e)
        {
            string keyagent = "";
            foreach (DictionaryEntry Entry in Partner)
            {
                keyagent += Entry.Key + ",";
            }
            for(int i=0; i<keyagent.Split(',').Length-1; i++)
            {
                double tam = 0;
                Partner[keyagent.Split(',')[i]] = tam;
            }
            foreach (DataRow dr in dtIBET.Rows)
            {
                BetManager.GetAgentObj(dr["key"].ToString()).WinLoseWeek();
                dr["message"] = BetManager.GetAgentObj(dr["key"].ToString()).getMessage();
                double WL = BetManager.GetAgentObj(dr["key"].ToString()).getWinLose();
                double WLTotal = (double)Partner[dr["PartnerName"]];
                Partner[dr["PartnerName"]] = WL + WLTotal;
                Thread.Sleep(100);
            }


            foreach (DataRow dr in dtSBO.Rows)
            {
                BetManager.GetAgentObj(dr["key"].ToString()).WinLoseWeek();
                dr["message"] = BetManager.GetAgentObj(dr["key"].ToString()).getMessage();
                double WL = BetManager.GetAgentObj(dr["key"].ToString()).getWinLose();
                double WLTotal = (double)Partner[dr["PartnerName"]];
                Partner[dr["PartnerName"]] = WL + WLTotal;
                Thread.Sleep(100);
            }

            string output = "";
            foreach (DictionaryEntry Entry in Partner)
            {
                output += Entry.Key + ":" + Entry.Value + " VND\n";
            }
            rtb_OutPut.Text = output;
        }

        private void bt_Transfer_Click(object sender, EventArgs e)
        {
            string output = "";
            foreach (DataRow dr in dtSBO.Rows)
            {
                BetManager.GetAgentObj(dr["key"].ToString()).Transfer();
                Thread.Sleep(100);
                output += BetManager.GetAgentObj(dr["key"].ToString()).getMessage();
            }
            rtb_OutPut.Text = output;
        }

        private Hashtable Partner = new Hashtable();
        private void bt_Login_Click(object sender, EventArgs e)
        {
            tIbet = new Thread(delegate ()
            {
                foreach (DataRow dr in dtIBET.Rows)
                {
                    BetManager.CreatAgentObj("ibet", dr["key"].ToString(), dr["username"].ToString(), dr["usd"].ToString());
                    BetManager.GetAgentObj(dr["key"].ToString()).login();
                    BetManager.GetAgentObj(dr["key"].ToString()).SetUsd(dr["usd"].ToString());
                    BetManager.GetAgentObj(dr["key"].ToString()).SetHeSoCom(dr["com"].ToString());
                    if(Partner.Contains(dr["PartnerName"])==false)
                    {
                        double WinLosePartner = 0;
                        Partner.Add(dr["PartnerName"], WinLosePartner);
                    }
                    dr["message"] = BetManager.GetAgentObj(dr["key"].ToString()).getMessage();
                    Thread.Sleep(100);
                }
            });
            tIbet.Start();
            tSbo = new Thread(delegate ()
            {
                foreach (DataRow dr in dtSBO.Rows)
                {
                    BetManager.CreatAgentObj("sbo", dr["key"].ToString(), dr["username"].ToString(), dr["usd"].ToString());
                    BetManager.GetAgentObj(dr["key"].ToString()).login();
                    BetManager.GetAgentObj(dr["key"].ToString()).SetUsd(dr["usd"].ToString());
                    BetManager.GetAgentObj(dr["key"].ToString()).SetHeSoCom(dr["com"].ToString());
                    dr["message"] = BetManager.GetAgentObj(dr["key"].ToString()).getMessage();
                    Thread.Sleep(100);
                }
            });
            tSbo.Start();
        }
    }
}
