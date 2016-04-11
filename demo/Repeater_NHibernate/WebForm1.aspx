<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Repeater_NHibernate.WebForm1" %>

<%@ Register Src="~/PagingHelper.ascx" TagPrefix="uc1" TagName="PagingHelper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvDemo" runat="server"> 
            </asp:GridView>
            &nbsp;
            <uc1:PagingHelper runat="server" id="PagingHelper1" OnPageIndexChanged="PagingHelper1_OnPageIndexChanged" />
        </div>
    </form>
</body>
</html>
