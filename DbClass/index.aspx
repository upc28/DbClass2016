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
            
            margin-right:30px;
        }
        #Button2 {
            width: 83px;
            height: 28px;
            
            
        }
        #Button3 {
            width: 83px;
            height: 28px;
            
            margin-bottom: 0px;
        }
        #Text1 {
            height: 23px;
            margin-right:30px;
        }
        
        #Button9 {
            width: 83px;
            height: 28px;
            
            margin-bottom: 0px;
        }
                
        .auto-style3 {
            width: 165px;
        }
        .auto-style4 {
            margin-left: 4px;
        }
        .auto-style5 {
            width: 249px;
        }
        .auto-style6 {
            margin-left: 2px;
        }
        .auto-style7 {
            margin-left: 54px;
        }
                
        </style>
</head>
<body>
    <form id="form1" autocomplete="off" runat="server">
        <table  style="width:100%;vertical-align:central" >
            <tr>
                <td>
                    <asp:Button ID="Button10" runat="server" Height="25px" OnClick="Button10_Click" Text="源程序" Width="80px" />
                </td>
                <td style="position: fixed; text-align: center;">
        <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="程序文档" Height="25px" Width="80px" />
                </td>
                <td style="text-align: right"> 
                    <label id="Label1"  style="margin-top:10px;text-align:center;vertical-align:central;font-size: 20px;" >输入学号</label>
                    <asp:TextBox ID="TextBox1"   OnKeyPress="if (event.keyCode < 48 || event.keyCode >57) event.returnValue = false;" MaxLength ="8" runat="server" Height="21px" Width="147px" TextMode="SingleLine" style="font-size:21px;ime-mode:disabled" ></asp:TextBox>
                    </td>
                <td style="text-align: left" class="auto-style5">
                    <asp:Button ID="Button1" OnClick="bt1_Click" runat="server" Text="查询" CssClass="auto-style6" /> 
                    <asp:Button ID="Button2" OnClick="bt2_Click" runat="server" Text="删除" CssClass="auto-style4" /></td>
                <td style="text-align: center" class="auto-style3"> 
                    <asp:Button ID="Button3" runat="server" OnClick="bt3_Click" Text="插入记录" CssClass="auto-style7" /></td>
                <td style="text-align: center"><asp:Button ID="Button9" runat="server" OnClick="bt3_Click" Text="专业和奖励信息" Width="113px" /></td>
            </tr>
            <tr>
                <td colspan="5" style="text-align: center"><asp:Label ID="labelMsg" runat ="server" style="margin-top:10px;text-align:center;vertical-align:central;font-size: 20px;"></asp:Label> </td>
            </tr>
        </table>
        <asp:table id="table1" border="1" runat="server" style="width: 80%;margin:0 auto;border-style:Solid;text-align:center;top:6px;">        
    </asp:table>
        <br />
        <br />
        <br />
        <br />
    </form>

    
</body>
</html>
