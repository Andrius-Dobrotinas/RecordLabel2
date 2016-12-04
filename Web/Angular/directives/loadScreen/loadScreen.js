"use strict";

var application = angular.module("RecordLabel");

application.directive("loadScreen", function () {
    return {
        restrict: "A",
        replace: true,
        transclude: true,
        templateUrl: "Angular/directives/loadScreen/loadScreen.html",
        scope: {
            show: "&lsShow",
            class: "@lsClass"
        }
    }
});