var app = angular.module('myApp', ['smart-table']);
app.controller('productCtrl', function ($scope, $http) {
    $scope.rowCollection = [];  // base collection
    $scope.itemsByPage = 5;
    $scope.displayedCollection = [].concat($scope.rowCollection);  // displayed collection
    // Display Data
    $http.get('/api/Products/').success(function (usr) {
        $scope.rowCollection = usr;
        $scope.displayedCollection = [].concat($scope.rowCollection);
        console.log($scope.rowCollection);
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";

    });
});