using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace DbClass
{
    public partial class information : System.Web.UI.Page
    {
        MySqlConnection sqlcon;
        string strCon = "server=www.upc28.com;uid=dbclassusr;pwd=1996;database=dbclass";
        protected void Page_Load(object sender, EventArgs e)
        {
            ConMysql();
        }
        protected void ConMysql()
        {
            sqlcon = new MySqlConnection(strCon);
            sqlcon.Open();
        }
        private MySqlDataReader getSDR(string fillSql)
        {
            MySqlCommand sqlcmd = new MySqlCommand(fillSql, sqlcon);
            MySqlDataReader sd = sqlcmd.ExecuteReader();
            return sd;
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            Label2.Text = "";
            MySqlDataReader sdr1;
            sdr1 = getSDR("select NAME from professionre");
            while (sdr1.Read())
            {
                Label2.Text += "<br>" + sdr1.GetString(0) + "</br>";
            }
            sdr1.Close();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Label3.Text = "";
            MySqlDataReader sdr1;
            sdr1 = getSDR("select DETAIL from rewardre");
            while (sdr1.Read())
            {
                Label3.Text += "<br>" + sdr1.GetString(0) + "</br>";
            }
            sdr1.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            MySqlDataReader sdr1;
            if (TextBox2.Text == "") return;
            sdr1 = getSDR("insert into professionre (NAME) values('" + TextBox2.Text + "')");
            sdr1.Close();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            MySqlDataReader sdr1;
            if (TextBox3.Text == "") return;
            sdr1 = getSDR("insert into rewardre (DETAIL) values('" + TextBox3.Text + "')");
            sdr1.Close();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}