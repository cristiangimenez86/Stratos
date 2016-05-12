(function () {
    'use strict';
    var controllerId = 'clientlist';
    angular.module('app').controller(controllerId, ['common', 'datacontext', '$location', clientlist]);

    function clientlist(common, datacontext, $location) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.messageCount = 0;

        vm.clients = null;
        vm.clientsForAutocomplete = [];

        activate();

        function activate() {
            var promises = [getClients()];
            common.activateController(promises, controllerId);
        }

        function getClients() {
            return datacontext.getClients().then(function (data) {
                vm.clientsForAutocomplete = data.data;
                return vm.clients = data.data;
            });
        }
        
        vm.SearchClients = function () {
            var promises = [searchClients()];
            common.activateController(promises, controllerId);
        };
        
        function searchClients() {
            var criteria = null;
            console.log(vm.searchClient);
            console.log(vm.searchCriteria);
            
            if (vm.searchClient) {
                criteria = vm.searchClient.title;
            }
            return datacontext.searchClients(criteria).then(function (data) {
                return vm.clients = data.data;
            });
        }
        
        vm.ViewServers = function (client) {
            $location.path('/serverlist/' + client);
        };


        vm.DeleteClient = function (client) {
            if (confirm('Are sure want to delete this client?')) {
                var promises = [deleteClient(client)];
                common.activateController(promises, controllerId);
            }
        };
        
        function deleteClient(client) {
            return datacontext.deleteClient(client).then(function () {
                vm.SearchClients();
            });
        }
        
        vm.EditClient = function (client) {
            $location.path('/clientdetails/' + client);
        };
        
        vm.AddClient = function () {
            $location.path('/clientdetails/' + 0);
        };
    }
})();