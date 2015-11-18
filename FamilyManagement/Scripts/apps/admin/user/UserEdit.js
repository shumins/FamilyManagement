"use strict";
angular
 .module("app", [])
.controller("listform", ["$scope", "$http", function ($scope, $http) {
    $scope.name = "00";
    $scope.submit = function ()
    {
        alert("123");
    }
}]);