//结合layer tips与.net 校验组件

layui.define(['jquery', 'layer'], function (exports) { //提示：模块也可以依赖其它模块，如：layui.define('layer', callback);
    var $ = layui.jquery;
    //var layer = layui.layer;
    function getFrameWinBy(param, windowObject) {
        var win = !!windowObject ? windowObject : window;
        var type = Object.prototype.toString.call(param);
        if (type === '[object String]') {
            return win[param];
        } else if (type === '[object Number]') {
            return win['layui-layer-iframe' + param]
        } else if (type === '[object Object]') {
            return win[param.find('iframe')[0]['name']]
        }
    }
    var obj = {
        output: function (err) {
            if (err.length == 0) {
                frame.layer.msg("操作失败", { time: 0 })
            } else {
                $.each(err, function (i, val) {
                    top.layer.tips(val.ErrorMessage, '#' + val.PropertyName, { tips: [2, '#FF6838'], tipsMore: true });
                })
            }
        },
        iframeOutput: function (body, err) {
            var frame = getFrameWinBy(body, top);
            if (err.length==0) {
                frame.layer.msg("操作失败", {time:0})
            } else {
                $.each(err, function (i, val) {
                    frame.layer.tips(val.ErrorMessage, "#" + val.PropertyName, { tips: [2, '#FF6838'], tipsMore: true });
                })
            }
           
        }
    };

    exports('tipsErr', obj);
});
