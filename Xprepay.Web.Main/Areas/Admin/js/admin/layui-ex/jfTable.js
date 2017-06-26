layui.define(['form', 'jquery', 'laypage'], function (exports) {
    var $ = layui.jquery, laypage = layui.laypage, form = layui.form();
   
    $.fn.jfTable = function (_opt, args) {
        if (typeof _opt == "string") {//判断是方法还是对象

            return JfTable.methods[_opt](this, args);
        }
        _opt = _opt || {};
        return this.each(function () {
            var grid = $.data(this, "jfTable");
            if (grid) {
                _opt = $.extend(grid.options, _opt);
                grid.options = _opt;
            } else {
                grid = new JfTable(this, _opt);
                $(this).data('jfTable', grid);
            }
        });
    }


    var JfTable = function (element, option) {
        this.$element = $(element);
        if (option.select) {
            option.columns.unshift({
                type: 'check',
                width: 50
            });
        }
        this.option = $.extend({}, JfTable.default, option);
        this.init();
        if (option.page) {
            this.$page = $("<div class='page-bar'></div>").insertAfter(this.$element);
            this.initPage();
        }
    }

    JfTable.prototype.init = function () {
        $("<table class='layui-table'></table>").appendTo(this.$element.html(""));
        if (this.option.url) {
            this.ajaxData();
        }
        this.initBody();
        this.initToolbar();
    };

    JfTable.prototype.initEvent = function () {
        var t = this, _opt = t.option;
        if (_opt.select) {
            form.render("checkbox");
            form.on('checkbox(allChoose)', function (data) {
                var child = $(data.elem).parents('table').find('tbody input[type="checkbox"]');
                child.each(function (index, item) {
                    item.checked = data.elem.checked;
                });
                form.render('checkbox');
            });
        }
    }


    //生成工具栏
    JfTable.prototype.initToolbar = function () {
        var t = this, $e = t.$element, _opt = t.option, toolbar = _opt.toolbar, tool = $("<div class='layui-btn-group'></div>").prependTo($e);
        $.each(toolbar, function (index, item) {
            var btn = $("<button class='layui-btn " + _opt.toolbarClass + "'></button>").appendTo(tool);
            if (item.icon) {
                $("<i class='layui-icon'>" + item.icon + "</i>").appendTo(btn);
            } else {
                btn.append(item.text);
            }
            btn[0].onclick = eval(item.handle || function () { });//绑定匿名事件

        });
    }

    JfTable.prototype.initPage = function () {
        var t = this, opt = t.option, page = t.$page;
        console.log(opt);
        laypage({
            cont: page,
            curr: opt.curr,
            pages: opt.pages,
            groups: 5,
            jump: function (obj, s) {
                t.option.queryParam = $.extend(opt.queryParam, { pageNumber: obj.curr });
                if (!s) {
                    t.init();
                }
            }
        });
    }

    JfTable.prototype.initBody = function () {
        var t = this, $e = t.$element, opt = t.option, col = opt.columns, dt = opt.data,
            $table = $e.find("table").html(""),
            $cg = $("<colgroup></colgroup>").appendTo($table),
            $th = $("<thead></thead>").appendTo($table),
            $thr = $("<tr></tr>").appendTo($th),
            $tb = $("<tbody></tbody>").appendTo($table);
        $tb.html("");
        if (opt.select) {
            $table.wrapAll("<div class='layui-form'></div>");
        }
        //遍历创建表头

        for (var i = 0, l = col.length; i < l; i++) {
            var c = col[i];
            i == (l - 1) ? $("<col>").appendTo($cg) : $("<col width='" + c.width + "'>").appendTo($cg);
            c.type == 'check' ? $("<th><input type='checkbox' lay-skin='primary' lay-filter='allChoose'></th>").appendTo($thr) : $("<th>" + c.text + "</th>").appendTo($thr);
        }

        //生成tbody  表格体

        for (var i = 0, l = dt.length; i < l; i++) {
            var d = dt[i], $tr = $("<tr></tr>").appendTo($tb);
            //取出对应列值

            for (var j = 0, cl = col.length; j < cl; j++) {
                var c = col[j], v = d[c.name], f = c.formatter;
                if (c.type == 'check') {
                    $("<td><input type='checkbox' value='" + i + "' lay-skin='primary'></td>").appendTo($tr);
                    continue;
                }
                if (typeof f == "function") {
                    v = f(v, d, i);
                }
                $("<td>" + v + "</td>").appendTo($tr);
            }
        }
        opt.onLoadSuccess(dt);
        if (opt.select) {
            t.initEvent();
        }
    }

    JfTable.prototype.ajaxData = function () {
        var opt = this.option, param = $.extend({}, opt.queryParam, { pageSize: opt.pageSize }),
            result = $.ajax({
                url: opt.url,
                method: opt.method,
                data: opt.onBeforeLoad(param),
                async: false
            }).responseJSON;
        opt.dataFilter(result);
        if (opt.page) {
            opt.pages = result.totalPage;
            opt.curr = result.pageNumber;
        }
        opt.data = result.list;
    }

    JfTable.methods = {
        option: function (jq) {
            return $.data(jq[0], "jfTable").option;
        },
        insertRow: function (jq, row) {
            var s = $.data(jq[0], "jfTable"), opt = s.option;
            opt.data.unshift(row);
            s.initBody();
        },
        getRow: function (jq, args) {
            var s = $(jq[0]).jfTable('option');
            return s.data[args];
        },
        reload: function (jq, param) {
            var t = $.data(jq[0], "jfTable"), opt = t.option;
            opt.param = $.extend({}, opt.queryParam, param);
            t.init();
            if (opt.page) {
                t.initPage();
            }
        },
        updateRow: function (jq, param) {
            var s = $.data(jq[0], "jfTable"), opt = s.option;
            opt.data[param.index] = param.row;
            s.initBody();
        },
        getSelected: function (jq) {
            var s = $(jq[0]).find("table.layui-table tbody .layui-form-checked"), r = [];
            for (var i = 0, l = s.length; i < l; i++) {
                var index = $(s[i]).prev().val();
                r[i] = this.getRow(jq, index);
            }
            return r || undefined;
        }

    };
    JfTable.default = {
        columns: [],
        url: null,
        data: [],
        method: "get",
        select: false,
        toolbar: [],
        pageSize: 20,
        queryParam: {},
        onBeforeLoad: function (param) {
            return param;
        },
        onLoadSuccess: function (data) {
            return data;
        },
        dataFilter: function (res) {
            return res;
        }
    };

    exports('jfTable', {});
});