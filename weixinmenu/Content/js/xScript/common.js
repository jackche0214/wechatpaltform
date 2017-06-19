var AlertType = {
    Success: "Success",
    Warning: "Warning",
    Loading: "Loading",
    Error: "Error",
    Default: "Default",
    Confirm: "Confirm"
};

function QQAlert(msg, msgType) {
    if (msgType == null || msgType == undefined || arguments.length == 1) {
        msgType = AlertType.Default;
    }
    var className = "gtl_ico_hits";
    if (msgType == AlertType.Success) {
        className = "gtl_ico_succ";
    } else if (msgType == AlertType.Warning) {
        className = "gtl_ico_hits";
    } else if (msgType == AlertType.Error) {
        className = "gtl_ico_fail";
    } else if (msgType == AlertType.Default) {
        className = "gtl_ico_hits";
    } else if (msgType == AlertType.Confirm) {
        className = "gtl_ico_hits";
    }

    var $alert = $("#qqAlert");

    $alert.find("span#text").html(msg);

    $alert.find("span#mode_tips_v2 > span:eq(0)").removeClass().addClass(className);

    $alert.fadeIn("slow");

    setTimeout(function () { $alert.fadeOut("slow"); }, 3000);
}

function ShowLoading(html) {
    var $bg = $("#bodyBackground");
    $bg.css({ height: $(window).height() + $(window).scrollTop() });
    $bg.show();
    var $loading = $("#loading");
    if (html != undefined && html != "") {
        $loading.find(".text").html(html);
    }

    $loading.show();
};

function HideLoading() {
    $("#bodyBackground").hide();
    var $loading = $("#loading");
    $loading.hide();
    $loading.find(".text").html("正在提交您的请求,请稍候......");
};


$(function () {
    QQAlertHtml();
});

function QQAlertHtml() {
    /*QQ alert*/
    var $opacity = $("<div id=\"bodyBackground\"></div>");
    $opacity.css({
        opacity: .6
    });

    var $last = $(document.body);
    $last.append($opacity);

    var $qqAlert = "<div id=\"qqAlert\" class=\"msgbox_layer_wrap\">" +
                        "<span id=\"mode_tips_v2\" class=\"msgbox_layer\" style=\"z-index: 10000;\">" +
                            "<span class=\"gtl_ico_succ\"></span><span id=\"text\">评论成功</span> <span class=\"gtl_end\"></span>" +
                        "</span>" +
                   "</div>";


    $last.append($qqAlert);

    var path = "http://" + window.location.host + "/";
    var $qqloading = "<div id=\"loading\" class=\"msgbox_layer_wrap\">" +
                        "<span id=\"mode_tips_v2\" class=\"msgbox_layer\" style=\"z-index: 10000;\">" +
                            "<span class=\"gtl_ico_clear\"></span>" +
                            "<img alt=\"\" src=\"/images/webimages/xImages/blue-loading.gif\">" +
                            "<span class=\"text\">正在提交您的请求,请稍候......</span>" +
                            "<span class=\"gtl_end\"></span>" +
                        "</span>" +
                      "</div>";

    $last.append($qqloading);
    /*QQ alert*/

}


function setCookie(name, value) {
    var date = new Date();
    date.setTime(date.getTime() + (86400 * 1000 * 2));
    document.cookie = name + "=" + escape(value) + "; path=/"
};

function getCookie(name) {
    var search;
    search = name + "=";
    offset = document.cookie.indexOf(search);
    if (offset != -1) {
        offset += search.length;
        end = document.cookie.indexOf(";", offset);
        if (end == -1) end = document.cookie.length;
        return unescape(document.cookie.substring(offset, end))
    } else return ""
};




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

String.prototype.IsPrice = function () {
    if (this == undefined || this == null || this == "") return false;
    var regx = /^[0-9]+([.]{1}[0-9]{1,2})?$/;
    return regx.test(this);
}


Array.prototype.idxOf = function (obj) {
    for (var i = 0; i < this.length; i++) {
        if (this[i] === obj) {
            return i
        }
    }
    return -1
};

Array.prototype.contain = function (obj) {
    return this.idxOf(obj) !== -1
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

String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "")
};

String.prototype.trimAll = function () {
    return this.replace(/(^\s*)|(\s*)|(\s*$)/g, "")
};

