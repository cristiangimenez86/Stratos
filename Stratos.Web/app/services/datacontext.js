(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', '$http', datacontext]);

    function datacontext(common, $http) {
        var $q = common.$q;

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

        //---------------------------- Servers ------------------
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
        
        //function getServers() {
        //    var servers = [
        //        { id: '1', url: 'Papa', username: 'John', password: 'Papa'},
        //        { id: '2', url: 'Bell', username: 'Ward', password: 'Bell'},
        //        { id: '3', url: 'Jones', username: 'Colleen', password: 'Jones' },
        //        { id: '4', url: 'Green', username: 'Madelyn', password: 'Green' },
        //        { id: '5', url: 'Jobs', username: 'Ella', password: 'Jobs' },
        //        { id: '6', url: 'Gates', username: 'Landon', password: 'Gates' },
        //        { id: '7', url: 'Guthrie', username: 'Haley', password: 'Guthrie' }
        //    ];
        //    return $q.when(servers);
        //}
        
        //function searchClients() {
        //    var servers = [
        //        { id: '1', name: 'Papa', company: 'John', email: 'Papa@asd.com', phone:'123456456' },
        //        { id: '2', name: 'Bell', company: 'Ward', email: 'Bell@asd.com', phone: '123456456' },
        //        { id: '3', name: 'Jones', company: 'Colleen', email: 'Jones@asd.com', phone: '123456456' },
        //        { id: '4', name: 'Green', company: 'Madelyn', email: 'Green@asd.com', phone: '123456456' },
        //        { id: '5', name: 'Jobs', company: 'Ella', email: 'Jobs@asd.com', phone: '123456456' },
        //        { id: '6', name: 'Gates', company: 'Landon', email: 'Gates@asd.com', phone: '123456456' },
        //        { id: '7', name: 'Guthrie', company: 'Haley', email: 'Guthrie@asd.com', phone: '123456456' }
        //    ];
        //    return $q.when(servers);
        //}
        
        //function getClients() {
        //    var servers = [
        //        { id: '1', name: 'Papa', company: 'John', email: 'Papa@asd.com', phone: '123456456' },
        //        { id: '2', name: 'Bell', company: 'Ward', email: 'Bell@asd.com', phone: '123456456' },
        //        { id: '3', name: 'Jones', company: 'Colleen', email: 'Jones@asd.com', phone: '123456456' },
        //        { id: '4', name: 'Green', company: 'Madelyn', email: 'Green@asd.com', phone: '123456456' },
        //        { id: '5', name: 'Jobs', company: 'Ella', email: 'Jobs@asd.com', phone: '123456456' },
        //        { id: '6', name: 'Gates', company: 'Landon', email: 'Gates@asd.com', phone: '123456456' },
        //        { id: '7', name: 'Guthrie', company: 'Haley', email: 'Guthrie@asd.com', phone: '123456456' }
        //    ];
        //    return $q.when(servers);
        //}
        
        //function getClient() {
        //    var client = { id: '1', name: 'Papa', company: 'John', email: 'Papa@asd.com', phone: 'Florida' };
        //    return $q.when(client);
        //}
        
        //function getServer() {
        //    var server = { id: '1', url: 'Papa', username: 'John', password: 'Florida' };
        //    return $q.when(server);
        //}
    }
})();