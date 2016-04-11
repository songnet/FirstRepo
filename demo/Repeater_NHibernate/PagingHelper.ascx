<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PagingHelper.ascx.cs" Inherits="Repeater_NHibernate.PagingHelper" %>
<div style="width:100%">
    <asp:LinkButton ID="lbtnFirstPage" runat="server" CausesValidation="false" onclick="lbtnPage_Click"  >首页</asp:LinkButton>
    <asp:LinkButton ID="lbtnPrevPage" runat="server" CausesValidation="false"  onclick="lbtnPage_Click" >上一页</asp:LinkButton>
    &nbsp;第<asp:Label ID="lbPageIndex" runat="server" Text=""></asp:Label>
    页/共<asp:Label ID="lbTotalPages" runat="server" Text=""></asp:Label>
    页&nbsp;
    <asp:LinkButton ID="lbtnNextPage" runat="server" CausesValidation="false"  onclick="lbtnPage_Click" >下一页</asp:LinkButton>
    <asp:LinkButton ID="lbtnLastPage" runat="server" CausesValidation="false"  onclick="lbtnPage_Click" >尾页</asp:LinkButton>
    &nbsp;转到
    <asp:TextBox ID="txtGoto" runat="server" Width="32px"></asp:TextBox>
    页<asp:Button ID="btnGoto" runat="server" Text="确定" onclick="btnGoto_Click" />
</div>