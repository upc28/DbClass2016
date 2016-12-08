<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insert.aspx.cs" Inherits="DbClass.insert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style1" colspan="2">插入学生信息</td>

            </tr>
            <tr>
                <td class="auto-style1"><label>学号</label></td>
                <td>
                    <asp:TextBox ID="tbox0" runat="server" MaxLength="8"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lab0" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"><label>姓名</label></td>
                <td>
                    <asp:TextBox ID="tbox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lab1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">性别</td>
                <td>
                    <asp:DropDownList ID="dlist2" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lab2" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">年龄</td>
                <td>
                    <asp:TextBox ID="tbox3" runat="server" MaxLength="2"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lab3" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">专业</td>
                <td>
                    <asp:DropDownList ID="dlist4" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lab4" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">奖励</td>
                <td>
                    <asp:DropDownList ID="dlist5" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lab5" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="2">
                    <asp:Button ID="btnAdd" runat="server" OnClick="Button1_Click" Text="插入" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消" />
                </td>
            </tr>
        </table>
    
    </div>
        <asp:Label ID="labMsg" runat="server"></asp:Label>
    </form>
</body>
</html>