function QueryUrlParameter(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null) return "";
    else return results[1]
};

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


/** 
   * 身份证号码与出生日期的验证 
   * 前提是：身份证号和出生日期格式都已经过格式验证 
   * 身份证号为15或18位，出生日期格式为XXXX-XX-XX 
   */
function checkIdAndBirthday(strId, strBrithday) {
    var dateTemp = new Date();
    if (strBrithday != "") {
        var arr_date = strBrithday.split("-");
        var inputDate = new Date(arr_date[0], arr_date[1] - 1, arr_date[2]);
        if (inputDate > dateTemp) {
            QQAlert("出生日期时间不能大于今天！请检查！");
            return false;
        }
        //15位身份证 
        if (strId.length == 15) {
            //从ID NO 中截取生日6位数字，前面加上19 
            var idBirthday = "19" + strId.substr(6, 6);
            //日期字符串中的8位生日数字 
            var textBirthday = arr_date[0] + arr_date[1] + arr_date[2];
            if (idBirthday == textBirthday) {
                return true;
            } else {
                QQAlert("出生日期与身份证日期不一致，请检查！");
                return false;
            }
        }
        //18位身份证 
        if (strId.length == 18) {
            //从ID NO 中截取生日8位数字 
            var idBirthday = strId.substr(6, 8);
            //日期字符串中的8位生日数字 
            var textBirthday = arr_date[0] + arr_date[1] + arr_date[2];
            if (idBirthday == textBirthday) {
                return true;
            } else {
                QQAlert("出生日期与身份证日期不一致，请检查！");
                return false;
            }
        }
    }
    return true;
}

function xConfirm(msg, fun) {
    var $arglen = arguments.length;
    var trString = "<tr><td align=\"left\" style=\"height:120px;\">";
    trString += "<div class=\"autoWarning\">" + msg + "</div></td></tr>";
    trString += "<tr><td align=\"right\" style=\"border-top:1px solid #ddd;height:50px;\">" +
                "<input type='button' class=\"btn-auto autosave\" title=\"确定\" value=\"确定\" />" +
                "<input type='button' class=\"btn-auto autocancel\" title=\"取消\" value=\"关闭\" />" +
                "</td></tr>";

    var $tableFrom =
"<div class=\"layerDialog\" id=\"deleteRecordForm\">" +
"<div class=\"bg\">" +
"<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
"<tbody>" +
"<tr>" +
"<td>" +
    "<div class=\"layerDialogCtn\">" +
        "<div style=\"cursor: move;\" class=\"title\">" +
                      "<span>系统提示</span>" +
        "</div>" +
        "<a title=\"关闭\" class=\"close\"></a>" +
        "<div style=\"width:350px; height:180px; padding: 2px;\">" +
            " <table style=\"width: 98%; margin: auto;\">" +
            " <tbody>" +
            trString +
            "</tbody>" +
            "</table>" +
        "</div>" +
    "</div>" +
"</td>" +
"</tr>" +
" </tbody>" +
" </table>" +
"</div>" +
"</div>";

    var $topPage = $(window.top.document).find("body");
    $topPage.append($tableFrom);

    $tableFrom = $topPage.find("#deleteRecordForm");
    $tableFrom.css("position", "absolute");
    $tableFrom.css("top", ($(window.top).height() - $tableFrom.height()) / 2 + "px");
    $tableFrom.css("left", ($(window.top).width() - $tableFrom.width()) / 2 + "px");
    $tableFrom.find("input.autocancel,a.close").on("click", function () {
        $tableFrom.remove();
    });

    var id = this.Id;
    $this = $("#" + id);

    $tableFrom.find("input.autosave").on("click", function () {
        $tableFrom.hide();

        fun();
    });

    $tableFrom.show();
}


jQuery.fn.center = function () {
    var $this = this;
    $this.css("position", "fixed");
    $this.css("top", ($(window).height() - this.height()) / 2 + "px");
    $this.css("left", ($(window).width() - this.width()) / 2 + "px");

    $this.find(".close").on("click", function () {
        $this.hide();
    });

    $this.find(".xsoft-tip-dialog-close").on("click", function () {
        $this.hide();
    });

    return $this;
}

