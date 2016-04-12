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
            <table>
                <tr>
                    <td class="style1" align="left">hehe</td>
                </tr>

                <tr>
                    <td class="style1">
                        <asp:Repeater ID="Repeater1" runat="server">

                            <HeaderTemplate>
                                <table>
                                    <tr>
                                        <td>头模板</td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><font color="red"> <%#("timekey")%></font></td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr>
                                    <td><a href='Default.aspx?id=<%#"databaselogid" %>'><%#("SalesAmountQuota")%></a></td>
                                </tr>
                            </AlternatingItemTemplate>
                            <FooterTemplate>
                                <tr>
                                    <td>尾模板</td>
                                </tr>
                                </table></FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>


                <tr>
                    <td class="style1">
                        <asp:HyperLink ID="first" runat="server">首页</asp:HyperLink>
                        <asp:HyperLink ID="next" runat="server">下一页</asp:HyperLink>
                        <asp:HyperLink ID="up" runat="server">上一页</asp:HyperLink>
                        <asp:HyperLink ID="last" runat="server">末页</asp:HyperLink>
                    </td>
                </tr>

                <tr>
                    <td class="style1">当前页为：<asp:Label ID="lblCurrentPage" runat="server"
                        Text="Label"></asp:Label>&nbsp;
                共<asp:Label ID="labPage" runat="server" Text="Label"></asp:Label>
                        页</td>
                    <td class="style1" style="height: 21px">
                        <asp:HyperLink ID="HyperLink1" runat="server">首页</asp:HyperLink>

                        <asp:HyperLink ID="HyperLink2" runat="server">上一页</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink3" runat="server">下一页</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink4" runat="server">末页</asp:HyperLink>
                    </td>
                </tr>


            </table>
        </div>
    </form>
</body>
</html>
