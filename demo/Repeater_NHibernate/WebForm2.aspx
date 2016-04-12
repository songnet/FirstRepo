<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Repeater_NHibernate.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="173px">
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <table border onmousedown="1">
                            <tr>
                                <td>头模板</td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>序号：<%# ("ID") %></td>
                        </tr>
                        <tr>
                            <td>编码：<%# ("SchoolName") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tr>
                            <td>脚模板</td>
                        </tr>
                        </table></FooterTemplate>
                </asp:Repeater>
                当前页：<asp:Label ID="num" runat="server"></asp:Label>
                <br />
                <asp:Button ID="BtnUp" runat="server" OnClick="BtnUp_Click" Text="上一页" />
                <asp:Button ID="BtnDown" runat="server" OnClick="BtnDown_Click" Text="下一页" />
            </asp:Panel>
            <br />
            <br />

        </div>
    </form>
</body>
</html>
