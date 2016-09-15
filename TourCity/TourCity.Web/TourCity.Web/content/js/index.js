//main app module
var tourcityapp = angular.module('tourcityapp', ['ngRoute']);

//Controller
var maincontroller = tourcityapp.controller('maincontroller',
    function ($scope) {

        $scope.Name = "TestName";
        $scope.Categories = [{ Name: "guagua" }, { Name: "lubao" }];

    });

//Routes
tourcityapp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/',
        {
            template: 'Welcome user!'
        })
        .when('/anotherpage',
        {
            template: 'Welcome user, again!'
        })
        .otherwise({
            template: '404'
        });
}]);

