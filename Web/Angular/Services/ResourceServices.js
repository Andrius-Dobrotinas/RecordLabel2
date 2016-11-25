"use strict";

var application = angular.module("RecordLabel");

application.factory("metadataService", ["$resource", function ($resource) {
    return $resource("/api/Metadata/Get");
}]);

application.factory("releasesService", ["$resource", function ($resource) {
    return $resource("/api/Release/:act/:id", { id: "@id" }, {
        get: { method: "GET", params: { act: "Get" } },
        getForEdit: { method: "GET", params: { act: "GetForEdit" } },
        save: { method: "POST", params: { act: "Post" } }
    });
}]);

application.factory("constantsService", ["$resource", function ($resource) {
    return $resource("api/Constants/:act", { id: "@id" }, {
        get: { method: "GET", params: { act: "Get" }, cache: true },
    });
}]);

application.factory("artistsService", ["$resource", function ($resource) {
    return $resource("api/Artists/:act", { id: "@id" }, {
        // Returns a list of artists with essential data only
        getList: { method: "GET", params: { act: "GetList" }, isArray: true }
    });
}]);

application.factory("mediaTypesService", ["$resource", function ($resource) {
    return $resource("api/MediaTypes/:act");
}]);