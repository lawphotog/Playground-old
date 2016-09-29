function loginController($scope, $http, config) {

    var userName = localStorage['userName'];
    var accessToken = localStorage['accessToken'];
    
    $scope.isAuthenticated = false;

    if (userName && accessToken) {
        $scope.isAuthenticated = true;

        $scope.username = userName;
        $scope.accessToken = accessToken;
    }

    $scope.login = function (user) {

        if (!user) {
            toastr.error('both username and password are required');
        }
        else if (typeof user.username == 'undefined' || typeof user.password == 'undefined') {
            toastr.error('both username and password are required');
        }
        else {

            angular.element('#login').attr('disabled', true);

            var logindata = $.param({ 'grant_type': 'password', 'username': user.username, 'password': user.password });

            $http({
                url: config.url.base + 'Token',
                dataType: 'json',
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                },
                data: logindata
            })
            .success(function (data) {

                if (data.userName && data.access_token) {

                    toastr.success("login successful");

                    localStorage["userName"] = data.userName;
                    localStorage["accessToken"] = data.access_token;

                    document.location.href = 'index.html';
                }
            })
            .error(function (error) {
                toastr.error(error.error_description);
                angular.element('#login').attr('disabled', false);
                $('#login').text('Login');
            })
            .then(function () {
                $('#login').text('Login');
            });
        };
        
    };

    $scope.logout = function () {

        var url = config.url.base + 'b/api/Account/Logout';
        var token = $scope.accessToken;

        //toastr.info(url);
        //toastr.info(token);

        $http({
            url: url,
            method: 'POST',
            headers: {
                Authorization: "Bearer " + token
            }
        })
        .success(function() {

            localStorage['userName'] = "";
            localStorage['accessToken'] = "";

            localStorage.clear();

            //$location.path('/');
            //refresh everything after logout
            document.location.href = 'index.html';
        })
        .error(function (error) {
            toastr.error('error:' + error);
            toastr.error('error:' + error.Message);

            localStorage['userName'] = "";
            localStorage['accessToken'] = "";

            localStorage.clear();

            document.location.href = 'index.html';
        });
    };


}