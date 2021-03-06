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
var api_service_1 = require("../base/api.service");
var auth_service_1 = require("../auth.guard/auth.service");
var AccountService = (function () {
    function AccountService(api, authService) {
        this.api = api;
        this.authService = authService;
    }
    AccountService.prototype.login = function (email, password) {
        return this.authService.auth(email, password);
    };
    AccountService.prototype.signUp = function (student) {
        return this.api.post("/signup", student);
    };
    AccountService.prototype.verify = function (token) {
        return this.api.get("/signup/verify/" + token);
    };
    AccountService.prototype.register = function (register) {
        return this.api.post("/signup/register", register);
    };
    AccountService.prototype.user = function () {
        return this.api.get("/auth/user");
    };
    AccountService.prototype.updateProfile = function (profile) {
        return this.api.put("/student/update-profile", profile.Id, profile);
    };
    return AccountService;
}());
AccountService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [api_service_1.ApiService, auth_service_1.AuthService])
], AccountService);
exports.AccountService = AccountService;