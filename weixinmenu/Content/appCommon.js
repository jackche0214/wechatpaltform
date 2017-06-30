

var browser = {
    versions: function () {
        var u = navigator.userAgent, app = navigator.appVersion;
        return {
            trident: u.indexOf('Trident') > -1, //IE内核
            presto: u.indexOf('Presto') > -1, //opera内核
            webKit: u.indexOf('AppleWebKit') > -1, //苹果、谷歌内核
            gecko: u.indexOf('Gecko') > -1 && u.indexOf('KHTML') == -1,//火狐内核
            mobile: !!u.match(/AppleWebKit.*Mobile.*/), //是否为移动终端
            ios: !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/), //ios终端
            android: u.indexOf('Android') > -1 || u.indexOf('Linux') > -1, //android终端或者uc浏览器
            iPhone: u.indexOf('iPhone') > -1, //是否为iPhone或者QQHD浏览器
            iPad: u.indexOf('iPad') > -1, //是否iPad
            webApp: u.indexOf('Safari') == -1, //是否web应该程序，没有头部与底部
            weixin: u.indexOf('MicroMessenger') > -1, //是否微信 （2015-01-22新增）
            qq: u.match(/\sQQ/i) == " qq" //是否QQ
        };
    }(),
    language: (navigator.browserLanguage || navigator.language).toLowerCase()
}

function QueryUrlParameter(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null) return "";
    else return results[1]
};

var AlertType = {
    Success: "Success",
    Warning: "Warning",
    Loading: "Loading",
    Error: "Error",
    Default: "Default",
    Confirm: "Confirm"
};

$(function () {

    var $last = $(document.body);
    /*QQ alert*/

    var $qqloading = "<div id=\"loading\" class=\"ui-loading-block \">"
                        + "<div class=\"ui-loading-cnt\">"
                            + "<i class=\"ui-loading-bright\"></i>"
                            + "<p>加载中...</p>"
                        + "</div>"
                   + "</div>";

    $last.append($qqloading);


    var $alert = "<div id=\"alert\" class=\"ui-dialog \">"
                    + "<div class=\"ui-dialog-cnt\">"
                       + "<div class=\"ui-dialog-bd\">"
                           + "<div>"
                                + "<h4>系统提示</h4>"
                                + "<div>系统提示内容</div>"
                            + "</div>"
                        + "</div>"
                            + "<div class=\"ui-dialog-ft ui-btn-group\">"
                                + "<button type=\"button\" data-role=\"button\" class=\"select\" id=\"dialogCanncel\">取消</button>"
                                + "<button type=\"button\" data-role=\"button\" id=\"dialogOk\">确定</button>"
                            + "</div>"
                        + "</div>"
                + "</div>";

    $last.append($alert);

    /*QQ alert*/

});

function Comfirm(msg, okFun, cancelFun, btnArray) {
    if (!btnArray.length) {
        btnArray.push("取消");
        btnArray.push("确定");
    }

    var $alert = $("#alert");

    $alert.find("button").css({ 'display': 'block' });

    $alert.find("#dialogOk").html(btnArray[1]).off().on("click", function () {
        $alert.css({ 'display': 'none' });
        if (typeof okFun == 'function') {
            okFun();
        }
    });
    $alert.find("#dialogCanncel").html(btnArray[0]).off().on("click", function () {
        $alert.css({ 'display': 'none' });
        if (typeof cancelFun == 'function') {
            cancelFun();
        }
    });

    $alert.find(".ui-dialog-bd > div > div").html(msg);

    $alert.css({ 'display': '-webkit-box' });
}


function Alert(msg, okFun) {

    var $alert = $("#alert");

    $alert.find("button").css({ 'display': 'block' });

    $alert.find("#dialogOk").css({ 'display': 'none' });

    $alert.find("#dialogCanncel").html("关闭").off().on("click", function () {
        $alert.css({ 'display': 'none' });
        if (typeof okFun == 'function') {
            okFun();
        }
    });

    $alert.find(".ui-dialog-bd > div > div").html(msg);

    $alert.css({ 'display': '-webkit-box' });
}

function loading(isShow, msg) {
    var _isShow = true;
    var _msg = "加载中...";
    if (arguments.length == 0) {

    } else if (arguments.length == 1 && typeof isShow == "boolean") {
        _isShow = isShow;
    } else if (arguments.length == 1 && typeof isShow == "string") {
        _msg = isShow;
    } else if (arguments.length == 2) {
        _isShow = isShow;
        _msg = msg;
    }

    if (_isShow) {
        var $loading = $("#loading");
        $loading.find("p").html(_msg);
        $loading.css({ 'display': '-webkit-box' });
    } else {
        var $loading = $("#loading");
        $loading.css({ 'display': 'none' });
        $loading.find("p").html("");
    }
};


function StringBuilder() {
    this._array = new Array();
}

StringBuilder.prototype.append = function (str) {
    this._array.push(str);
}

StringBuilder.prototype.toString = function (joinGap) {
    return this._array.join(joinGap);
}


String.prototype.IsICard = function () {
    var regx = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;
    return regx.test(this);
}
String.prototype.IsEmail = function () {
    var regx = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
    return regx.test(this);
}
String.prototype.IsPhone = function () {
    var regx = /^(0|86|17951)?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$/;
    return regx.test(this);
}


/** 
* 时间对象的格式化 
*/
Date.prototype.format = function (format) {
    /* 
    * format="yyyy-MM-dd hh:mm:ss"; 
    */
    var o = {
        "M+": this.getMonth() + 1,
        "d+": this.getDate(),
        "h+": this.getHours(),
        "m+": this.getMinutes(),
        "s+": this.getSeconds(),
        "q+": Math.floor((this.getMonth() + 3) / 3),
        "S": this.getMilliseconds()
    }

    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4
    - RegExp.$1.length));
    }

    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1
    ? o[k]
    : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
}
