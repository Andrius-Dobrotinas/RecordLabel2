"use strict";

angular.module("RecordLabel", ["ngRoute", "ngResource"])
    .config(function ($routeProvider) {
        $routeProvider.when("/Releases", {
            templateUrl: "Angular/templates/ReleaseList.html",
            controller: "ReleaseListCtrl"
        })
        .when("/Releases/new", {
            templateUrl: "Angular/templates/ReleaseEdit.html",
            controller: "ReleaseEditCtrl"
        })
        .when("/Releases/:id", {
            templateUrl: "Angular/templates/ReleaseView.html",
            controller: "ReleaseViewCtrl"
        })
        .when("/Releases/edit/:id", {
            templateUrl: "Angular/templates/ReleaseEdit.html",
            controller: "ReleaseEditCtrl"
        })        
        .otherwise({
            redirectTo: "/Releases"
        })
    })
    .run(["$rootScope", "metadataService", "infoMsgService", function ($rootScope, metadataService, infoMsgService) {
        $rootScope.errors = [];
        $rootScope.infoMessage;

        // Populate global metadata list because we'll need it a lot
        $rootScope.metadataList = metadataService.query();

        $rootScope.$on('$locationChangeStart', function (event) {
            $rootScope.errors.length = 0;
            infoMsgService.changeLocation();
        });
    }
]);