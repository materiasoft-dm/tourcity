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
        .when('/', {
            templateUrl: 'Profile/index'
        })
       .when('/categories', {
           templateUrl: 'Profile/categories'
       })
        .when('/facebook/register', {
            templateUrl: 'facebookmanager/register'
        })

        .otherwise({
            template: '404'
        });
}]);

