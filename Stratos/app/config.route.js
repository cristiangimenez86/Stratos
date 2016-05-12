(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());
    
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: 'app/client/clientlist.html',
                    title: 'Clients',
                }
            }, {
                url: '/clientdetails/:clientId',
                config: {
                    title: 'Client Details',
                    templateUrl: 'app/client/clientdetails.html',
                }
            }, {
                url: '/serverlist/:clientId',
                config: {
                    title: 'Servers',
                    templateUrl: 'app/server/serverlist.html',
                }
            }, {
                url: '/serverdetails/:clientId/:serverId',
                config: {
                    title: 'Server Details',
                    templateUrl: 'app/server/serverdetails.html',
                }
            }
        ];
    }
})();