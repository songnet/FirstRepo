function InitCharts(chartDivId,
    chartTitleText,
    chartTitleSubText,
    legendText,
    xAxis_data,
    series_data,
    chartType,
    //axisLabelRotate,
    barMaxWidth
    //caseId,
    //IsChecked
    ) {

    //X轴过长是否显示滚动条
    var dataZoomShow = false;
    var dataZoomEnd = 100;//结束百分比
    //var xAxis_dataLength = eval(xAxis_data.replace(/&#39;/g, "'")).length;
    //if (xAxis_dataLength != null && xAxis_dataLength > 12) {
    //    dataZoomShow = true;
    //    dataZoomEnd = parseInt(parseInt(12) / parseInt(xAxis_dataLength) * 100);
    //}

    //初始化X轴字体显示倾斜度
    //if (axisLabelRotate == undefined || axisLabelRotate == null || axisLabelRotate == "" || axisLabelRotate == "0") {
    //    axisLabelRotate = 20;
    //}
    //初始化柱子宽度
    if (barMaxWidth == undefined || barMaxWidth == null || barMaxWidth == "" || barMaxWidth == "0") {
        barMaxWidth = 45;
    }

    require.config({
        paths: {
            echarts: 'Scripts/echarts'
        }
    });
    require(
        [
            'echarts',
            'echarts/chart/bar'
        ],
        function (ec) {
            var myChart = ec.init(document.getElementById(chartDivId), 'macarons');//macarons表示皮肤
            var option = {
                title: {
                    text: chartTitleText,
                    subtext: chartTitleSubText,
                    textStyle: {
                        fontSize: 15
                    }
                },
                tooltip: {
                    trigger: 'axis',
                    //backgroundColor: 'rgba(0,0,0,0.5)',
                    axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                        type: 'line',         // 默认为直线，可选为：'line' | 'shadow'
                        lineStyle: {          // 直线指示器样式设置
                            color: 'red',//坐标轴指示器，默认type为line，可选为：'line' | 'cross' | 'shadow' | 'none'(无)，
                            type: 'dashed'
                        }
                    }
                },
                legend: {
                    data: [legendText]//图例名称
                },
                toolbox: {
                    show: true,
                    feature: {
                        //magicType: { show: true, type: ['line', 'bar'] },
                        restore: { show: true },
                        saveAsImage: { show: true }
                    }
                },
                calculable: false,//是否启用拖拽重计算特性，默认关闭(即值为false)  
                dataZoom: {
                    show: dataZoomShow,//是否显示滚动条
                    //realtime: true,
                    y: 35,
                    height: 10,//滚动条高度
                    start: 0,//开始百分比
                    end: dataZoomEnd//结束百分比
                },
                xAxis: [
                    {
                        axisLabel: {
                            //rotate: axisLabelRotate  //字体倾斜度
                        },
                        type: 'category',
                        data: eval(xAxis_data)  //X轴数据
                    }
                ],
                yAxis: [
                    {
                        type: 'value',
                        splitArea: { show: true }
                    }
                ],
                series: [
                    {
                        name: legendText,
                        Id: 1,
                        barMaxWidth: barMaxWidth,//设置系统最大宽度，不设置时自动适应
                        itemStyle: {
                            normal: {
                                label: { show: true },
                                color: function (params) {
                                    var colorList = [
                        		 	'#C1232B', '#B5C334', '#FCCE10', '#E87C25', '#27727B', '#FE8463',
                        		 	'#D7504B', '#C6E579', '#F4E001', '#F0805A', '#26C0C0', '#9BCA63'
                                    ];
                                    if (params.dataIndex > 12) {
                                        return colorList[(params.dataIndex - 12) % 12];
                                    } else {
                                        return colorList[params.dataIndex];
                                    }
                                }
                            }
                        },
                        type: chartType,//图表显示类型，柱状还是线性
                        data: eval(series_data)
                    }
                ]
            };
            window.onresize = myChart.resize;
            var ecConfig = require('echarts/config');


            myChart.on(ecConfig.EVENT.CLICK, function (param) {
                //if (IsChecked == 1) {
                //    if (caseId != null && caseId != "" && caseId != undefined) {

                //        var index = param.dataIndex;
                //        var caseIds = caseId.split('|')[index];
                //        //GetFaultsByCaseIds(caseIds);
                //        //location.href = "../FaultTrack/GetFaultsByCaseIds?caseids=" + caseIds;
                //    }
                //    else {

                //        var name = param.name;
                //        var start = $("#start").val();
                //        var end = $("#end").val();
                //        location.href = "../ServiceStatistic/ShowWorkLog?startTime=" + start + "&endTime=" + end + "&name=" + name;
                //    }
                //}
            });
            myChart.setOption(option, true);
        }
    );
}


//function GetFaultsByCaseIds(caseids) {
//    $("#hide_caseids").val(caseids);
//    $("#form_case").submit();
//}