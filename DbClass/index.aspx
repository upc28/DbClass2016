<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DbClass.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #Button1 {
            width: 83px;
            height: 28px;
            margin-left:30px;
            margin-right:30px;
        }
        #Button2 {
            width: 83px;
            height: 28px;
            margin-right:30px;
            
        }
        #Button3 {
            width: 83px;
            height: 28px;
            margin-left:50px;
            

        }
        #Text1 {
            height: 23px;
            margin-right:30px;
        }
        
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <table  style="width:100%;text-align:center;vertical-align:central" >
            <tr>
                <td> 
                    <label id="Label1"  style="margin-top:10px;text-align:center;vertical-align:central;font-size: 20px;" >输入学号</label>
                    <asp:TextBox ID="TextBox1"   OnKeyPress="if (event.keyCode < 48 || event.keyCode >57) event.returnValue = false;" MaxLength ="8" runat="server" Height="21px" Width="147px" TextMode="SingleLine" style="font-size:21px;ime-mode:disabled" ></asp:TextBox>
                    <asp:Button ID="Button1" OnClick="bt1_Click" runat="server" Text="查询" /><asp:Button ID="Button2" OnClick="bt2_Click" runat="server" Text="删除" /><asp:Button ID="Button3" runat="server" OnClick="bt3_Click" Text="插入" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="labelMsg" runat ="server" style="margin-top:10px;text-align:center;vertical-align:central;font-size: 20px;"></asp:Label> </td>
            </tr>
        </table>
        <asp:table id="table1" border="1" runat="server" style="width: 80%;margin:0 auto;border-style:Solid;text-align:center;top:6px;">        
    </asp:table>
        <br />
        <table style="width:100%;">
            <tr>
                <td colspan="3">专业信息</td>
                <td colspan="3">奖励类别</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button4" runat="server" Text="添加" />
                </td>
                <td>
                    <asp:Button ID="Button5" runat="server" Text="显示" OnClick="Button5_Click" />
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button6" runat="server" Text="添加" />
                </td>
                <td>
                    <asp:Button ID="Button7" runat="server" Text="显示" OnClick="Button7_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
    </form>

    
</body>
</html>