function tip(state, msg) {
    var tip = $("div.form-message");
    tip.html("");
    tip.html("<div class=\"form-" + state + "-text\">" + msg + "</div>");
    tip.show();
}

function clearTip() {
    var tip = $("div.form-message").html("").hide();
}

function OpenXWindow(_url, _title, w, h) {
    var _width = w;
    var _height = h;
    if ($("#xWindow").length) {
        $("#xWindow").remove();
    }

    var dialog = $("<div class=\"dialog-container\" id=\"xWindow\" "
           + " style=\"width:" + _width + "px; height: " + _height + "px;\">"
           + "<div class=\"dialog-container-header\">"
           + "<h3>" + _title + "</h3>"
           + "</div>"
           + "<div class=\"dialog-container-body\" style=\"width:" + (_width) + "px; height: " + (_height - 43) + "px;\">"
           + "<iframe frameborder=\"0\" id=\"win_dialog_frm_" + _url + "\""
           + "style=\"width: 100%; height: 99%; border: 0px none;\" src=\"" + _url + "\"></iframe>"
           + "</div>"
           + "<span class=\"dialog-container-close\"></span>"
           + "</div>"
           );

    $("body").append(dialog);
    $dialog = $("#xWindow");
    $dialog.css("position", "fixed");
    $dialog.css("zindex", "9999999");
    $dialog.css("top", ($(window).height() - $dialog.height()) / 2 + "px");
    $dialog.css("left", ($(window).width() - $dialog.width()) / 2 + "px");
    $dialog.show();
    $dialog.find("span.dialog-container-close").bind("click", function () { $dialog.remove() });
}


function CloseXWindow() {
    if ($("#xWindow").length) {
        $("#xWindow").remove();
    }
}

function OpenTopXWindow(_url, _title, w, h) {
    var _width = w;
    var _height = h;
    var $topWin = $(window.top.document).find("#xWindow");
    if ($topWin.length) {
        $topWin.remove();
    }


    var dialog = $("<div class=\"dialog-container\" id=\"xWindow\" "
           + " style=\"width:" + _width + "px; height: " + _height + "px;\">"
           + "<div class=\"dialog-container-header\">"
           + "<h3>" + _title + "</h3>"
           + "</div>"
           + "<div class=\"dialog-container-body\" style=\"width:" + (_width) + "px; height: " + (_height - 43) + "px;\">"
           + "<iframe frameborder=\"0\" id=\"win_dialog_frm_" + _url + "\""
           + "style=\"width: 100%; height: 99%; border: 0px none;\" src=\"" + _url + "\"></iframe>"
           + "</div>"
           + "<span class=\"dialog-container-close\"></span>"
           + "</div>"
           );

    $(window.top.document).find("body").children().last().after(dialog);
    $dialog = $(window.top.document.body).find("#xWindow");
    $dialog.css("position", "fixed");
    $dialog.css("zindex", "9999999");
    $dialog.css("top", ($(window.top).height() - $dialog.height()) / 2 + "px");
    $dialog.css("left", ($(window.top).width() - $dialog.width()) / 2 + "px");
    $dialog.find("span.dialog-container-close").on("click", function () { $dialog.remove() });
    $dialog.show();

}


function jmfwwbox(msg, fun, className) {
    if (className == undefined || className == null) {
        className = "btn-success";
    }
    bootbox.dialog({
        message: msg,
        title: "居民服务网",
        size: 'small',
        buttons: {
            success: {
                label: "确定",
                className: className,
                callback: function () {
                    if (fun != undefined && fun != null) {
                        fun();
                    }
                }
            }
        }
    });
}

function showMsg(title, msg, isAlert) {
    if (isAlert !== undefined && isAlert) {
        $.messager.alert(title, msg);
    } else {
        $.messager.show({
            title: title,
            msg: msg,
            showType: 'show'
        });
    }
}

//确认框
function showConfirm(title, msg, callback) {
    $.messager.confirm(title, msg, function (r) {
        if (r) {
            if (jQuery.isFunction(callback))
                callback.call();
        }
    });
}

//进度框
function showProcess(isShow, title, msg) {
    if (!isShow) {
        $.messager.progress('close');
        return;
    }
    var win = $.messager.progress({
        title: title,
        msg: msg
    });
}
