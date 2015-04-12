'use strict';
app.controller('contatosController', ['$scope', 'contatosService', 'categoriasService', '$rootScope', function ($scope, contatosService, categoriasService, $rootScope) {

    $scope.contatos = [];
    $scope.search = $rootScope.contactSearch || "";
    var _setDefaultModel = function () {
        $scope.formData = {
            "IdContato": "",
            "NomeContato": "",
            "TelefoneResidencial": "",
            "TelefoneCelular": "",
            "IdCategoria": ""
        };
    };
    _setDefaultModel();

    categoriasService.getCategorias().then(function (results) {
        $scope.categorias = results.data;
    });

    var _carregaLista = function ($scope) {
        contatosService.getContatos().then(function (results) {
            $scope.contatos = results.data;

        }, function (error) {
            alert(error.data.message);
        });
    };
    _carregaLista($scope);
    var _formatPhone = function (str) {
        if (!str) return str;
        var ddd = str.substring(0, 2);
        var hifen = str.length === 10 ? 6 : 7;
        var part1 = str.substring(2, hifen);
        var part2 = str.substring(hifen);
        var phone = part1 + "-" + part2;
        return "(" + ddd + ") " + phone;
    };

    var _delete = function (id) {
        bootbox.confirm("Tem certeza que quer excluir este contato?", function (r) {
            if (r)
                contatosService.deleteContato(id).then(function () {
                    _carregaLista($scope);
                });
        });
    };

    var _alter = function (c) {
        $scope.formData.IdContato = c.idContato;
        $scope.formData.NomeContato = c.nomeContato;
        $scope.formData.TelefoneResidencial = c.telefoneResidencial;
        $scope.formData.TelefoneCelular = c.telefoneCelular;
        $scope.formData.IdCategoria = c.idCategoria;
        jQuery("#modalContato").append("body").modal('show');
    };

    var _salvarDados = function () {
        var form = $scope.formData;

        if (form.NomeContato === "") {
            bootbox.alert("Preencha o nome.");
            return;
        }

        if (form.TelefoneCelular === "" && form.TelefoneResidencial === "") {
            bootbox.alert("Preencha pelo menos um dos telefones.");
            return;
        }

        if (form.IdCategoria === "") {
            bootbox.alert("Selecione a categoria.");
            return;
        }

        var $req;
        if (form.IdContato) { //ALTERAÇÃO
            $req = contatosService.alterarContato(form);
        } else { //NOVO
            $req = contatosService.criarContato(form);
        }
        $req.success(function () {
            jQuery("#modalContato").modal('hide');
            _carregaLista($scope);
        })
        .error(function () {
            bootbox.alert("Ocorreu algum erro ao salvar.");
        });
    };

    var _novo = function () {
        _setDefaultModel();
        jQuery("#modalContato").append("body").modal('show');
    };

    $scope.formatPhone = _formatPhone;
    $scope.delete = _delete;
    $scope.alter = _alter;
    $scope.salvarDados = _salvarDados;
    $scope.novo = _novo;

}]);