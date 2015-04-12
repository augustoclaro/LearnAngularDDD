'use strict';
app.controller('categoriasController', ['$scope', 'categoriasService', '$rootScope', '$location', function ($scope, categoriasService, $rootScope, $location) {

    $scope.categorias = [];
    $scope.search = "";
    var _setDefaultModel = function () {
        $scope.formData = {
            "IdCategoria": "",
            "NomeCategoria": ""
        };
    };
    _setDefaultModel();

    var _carregaLista = function ($scope) {
        categoriasService.getCategorias().then(function (results) {
            $scope.categorias = results.data;

        }, function (error) {
            bootbox.alert(error.data.message);
        });
    };
    _carregaLista($scope);

    var _delete = function (id) {
        bootbox.confirm("Tem certeza que quer excluir esta categoria?", function (r) {
            if (r)
                categoriasService.deleteCategoria(id).then(function () {
                    _carregaLista($scope);
                });
        });
    };

    var _alter = function (c) {
        $scope.formData.IdCategoria = c.idCategoria;
        $scope.formData.NomeCategoria = c.nomeCategoria;
        jQuery("#modalCategoria").append("body").modal('show');
    };

    var _salvarDados = function () {
        var form = $scope.formData;

        if (form.NomeCategoria === "") {
            bootbox.alert("Preencha o nome.");
            return;
        }

        var $req;
        if (form.IdCategoria) { //ALTERAÇÃO
            $req = categoriasService.alterarCategoria(form);
        } else { //NOVO
            $req = categoriasService.criarCategoria(form);
        }
        $req.success(function () {
            jQuery("#modalCategoria").modal('hide');
            _carregaLista($scope);
        })
        .error(function () {
            bootbox.alert("Ocorreu algum erro ao salvar.");
        });
    };

    var _novo = function () {
        _setDefaultModel();
        jQuery("#modalCategoria").append("body").modal('show');
    };

    var _listContacts = function (c) {
        console.log(c);
        $rootScope.contactSearch = c.nomeCategoria;
        $location.path('/contatos');
    };

    $scope.delete = _delete;
    $scope.alter = _alter;
    $scope.salvarDados = _salvarDados;
    $scope.novo = _novo;
    $scope.listContacts = _listContacts;

}]);