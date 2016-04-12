<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Repeater_NHibernate.WebForm3" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="Webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="title">
                <img src="images/department_work.gif" mce_src="images/department_work.gif" border="0px" />部门工作  
            </div>
            <div id="body">
                <div id="select">
                    关键字：<asp:TextBox ID="txtkeyWord" MaxLength="100" runat="server"></asp:TextBox>
                    查找方式：<asp:DropDownList ID="ddlStyle" Width="100px" runat="server">
                        <asp:ListItem Value="0">-按标题-</asp:ListItem>
                        <asp:ListItem Value="1">-按作者-</asp:ListItem>
                        <asp:ListItem Value="2">-按内容-</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btSearch" runat="server" Height="20px" Text="搜索"
                        OnClick="btSearch_Click" />
                </div>
                <div id="show">
                    <asp:Repeater ID="repShowNews" runat="server">
                        <HeaderTemplate>
                            <table class="table_style" width="100%" id="changecolor">
                                <tr style="background-color: #ECF3FD;">
                                    <th>ID</th>
                                    <th>校名</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("ID").ToString().Trim() %></td>
                                <td><%#Eval("SchoolName").ToString().Trim() %></td>
                            </tr>

                        </ItemTemplate>
                        <FooterTemplate>
                            </table>  
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div id="page">
                    <Webdiyer:AspNetPager ID="AspNetPager1" runat="server"
                        CurrentPageButtonClass="biaogebg" CurrentPageButtonStyle="biaogebg"
                        CustomInfoHTML="[第 %CurrentPageIndex% / %PageCount% 页] [共%RecordCount%条 %PageSize%条/页]　"
                        FirstPageText="首页" LastPageText="尾页" LayoutType="Table" NextPageText="后一页"
                        OnPageChanging="AspNetPager1_PageChanging" PrevPageText="上一页"
                        ShowCustomInfoSection="Right" ShowPageIndexBox="Always" SubmitButtonText="Go"
                        TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" ShowBoxThreshold="20"
                        PagingButtonSpacing="8px" CenterCurrentPageButton="True"
                        CustomInfoSectionWidth="30%" PageIndexBoxType="DropDownList" PageSize="15"
                        ShowPrevNext="False">
                    </Webdiyer:AspNetPager>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
