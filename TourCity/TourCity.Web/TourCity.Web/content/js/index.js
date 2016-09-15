var tourcityapp = angular.module('tourcityapp', []);

var maincontroller = tourcityapp.controller('maincontroller',
    function ($scope) {

        $scope.Name = "TestName";
        $scope.Categories = [{Name: "guagua"}, { Name: "lubao" }];

    });


