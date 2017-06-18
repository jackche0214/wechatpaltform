define(function(require) {
	var pro = require('pro');
	var Index = require('hd/common/Index');
    var Msgbox = require('ui/Msgbox');
    var Location = require('common/Location');

	/**
	 * 占卜送红包 首页活动类
	 */
	return Index.extend(null, {
		init: fInit,
		showNoDivineBox: fShowNoDivineBox  // 占卜弹框
	});

	/**
	 * 初始化
	 */
	function fInit() {
		// url带tag参数时弹框
		/*if(Location.getParam('action') == this.tag && Location.getHashValue('valid') === 'false'){
			this.showNoDivineBox();
		}*/

		if(Location.getParam('action') == 'divine' && Location.getHashValue('valid') === 'false'){
			this.showNoDivineBox();
		}
	}

	function fShowNoDivineBox(){
		var me = this;

		Msgbox.show({
			className: 'w-msgbox-special',
			text: [
				'<style>',
					'.w-msgbox-special{width:300px;}',
					'.w-msgbox-special .w-msgbox-bd{padding:0}',
					'.w-msgbox-special-btn{margin:24px 6px 0;display:inline-block;width:110px;height:35px;text-align:center;line-height:35px;background:#f45145;font-weight:bold;color:#fff;font-size:16px;border-radius:6px;}',
				'</style>',
				'<a style="position:absolute;width:25px;height:25px;right:0;top:0" data-pro="close" href="javascript:void(0);"></a>',
				'<div style="padding:30px 7px 0;font-size:14px;background:url(' + G.url + 'hd/150709_divine/mix-bg.png) no-repeat;background-size:300px 426px;color:#666666;text-align:center;_zoom:1">',
					'<p>年轻人，今天已经指点过你了</p>',
					'<p>明天再来吧~</p>',
				'</div>',
				'<div style="height:80px;background:url(' + G.url + 'hd/150709_divine/mix-bg.png) 0 -226px no-repeat;background-size:300px 426px;text-align:center">',
					'<a class="w-msgbox-special-btn" data-pro="cancel" href="javascript:void(0);">我知道了</a>',
				'</div>'
			].join(''),
            ok: false
        });
	}

});
