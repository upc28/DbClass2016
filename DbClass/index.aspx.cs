using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

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
        string strCon = "server=localhost;uid=root;pwd=;database=dbclass";
        Button btnAdd,btnCancel;
        TextBox tbox0, tbox1, tbox4;
        DropDownList dlist2, dlist5, dlist6;
        protected void Page_Load(object sender, EventArgs e)
        {
            ConMysql();
            refreshTable("");


            btnAdd = new Button();
            btnAdd.Text = "添加";
            btnAdd.ID = "btnAdd";
            btnAdd.Click += new EventHandler(this.bt4_Click);
            this.Page.Form.Controls.Add(btnAdd);
            btnAdd.Visible = false;

            btnCancel = new Button();
            btnCancel.Text = "取消";
            btnCancel.ID = "btnCancel";
            btnCancel.Click += new EventHandler(this.bt5_Click);
            this.Page.Form.Controls.Add(btnCancel);
            btnCancel.Visible = false;
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
                tRow.Cells.Add(tCell);
            }
            table1.Rows.Add(tRow);
            string tTextBox = ss;
            if (tTextBox != "")
            {
                tTextBox = "and Student.ID = " + tTextBox;
            }
            sdr1 = getSDR("select Student.ID,Student.NAME,Student.SEX,Student.AGE,professionre.NAME from Student,professionre where Student.PROFESSIONID = professionre.ID " + tTextBox);
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
        protected void showInsert()
        {
            table1.Rows.Clear();
            TableRow tRow;
            TableCell tCell;
            string[] tHead = new string[] { "学号", "姓名", "性别", "年龄", "专业", "奖励" };
            for (int i = 0; i < 6; i++)
            {
                tRow = new TableRow();
                tCell = new TableCell();
                tCell.Text = tHead[i];
                tRow.Cells.Add(tCell);
                table1.Rows.Add(tRow);
            }

            tCell = new TableCell();
            tbox0 = new TextBox();
            tbox0.MaxLength = 8; tbox0.Font.Size = 11;
            tCell.Controls.Add(tbox0);
            table1.Rows[0].Cells.Add(tCell);

            tCell = new TableCell();
            tbox1 = new TextBox();
            tbox1.MaxLength = 8; tbox1.Font.Size = 11;
            tCell.Controls.Add(tbox1);
            table1.Rows[1].Cells.Add(tCell);

            tCell = new TableCell();
            dlist2 = new DropDownList();
            dlist2.Items.Add(new ListItem("", "0"));
            dlist2.Items.Add(new ListItem("男", "1"));
            dlist2.Items.Add(new ListItem("女", "2"));
            tCell.Controls.Add(dlist2);
            table1.Rows[2].Cells.Add(tCell);

            tCell = new TableCell();
            tbox4 = new TextBox();
            tbox4.MaxLength = 8; tbox4.Font.Size = 11;
            tCell.Controls.Add(tbox4);
            table1.Rows[3].Cells.Add(tCell);

            tCell = new TableCell();
            dlist5 = new DropDownList();
            MySqlDataReader sdr1;
            sdr1 = getSDR("select ID,NAME from professionre");
            while (sdr1.Read())
            {
                dlist5.Items.Add(new ListItem(sdr1.GetValue(1).ToString(), sdr1.GetValue(0).ToString()));
            }
            sdr1.Close();
            tCell.Controls.Add(dlist5);
            table1.Rows[4].Cells.Add(tCell);

            tCell = new TableCell();
            dlist6 = new DropDownList();
            sdr1 = getSDR("select ID,DETAIL from rewardre");
            dlist6.Items.Add(new ListItem("", "0"));
            while (sdr1.Read())
            {
                dlist6.Items.Add(new ListItem(sdr1.GetValue(1).ToString(), sdr1.GetValue(0).ToString()));
            }
            sdr1.Close();
            tCell.Controls.Add(dlist6);
            table1.Rows[5].Cells.Add(tCell);

            tRow = new TableRow();
            tCell = new TableCell();
            /*Button btn = new Button();
            btn.Text = "添加";
            btn.ID = "btnInsert1";
            
            btn.Click += new EventHandler(this.bt4_Click);*/
            //btn.Attributes.Add("onclick", "bt4_Click");
            //this.Page.Form.Controls.Add(btn);
            
            tCell.Controls.Add(btnAdd);
            Label tlab = new Label();
            tlab.Text = "     ";
            tCell.Controls.Add(tlab);
            tCell.Controls.Add(btnCancel);
            btnAdd.Visible = true;
            btnCancel.Visible = true;
            /*btn = new Button();
            btn.Text = "取消";
            tCell.Controls.Add(btn);*/
            
            tCell.ColumnSpan = 2;
            tRow.Cells.Add(tCell);
            table1.Rows.Add(tRow);
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

        protected void insertStu()
        {   
            string num = tbox0.Text;
            if (num.Length == 0)
            {
                labelMsg.Text = "请输入学号";
                return;
            }
            MySqlDataReader sdr1;
            bool mode=false;
            sdr1 = getSDR("select count(ID) from Student where ID = " + num);
            if(sdr1.Read())
            {
                if (sdr1.GetValue(0).ToString() == "1")
                {
                    mode = true;
                }
                else mode = false;
            }
            sdr1.Close();
            if(mode)
            {
                InsertMsg insertmsg;
                sdr1 = getSDR("select NAME,AGE,SEX,PROFESSION from Student where ID = " + num);
                if (sdr1.Read())
                {
                    insertmsg = new InsertMsg(num, sdr1.GetValue(0).ToString(), sdr1.GetValue(1).ToString(), sdr1.GetValue(2).ToString(), sdr1.GetValue(3).ToString());
                }
                else insertmsg = new InsertMsg();
                sdr1.Close();
                if(tbox1.Text!=""&&tbox1.Text!=insertmsg.name)
                {
                    labelMsg.Text = "学号已存在";
                    return;
                }
                if (tbox4.Text != "" && tbox4.Text != insertmsg.age)
                {
                    labelMsg.Text = "学号已存在";
                    return;
                }
                if(dlist2.Text!=""&&dlist2.Text!=insertmsg.sex)
                {
                    labelMsg.Text = "学号已存在";
                    return;
                }
                if (dlist5.Text != "" && dlist5.Text != insertmsg.profession)
                {
                    labelMsg.Text = "学号已存在";
                    return;
                }
                if(dlist6.Text=="")
                {
                    labelMsg.Text = "啥也不插入是什么鬼=.=";
                    return;
                }
                sdr1 = getSDR("insert into reward values(" + num + "," + dlist6.SelectedValue + ")");
                if(sdr1.Read())
                {
                    labelMsg.Text = sdr1.GetValue(0).ToString();
                }
                sdr1.Close();
            }
            else
            {
                if(tbox1.Text==""||tbox4.Text==""||dlist2.Text==""||dlist5.Text=="")
                {
                    labelMsg.Text = "数据不完全";
                    return;
                }
                sdr1 = getSDR("insert into Student (ID,NAME,SEX,AGE,PROFESSIONID) values(" + num + "," + tbox1.Text + "," + dlist2.SelectedValue + "," + tbox4.Text + "," + dlist5.SelectedValue + ")");
                if(sdr1.Read())
                {
                    labelMsg.Text = sdr1.GetValue(0).ToString();
                }
                sdr1.Close();
            }

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
            showInsert();
        }
        protected void bt4_Click(object sender, EventArgs e)
        {
            insertStu();
        }
        protected void bt5_Click(object sender, EventArgs e)
        {
            refreshTable("");
        }
        
    }
}