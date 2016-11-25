"use strict";

angular.module("RecordLabelAngular").controller("ReleaseEditController",
    ["$scope", "$routeParams", "releasesService", "artistsService", "mediaTypesService", "constantsService",
    function ReleaseEditController($scope, $routeParams, releasesService, artistsService, mediaTypesService, constantsService) {

        $scope.constants = constantsService.get();
        
        $scope.artists = artistsService.getList();
        $scope.mediaTypes = mediaTypesService.query();

        $scope.model = releasesService.getForEdit($routeParams);

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