define(function(require) {
	var pro = require('pro');
	var Index = require('hd/common/Index');
    var Msgbox = require('ui/Msgbox');
    var Location = require('common/Location');
    var Cookie = require('common/Cookie');

	/**
	 * 不中返2特权活动类
	 */
	return Index.extend(null, {
		init: fInit,
		showMsgbox: fShowMsgbox  // 红包弹框
	});

	/**
	 * 初始化
	 */
	function fInit() {
		var sFrom = 'cpuedm_makeup2';
		// 未登录 且 from参数为活动名 时弹红包框
		if(Location.getParam('from') == sFrom){
			this.showMsgbox();
		}else if(Cookie.get("from") == sFrom){
			this.showMsgbox();
			Cookie.del("from");
		}
	}

	function fShowMsgbox(){
		Msgbox.show({
			className: 'w-msgbox-special w-msgbox-special-tequan',
            title: '恭喜您获得“<span class="txt-red">不中返2元</span>”特权',
            text: '4月15日前，单笔支付金额达2元，不中奖就<br/>返2元红包，每个用户限参加一次。',
            ok: false,
            cancel: true,
            cancelText: '我知道了'
        });
	}
});