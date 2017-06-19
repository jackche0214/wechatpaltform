define(function(require) {
	var pro = require('pro');
	var BaseSpecial = require('global/special/BaseSpecial');
    var Broadcast = require('global/Broadcast');

	/**
	 * 员工专场
	 */
	return BaseSpecial.extend({
        members: {
            onRender: fOnRender,

            match: fMatch,
            init: fInit,
            insertNav: fInsertNav
        }
	});

    function fInsertNav(){
        var oView = this.view;
        var oAllLis = oView.findAll('.m-menu-list-item');
        var oNav = new pro.View({
            template: ['<li class="m-menu-list-item{{#focus}} selected{{/focus}}" data-name="staff">',
                            '<var>|</var>',
                            '<a class="m-menu-list-item-link" href="/wy">员工专场</a>',
                        '</li>'].join(''),
            data: {
                focus: app.getName() == 'staff'
            }
        });

        oNav.renderBefore(oAllLis[oAllLis.length - 1]);
    }

    function fMatch(){
        return app.isNTES() || /@(?:(?:mesg\.)?corp\.netease\.com|yixin\.im)$/.test(app.getUsername());
    }

    function fInit(){
        if(this.match()){
            this.insertNav();
        }
    }

	/**
	 * 初始化
	 */
	function fOnRender() {
        var that = this;
        if(app.isHistory()){
            this.context.receive(Broadcast.GLOBAL_DATA_READY, function(){
                that.init();
            });
        }else{
            that.init();
        }
	}

});
