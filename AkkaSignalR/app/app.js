$(function () {

    var file = $.connection.file;

    $.connection.hub.start().done(function () {

        file.server.start();

    });

    file.client.count = function (value) {
        console.log(value);
        $('#count').text(value);
    };
});