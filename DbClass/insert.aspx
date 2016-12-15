<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insert.aspx.cs" Inherits="DbClass.insert" CodePage ="65001" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 147px;
        }
        .auto-style3 {
            text-align: center;
            width: 133px;
        }
    </style>
</head>
<body>
    <form id="form1" autocomplete="off" runat="server">
    <div style="border-style: hidden">
    
        <table border="1" style="width:50%;margin:0 auto;border-style:Solid;">
            <tr>
                <td class="auto-style1" colspan="2" style="border-style: hidden">插入学生信息</td>

            </tr>
            <tr>
                <td class="auto-style3"><label>学号</label></td>
                <td class="auto-style2">
                    <asp:TextBox ID="tbox0" runat="server" MaxLength="8"></asp:TextBox>
                </td>
                <td style="border-style: hidden">
                    <asp:Label ID="lab0" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"><label>姓名</label></td>
                <td class="auto-style2">
                    <asp:TextBox ID="tbox1" runat="server"></asp:TextBox>
                </td>
                <td style="border-style: hidden">
                    <asp:Label ID="lab1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">性别</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="dlist2" runat="server">
                    </asp:DropDownList>
                </td>
                <td style="border-style: hidden">
                    <asp:Label ID="lab2" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">年龄</td>
                <td class="auto-style2">
                    <asp:TextBox ID="tbox3" runat="server" MaxLength="2"></asp:TextBox>
                </td>
                <td style="border-style: hidden">
                    <asp:Label ID="lab3" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">专业</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="dlist4" runat="server">
                    </asp:DropDownList>
                </td>
                <td style="border-style: hidden">
                    <asp:Label ID="lab4" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">奖励</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="dlist5" runat="server">
                    </asp:DropDownList>
                </td>
                <td style="border-style: hidden">
                    <asp:Label ID="lab5" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="2">
                    <asp:Button ID="btnAdd" runat="server" OnClick="Button1_Click" Text="插入" />
                    <label style="visibility:hidden"> 55 </label>
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消" />
                </td>
            </tr>
        </table>
    
    </div>
        &nbsp;<table style="width:100%;">
            <tr>
                <td style="text-align: center">
        <asp:Label ID="labMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
