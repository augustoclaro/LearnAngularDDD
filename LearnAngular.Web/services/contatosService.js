'use strict';
app.factory('contatosService', ['$http', function ($http) {

    var serviceBase = 'http://localhost:55164/';
    var contatosServiceFactory = {};

    var _getContatos = function () {

        return $http.get(serviceBase + 'api/contatos').then(function (results) {
            return results;
        });
    };

    var _deleteContato = function (id) {
        return $http.delete(serviceBase + 'api/contatos/' + id).then(function (results) {
            return results;
        });
    };

    var _criarContato = function (c) {
        return $http.post(serviceBase + 'api/contatos', c, { headers: { 'Content-Type': 'application/json' } });
    };

    var _alterarContato = function (c) {
        return $http.patch(serviceBase + 'api/contatos', c, { headers: { 'Content-Type': 'application/json' } });
    };

    contatosServiceFactory.getContatos = _getContatos;
    contatosServiceFactory.deleteContato = _deleteContato;
    contatosServiceFactory.criarContato = _criarContato;
    contatosServiceFactory.alterarContato = _alterarContato;

    return contatosServiceFactory;

}]);