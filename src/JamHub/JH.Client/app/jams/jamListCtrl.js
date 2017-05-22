(function () {
    "use strict";
    angular
        .module("jamManagement")
        .controller("JamListCtrl",
                     ["jamResource",
                         JamListCtrl]);

    function JamListCtrl(jamResource) {
        var vm = this;

        jamResource.query({
            $filter: "contains(JamCode, 'GDN') and Rating ge 5 and Rating le 20",
            $orderby: "Rating desc"},
            function (data) {
                vm.jams = data;
            });

        // Alternative code using variables instead of hard-coded values
        //vm.searchCriteria = "GDN";
        //vm.sortProperty = "Rating";
        //vm.sortDirection = "desc";

        //jamResource.query({
        //    $filter: "contains(JamCode, '" + vm.searchCriteria + "')" +
        //        " or contains(JamName, '" + vm.searchCriteria + "')",
        //    $orderby: vm.sortProperty + " " + vm.sortDirection
        //}, function (data) {
        //    vm.jams = data;
        //})

    }
}());
