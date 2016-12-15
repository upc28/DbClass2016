<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="information.aspx.cs" Inherits="DbClass.information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        
        .auto-style1 {
            height: 20px;
        }
        
        </style>
</head>
<body>
    <form id="form1" autocomplete="off" runat="server">
    <div>
    
        <table id="table2" border="1" style="width:60%;margin:0 auto;border-style:solid;">
            <tr>
                <td colspan="3">专业信息</td>
                <td colspan="3">奖励类别</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button4" runat="server" Text="添加" OnClick="Button4_Click" />
                </td>
                <td>
                    <asp:Button ID="Button5" runat="server" Text="显示" OnClick="Button5_Click" />
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="Button6" runat="server" Text="添加" OnClick="Button6_Click" />
                </td>
                <td>
                    <asp:Button ID="Button7" runat="server" Text="显示" OnClick="Button7_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3" class="auto-style1">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
                <td colspan="3" class="auto-style1">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6" class="auto-style1" style="text-align: center">
                    <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="返回" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
