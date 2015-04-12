'use strict';
app.factory('storageService', ['$localStorage', '$sessionStorage', function ($localStorage, $sessionStorage) {

    var storageServiceFactory = {};
    var mode = 'session';

    var _setMode = function (_mode) {
        mode = _mode;
    }

    var _get = function (k) {
        if (mode === 'session')
            return $sessionStorage[k];
        else if (mode === 'local')
            return $localStorage[k];
    }

    var _set = function (k, v) {
        if (mode === 'session')
            $sessionStorage[k] = v;
        else if (mode === 'local')
            $localStorage[k] = v;
    }

    storageServiceFactory.setMode = _setMode;
    storageServiceFactory.get = _get;
    storageServiceFactory.set = _set;

    return storageServiceFactory;

}]);