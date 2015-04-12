'use strict';
app.factory('categoriasService', ['$http', function ($http) {

    var serviceBase = 'http://localhost:55164/';
    var categoriasServiceFactory = {};

    var _getCategorias = function () {

        return $http.get(serviceBase + 'api/categorias').then(function (results) {
            return results;
        });
    };

    var _deleteCategoria = function (id) {
        return $http.delete(serviceBase + 'api/categorias/' + id).then(function (results) {
            return results;
        });
    };

    var _criarCategoria = function (c) {
        return $http.post(serviceBase + 'api/categorias', c, { headers: { 'Content-Type': 'application/json' } });
    };

    var _alterarCategoria = function (c) {
        return $http.patch(serviceBase + 'api/categorias', c, { headers: { 'Content-Type': 'application/json' } });
    };

    categoriasServiceFactory.getCategorias = _getCategorias;
    categoriasServiceFactory.deleteCategoria = _deleteCategoria;
    categoriasServiceFactory.criarCategoria = _criarCategoria;
    categoriasServiceFactory.alterarCategoria = _alterarCategoria;

    return categoriasServiceFactory;

}]);