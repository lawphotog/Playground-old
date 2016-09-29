function sidebarController($scope, $http, $location, audio, config) {

    var userName = localStorage['userName'];
    var accessToken = localStorage['accessToken'];

    $scope.isAuthenticated = false;

    if (userName && accessToken) {
        $scope.isAuthenticated = true;

        $scope.username = userName;
    }

    $scope.categories = [];
    $scope.lists = [];

    var getcaturl = config.url.webservice + 'GetCategories';
    var getlisturl = config.url.webservice + 'GetLists';
    var getitemsurl = config.url.webservice + 'GetItems';
    var getitemsbycategory = config.url.webservice + 'GetItemsByCategory';
    var getitemsbylist = config.url.webservice + 'GetItemsByList';
    
    $http.get(getcaturl)
        .success(function (data) {
            angular.copy(data, $scope.categories);
        })
        .error(function (error) {
            toastr.error('error:' + error);
    });

    $http.get(getlisturl)
        .success(function (data) {
            angular.copy(data, $scope.lists);
        })
        .error(function (error) {
            toastr.error('error:' + error);
    });

    $scope.GetItemsByCategory = function (cId) {
        $location.path('/category/' + cId);
    };

    $scope.GetItemsByList = function (lId) {
        $location.path('/list/' + lId);
    };
}