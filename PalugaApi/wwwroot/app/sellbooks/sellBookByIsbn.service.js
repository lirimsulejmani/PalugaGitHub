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
var google_service_1 = require(".././search/google.service");
var SellBookByIsbnService = (function () {
    function SellBookByIsbnService(api, googleService) {
        this.api = api;
        this.googleService = googleService;
    }
    SellBookByIsbnService.prototype.getBookByIsbn = function (isbn) {
        var q = "isbn:".concat(isbn);
        return this.googleService.search(q, 1);
        //  return this.api.get('/Books/SearchOnGoodreadsByIsbn/' + isbn);
    };
    SellBookByIsbnService.prototype.getGoodreadBookByIsbn = function (isbn) {
        return this.api.get('/Books/SearchOnGoodreadsByIsbn/' + isbn);
    };
    SellBookByIsbnService.prototype.sellBook = function (sellingBook) {
        return this.api.post("/sellingBook", sellingBook);
    };
    SellBookByIsbnService.prototype.Upload = function (file) {
        return this.api.post("/sellingBook/upload", file);
    };
    return SellBookByIsbnService;
}());
SellBookByIsbnService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [api_service_1.ApiService, google_service_1.GoogleService])
], SellBookByIsbnService);
exports.SellBookByIsbnService = SellBookByIsbnService;
