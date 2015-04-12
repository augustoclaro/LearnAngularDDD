var app = angular.module('AngularAuthApp', [
    'ngRoute',
    'ngStorage',
    'angular-loading-bar',
    'gdi2290.md5-service',
    'ui.utils.masks'
]);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/views/signup.html"
    });

    $routeProvider.when("/contatos", {
        controller: "contatosController",
        templateUrl: "/views/contatos.html"
    });

    $routeProvider.when("/categorias", {
        controller: "categoriasController",
        templateUrl: "/views/categorias.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);