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
        .when('/',{
            templateUrl: 'home/index.html'
        })
        .when('/anotherpage',{
            templateUrl: 'home/index2.html'
        })
        .otherwise({
            template: '404'
        });
}]);

