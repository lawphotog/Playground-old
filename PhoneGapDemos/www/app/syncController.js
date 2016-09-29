function syncController($http, $scope) {

    $scope.exit = function () {
        navigator.app.exitApp();
    };

    $scope.toggleflashlight = function () {
        window.plugins.flashlight.toggle();
    };

    $scope.getdeviceinfo = function () {
        var platform = window.device.platform;
        var version = window.device.version;
        var cordova = window.device.cordova;
        var model = window.device.model;

        toastr.info('your device platform: ' +
            platform + '\n' + 'your device version: ' +
            version + '\n' + 'your device model: ' +
            model + '\n' + 'cordova: ' + cordova);
    };

    $scope.getLocation = function() {

        toastr.info('please wait .. it can take a while');
        navigator.geolocation.getCurrentPosition(onSuccess, onError);

        function onSuccess(position) {

            var message = 'Latitude: ' + position.coords.latitude + '\n' +
                        'Longitude: ' + position.coords.longitude + '\n' +
                        'Altitude: ' + position.coords.altitude + '\n' +
                        'Accuracy: ' + position.coords.accuracy + '\n' +
                        'Altitude Accuracy: ' + position.coords.altitudeAccuracy + '\n' +
                        'Heading: ' + position.coords.heading + '\n' +
                        'Speed: ' + position.coords.speed + '\n' +
                        'Timestamp: ' + position.timestamp + '\n';

            toastr.info(message);

        };

        function onError(error) {
            alert('code: ' + error.code + '\n' +
                  'message: ' + error.message + '\n');
        }
    };

    $scope.vibrate = function() {
        toastr.info('should vibrate now');
        navigator.notification.vibrate(3000);
    };

    $scope.beep = function() {
        toastr.info('should beep now');
        navigator.notification.beep(1);
    };

    $scope.takePicture = function () {

        toastr.info('inside take picture');

        navigator.camera.getPicture(onSuccess, onFail, {
            quality: 50,
            destinationType: Camera.DestinationType.DATA_URL
        });

        function onSuccess(imageData) {
            toastr.info("camera success");
            var image = document.getElementById('myImage');
            image.src = "data:image/jpeg;base64," + imageData;
        }

        function onFail(message) {
            alert('Failed because: ' + message);
        }

    };

    $scope.GetHeading = function() {

        toastr.info('get heading');

        navigator.compass.getCurrentHeading(compassSuccess, compassError);
        function compassSuccess(heading) {
            toastr.info('Heading: ' + heading.magneticHeading);
        };

        function compassError(error) {
            toastr.info('CompassError: ' + error.code);
        };
    };    

    $scope.GetAlert = function() {

        toastr.info('an alert should be there shortly');

        navigator.notification.alert(
            'You are the winner! You are the winner! You are the winner! You are the winner! You are the winner!',  // message
            alertDismissed,         // callback
            'Native Alert Test',            // title
            'Done'                  // buttonName
        );

        function alertDismissed() {
            // do something
        }
    };

    $scope.OpenBrowser = function () {

        var ref = window.open('http://google.co.uk', '_blank', 'location=yes');

        //navigator.app.loadUrl
    };

    var watchID = null;
    $scope.watchHeading = function () {
        
        var options = { frequency: 1500 };
        watchID = navigator.compass.watchHeading(onSuccess, onError, options);


        function stopWatch() {
            if (watchID) {
                navigator.compass.clearWatch(watchID);
                watchID = null;
            }
        }

        function onSuccess(heading) {

            toastr.info('Heading: ' + heading.magneticHeading);
        }

        // onError: Failed to get the heading
        //
        function onError(compassError) {
            toastr.error('Compass error: ' + compassError.code);
        }

    };

    $scope.stopwatch = function() {

        if (watchID) {
            navigator.compass.clearWatch(watchID);
            watchID = null;
        }

    };

    $scope.GetFile = function () {

        window.requestFileSystem(LocalFileSystem.PERSISTENT, 0, 
            function onFileSystemSuccess(fileSystem) {
                fileSystem.root.getFile(
                "dummy.html", {create: true, exclusive: false}, 
                function gotFileEntry(fileEntry) {
                    var sPath = fileEntry.fullPath.replace("dummy.html","");
                    var fileTransfer = new FileTransfer();
                    fileEntry.remove();

                    toastr.info(sPath);

                    fileTransfer.download(
                        "http://www.w3.org/2011/web-apps-ws/papers/Nitobi.pdf",
                        sPath + "theFile.pdf",
                        function(theFile) {
                            toastr.info("download complete: " + theFile.toURI());
                            showLink(theFile.toURI());
                        },
                        function(error) {
                            toastr.info("download error source " + error.source);
                            toastr.info("download error target " + error.target);
                            toastr.info("upload error code: " + error.code);
                        }
                    );
                }, fail);
            }, fail);
    };

}






