var app = angular.module('burmese.study.mobile', ['ngRoute', 'mobile-angular-ui']);

app.config(function($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: 'views/home.html'
        })
        .when('/home', {
            templateUrl: 'views/home.html'
        })
        .when('/category/:cId', {
            templateUrl: 'views/home.html'
        })
        .when('/list/:lId', {
            templateUrl: 'views/home.html'
        })
        .when('/favourites', {
            templateUrl: 'views/favourites.html'
        })
        .when('/sync', {
            templateUrl: 'views/sync.html'
        });
});

app.directive('a', function () {
    return {
        restrict: 'E',
        link: function (scope, elem, attrs) {
            if (attrs.ngClick || attrs.href === '' || attrs.href === '#') {
                elem.on('click', function (e) {
                    e.preventDefault();
                });
            }
        }
    };
});

app.factory('audio', function ($document) {

    var audioElement = $document[0].createElement('audio');
    return {
        audioElement: audioElement,

        play: function (filename) {
            audioElement.src = filename;
            audioElement.play();
        }
    };
});

app.factory('config', function () {

    var base = 'http://myanmarlanguage.training/bt/';

    //var base = 'http://localhost:53013/';

    var url = {
        base: base,
        webservice: base + 'api/Mobi/',
        audio: base + 'Uploads/'
    };
    
    return {        
        url: url
    };

});