"use strict";

application.factory("stateSvc", ["$rootScope", function ($rootScope) {
    return {
        setState: function (loading) {
            $rootScope.isLoading = loading;
        }
    }
}]);