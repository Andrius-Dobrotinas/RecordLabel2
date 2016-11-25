"use strict";

angular.module("RecordLabel", ["ngRoute", "ngResource"])
    .config(function ($routeProvider) {
        $routeProvider.when("/Release", {
            templateUrl: "Angular/Templates/ReleaseList.html",
            controller: "ReleaseListController"
        })
        .when("/Release/:id", {
            templateUrl: "Angular/Templates/ReleaseView.html",
            controller: "ReleaseViewController"
        })
        .when("/Release/edit/:id", {
            templateUrl: "Angular/Templates/ReleaseEdit.html",
            controller: "ReleaseEditController"
        })
        .otherwise({
            redirectTo: "/Release"
        })
    })
    .run(["$rootScope", "metadataService", function ($rootScope, metadataService) {
        $rootScope.errors = [];

        // Populate global metadata list because we'll need it a lot
        $rootScope.metadataList = metadataService.query();
    }
]);