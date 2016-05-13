(function () {
    'use strict';
    var controllerId = 'serverdetails';
    angular.module('app').controller(controllerId, ['common', 'datacontext','$location', '$routeParams', serverdetails]);

    function serverdetails(common, datacontext, $location, $routeParams) {
        var logError = common.logger.getLogFn(controllerId, 'error');

        var vm = this;
        var serverId = ($routeParams.serverId) || 0;
        var clientId = ($routeParams.clientId) || 0;
        vm.server = {};

        activate();

        function activate() {
            var promises = [];

            if (serverId != 0) {
                promises = [getServer()];
            }
            common.activateController(promises, controllerId);
        }

        function getServer() {
            return datacontext.getServer(serverId).then(function (data) {
                return vm.server = data.data;
            }).catch(function () { logError("oops! Something went wrong."); });
        }
        
        vm.Save = function () {
            var promises;
            if (serverId == 0) {
                promises = [insertServer()];
            } else {
                promises = [updateServer()];
            }

            common.activateController(promises, controllerId);
        };

        function insertServer() {
            vm.server.clientId = clientId;
            return datacontext.insertServer(vm.server).then(function () {
                $location.path('/serverlist/' + clientId);
            }).catch(function () { logError("oops! Something went wrong."); });
        }

        function updateServer() {
            return datacontext.updateServer(vm.server).then(function () {
                $location.path('/serverlist/' + clientId);
            }).catch(function () { logError("oops! Something went wrong."); });
        }
    }
})();