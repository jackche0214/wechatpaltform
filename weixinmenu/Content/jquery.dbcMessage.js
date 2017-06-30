/// <reference path="jquery-1.4.4-vsdoc.js"/>
$.extend({
    dbcAlert: function (parObj) {
        var defParObj = {
            icon: "info",
            title: "系统提示",
            content: "友情提示",
            callback: null
        }
        $.extend(defParObj, parObj);
        var icon = "";
        var iconColor = "";
        switch (defParObj.icon) {
            case "ok":
                icon = "iconok";
                iconColor = "#7fd41e";
                break;
            case "no":
                icon = "iconno";
                iconColor = "#a70707";
                break;
            case "info":
                icon = "iconinfo";
                iconColor = "orange";
                break;
        }
        var htmlMsg = '<div class="popBox">';
        htmlMsg += '<p class="msg-title"><span>友情提示</span><a href="javascript:void(0)" class="close_btn cancle_btn"><span style="background:url(../Content/GXFWWUI/styImg/bg.png);background-position:13px -185px;" class="close"/></span></a></p>';
        htmlMsg += '<p class="msg-row"><i class="' + icon + '"></i><span class="msg-content" style="color:' + iconColor + '"><label>' + defParObj.content + '</label></span></p>'
        //htmlMsg += '<div class="auto-close">(10秒钟自动关闭)</div>';
        htmlMsg += '<a href="javascript:void(0)" class="btn close">确认</a>';
        htmlMsg += '</div>';
        htmlMsg += '<div class="common_bg"></div>';
        $("body").append(htmlMsg).find(".close").bind("click", function () {
            if (defParObj.callback != null) {
                defParObj.callback();
            }
            $.dbcCloseMsg();
        });
    },
    dbcCloseMsg: function () {
        $(".popBox").remove();
        $(".common_bg").remove();
    },
    dbcConfirm: function (parObj) {
        var defParObj = {
            icon: "info",
            title: "友情提示",
            content: "友情提示!",
            callbackOk: null,
            callbackCancel: null,
        }
        $.extend(defParObj, parObj);
        var icon = "";
        var iconColor = "";
        switch (defParObj.icon) {
            case "ok":
                icon = "iconok";
                iconColor = "#7fd41e";
                break;
            case "no":
                icon = "iconno";
                iconColor = "#a70707";
                break;
            case "info":
                icon = "iconinfo";
                iconColor = "orange";
                break;
        }
        var htmlMsg = '<div class="popBox">';
        htmlMsg += '<p class="msg-title"><span>友情提示</span><a href="javascript:void(0)" class="close_btn cancle_btn"><span class="cancel" style="background:url(../Content/GXFWWUI/styImg/bg.png); background-position:13px -185px;"></span></a></p>';
        htmlMsg += '<p class="msg-row"><i class="' + icon + '"></i><span class="msg-content" style="color:' + iconColor + '"><label>' + defParObj.content + '</label></span></p>'
        //htmlMsg += '<div class="auto-close">(10秒钟自动关闭)</div>';
        htmlMsg += '<a href="javascript:void(0)" class="btn ok">确认</a><a href="javascript:void(0)"class="btn cancel margin-left20">取消</a>';
        htmlMsg += '</div>';
        htmlMsg += '<div class="common_bg"></div>';
        var popBox = $("body").append(htmlMsg);
        popBox.find(".ok").bind("click", function () {
            $.dbcCloseMsg();
            if (defParObj.callbackOk != null) {
                defParObj.callbackOk()
            }
        });
        popBox.find(".cancel").bind("click", function () {
            $.dbcCloseMsg();
            if (defParObj.callbackCancel != null) {
                defParObj.callbackCancel()
            }
        });
    }
});