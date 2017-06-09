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
var account_service_1 = require("../account/account.service");
var school_service_1 = require("../school/school.service");
var UserProfileComponent = (function () {
    function UserProfileComponent(accountService, schoolService) {
        this.accountService = accountService;
        this.schoolService = schoolService;
        this.schools = new Array();
    }
    UserProfileComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.accountService.user().subscribe(function (response) {
            _this.profile = response.data;
        }, function (error) {
            debugger;
        });
        this.schoolService.getSchools().subscribe(function (res) { return _this.schools = res.data; });
    };
    UserProfileComponent.prototype.onSubmit = function (form) {
        var _this = this;
        this.accountService.updateProfile(this.profile).subscribe(function (response) {
            _this.message = response.message;
        }, function (error) {
            debugger;
        });
    };
    return UserProfileComponent;
}());
UserProfileComponent = __decorate([
    core_1.Component({
        selector: "user-profile-container",
        templateUrl: "./profile.view.html?v=" + Date()
    }),
    __metadata("design:paramtypes", [account_service_1.AccountService, school_service_1.SchoolService])
], UserProfileComponent);
exports.UserProfileComponent = UserProfileComponent;
