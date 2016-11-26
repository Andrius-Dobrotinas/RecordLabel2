"use strict";

angular.module("RecordLabel", ["ngRoute", "ngResource"])
    .config(function ($routeProvider) {
        $routeProvider.when("/Releases", {
            templateUrl: "Angular/Templates/ReleaseList.html",
            controller: "ReleaseListController"
        })
        .when("/Releases/:id", {
            templateUrl: "Angular/Templates/ReleaseView.html",
            controller: "ReleaseViewController"
        })
        .when("/Releases/edit/:id", {
            templateUrl: "Angular/Templates/ReleaseEdit.html",
            controller: "ReleaseEditController"
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
            infoMsgService.changeLocation();
        });
    }
]);