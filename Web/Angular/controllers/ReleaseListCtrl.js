"use strict";

angular.module("RecordLabel").controller("ReleaseListCtrl",
    ["$scope", "releasesService", "resourceErrorHandler",
    function ReleaseListCtrl($scope, releasesService, resourceErrorHandler) {
        $scope.entries = resourceErrorHandler(releasesService.queryBatch({ batch: 1 }));
        // TODO: add LoadMore button and make this thing track requested batches

        $scope.isAdminMode = true;
    }
]);