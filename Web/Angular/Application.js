"use strict";

angular.module("RecordLabel", ["ngRoute", "ngResource"])
    .config(function ($routeProvider) {
        $routeProvider.when("/Releases", {
            templateUrl: "Angular/templates/ReleaseList.html",
            controller: "ReleaseListCtrl",
            controllerAs: "ctrl"
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

        $rootScope.settings = {
            ItemsPerPage: 10  // Default setting
        };

        // Synchronous call to get settings. Settings must be retrieved before any other requests are be made
        // because they contain ItemsPerPage param.
        $.ajax({
            url: "api/Settings/Get",
            async: false
        }).done(function (data) {
            $rootScope.settings.ItemsPerPage = data.ItemsPerPage;
        });

        $rootScope.$on('$locationChangeStart', function (event) {
            $rootScope.errors.length = 0;
            infoMsgService.changeLocation();
        });

        $rootScope.isAdminMode = true;
    }
]);