$(function () {
    //var type = '';
    //var title = '<tr><th>＃</th><th>待付款</th><th>宝宝数量</th><th>交易金额</th><th>操作</th></tr>';
    //var datalist = '';

    //for (var i = 0; i < 10; i++) {
    //    datalist += '<tr><td>所有</td><td>9999</td><td>999</td><td>99999.00</td><td>' +
    //                '<div class="sui-btn-toolbar"><div class="sui-btn-group"><button class="sui-btn btn-primary">编辑</button><button class="sui-btn btn-danger">删除</button>' +
    //                '</div></div></td></tr>';
    //}
    //$(".ajaxlist").html('<thead>' + title + '</thead><tbody>' + datalist + '</tbody>');
});



function selectAjax(url, para, titel) {
    $.post(url, para, function (data) {
        console.log(data);
        Binders(data.Value);//PageIndex: 0, PageSize: 10, TotalCount: 5, TotalPages:1
        
        $(".Sui-page").pagination({
            itemsCount: data.TotalCount,
            pageSize: data.PageSize,
            styleClass: ['pagination-large'],
            displayPage: 6,
            onSelect: function (index) {//点击分页按钮时执行
                var model = getdata();
                model.PageIndex = index - 1;
                selectAjax(url, model);
            }
        });
    });
};


