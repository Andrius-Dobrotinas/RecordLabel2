"use strict";

var application = angular.module("RecordLabel");

application.directive("loaderButton", function () {
    return {
        restrict: "A",
        replace: true,
        templateUrl: "Angular/directives/loaderButton/loaderButton.html",
        scope: {
            text: "@lbtnText",
            busy: "&lbtnIsBusy",
            action: "&lbtnClick"
        }
    }
});