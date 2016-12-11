using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Text;

namespace DbClass
{
    public partial class insert : System.Web.UI.Page
    {
        MySqlConnection sqlcon;
        string strCon = "server=www.upc28.com;uid=root;pwd=1996;database=dbclass";
        protected void Page_Load(object sender, EventArgs e)
        {

            ConMysql();
            if (!IsPostBack)
            {
                initTable();
            }          
            

        }
        protected void initTable()
        {
            MySqlDataReader sdr1;
            dlist2.Items.Add(new ListItem("", "0"));
            dlist2.Items.Add(new ListItem("男", "1"));
            dlist2.Items.Add(new ListItem("女", "2"));
            sdr1 = getSDR("select ID,NAME from professionre");
            dlist4.Items.Add(new ListItem("", "0"));
            while (sdr1.Read())
            {
                dlist4.Items.Add(new ListItem(sdr1.GetValue(1).ToString(), sdr1.GetValue(0).ToString()));
            }
            sdr1.Close();
            sdr1 = getSDR("select ID,DETAIL from rewardre");
            dlist5.Items.Add(new ListItem("", "0"));
            while (sdr1.Read())
            {
                dlist5.Items.Add(new ListItem(sdr1.GetValue(1).ToString(), sdr1.GetValue(0).ToString()));
            }
            sdr1.Close();
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

        protected void insertMsg()
        {       

            initLab();
            string num = tbox0.Text;
            if(num.Length!=8)
            {
                lab0.Text = "学号格式错误";
                labMsg.Text = "插入错误";
                return;
            }
            foreach(char s in num)
            {
                if(!Char.IsNumber(s))
                {
                    lab0.Text = "学号格式错误";
                    labMsg.Text = "插入错误";
                    return;
                }
            }
            string name, sex, age, profession;
            name = tbox1.Text;
            sex = dlist2.SelectedValue;
            age = tbox3.Text;
            profession = dlist4.SelectedValue;
            MySqlDataReader sdr1;
            sdr1 = getSDR("select NAME,AGE,SEX,PROFESSIONID from student where ID = " + num);
            if (sdr1.Read())
            {
                if((name!=""&&name!=sdr1.GetValue(0).ToString())|| (age != "" && age != sdr1.GetValue(1).ToString())||
                    (sex != "0" && sex != sdr1.GetValue(2).ToString())|| (profession != "0" && profession != sdr1.GetValue(3).ToString()))
                {
                    lab1.Text = "学号已存在";
                    labMsg.Text = "插入错误";
                    return;
                }               
                sdr1.Close();
                if (dlist5.SelectedValue != "0")
                {
                    sdr1 = getSDR("insert into reward values(" + num + "," + dlist5.SelectedValue + ")");
                    sdr1.Close();
                    labMsg.Text = "插入信息成功：</p>" +
                              "学号:" + num + "</p>" +
                              "奖励:" + dlist5.SelectedItem.Text + "</p>";
                }
                else
                {
                    labMsg.Text = "你啥也不添加是什么鬼=.=";
                }
            }
            else
            {
                sdr1.Close();
                if (name=="")
                {
                    lab1.Text = "姓名不能为空";
                    labMsg.Text = "插入错误";
                    return;
                }
                if (sex == "0")
                {
                    lab2.Text = "性别不能为空";
                    labMsg.Text = "插入错误";
                    return;
                }
                if (age == "")
                {
                    lab3.Text = "年龄不能为空";
                    labMsg.Text = "插入错误";
                    return;
                }
                if (profession == "0")
                {
                    lab4.Text = "专业不能为空";
                    labMsg.Text = "插入错误";
                    return;
                }

                byte[] utf8 = Encoding.UTF8.GetBytes(name);
                name = Encoding.UTF8.GetString(utf8);;

                sdr1 = getSDR("insert into student  values(" + num + ",'" + name + "'," + sex + "," + age + "," + profession + ")");
                sdr1.Close();
                labMsg.Text = "插入信息成功：</p>" +
                              "学号:" + num + "</p>" +
                              "姓名:" + name + "</p>" +
                              "性别:" + dlist2.SelectedItem.Text + "</p>" +
                              "年龄:" + age + "</p>" +
                              "专业:" + dlist4.SelectedItem.Text + "</p>";
                if (dlist5.SelectedValue!="0")
                {
                    sdr1 = getSDR("insert into reward values(" + num + "," + dlist5.SelectedValue + ")");
                    sdr1.Close();
                    labMsg.Text += "奖励:" + dlist5.SelectedItem.Text;
                }               
            }   
        }

        protected void initLab()
        {
            lab0.Text = "";
            lab1.Text = "";
            lab2.Text = "";
            lab3.Text = "";
            lab4.Text = "";
            lab5.Text = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            insertMsg();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
       
    }
}