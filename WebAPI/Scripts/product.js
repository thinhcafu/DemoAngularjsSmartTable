var app = angular.module('myApp', ['ui.grid', 'ui.grid.selection','smart-table']);
app.controller('productCtrl', ['$scope', '$http', '$filter', 'uiGridConstants', function ($scope, $http, $filter, uiGridConstants) {
    $scope.lastId = 0;
    $scope.products = [];
    $scope.totalProducts = 0;
    $scope.pageCurrent = 1;

    $scope.rowCollection = [     
    ]; // base collection
    $scope.itemsByPage = 5;
    $scope.displayedCollection = [].concat($scope.rowCollection); // displayed collection

    // display data
    $http.get('/api/Products/').success(function (usr) {
        $scope.rowCollection = urs.products;
        $scope.displayedCollection = [].concat($scope.rowCollection);
        console.log($scope.rowCollection);
    });
    ////.error(function(){
    ////    $scope.error= "loi";
    ////});
    $scope.gridOptions = {
        columnDefs: [
          { field:'Id'},
          { field:'Name' }
         
        ],
        enableFiltering: true,
        enableRowSelection: true
    };
    $scope.gridOptions.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
        $scope.gridApi = gridApi;
        gridApi.selection.on.rowSelectionChanged($scope,function(row){
            
            $scope.getDataToEdit(row.entity);// tu dong truyen du lieu xuong form edit
        });
  
       
       
    };
    
    $scope.gridOptions.multiSelect = false;

    //xac thuc user
    $.ajaxSetup({
        headers: {
            "Authorization": "Base " + btoa("thinhcafu" + ":" + "1234")
        }
    });

    $scope.loadProducts = function (page) {
        $.ajax({
            type: 'get',
            url: "api/products?page="+page,
            contentType: "application/json"
        }).done(function (data) {
            $scope.$apply(function () {
                //alert(JSON.stringify(data));
                $scope.products = data["Products"];
                $scope.gridOptions.data = $scope.products;
                $scope.rowCollection = $scope.products;
               //$scope.totalProducts = data["NumberProducts"];// lay so luong product de phan trang
            });

        }).fail(function (x) {
            alert(x.responseText);
        });
    };
    $scope.loadProducts(1);

    //add product
    $scope.add = function () {
        var dataJSON = { ID: -1, Name: $scope.NameAdd };
        $.ajax({
            url: "/api/products",
            data: JSON.stringify(dataJSON),
            contentType: 'application/json;charset=utf-8',
            dataType: 'json',
            type: 'POST'
        }).done(function () {
            $scope.loadProducts($scope.pageCurrent);
        }).fail(function (x) {
            alert('Error'+x.responseText);
        });
    };
    // lay du lieu de edit
    $scope.getDataToEdit = function (product) {
        $scope.Name = product.Name;
        $scope.lastId = product.Id;
    };

    // edit product
    $scope.edit = function () {
        var dataJSON = { Id: $scope.lastId, Name: $scope.Name };

        $.ajax({
            type: 'PUT',
            url: '/api/products/' + $scope.lastId + '',
            data: JSON.stringify(dataJSON),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json'
        }).done(function () {
            $scope.loadProducts($scope.pageCurrent);
        }).fail(function (x) {
            alert("error"+x.responseText);
        });
    };

    // ham prev
    $scope.prev = function () {
        $scope.pageCurrent--;
        if ($scope.pageCurrent < 1)
        {
            $scope.pageCurrent = 1;
        }
        $scope.loadProducts($scope.pageCurrent);
    }

    // ham next
    // ham prev
    $scope.next = function () {
      //  alert($scope.totalProducts);
        $scope.pageCurrent++;
        if ($scope.pageCurrent > Math.ceil($scope.totalProducts / 5))
        {
            $scope.pageCurrent = Math.ceil($scope.totalProducts / 5);
        }
        $scope.loadProducts($scope.pageCurrent);
    }
}]);