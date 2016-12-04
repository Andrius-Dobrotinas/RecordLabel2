"use strict";

// This service takes care of loading items in batches and tracking availability of more items
application.factory("batchedListSvc", ["resourceErrorHandler", function (resourceErrorHandler) {
    return function (resourceService, itemsPerPage) {
        var service = function () {
            this.entries = [];
            this.currentBatch = 0;
            this.moreItemsAvailable = false;
            this.promise = undefined;

            var svc = this;
            this.loadMore = function () {
                svc.promise = resourceErrorHandler(resourceService.queryBatch(
                {
                    batch: ++svc.currentBatch,
                    size: itemsPerPage
                }));

                svc.promise.$promise.then(function (data) {
                    svc.entries = svc.entries.concat(data.Entries);
                    svc.batchesLeft = data.BatchCount - svc.currentBatch;
                    svc.moreItemsAvailable = svc.batchesLeft > 0;
                });
            }
        }

        var svc = new service();
        svc.loadMore();

        return svc;
    }
}]);