"use strict";

var application = angular.module("RecordLabel");

application.directive("modalBox", function ($compile) {
    return {
        restrict: "A",
        replace: true,
        transclude: {
            body: "modalBoxBody",
            buttons: "?modalBoxButtons"
        },
        templateUrl: "Angular/Directives/Templates/ModalBox.html",
        scope: {
            id: "@modalId",
            title: "@modalTitle",
            closeButtonTitle: "@modalCloseButtonTitle",
            closeButtonDisabled: "&modalCloseButtonDisabled",
            xButton: "&modalNoTopCloseButton"
        }
    }
});