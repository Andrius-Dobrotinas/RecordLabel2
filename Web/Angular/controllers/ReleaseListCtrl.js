"use strict";

angular.module("RecordLabel").controller("ReleaseListCtrl",
    ["$scope", "releasesService", "batchedListSvc",
    function ReleaseListCtrl($scope, releasesService, batchedListSvc) {
        var ctrl = this;
        
        var svc = batchedListSvc(releasesService, $scope.settings.ItemsPerPage);
        
        ctrl.entries = function () {
            return svc.entries;
        }

        ctrl.moreItemsAvailable = function () {
            return svc.moreItemsAvailable;
        }

        ctrl.loadMore = function () {
            svc.loadMore();
        }
    }
]);