define(function(require) {
	var $ = require('$');
	var pro = require('pro');
	var Index = require('hd/common/Index');
    var Cookie = require('common/Cookie');
    var Location = require('common/Location');

	/**
	 * APP下载推广活动类
	 */
	return Index.extend(null, {
		init: fInit,
		showFixedLayer: fShowFixedLayer  // 推广浮层
	});

	/**
	 * 初始化
	 */
	function fInit() {
		var me = this;
		var sUA = navigator.userAgent;
		var bIsAndroid = /android/i.test(sUA);
		var bIsIOS = /iphone/i.test(sUA);
		var bIsNews = (G || {}).ver == 'news';
		var bIsKaola = (G || {}).ver == 'kaola';
		var sFrom = Location.getParam('from') || "";
		var bAllowFrom = true;
		if(sFrom.indexOf('no_') === 0){
			bAllowFrom = false;
		}

		// 针对特殊推广渠道 不出现推广浮层
		var bShowLayer = true;
		var sNoDownload = Location.getParam('nodl') || "";
		if(sNoDownload - 0 === 1){
			bShowLayer = false;
		}

		//	ios不出下载推广
		if(bIsIOS){
			bShowLayer = false;
		}

		// 仅对安卓、IOS用户出现推广，但非新闻客户端，且允许推广渠道下载
		if(!bIsNews && !bIsKaola && (bIsAndroid || bIsIOS) && !Cookie.get("appDownload") && bAllowFrom && bShowLayer){
			this.showFixedLayer();
		}
	}

	function fShowFixedLayer(){
		// var sFrom = Location.getParam('from').replace(/w_/,'app_') || "oneduobaoshipei";
		var sFrom = "oneduobaoshipei";
		try{ sFrom = Location.getParam('from').replace(/w_/,'app_'); }catch(e){}
		var sApkUrl = "http://1.163.com/client?from="+sFrom;
		
		this.fixedLayer = new pro.View({
			template: [
				'<div id="appdownload" style="position:fixed;z-index:11;bottom:0;left:0;width:100%;height:65px;background:rgba(0,0,0,.7);">',
					'<a data-pro="close" href="javascript:void(0);" style="position:absolute;top:0;left:0;">',
						'<img width="22" height="22" src="http://mimg.127.net/p/yymobile/hd/150330_appchargeprize/layer_close.png" />',
					'</a>',
					'<a data-pro="layer" style="padding:10px 10px 0 25px;display:block;color:#fefefe;" href="'+sApkUrl+'" target="_blank">',
						'<div style="max-width:280px;margin:0 auto">',
							'<img style="float:left" width="48" height="48" src="http://mimg.127.net/p/yymobile/hd/150330_appchargeprize/layer_logo.png" class="appdownload-logo" />',
							'<div style="float:left;width:150px;text-align:center">',
								'<p style="font-size:16px;line-height:24px;">随时随地1元夺宝</p>',
								'<p style="font-size:14px;line-height:24px;">支持iOS和安卓</p>',
							'</div>',
							'<span style="float:right;margin-top:6px;display:inline-block;padding:0 10px;font-size:14px;line-height:34px;color:#3C3F47;background:#E0E0E0;border-radius:4px;">马上下载</span>',
						'</div>',
					'</a>',
				'</div>'
			].join(''),
			doms: {
				'close': '@close',
				'layer': '@layer'
			},
			events: {
				'@close': function(){
					this.destroy();
					$('.w-miniCart').css('bottom', '10px');
					$('.w-button-backToTop').css('bottom', '10px');
					// 临时cookie 关闭浏览器失效
					Cookie.set("appDownload", 1);
				},
				'@layer': function(){
					this.destroy();
					$('.w-miniCart').css('bottom', '10px');
					$('.w-button-backToTop').css('bottom', '10px');
					// 当做已点击，30天后继续弹出
					Cookie.set("appDownload", 1, 'd30');
				}
			},
			listeners: {
				'create': function(){
					$('.w-miniCart').css('bottom', '70px');
					$('.w-button-backToTop').css('bottom', '70px');
				},
			}
		});

		this.fixedLayer.render(document.body);
	}
});