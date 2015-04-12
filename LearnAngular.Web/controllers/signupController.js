'use strict';
app.controller('signupController', ['$scope', '$location', '$timeout', 'authService', function ($scope, $location, $timeout, authService) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.registration = {
        NomeUsuario: "",
        Login: "",
        Senha: "",
        ConfirmarSenha: ""
    };

    $scope.signUp = function () {
        if ($scope.registration.NomeUsuario === "" || $scope.registration.Senha === "" || $scope.registration.Login === "") {
            $scope.savedSuccessfully = false;
            $scope.message = "Preencha todos os campos.";
            return;
        }

        if ($scope.registration.Senha != $scope.registration.ConfirmarSenha) {
            $scope.savedSuccessfully = false;
            $scope.message = "A senha e a confirmação de senha não conferem.";
            return;
        }

        authService.saveRegistration($scope.registration).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "Usuário cadastrado com sucesso. Redirecionando para a página de login...";
            startTimer();

        },
         function (response) {
             $scope.message = response.data.error;
         });
    };

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/login');
        }, 2000);
    }

}]);