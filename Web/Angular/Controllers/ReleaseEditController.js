"use strict";

angular.module("RecordLabel").controller("ReleaseEditController",
    ["$scope", "$routeParams", "releasesService", "artistsService", "mediaTypesService", "constantsService", "resourceErrorHandler", "modelPostResourceService",
function ReleaseEditController($scope, $routeParams, releasesService, artistsService, mediaTypesService, constantsService, resourceErrorHandler, modelPostResourceService) {

        $scope.constants = resourceErrorHandler(constantsService.get());                     
        $scope.artists = resourceErrorHandler(artistsService.getList());
        $scope.mediaTypes = resourceErrorHandler(mediaTypesService.query());
        $scope.model = resourceErrorHandler(releasesService.getForEdit($routeParams));
        $scope.validationErrors = [];

        $scope.update = function (form) {
            // TODO: handle error responses
            if (form.$valid) {
                $scope.validationErrors.length = 0;
                modelPostResourceService(releasesService.save($scope.model), "/Releases", $scope.validationErrors);
            } else {
                $scope.errors.push({ statusText: "Data cannot be submitted because there are validation errors!" });
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

        // Checks if a field has invalid value
        $scope.isValid = function (formField) {
            return formField.$dirty && formField.$invalid;
        }

        // Checks if a field has an invalid NON-empty value
        $scope.isValidForRequired = function (formField) {
            return formField.$dirty && !formField.$error.required && formField.$invalid;
        }

        // Checks if a field is empty
        $scope.isEmptyForRequired = function (formField) {
            return formField.$error && formField.$error.required;
        }
    }
]);