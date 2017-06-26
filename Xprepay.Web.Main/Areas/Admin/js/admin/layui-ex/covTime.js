//时间戳转换

layui.define('jquery', function (exports) { //提示：模块也可以依赖其它模块，如：layui.define('layer', callback);
    var $ = layui.jquery;
    //年月日时分秒
    layui.data.covFullTime = function (time) {
        if (time == null || time == "") {
            return "-";
        }
        var now = new Date(parseInt(time.replace("/Date(", "").replace(")/", "")));
        var year = now.getFullYear();
        var month = now.getMonth() + 1;
        var date = now.getDate();
        var hour = now.getHours();
        var minute = now.getMinutes();
        var second = now.getSeconds();
        return year + "-" + month + "-" + date + "   " + hour + ":" + minute + ":" + second;
    }
    //年月日
    layui.data.covTime = function (time) {
        if (time == null || time == "") {
            return "-";
        }
        var now = new Date(parseInt(time.replace("/Date(", "").replace(")/", "")));
        var year = now.getFullYear();
        var month = now.getMonth() + 1;
        var date = now.getDate();
        var hour = now.getHours();
        var minute = now.getMinutes();
        var second = now.getSeconds();
        return year + "-" + month + "-" + date;
    }

    exports('covTime', {});
});
