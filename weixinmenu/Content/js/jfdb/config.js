(function(){
    var config = {
        'divine': {
            'base': 'plugin-hd/150709_divine',
            'index': 'index.v3',
            'detailOngoing': 'detail.v3'
        },
        'stafftheme': {
            'base': 'plugin-hd/160226_staff',
            'nav': 'nav'
        },
        'april_promotion': {
            'base': 'plugin-hd/160414_april',
            'rechargeResult': 'rechargeResult'
        },
        'appguide': {
            'base': 'plugin-hd/160418_appguide',
            'index': 'index_v1'
        },
        'mayrecharge': {
            'base': 'plugin-hd/160420_may',
            'rechargeResult': 'PSC_YI_C_MayHoliday-1.0.5'
        },
        'sixochargeevent': {
            'base': 'plugin-hd/160421_anniversary',
            'rechargeResult': 'rechargeResult',
            'duobaoOrderResult': 'payResult'
        }
    };

    window.app ? app.setSpecialConfig(config) : window.onAppReady = function(){app.setSpecialConfig(config)};
})();