using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Word;

namespace DbClass
{
    public struct Reward
    {
        public string key, value;
        public Reward(string _key,string _value)
        {
            key = _key;value = _value;
        }
    };
    public struct InsertMsg
    {
        public string num, name, age;
        public string sex, profession;
        public InsertMsg(string _num,string _name,string _age,string _sex,string _profession)
        {
            num = _num; name = _name; age = _age; sex = _sex; profession = _profession;
        }
    };


    public partial class index : System.Web.UI.Page
    {
        MySqlConnection sqlcon;
        string strCon = "server=www.upc28.com;uid=root;pwd=1996;database=dbclass";
        System.Web.UI.WebControls.Style style1;


        protected void Page_Load(object sender, EventArgs e)
        {
            
           // if (!this.IsPostBack)
           // {
                ConMysql();
                
                refreshTable("");

            //  }
            style1 = new System.Web.UI.WebControls.Style();
            style1.Height = 30;

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
        protected void refreshTable(string ss)
        {     
            table1.Rows.Clear();
            TableCell tCell;
            TableRow tRow;
            MySqlDataReader sdr1;
            //表头
            string []tHead = new string[] { "学号", "姓名", "性别", "年龄", "专业", "奖励" };
            tRow = new TableRow();
            for(int i=0;i<=5;i++)
            {
                tCell = new TableCell();
                tCell.Text = tHead[i];
                
                tCell.ApplyStyle(style1);
                tRow.Cells.Add(tCell);
            }
            table1.Rows.Add(tRow);
            string tTextBox = ss;
            if (tTextBox != "")
            {
                tTextBox = "and student.ID = " + tTextBox;
            }
            sdr1 = getSDR("select student.ID,student.NAME,student.SEX,student.AGE,professionre.NAME from student,professionre where student.PROFESSIONID = professionre.ID " + tTextBox);
            while(sdr1.Read())
            {
                tRow = new TableRow();
                for(int i=0;i<5;i++)
                {
                    tCell = new TableCell();
                    tCell.Text = sdr1.GetValue(i).ToString();
                    tRow.Cells.Add(tCell);
                } 
                table1.Rows.Add(tRow);
            }
            sdr1.Close();
            for(int i=1;i<table1.Rows.Count;i++)
            {
                sdr1 = getSDR("select DETAIL from rewardre where ID in (select REWARDID from reward where SID = " + table1.Rows[i].Cells[0].Text + ")");
                tCell = new TableCell();
                while (sdr1.Read())
                {
                    tCell.Text += sdr1.GetValue(0).ToString() + "</br>";
                }
                sdr1.Close();
                table1.Rows[i].Cells.Add(tCell);
            }

        }      

        protected bool check_Num(string ss)
        {
            if (ss.Length == 0)
            {
                labelMsg.Text = "";
                return true;
            }
            if (ss.Length!=8)
            {
                labelMsg.Text = "学号格式错误";
                return false;
            }
            foreach(char s in ss)
            {
                if(!Char.IsNumber(s))
                {
                    labelMsg.Text = "学号格式错误";
                    return false;
                }
            }
            labelMsg.Text = "";
            return true;
        }

        protected void showProfessionRe()
        {
            

        }

        protected void showRewardRe()
        {

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void bt1_Click(object sender, EventArgs e)
        {
            if (!check_Num(TextBox1.Text)) return;
            refreshTable(TextBox1.Text);
        }
        protected void bt2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Length == 0) return;
            if (!check_Num(TextBox1.Text)) return;
            MySqlDataReader sdr1;
            sdr1 = getSDR("delete from Student where ID = " + TextBox1.Text);//mysql加触发器
            if (sdr1.Read()) Response.Write(sdr1.GetValue(0).ToString());
            sdr1.Close();
            refreshTable("");
        }
        protected void bt3_Click(object sender, EventArgs e)
        {
            //showInsert();
            Response.Redirect("insert.aspx");
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Label2.Text = "";       
            MySqlDataReader sdr1;
            sdr1 = getSDR("select NAME from professionre");
            while(sdr1.Read())
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
            sdr1 = getSDR("insert into professionre (NAME) values('"+TextBox2.Text+"')");
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
            ApplicationClass word = new ApplicationClass();
            Type wordType = word.GetType();
            Documents docs = word.Documents;

        }
    }
}