/// <reference path="jquery-1.9.1.js" />
/// <reference path="http://res.wx.qq.com/open/js/jweixin-1.0.0.js" />

(function () {
    document.write("<script src=\"http://res.wx.qq.com/open/js/jweixin-1.0.0.js\"></script>");
    $.extend({

        /**  
         1. 设置cookie的值，把name变量的值设为value    
        example $.cookie(’name’, ‘value’); 
         2.新建一个cookie 包括有效期 路径 域名等 
        example $.cookie(’name’, ‘value’, {expires: 7, path: ‘/’, domain: ‘jquery.com’, secure: true}); 
        3.新建cookie 
        example $.cookie(’name’, ‘value’); 
        4.删除一个cookie 
        example $.cookie(’name’, null); 
        5.取一个cookie(name)值给myvar 
        var account= $.cookie('name'); 
        **/
        cookieHelper: function (name, value, options) {
            if (typeof value != 'undefined') { // name and value given, set cookie 
                options = options || {};
                if (value === null) {
                    value = '';
                    options.expires = -1;
                }
                var expires = '';
                if (options.expires && (typeof options.expires == 'number' || options.expires.toUTCString)) {
                    var date;
                    if (typeof options.expires == 'number') {
                        date = new Date();
                        date.setTime(date.getTime() + (options.expires * 24 * 60 * 60 * 1000));
                    } else {
                        date = options.expires;
                    }
                    expires = '; expires=' + date.toUTCString(); // use expires attribute, max-age is not supported by IE 
                }
                var path = options.path ? '; path=' + options.path : '';
                var domain = options.domain ? '; domain=' + options.domain : '';
                var secure = options.secure ? '; secure' : '';
                document.cookie = [name, '=', encodeURIComponent(value), expires, path, domain, secure].join('');
            } else { // only name given, get cookie 
                var cookieValue = null;
                if (document.cookie && document.cookie != '') {
                    var cookies = document.cookie.split(';');
                    for (var i = 0; i < cookies.length; i++) {
                        var cookie = jQuery.trim(cookies[i]);
                        // Does this cookie string begin with the name we want? 
                        if (cookie.substring(0, name.length + 1) == (name + '=')) {
                            cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                            break;
                        }
                    }
                }
                return cookieValue;
            }
        }

    });

    var ldd = {
        ui: {
            /**
             * 消息框（自动关闭）
             * @param text  消息内容
             * @param time  显示时间
             */
            message: function (text, time) {
                var bg = $("<div class=\"jubao_tc\">");
                var jb = $("<div class=\"jbtit\">").text(text);

                bg.append(jb);

                $("body").append(bg.show());

                setTimeout(function () {
                    bg.remove();
                }, time);
            }
        }
    };

    var id = typeof (MerchantArticleId) != "undefined" ? MerchantArticleId : 0;

    var article = {
        detail: function (call) {
            $.post("/article/detail", { id: id }, function (data) {
                if (call)
                    call(data.Data);
            }, "json");
        },
        load: function (call) {
            $.post("/article/load", { id: id }, function (data) {
                if (call)
                    call(data);
            }, "json");

        },
        click: function (templateId, call) {
            $.post("/article/clickmerchanttemplet", { merchantarticleid: id, merchanttemletid: templateId }, function (data) {
                call(data);
            }, "json");

        },
        shared: function (call) {
            $.post("http://2.weidiudiu.cn/article/wxshare", { id: id }, function (data) {
                wx.config(data.wxconfig);

                var content = data.content;
                content.link=window.location.href;
                content.success = function () {
                    // 用户确认分享后执行的回调函数
                    $.post("http://2.weidiudiu.cn/article/shared", { id: id }, function (d) {
                        if (call)
                            call(d);
                    }, "json");
                };

                wx.ready(function () {
                    wx.onMenuShareTimeline(content);
                    wx.onMenuShareAppMessage(content);
                });

            }, "json")

        },
        agree: function (call) {
            $.post("/article/agree", { id: id }, function (data) {
                if (call)
                    call(data);
            }, "json");

        }
    };

    /**
     * 
     * @param [Array] array
     */
    String.prototype.contains = function (array) {
        for (var i = 0; i < array.length; i++) {
            if (this.toLowerCase().indexOf(array[i]) > -1)
                return true;
        }
        return false;

    }

    String.prototype.format = function (args) {
        var result = this;
        if (arguments.length > 0) {
            if (arguments.length == 1 && typeof (args) == "object") {
                for (var key in args) {
                    if (args[key] != undefined) {
                        var reg = new RegExp("({" + key + "})", "g");
                        result = result.replace(reg, args[key]);
                    }
                }
            }
            else {
                for (var i = 0; i < arguments.length; i++) {
                    if (arguments[i] != undefined) {
                        //var reg = new RegExp("({[" + i + "]})", "g");//这个在索引大于9时会有问题，谢谢何以笙箫的指出
                        var reg = new RegExp("({)" + i + "(})", "g");
                        result = result.replace(reg, arguments[i]);
                    }
                }
            }
        }
        return result;
    }

    /**
     * 打开链接
     * @param link
     */
    function openLink(templateId, link) {
        article.click(templateId, function () {
            var _link = link.replace("http://", "");
            if (RegExp(/^(0|86|17951)?(1[0-9][0-9])[0-9]{8}$/).test(_link)) {
                window.location.href = "tel:" + _link;
            }
            else {
                window.location.href = link;
            }
        });
    }
    window.openLink = openLink;

    /*
    * 弹窗打开图片
    * */
    function openImage(templateId, src) {
        article.click(templateId, function () {
            var dialog = $("<div class='msg_tcbg' style='display: block;'><div class='msg_tc'><img src='' ><span>长按二维码识别</span><ul class='sp_close'>关闭</ul></div></div>");
            dialog.find("img").attr("src", src);
            dialog.find(".sp_close").click(function () {
                dialog.remove();
            });
            $("body").append(dialog);

        });
    }
    window.openImage = openImage;

    // 通用事件绑定
    function pageEvent() {
        var elloads = $(".wz_meta i");
        var elzans = $("#zans");

        var elzan = $(".wz_meta .zan").parent();
        // var eljubao = $(".jubao");

        /**
         * 获取统计详情
         */
        function getDetail() {
            article.detail(function (data) {
                if (data.LikeNum > 100000) {
                    elzans.text("100000+");
                }
                else {
                    elzans.text(data.LikeNum);
                }
                if (data.LikeNum > 100000) {
                    elloads.text("100000+");
                }
                else {
                    elloads.text(data.ExposeNum);

                }
            });

        }

        getDetail();

        // 文章曝光+1
        article.load();

        // 文章转发（微信分享事件绑定）
        article.shared(function () {

        });

        // 文章赞+1
        var zanicon = elzan.parent().find(".zan");
        if (!$.cookieHelper("article" + id)) {
            zanicon.removeClass("zan");
        }
        elzan.click(function () {
            if ($.cookieHelper("article" + id)) {
                return;
            }
            zanicon.addClass("zan");
            $.cookieHelper("article" + id, "agree");
            article.agree(function () {
                getDetail();
            });

        });

        // 举报文章
        // eljubao.click(function () {
        //     ldd.ui.message("举报成功！", 1000);
        // });

        var itg = $(".tg_close");
        itg.click(function () {
            window.location.href = "/merchant/agency?merchantarticleid=" + id;
        });


        imageDeal();

        videoDeal();
    }

    /**
     * 处理界面上的图片地址
     */
    function imageDeal() {
        var vf = $("img");
        vf.each(function () {
            img = $(this);
            var src = img.attr("src");
            if (!src) {
                src = img.attr("data-src");
                img.attr("src", src);
            }
        });
    }

    /**
     * 处理界面上的视频尺寸
     */
    function videoDeal() {
        var vfs = $(".video_iframe");

        if (vfs.length == 0)
            return;

        vfs.each(function () {
            var vf = $(this);

            var oh = parseFloat(vf.attr("height"));
            var ow = parseFloat(vf.attr("width"));

            var winw = $(window).width() - 30;
            var iw = winw > ow ? ow : winw;
            var ih = oh * iw / ow;

            var src = vf.attr("src");
            if (!src) {
                src = vf.attr("data-src");
            }

            var src = src.replace(oh, ih).replace(ow, iw);
            vf.attr("src", src);
            var _oldStyle = vf.attr("style"), style;
            if (_oldStyle)
                style = _oldStyle.replace(oh, ih).replace(ow, iw);
            else
                style = "width: {0}px; height: {1}px;".format(iw, ih);
            vf.attr("style", style);

            vf.attr("width", iw);
            vf.attr("height", ih);

        });
    }

    pageEvent();

    function setSliderHeight(slider) {
        slider.find(".tl_tg img").height(slider.width() / 4 + "px");

        var ul = slider.find(">ul");
        var len = slider.find(".sw_wrap>div").length;
        if (len == 0)
            slider.remove();

        for (var i = 0; i < len; i++) {
            ul.append("<li>");
        }

    }

    var top = $("#mySwipe2");
    setSliderHeight(top);
    var topslider = Swipe(top[0], {
        auto: 2000,
        continuous: true,
        disableScroll: true,
        callback: function (pos) {
            top.find(">ul>li").removeClass("on");
            $(top.find(">ul>li")[pos]).addClass("on");

        }
    });

    var bot = $("#mySwipe3");
    setSliderHeight(bot);
    Swipe(bot[0], {
        auto: 2000,
        continuous: true,
        disableScroll: true,
        callback: function (pos) {
            bot.find(">ul>li").removeClass("on");
            $(bot.find(">ul>li")[pos]).addClass("on");

        }
    });

    var fixedslider = $("#mySwipe4");
    setSliderHeight(fixedslider);
    fixedslider.Swipe({
        auto: 2500,
        continuous: true,
         disableScroll: true,
        callback: function (pos) {
            fixedslider.find(">ul>li").removeClass("on");
            $(fixedslider.find(">ul>li")[pos]).addClass("on");
        }
    });

    var tg = $(".tg_close").hide(); //$("<div class=\"tg_close fixed_close\">我要推广<span></span></div>").hide();
    tg.find("span").click(function () { tg.remove();$("#mySwipe4").hide() });

    $(document).ready(function () {
        var $window = $(window);

        // 定位图文、名片、二维码
        var tw = $(".sw_wrap .tw_tg");
        var mp = $(".sw_wrap .mp_tg");
        var ewm = $(".sw_wrap .ewm_tg");

        function setBannerMargintop(els) {
            els.each(function () {
                var tw = $(this);
                //tw.css({ marginTop: ($(".wrw_ban2 .sw_wrap").height() - tw.height()) / 2 });
            })
        }

        $window.scroll(function (e) {
            var top = $window.scrollTop();

            var min = 0;//self.height();
            var max = bot.offset().top - $window.height();

            if (top > min && top < max) {
                fixedslider.addClass("show");
                var bHei = fixedslider.height();
                // bHei = bHei <= 80 ? 80 : bHei;
                tg.show();
                //if (!fixedslider.hasClass("show")) {
                //}
                setBannerMargintop(tw);
                setBannerMargintop(mp);
                setBannerMargintop(ewm);
            }
            else {
                fixedslider.removeClass("show");
                tg.hide();
            }
        });
    })

})(jQuery);

