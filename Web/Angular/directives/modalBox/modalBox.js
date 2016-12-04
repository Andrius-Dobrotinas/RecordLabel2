"use strict";

var application = angular.module("RecordLabel");

application.directive("modalBox", function () {
    return {
        restrict: "A",
        replace: true,
        transclude: {
            body: "modalBoxBody",
            buttons: "?modalBoxButtons"
        },
        templateUrl: "Angular/directives/modalBox/modalBox.html",
        scope: {
            id: "@modalId",
            title: "@modalTitle",
            closeButtonTitle: "@modalCloseBtnTitle",
            closeButtonDisabled: "&modalCloseBtnDisabled",
            xButton: "&modalNoTopCloseBtn"
        }
    }
});