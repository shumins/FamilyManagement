
    "use strict";
    angular
      .module("app", ["CommonFilter", "brantwills.paging"])
      .controller("userlist", ["$scope", "$http", function ($scope, $http) {
          $scope.currentPage = 0;
          $scope.pageSize = 1;
          $scope.itemCount = 0;
          $scope.changePage = function (page) {
              var pageSize = 20;
              $http({
                  method: 'get',
                  url: '/Api/AdminUser/GetUserList?pageSize=' + pageSize + '&page=' + page
              }).success(function (data) {
                  if (data.State) {
                      $scope.currentPage = page;
                      $scope.pageSize = pageSize;
                      $scope.itemCount = data.Pager.TotalCount;
                      var userList = [];
                      for (var i = 0; i < data.List.length; i++) {
                          var list = {};
                          list.id = data.List[i].Id;
                          list.username = data.List[i].UserName;
                          list.age = data.List[i].Age;
                          list.sex = data.List[i].Sex === 1?"男":"女";
                          list.phone = data.List[i].Phone;
                          list.createtime = data.List[i].CreateTime;
                          list.address = data.List[i].Address;
                          list.email = data.List[i].Email;
                          list.status = data.List[i].Status;
                          
                          userList.push(list);
                      }
                      $scope.userList = userList;
                  } else {
                      alert(data.Message);
                  }
              });
          }
          //第一次加载分页
          $scope.changePage(1);
          $scope.member_stop = function (status, id) {
              if (status === 1) {
                  layer.confirm('确认要停用吗？', function (index) {
                  });
              } else if (status === 0) {
                  layer.confirm('确认要启用吗？', function (index) {
                  });
              }

              

          }


        }]);