$(function () {
    var a_number=$("#ps_ition2").children().length;
      var a_w=$("#ps_ition2").width();
      var li_w=(a_w)/a_number
      $("#ps_ition2 li").css("width",li_w);

      var a_number=$("#ps_ition").children().length;
      var a_w=$("#ps_ition").width();
      var li_w=(a_w)/a_number
      $("#ps_ition li").css("width",li_w);

        //var data = {
                    //'imgurl':'http://192.168.1.200:81/upload/2016/04/d295d75f-bcc3-4805-bc6c-919c6ca9da44.png'
                 // };
       // $.get("",function (date) {
              //$(".wz_content").prepend("<div class='add_info'><img src=''></div>");
            // $(".add_info img").attr("src",data.imgurl)
       // })
    $(".twdesc").each(function() {
            $(this).find("h4:eq(0)").css({"display":"inline-block","color":"#86888a","width":"initial"})
        });
    $(".wrw_ban2 .twdesc").each(function() {
            $(this).find("h4:eq(0)").css({"display":"inline-block","color":"red","width":"initial"})
        });
    var a_h=$(window).height();
        $("body").css("height",a_h);

        if(a_h>667){
            $(".wz_tg .mp_tg .twdesc h2").css("max-width","49%");
            $(".wrw_ban2 .mp_tg .twdesc h2").css("max-width","49%");
        }
        else if(a_h<=568){
           $(this).find("h4:eq(0)").hide();
           $(".wz_tg .mp_tg .twdesc h2").css("max-width","100%");
            $(".wrw_ban2 .mp_tg .twdesc h2").css("max-width","100%");
        }

    if (/(iPhone|iPad|iPod|iOS)/i.test(navigator.userAgent)) { 
            
            $(".wrw_ban2").addClass('iphone')
          } 
            else if (/(Android)/i.test(navigator.userAgent)) { 
              $(".wrw_ban2").removeClass('iphone')
            $(".wrw_ban2").addClass('andio');
          } 
            else { 
              
            };


        
})

$(".video-holder").on("click",".play-icon",function(){var a=$(this).parent().find("video");$(this).attr("style","display:none");$(this).parent().find("img").attr("style","display:none");a.width("100%"),a.height("100%"),a[0].play()}),!function(){var b=document.documentElement.dataset.width,c=Math.floor(6.9*b/7.5);$(".js-img").each(function(b){var d=this.dataset,e=d.width,f=d.height,g=d.echo,h=Math.floor(c/e*f),i=a.optImage(g,690);this.width=c,this.height=h,this.dataset.echo=i})}();
 
