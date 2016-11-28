"use strict";

angular.module("RecordLabel").controller("ReleaseListController",
    ["$scope", "releasesService", "resourceErrorHandler",
    function ReleaseListController($scope, releasesService, resourceErrorHandler) {
        $scope.entries = resourceErrorHandler(releasesService.queryBatch({ batch: 1 }));
        // TODO: add LoadMore button and make this thing track requested batches

        $scope.isAdminMode = true;
    }
]);