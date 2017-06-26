//表格控件
layui.define(['jquery', 'laypage', 'laytpl'], function (exports) { //提示：模块也可以依赖其它模块，如：layui.define('layer', callback);
    var $ = layui.jquery, laypage = layui.laypage, laytpl = layui.laytpl;

    //jq 的扩展方法 $("#test").laydata()
    $.fn.laydata = function (_opt, args) {
        if (typeof _opt === "string") {//判断是方法还是对象
            return laydata.methods[_opt](this, args);
        }
        _opt = _opt || {};
        return this.each(function () {
            var grid = $.data(this, "laydata");
            if (grid) {
                _opt = $.extend(grid.options, _opt);
                grid.options = _opt;
            } else {
                grid = new laydata(this, _opt);
                $(this).data('laydata', grid);
            }
        });
    }

    var laydata = function (element, option) {
        this.option = option;
        this.element = element;
        this.init();
    }

    laydata.prototype.element = {};
    laydata.prototype.option = {};
    
   
    laydata.prototype.laytpl = function (element, template, data) {
        var gettpl = document.getElementById(template).innerHTML;
        laytpl(gettpl).render(data, function (html) {
            element.innerHTML = html;
        });
    }

    //构造
    laydata.prototype.init = function () {
        this.ajaxdata();//加载数据
        this.page(this.option.parame);
    };

    laydata.prototype.ajaxdata = function () {
        var $this = this;
        var url = $this.option.url;
       var parame = $this.option.parame
        $.post(url, parame, function (data) {
            $this.laytpl($this.element, $this.option.template, data.Value);
            parame.PageIndex = data.PageIndex;
            parame.PageSize = data.PageSize;
            parame.TotalCount = data.TotalCount;
            parame.TotalPages = data.TotalPages;
            $this.page(parame);
        });
    }
    //分页
    laydata.prototype.page = function (parame) {
        var $this = this;
        //PageIndex: 0, PageSize: 10, TotalCount: 1, TotalPages: 1
        laypage({
            cont: "laypage", //容器。值支持id名、原生dom对象，jquery对象。【如该容器为】：<div id="page1"></div>
            pages: parame.TotalPages, //通过后台拿到的总页数
            curr: parame.PageIndex + 1, //当前页
            jump: function (obj, first) { //触发分页后的回调
                if (!first) { //点击跳页触发函数自身，并传递当前页：obj.curr
                    parame.PageIndex = obj.curr - 1;
                    $this.ajaxdata($this.element, $this.option);
                }
            }
        });
    }

    laydata.methods = {
        option: function (jq) {
            return $.data(jq[0], "laydata").option;
        },
        //重新加载
        reload: function (jq, parame) {
            var laydata = $.data(jq[0], "laydata");
            laydata.option.parame = parame;//重新绑定参数
            laydata.ajaxdata();
        },
    };

    exports('laydata', {});
});




