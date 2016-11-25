"use strict";

angular.module("RecordLabel").controller("ReleaseEditController",
    ["$scope", "$routeParams", "releasesService", "artistsService", "mediaTypesService", "constantsService", "resourceErrorHandler",
    function ReleaseEditController($scope, $routeParams, releasesService, artistsService, mediaTypesService, constantsService, resourceErrorHandler) {

        $scope.constants = resourceErrorHandler(constantsService.get());
                        
        $scope.artists = resourceErrorHandler(artistsService.getList());
        $scope.mediaTypes = resourceErrorHandler(mediaTypesService.query());

        $scope.model = resourceErrorHandler(releasesService.getForEdit($routeParams));

        $scope.update = function (ReleaseEditForm) {
            if (ReleaseEditForm.$valid) {
                releasesService.save($scope.model);
            }
        }

        $scope.addReference = function () {
            $scope.model.References.push(angular.copy($scope.constants.DefaultReference));
        }

        $scope.deleteReference = function (index) {
            $scope.model.References.splice(index, 1);
        }

        $scope.addTrack = function () {
            $scope.model.Tracks.push(angular.copy($scope.constants.DefaultTrack));
        }

        $scope.deleteTrack = function (index) {
            $scope.model.Tracks.splice(index, 1);
        }
    }
]);