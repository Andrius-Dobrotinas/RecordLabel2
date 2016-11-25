"use strict";

angular.module("RecordLabel").controller("ReleaseListController",
    ["$scope", "releasesService", "resourceErrorHandler",
    function ReleaseListController($scope, releasesService, resourceErrorHandler) {
        $scope.entries = resourceErrorHandler(releasesService.query());

        $scope.isAdminMode = true;
    }
]);