﻿"use strict";

angular.module("RecordLabelAngular").controller("ReleaseViewController",
    ["$scope", "$routeParams", "$sce", "releasesService", "resourceErrorHandler",
    function ReleaseViewController($scope, $routeParams, $sce, releasesService, resourceErrorHandler) {

        var takeCareOfResponse = function (data) {
            var model = data.Release
            model.YoutubeReferences = data.YoutubeReferences;

            // Fix youtube links for use with iFrame. TODO: probably convert to a service?
            if (model.YoutubeReferences) {
                model.YoutubeReferences.forEach(function (reference) {
                    reference.Target = $sce.trustAsResourceUrl(reference.Target)
                })
            }

            $scope.model = model;
        }

        resourceErrorHandler(releasesService.get($routeParams)).$promise.then(takeCareOfResponse);
    }
]);