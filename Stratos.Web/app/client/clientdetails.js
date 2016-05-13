(function () {
    'use strict';
    var controllerId = 'clientdetails';
    angular.module('app').controller(controllerId, ['common', 'datacontext', '$location', '$routeParams', clientdetails]);

    function clientdetails(common, datacontext, $location, $routeParams) {
        var logError = common.logger.getLogFn(controllerId, 'error');

        var vm = this;
        var clientId = ($routeParams.clientId) || 0;

        vm.client = {};

        activate();

        function activate() {
            var promises = [];

            if (clientId != 0) {
                promises = [getClient()];
            }
            common.activateController(promises, controllerId);
        }

        function getClient() {
            return datacontext.getClient(clientId).then(function (data) {
                return vm.client = data.data;
            }).catch(function () { logError("oops! Something went wrong."); });
        }

        vm.Save = function () {
            var promises;
            if (clientId == 0) {
                promises = [insertClient()];
            } else {
                promises = [updateClient()];
            }

            common.activateController(promises, controllerId);
        };

        function insertClient() {
            return datacontext.insertClient(vm.client).then(function () {
                $location.path('/clientlist/');
            }).catch(function () { logError("oops! Something went wrong."); });
        }

        function updateClient() {
            return datacontext.updateClient(vm.client).then(function () {
                $location.path('/clientlist/');
            }).catch(function () { logError("oops! Something went wrong."); });
        }
    }
})();