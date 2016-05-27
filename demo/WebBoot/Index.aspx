<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebBoot.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Scripts/bootstrap-3.3.4-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Scripts/bootstrap-3.3.4-dist/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap-3.3.4-dist/js/jquery.min.js"></script>
    <script src="Scripts/bootstrap-3.3.4-dist/js/bootstrap.js"></script>
    <title></title>
    <style>
        /*body {
            TEXT-ALIGN: center;
        }*/

        #center {
            MARGIN-RIGHT: auto;
            MARGIN-LEFT: auto;
            height: 600px;
            width: 600px;
            vertical-align: middle;
        }
    </style>
    <script type="text/javascript">
        $(function () {


        })

        function AddFun() {

            $('#myModalLabel').text('添加');
            //$('#fu').();

            //$.ajax({
            //    url: '../api/Home/GetSelect',
            //    type: 'get',
            //    datatype: 'json',
            //    success: function (data) {
            //        var html = "";
            //        $.each(data.data, function (index, row) {
            //            html += '<option value="' + row.Value + '">' + row.Text + '</option>';
            //        });
            //        $('#sel1').empty();
            //        $('#sel1').append(html);


            //    }
            //})

            $('#myModal').modal('show');

        }


    </script>
</head>
<body>
    <!-- 标准的按钮 -->
    <button type="button" class="btn btn-default">默认按钮</button>

    <!-- 提供额外的视觉效果，标识一组按钮中的原始动作 -->
    <button type="button" class="btn btn-primary">原始按钮</button>

    <!-- 表示一个成功的或积极的动作 -->
    <button type="button" class="btn btn-success">成功按钮</button>

    <!-- 信息警告消息的上下文按钮 -->
    <button type="button" class="btn btn-info">信息按钮</button>

    <!-- 表示应谨慎采取的动作 -->
    <button type="button" class="btn btn-warning">警告按钮</button>

    <!-- 表示一个危险的或潜在的负面动作 -->
    <button type="button" class="btn btn-danger">危险按钮</button>

    <!-- 并不强调是一个按钮，看起来像一个链接，但同时保持按钮的行为 -->
    <button type="button" class="btn btn-link">链接按钮</button>

    <button class="btn btn-default" data-toggle="modal" onclick="AddFun()">添加</button>


    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="false" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel"></h4>
                </div>
                <div class="modal-body">
                    <form id="fu">

                        <!--隐藏域，用于传ID-->
                        <input type="hidden" id="uid" name="UserId" value="" />

                        <!--下拉框-->
                        <!--<div class="dropdown">
                            <button type="button" class="btn dropdown-toggle" id="dropdownMenu1"
                                    data-toggle="dropdown">
                                主题
                                <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                                <li role="presentation">
                                    <a role="menuitem" tabindex="-1" href="#">Java</a>
                                </li>
                                <li role="presentation">
                                    <a role="menuitem" tabindex="-1" href="#">数据挖掘</a>
                                </li>
                                <li role="presentation">
                                    <a role="menuitem" tabindex="-1" href="#">
                                        数据通信/网络
                                    </a>
                                </li>
                                <li role="presentation" class="divider"></li>
                                <li role="presentation">
                                    <a role="menuitem" tabindex="-1" href="#">分离的链接</a>
                                </li>
                            </ul>
                        </div>-->
                        <!--select-->
                        <div class="form-group">
                            <label for="name">选择科目</label>
                            <select class="form-control" id="sel1"></select>

                            <!--<label for="name">可多选的选择列表</label>
                            <select multiple class="form-control">
                                <option>1</option>
                                <option>2</option>
                                <option>3</option>
                                <option>4</option>
                                <option>5</option>
                            </select>-->
                        </div>


                        <div class="form-group">
                            <label for="exampleInputEmail1">Name</label>
                            <input type="text" class="form-control" id="uname" placeholder="Enter Name">
                        </div>

                        <!--横向radio-->
                        <div class="form-group">
                            <label for="exampleInputEmail1">Sex</label><br />
                            <label class="checkbox-inline">
                                <input type="radio" name="optionsRadiosinline" id="nan"
                                    value="male" checked>男
                            </label>
                            <label class="checkbox-inline">
                                <input type="radio" name="optionsRadiosinline" id="nv"
                                    value="female">女
                            </label>
                        </div>

                        <div class="form-group">
                            <label for="exampleInputPassword1">Age</label>
                            <input type="text" class="form-control" id="uage" placeholder="Enter Age">
                        </div>

                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default"
                        data-dismiss="modal">
                        关闭
                    </button>
                    <button type="submit" class="btn btn-primary" onclick="Save()">
                        提交
                    </button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>

    <!-- 居中的DIV -->
    <div id="center">
        <form class="form-horizontal" role="form">
            <div class="form-group">
                <label for="title" class="col-sm-2 control-label">题名</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" id="title" placeholder="必须填，便于查找检测报告" />
                </div>
            </div>
            <div class="form-group">
                <label for="author" class="col-sm-2 control-label">作者</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" id="author" placeholder="必须填，便于查找检测报告" />
                </div>
            </div>
            <ul id="myTab" class="nav nav-pills">
                <li role="presentation" class="active"><a href="#home" data-toggle="tab">粘贴文本</a></li>
                <li role="presentation"><a href="#upload" data-toggle="tab">上传文献</a></li>
            </ul>

            <div id="myTabContent" class="tab-content">
                <div class="tab-pane fade in active" id="home">
                    <p>W3Cschoool菜鸟教程是一个提供最新的web技术站点，本站免费提供了建站相关的技术文档，帮助广大web技术爱好者快速入门并建立自己的网站。菜鸟先飞早入行——学的不仅是技术，更是梦想。</p>
                </div>
                <div class="tab-pane fade" id="upload">
                    <p>
                        iOS 是一个由苹果公司开发和发布的手机操作系统。最初是于 2007 年首次发布 iPhone、iPod Touch 和 Apple 
      TV。iOS 派生自 OS X，它们共享 Darwin 基础。OS X 操作系统是用在苹果电脑上，iOS 是苹果的移动版本。
                    </p>
                </div>
            </div>
        </form>

    </div>

</body>
</html>
