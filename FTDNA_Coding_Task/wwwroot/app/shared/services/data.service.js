"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
var Rx_1 = require("rxjs/Rx");
var DataService = (function () {
    function DataService(http) {
        this.http = http;
        // this should come from the api/home controller getmethod 
        // that bootstrap step was skipped in this task in the interest of time 
        // but would be usefull in a public api to facilitate api versioning 
        // and reduce resource / identifier coupling.
        this.samples = 'api/samples?{id}{barcode}{createdAt}{createdBy}{statusId}';
        this.sample = 'api/samples';
        this.users = 'api/users';
        this.statuses = 'api/statuses';
    }
    DataService.prototype.getSamples = function (id, barcode, createdat, createdby, statusid) {
        var query;
        query = this.setOptionalQueryPart(this.samples, "id", id);
        query = this.setOptionalQueryPart(query, "barcode", barcode);
        query = this.setOptionalQueryPart(query, "createdAt", createdat);
        query = this.setOptionalQueryPart(query, "createdBy", createdby);
        query = this.setOptionalQueryPart(query, "statusId", statusid);
        if (query.endsWith("&")) {
            query = query.substring(0, query.length - 1);
        }
        return this.http.get(query)
            .map(function (resp) { return resp.json(); })
            .catch(this.handleError);
    };
    DataService.prototype.postSamples = function (postBody) {
        var query = this.sample;
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var options = new http_1.RequestOptions({ headers: headers });
        return this.http.post(query, postBody, options)
            .map(function (resp) { return resp.json(); })
            .catch(this.handleError);
    };
    DataService.prototype.getUsers = function () {
        return this.http.get(this.users)
            .map(function (resp) { return resp.json(); })
            .catch(this.handleError);
    };
    DataService.prototype.getStatuses = function () {
        return this.http.get(this.statuses)
            .map(function (resp) { return resp.json(); })
            .catch(this.handleError);
    };
    DataService.prototype.setOptionalQueryPart = function (query, name, value) {
        var token = "{" + name + "}";
        if (value) {
            return query.replace(token, name + "=" + value + "&");
        }
        else {
            return query.replace(token, "");
        }
    };
    DataService.prototype.handleError = function (error) {
        console.error(error);
        return Rx_1.Observable.throw(error.json().error || 'Server error');
    };
    return DataService;
}());
DataService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], DataService);
exports.DataService = DataService;
//# sourceMappingURL=data.service.js.map