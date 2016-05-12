(function () {
    'use strict';
    var controllerId = 'clientdetails';
    angular.module('app').controller(controllerId, ['common', 'datacontext', '$location', '$routeParams', clientdetails]);

    function clientdetails(common, datacontext, $location, $routeParams) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

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
                console.log(data);
                return vm.client = data.data;
            });
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
            });
        }
        
        function updateClient() {
            return datacontext.updateClient(vm.client).then(function () {
                $location.path('/clientlist/');
            });
        }
    }
})();