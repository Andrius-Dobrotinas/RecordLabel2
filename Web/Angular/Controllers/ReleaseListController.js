"use strict";

angular.module("RecordLabelAngular").controller("ReleaseListController",
    ["$scope", "releasesService",
    function ReleaseListController($scope, releasesService) {
        $scope.entries = releasesService.query();

        $scope.isAdminMode = true;
    }
]);