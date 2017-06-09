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
var register_model_1 = require("./register.model");
var VerifySignUpComponent = (function () {
    function VerifySignUpComponent(accountService, router, route) {
        this.accountService = accountService;
        this.router = router;
        this.route = route;
        this.Register = new register_model_1.Register();
    }
    VerifySignUpComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.subscribe(function (params) {
            _this.token = params['token'];
            _this.accountService.verify(_this.token).subscribe(function (res) {
                _this.Student = res.data;
                _this.Register.Email = _this.Student.Email;
                _this.Register.Token = _this.Student.ApiToken;
            }, function (error) {
                _this.router.navigate(['/login']);
            });
        });
    };
    VerifySignUpComponent.prototype.onSubmit = function (form) {
        var _this = this;
        this.accountService.register(this.Register).subscribe(function (res) {
            debugger;
            _this.router.navigate(['/login']);
        }, function (err) {
            debugger;
            _this.ErrorMessage = JSON.parse(err._body).error;
        });
    };
    return VerifySignUpComponent;
}());
VerifySignUpComponent = __decorate([
    core_1.Component({
        selector: 'verify-signup-container',
        templateUrl: './verify-signup.view.html?v=' + Date()
    }),
    __metadata("design:paramtypes", [account_service_1.AccountService, router_1.Router, router_1.ActivatedRoute])
], VerifySignUpComponent);
exports.VerifySignUpComponent = VerifySignUpComponent;