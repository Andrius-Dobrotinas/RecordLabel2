"use strict";

(function () {

    angular.module("RecordLabel")
        .config(function ($routeProvider) {
            $routeProvider.caseInsensitiveMatch = true;
            $routeProvider.when("/Releases", {
                templateUrl: "Angular/controllers/releases/list.html",
                controller: "ReleaseListCtrl",
                controllerAs: "ctrl"
            })
            .when("/Releases/New", {
                templateUrl: "Angular/controllers/releases/edit.html",
                controller: "ReleaseEditCtrl"
            })
            .when("/Releases/Edit/:id", {
                templateUrl: "Angular/controllers/releases/edit.html",
                controller: "ReleaseEditCtrl"
            })
            .when("/Releases/:id", {
                templateUrl: "Angular/controllers/releases/view.html",
                controller: "ReleaseViewCtrl"
            })
            .otherwise({
                redirectTo: "/Releases"
            })
        });

})();