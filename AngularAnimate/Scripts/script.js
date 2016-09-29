var app = angular.module('app', ['ngAnimate', 'ngRoute']);

app.constant('routes', [
    {
        path: '/view1', route: {
            templateUrl: 'view1.html',
            title: 'View 1'
        }
    },
    {
        path: '/view2', route: {
            templateUrl: 'view2.html',
            title: 'View 2'
        }
    },
    {
        path: '/view3', route: {
            templateUrl: 'view3.html',
            title: 'View 3'
        }
    }
]);

app.config(['$routeProvider', 'routes', routeConfigurator]);

function routeConfigurator($routeProvider, routes) {
    routes.forEach(function (r) {
        $routeProvider.when(r.path, r.route);
    });
    $routeProvider.otherwise({ redirectTo: '/view1' });
}

app.controller('demoController', ['$location', '$rootScope', '$route', 'routes', demoController]);

function demoController($location, $rootScope, $route, routes) {
    var vm = this;
    var currentPath;
    vm.views = routes;
    vm.animations = [
        { name: 'shuffle-animation', caption: 'Shuffle' },
        { name: 'top-down-animation', caption: 'Top Down' },
        { name: 'fader-animation', caption: 'Fade' }
    ];
    vm.currentAnimation = vm.animations[0];
    vm.setRoute = function (view) {
        $location.path(view.path);
    };
    vm.activeViewClass = function (view) {
        return view.path === currentPath ? 'active' : '';
    };
    vm.activeAnimationClass = function (animation) {
        return animation.name === vm.currentAnimation.name ? 'active' : '';
    };
    vm.setAnimation = function (animation) {
        vm.currentAnimation = animation;
    };

    $rootScope.$on('$routeChangeSuccess', function (scope, next, current) {
        currentPath = next.originalPath;
    });
};
