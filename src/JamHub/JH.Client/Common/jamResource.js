(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("jamResource",
                ["$resource",
                 "appSettings",
                 "currentUser",
                    jamResource])

    function jamResource($resource, appSettings, currentUser) {
        return $resource(appSettings.serverPath + "/api/jams/:id", null,
            {
                'get': {
                    headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
                },

                'save': {
                    headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
                },

                'update': {
                    method: 'PUT',
                    headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
                }
            });
    }
}());

