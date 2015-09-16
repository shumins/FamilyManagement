
    "use strict";
    angular
      .module("app",[])
      .controller("userlist", ["$scope", "$http", function ($scope,$http) {
          $scope.changePage = function (page) {
              var pageSize = 20;
              $http({
                  method: 'get',
                  url: '/Api/AdminUser/GetUserList?pageSize=' + pageSize + '&page=' + page
              }).success(function (data) {

              });
          }
          //第一次加载分页
          $scope.changePage(1);
       

      }]);
