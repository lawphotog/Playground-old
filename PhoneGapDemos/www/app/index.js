function onLoad() {
    document.addEventListener("deviceready", onDeviceReady, false);
}

function onDeviceReady() {
    
    document.addEventListener("menubutton", onMenuKeyDown, false);
    document.addEventListener("searchbutton", yourSearchCallbackFunction, false);

    checkConnection();

    document.addEventListener("batterystatus", onBatteryStatus, false);
    document.addEventListener("offline", deviceOffline, false);
    document.addEventListener("online", deviceOnline, false);

    window.requestFileSystem = window.requestFileSystem || window.webkitRequestFileSystem;
    window.requestFileSystem(LocalFileSystem.PERSISTENT, 0, gotFS, fail);

    //var pushNotification;
    //pushNotification = window.plugins.pushNotification;

    //if (device.platform == 'android' || device.platform == 'Android') {
    //    pushNotification.register(
    //        successHandler,
    //        errorHandler, {
    //            "senderID": "replace_with_sender_id",
    //            "ecb": "onNotificationGCM"
    //        });
    //}
    //else {
    //    pushNotification.register(
    //        tokenHandler,
    //        errorHandler, {
    //            "badge": "true",
    //            "sound": "true",
    //            "alert": "true",
    //            "ecb": "onNotificationAPN"
    //        });
    //}

    window.plugins.flashlight.available(function (isAvailable) {         

        if (isAvailable) {
            toastr.info('Flashlight is available on this device');
            // switch on
            window.plugins.flashlight.switchOn(); // success/error callbacks may be passed

            // switch off after 3 seconds
            setTimeout(function () {
                window.plugins.flashlight.switchOff(); // success/error callbacks may be passed
            }, 3000);

        } else {
            toastr.error("Flashlight not available on this device");
        }
    });    

    document.addEventListener("backbutton", function () {
        // pass exitApp as callbacks to the switchOff method
        window.plugins.flashlight.switchOff(exitApp, exitApp);
    }, false);

    function exitApp() {
        navigator.app.exitApp();
    }
}

function onBatteryStatus(info) {
    toastr.info('in battery status callback');
    toastr.info("Level: " + info.level + " isPlugged: " + info.isPlugged);
}

function deviceOffline() {
    toastr.info('network connection lost');
}

function deviceOnline() {
    toastr.info('network connection on');
}

function gotFS(fileSystem) {
    //console.log("got filesystem");
    //toastr.info(fileSystem.root);
    // save the file system for later access
    toastr.info(fileSystem.root.fullPath);
    window.rootFS = fileSystem.root;
}

function fail(error) {
    toastr.info(error);
}

function checkConnection() {
    var networkState = navigator.connection.type;

    var states = {};
    states[Connection.UNKNOWN] = 'Unknown connection';
    states[Connection.ETHERNET] = 'Ethernet connection';
    states[Connection.WIFI] = 'WiFi connection';
    states[Connection.CELL_2G] = 'Cell 2G connection';
    states[Connection.CELL_3G] = 'Cell 3G connection';
    states[Connection.CELL_4G] = 'Cell 4G connection';
    states[Connection.CELL] = 'Cell generic connection';
    states[Connection.NONE] = 'No network connection';

    toastr.info('Connection type: ' + states[networkState]);
}

function onMenuKeyDown() {
    toastr.info('menu clicked');
}

function yourSearchCallbackFunction() {
    toastr.info('search clicked');
}