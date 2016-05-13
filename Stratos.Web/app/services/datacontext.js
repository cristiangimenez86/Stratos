(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', '$http', datacontext]);

    function datacontext(common, $http) {

        var service = {
            getClients: getClients,
            getClient: getClient,
            searchClients: searchClients,
            insertClient: insertClient,
            updateClient: updateClient,
            deleteClient: deleteClient,
            getServers: getServers,
            getServer: getServer,
            insertServer: insertServer,
            updateServer: updateServer,
            deleteServer: deleteServer,
        };

        return service;

        //----------------- Client ------------------
        function getClients() {
            return $http({
                method: 'GET',
                url: 'api/Client',
            });
        }
        
        function getClient(id) {
            return $http({
                method: 'GET',
                url: 'api/Client/' + id,
            });
        }
        
        function searchClients(name) {
            if (!name) {
                return $http({
                    method: 'GET',
                    url: 'api/Client/',
                });
            }
            
            return $http({
                method: 'GET',
                url: 'api/Search/' + name,
            });
        }

        function insertClient(client) {
            return $http({
                method: 'POST',
                url: 'api/Client',
                data: client
            });
        }

        function updateClient(client) {
            return $http({
                method: 'PUT',
                url: 'api/Client',
                data: client
            });
        }

        function deleteClient(id) {
            return $http({
                method: 'DELETE',
                url: 'api/Client/' + id,
            });
        }

        //----------------- Server ------------------
        function getServers(cliendId) {
            return $http({
                method: 'GET',
                url: 'api/Server?cliendId=' + cliendId
            });
        }

        function getServer(id) {
            return $http({
                method: 'GET',
                url: 'api/Server/' + id,
            });
        }
        
        function insertServer(server) {
            return $http({
                method: 'POST',
                url: 'api/Server',
                data: server
            });
        }

        function updateServer(server) {
            return $http({
                method: 'PUT',
                url: 'api/Server',
                data: server
            });
        }

        function deleteServer(id) {
            return $http({
                method: 'DELETE',
                url: 'api/Server/' + id,
            });
        }
    }
})();