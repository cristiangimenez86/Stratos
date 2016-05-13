(function () {
    'use strict';
    var controllerId = 'clientlist';
    angular.module('app').controller(controllerId, ['common', 'datacontext', '$location', clientlist]);

    function clientlist(common, datacontext, $location) {
        var logError = common.logger.getLogFn(controllerId, 'error');

        var vm = this;
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
            }).catch(function () { logError("oops! Something went wrong."); });
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
            }).catch(function () { logError("oops! Something went wrong."); });
        }
        
        vm.ViewServers = function (client) {
            $location.path('/serverlist/' + client);
        };


        vm.DeleteClient = function (client) {
            if (confirm('Are sure want to delete this client and all its Servers?')) {
                var promises = [deleteClient(client)];
                common.activateController(promises, controllerId);
            }
        };
        
        function deleteClient(client) {
            return datacontext.deleteClient(client).then(function () {
                vm.SearchClients();
            }).catch(function () { logError("oops! Something went wrong."); });
        }
        
        vm.EditClient = function (client) {
            $location.path('/clientdetails/' + client);
        };
        
        vm.AddClient = function () {
            $location.path('/clientdetails/' + 0);
        };
    }
})();