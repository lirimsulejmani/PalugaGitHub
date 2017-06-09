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
var router_1 = require("@angular/router");
var account_service_1 = require("./account.service");
var LoginComponent = (function () {
    function LoginComponent(accountService, router) {
        this.accountService = accountService;
        this.router = router;
    }
    LoginComponent.prototype.ngOnInit = function () {
    };
    LoginComponent.prototype.login = function (form) {
        var _this = this;
        this.accountService.login(this.Email, this.Password)
            .subscribe(function (res) {
            //this.Student = res.data;
            localStorage.setItem("jwt", JSON.stringify(res));
            _this.getAuthUser();
            _this.router.navigate(['']);
        }, function (error) {
            console.log(error);
            _this.ErrorMessage = JSON.parse(error._body).error;
        });
    };
    LoginComponent.prototype.getAuthUser = function () {
        this.accountService.user().subscribe(function (res) {
            debugger;
            localStorage.setItem("user", JSON.stringify(res.data));
        }, function (error) {
            debugger;
        });
    };
    return LoginComponent;
}());
LoginComponent = __decorate([
    core_1.Component({
        selector: 'login-container',
        templateUrl: './login.view.html'
    }),
    __metadata("design:paramtypes", [account_service_1.AccountService, router_1.Router])
], LoginComponent);
exports.LoginComponent = LoginComponent;