
$(function () {
});

String.prototype.getCodeText = function (baseCodeJson, tableName) {
    if (this == "" || this == undefined) return "";
    var text = this;
    $.each(baseCodeJson, function (i, n) {
        if (n.dm_table_name == tableName && n.item_code == text) {
            text = n.item_name;
            return;
        }
    });

    return text;
};

//时间格式化
Date.prototype.format = function (format) {
    if (!format) {
        format = "yyyy-MM-dd hh:mm:ss";
    }
    var o = {
        "M+": this.getMonth() + 1, // month
        "d+": this.getDate(), // day
        "h+": this.getHours(), // hour
        "m+": this.getMinutes(), // minute
        "s+": this.getSeconds(), // second
        "q+": Math.floor((this.getMonth() + 3) / 3), // quarter
        "S": this.getMilliseconds()
        // millisecond
    };
    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
};

//弹出框以及系统消息框
function showMsg(msg, title, isAlert) {
    self.top.showMsg(title, msg, isAlert);
}

//确认框
function showConfirm(msg, title, callback) {
    self.top.showConfirm(title, msg, callback);
}

//进度框
function showProcess(isShow, title, msg) {
    self.top.showProcess(isShow, title, msg);
}

//例如在表单提交时，为了防止重复提交，会显示一个进度框。提交完成时，关闭进度框并提示操作信息：
function submitForm(url) {
    $('#ff').form('submit', {
        url: (url === undefined ? "/Ajax/Common.ashx" : url) + "?Type=" + typeCode,
        onSubmit: function () {
            var flag = $(this).form('validate');
            if (flag) {
                showProcess(true, '温馨提示', '正在提交数据...');
            }
            return flag
        },
        success: function (data) {
            showProcess(false);
            if (data == 1) {
                top.showMsg('温馨提示', '提交成功！');
                if (parent !== undefined) {
                    if ($.isFunction(window.reloadParent)) {
                        reloadParent.call();
                    } else {
                        parent.$("#tt").datagrid('reload');
                        parent.closeMyWindow();
                    }
                }
            } else {
                $.messager.alert('温馨提示', data);
            }
        },
        onLoadError: function () {
            showProcess(false);
            $.messager.alert('温馨提示', '由于网络或服务器太忙，提交失败，请重试！');
        }
    });
}

function showWindow(title, href, width, height, modal, minimizable, maximizable) {
    self.top.showWindow(title, href, width, height, modal, minimizable, maximizable);
}


function getWindowId(url) {
    url = url.replace("http://" + window.location.host, "");
    return url.replace(/\//g, "_");
}

function CloseWindow() {
    var id = getWindowId(document.URL);

    var isclose = arguments.length == 1 && arguments[0] == "close";
    if (!isclose) {
        this.top.radWindowCallBackFn.apply(this, arguments);
    }


    self.top.CloseWindow(id);
}