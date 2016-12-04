"use strict";

angular.module("RecordLabel").controller("ReleaseListCtrl",
    ["$scope", "releasesService", "resourceErrorHandler",
    function ReleaseListCtrl($scope, releasesService, resourceErrorHandler) {
        var ctrl = this;
        ctrl.currentBatch = 1;

        $scope.entries = [];
        var result = resourceErrorHandler(releasesService.queryBatch({ batch: ctrl.currentBatch, size: $scope.settings.ItemsPerPage }))
            .$promise.then(function(data) {
                $scope.entries = data.Entries;
                $scope.batchesLeft = data.BatchCount - ctrl.currentBatch;
            });
                // TODO: add LoadMore button and make this thing track requested batches

        $scope.isAdminMode = true;
    }
]);