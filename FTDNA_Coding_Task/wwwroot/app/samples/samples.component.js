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
var data_service_1 = require("../shared/services/data.service");
//import { ValuesPipe } from '../shared/ValuesPipe';
var SamplesComponent = (function () {
    function SamplesComponent(dataService) {
        this.dataService = dataService;
        this.editViewEnabled = false;
        this.Barcode = "";
        this.CreatedAt = "";
        this.CreatedBy = "";
        this.SampleId = "";
        this.StatusId = "";
        this.samples = [];
        this.users = function () { return []; };
        this.statuses = function () { return []; };
        this.newSample = {
            Barcode: "",
            CreatedBy: "",
            StatusId: ""
        };
    }
    SamplesComponent.prototype.createNewSample = function () {
        return this.newSample = {
            Barcode: "",
            CreatedBy: "",
            StatusId: ""
        };
    };
    SamplesComponent.prototype.seatch = function () {
        var _this = this;
        this.dataService.getSamples(this.SampleId, this.Barcode, this.CreatedAt, this.CreatedBy, this.StatusId)
            .subscribe(function (data) { return _this.samples = data; });
    };
    SamplesComponent.prototype.createSample = function () {
        var _this = this;
        this.dataService.postSamples(this.newSample)
            .subscribe(function () { return _this.createNewSample(); });
        this.newSample.Barcode = "";
        this.newSample.CreatedBy = "";
        this.newSample.StatusId = "";
    };
    SamplesComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.dataService.getUsers()
            .subscribe(function (data) {
            var userstmp = data.reverse().concat({ Id: "", UserName: "All" }).reverse();
            _this.users = function () { return userstmp; };
        });
        this.dataService.getStatuses()
            .subscribe(function (data) {
            var statusestmp = data.concat({ Id: "", Status: "All" }).reverse();
            _this.statuses = function () { return statusestmp; };
        });
    };
    return SamplesComponent;
}());
SamplesComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: 'samples',
        templateUrl: 'samples.component.html'
    }),
    __metadata("design:paramtypes", [data_service_1.DataService])
], SamplesComponent);
exports.SamplesComponent = SamplesComponent;
//# sourceMappingURL=samples.component.js.map