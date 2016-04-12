<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Repeater_NHibernate.WebForm2" %>

<%@ Register Src="~/UCPagingHelper.ascx" TagPrefix="uc1" TagName="UCPagingHelper" %>

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
            <br />
            <uc1:UCPagingHelper runat="server" id="UCPagingHelper" PageSize="2" />
        </div>
    </form>
</body>
</html>
