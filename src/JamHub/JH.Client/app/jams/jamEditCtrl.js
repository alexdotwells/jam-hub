(function () {
    "use strict";

    angular
        .module("jamManagement")
        .controller("JamEditCtrl",
                     JamEditCtrl);

    function JamEditCtrl(jamResource) {
        var vm = this;
        vm.jam = {};
        vm.message = '';

        jamResource.get({ id: 5 },
            function (data) {
                vm.jam = data;
                vm.originalJam = angular.copy(data);
            },
            function (response) {
                vm.message = response.statusText + "\r\n";
                if (response.data.exceptionMessage)
                    vm.message += response.data.exceptionMessage;
            });

        if (vm.jam && vm.jam.jamId) {
            vm.title = "Edit: " + vm.jam.jamName;
        }
        else {
            vm.title = "New Jam";
        }

        vm.submit = function () {
            vm.message = '';
            if (vm.jam.jamId) {
                vm.jam.$update({ id: vm.jam.jamId },
                    function (data) {
                        vm.message = "... Save Complete";
                    },
                    function (response) {
                        vm.message = response.statusText + "\r\n";
                        if (response.data.modelState) {
                            for (var key in response.data.modelState) {
                                vm.message += response.data.modelState[key] + "\r\n";
                            }
                        }
                        if (response.data.exceptionMessage)
                            vm.message += response.data.exceptionMessage;
                    });
            }
            else {
                vm.jam.$save(
                    function (data) {
                        vm.originalJam = angular.copy(data);

                        vm.message = "... Save Complete";
                    },
                    function (response) {
                        vm.message = response.statusText + "\r\n";
                        if (response.data.modelState) {
                            for (var key in response.data.modelState) {
                                vm.message += response.data.modelState[key] + "\r\n";
                            }
                        }
                        if (response.data.exceptionMessage)
                            vm.message += response.data.exceptionMessage;
                    });
            }
        };

        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.jam = angular.copy(vm.originalJam);
            vm.message = "";
        };

    }
}());
