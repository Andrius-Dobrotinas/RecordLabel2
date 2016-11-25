"use strict";

angular.module("RecordLabelAngular").controller("ReleaseListController",
    ["$scope", "releasesService", "resourceErrorHandler",
    function ReleaseListController($scope, releasesService, resourceErrorHandler) {
        $scope.entries = resourceErrorHandler(releasesService.query());

        $scope.isAdminMode = true;
    }
]);