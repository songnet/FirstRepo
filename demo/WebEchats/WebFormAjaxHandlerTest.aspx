<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAjaxHandlerTest.aspx.cs" Inherits="WebEchats.WebFormAjaxHandlerTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Scripts/jquery-1.8.3.min.js"></script>
    <title>Handler测试</title>
    <script type="text/javascript">

        function search() {
            var name = $('#name').val();
            //省略验证过程
            $.ajax({
                url: 'Handler/DataHandler.ashx',
                data: { type: 'search', name: name },
                dataType: 'json',
                success: function (json) {
                    //对于获取的数据执行相关的操作，如：绑定、显示等
                    alert(json);
                }
            });
        };


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            名字：<input id="name" type="text" />
            <input type="button" value="查询" onclick="search()" />
        </div>
    </form>
</body>
</html>
