function favouriteController($scope, $http, config, audio) {

    var userName = localStorage['userName'];
    var accessToken = localStorage['accessToken'];

    $scope.isAuthenticated = false;

    $scope.items = [];
    $scope.lists = [];

    if (userName && accessToken) {
        $scope.isAuthenticated = true;

        $scope.username = userName;
        $scope.accessToken = accessToken;

        var getlisturl = config.url.webservice + 'GetListsByUser';
        var getitemsbylisturl = config.url.webservice + 'GetItemsByList';

        $scope.playAudio = function (filename) {
            audio.play(config.url.audio + filename);
        };

        $http.get(getlisturl + '?userName=' + userName)
            .success(function (data) {
                angular.copy(data, $scope.lists);
            })
            .error(function (error) {
                toastr.error('error: ' + error);
            });

        $scope.GetItemsByList = function (lId) {

            $http.get(getitemsbylisturl + '?listId=' + lId)
            .success(function (data) {
                angular.copy(data, $scope.items);
            })
            .error(function (error) {
                toastr.error('error: ' + error);
            });
        };
    }
}