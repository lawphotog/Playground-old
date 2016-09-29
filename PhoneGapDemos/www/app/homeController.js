function homeController($http, $scope, audio, config, $routeParams) {

    var userName = localStorage['userName'];
    var accessToken = localStorage['accessToken'];

    //toastr.info('userName: ' + userName + ', assessToken: ' + accessToken);

    $scope.isAuthenticated = false;
    var categoryId = $routeParams.cId;
    var listId = $routeParams.lId;

    $scope.items = [];
    //$scope.userLists = [];

    var getitemsbycategory = config.url.webservice + 'GetItemsByCategory';
    var getitemsbylist = config.url.webservice + 'GetItemsByList';
    var getitemsurl = config.url.webservice + 'GetItems';
    var savefavouriteurl = config.url.webservice + 'SaveToFavourite';
    //var getlistbyuserurl = config.url.webservice + 'GetListsByUser';

    if (userName && accessToken) {
        $scope.isAuthenticated = true;

        $scope.username = userName;
        $scope.accessToken = accessToken;

        //$http.get(getlistbyuserurl + '?userName=' + userName)
        //    .success(function (data) {
        //        angular.copy(data, $scope.userLists);
        //    })
        //    .error(function (error) {
        //        toastr.error('error:' + error)
        //    });
    }

    

    

    if (categoryId) {
        
        $http.get(getitemsbycategory, {
            params: { categoryId: categoryId }
        })
        .success(function (data) {
            angular.copy(data, $scope.items);
        })
        .error(function (error) {
            toastr.error('error:' + error);
        });

    } else if (listId) {

        $http.get(getitemsbylist, {
            params: { listId: listId }
        })
        .success(function (data) {
            angular.copy(data, $scope.items);
        })
        .error(function (error) {
            toastr.error('error:' + error);
        });

    } else {

        $http.get(getitemsurl)
        .success(function (data) {
            angular.copy(data, $scope.items);
        })
        .error(function (error) {
            toastr.error('error: ' + error);
        });
         
    }

    $scope.addToFavourite = function (Id) {

        toastr.info('clicked');

        //$http.get(savefavouriteurl)
        //.success(function (data) {
        //    toastr.success('success');
        //})
        //.error(function (error) {
        //    toastr.error('error: ' + error)
        //});

    }

    $scope.playAudio = function (filename) {

        //var localAudio = 'audios/' + filename;

        //check file locally first
        //if file not exists, get from the server
        
        //if (localAudio.exist())
        //{
              //audio.play(localAudio);
        //}
        //else
        //{
        //    //get the file from the server and save in local
        //    //audio.play(config.url.audio + filename);
        //}




    };

    


}