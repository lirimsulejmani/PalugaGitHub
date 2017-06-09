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
var api_service_1 = require("../base/api.service");
var Observable_1 = require("rxjs/Observable");
require("rxjs/Rx");
require("rxjs/add/observable/throw");
var AuthService = (function () {
    function AuthService(http, apiService) {
        this.http = http;
        this.apiService = apiService;
        this.headers = new http_1.Headers({
            'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8',
            Accept: 'application/json'
        });
    }
    AuthService.prototype.auth = function (email, password) {
        var data = new http_1.URLSearchParams();
        data.append('username', email);
        data.append('password', password);
        return this.http.post(this.apiService.apiUrl + "/token", data, { headers: this.headers })
            .map(this.checkForError)
            .catch(function (err) { return Observable_1.Observable.throw(err); })
            .map(this.getJson);
    };
    AuthService.prototype.getJson = function (resp) {
        return resp.json();
    };
    AuthService.prototype.checkForError = function (resp) {
        if (resp.status >= 200 && resp.status < 300) {
            return resp;
        }
        else {
            var error = new Error(resp.statusText);
            error['response'] = resp;
            console.error(error);
            throw error;
        }
    };
    return AuthService;
}());
AuthService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http, api_service_1.ApiService])
], AuthService);
exports.AuthService = AuthService;