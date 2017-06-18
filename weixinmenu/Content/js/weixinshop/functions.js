/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 * 公共函数库
 */

$(function() {
    //表单提交
    form_submit = function(form) {
        url=form.attr("action");
        $.ajax({
            cache: true,
            type: "POST",
            url:url,
            data:form.serialize(),
            async: false,
            success: function(json) {
                json=eval('(' +json+ ')');
                if(json.errcode!='1'){
                    $.toast(json.errmsg);
                    return false;
                }
                $.toast(json.errmsg);
                if (json.errcode && json.url !=='') {
                    setTimeout(function() {
                        window.location.href =json.url;
                    }, 1000);
                } else {
                   return false;
                }
            }
        });
    } ;

    // 如果后退的域名是同域的 url，则执行后退，否则直接重定向到主页。
    /*go_back = function() {
        if (document.referrer && /\/\/([^\/]+)/.exec(document.referrer)[1] === location.host) {
            history.go(-1);
        } else {
            window.location.href = '/';
        }
    };*/

});

//系统模块升级中提示
function upgrading(){
    $.toast('此模块升级中');
    return false;
}


/**
 * 图片加载
 */
function lazyLoad(){
    $('.lazyload').each(function(){
        var url = $(this).attr('data-original');
        var img = new Image();
        img.src = url;
        var that = $(this);
        img.onload = function(){
            that.attr('src',url);
        }
    });
}



