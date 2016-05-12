(function () {
    'use strict';
    var controllerId = 'serverlist';
    angular.module('app').controller(controllerId, ['common', 'datacontext', '$location', '$routeParams', serverlist]);

    function serverlist(common, datacontext, $location, $routeParams) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        var clientId = ($routeParams.clientId) || 0;
        
        vm.servers = [];
        
        activate();

        function activate() {
            var promises = [getServers()];
            common.activateController(promises, controllerId);
        }

        vm.DeleteServer = function (server) {
            if (confirm('Are sure want to delete this server?')) {
                var promises = [deleteServer(server)];
                common.activateController(promises, controllerId);
            }
        };

        function deleteServer(server) {
            return datacontext.deleteServer(server).then(function () {
                activate();
            });
        }

        vm.EditServer = function (server) {
            $location.path('/serverdetails/' + clientId + '/' + server);
        };

        vm.AddServer = function () {
            $location.path('/serverdetails/' + clientId + '/' + 0);
        };

        //function pageLoad() {
        //    return datacontext.pageLoad().then(function (data) {
        //        return vm.Clients = data;
        //    });
        //}

        function getServers() {
            return datacontext.getServers(clientId).then(function (data) {
                return vm.servers = data.data;
            });
        }
    }
})();