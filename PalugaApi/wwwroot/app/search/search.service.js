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
var google_service_1 = require("./google.service");
var BookService = (function () {
    function BookService(api, googleService) {
        this.api = api;
        this.googleService = googleService;
    }
    BookService.prototype.getBooks = function (query, page) {
        return this.googleService.search(query, page);
        //return this.api.get('/Books/SearchOnGoodreads/' + query + "/" + page);
    };
    BookService.prototype.getById = function (id) {
        return this.googleService.getById(id);
    };
    BookService.prototype.getBookByIsbn = function (isbn) {
        return this.googleService.getByIsbn(isbn);
    };
    BookService.prototype.getGoodreadBookByIsbn = function (isbn) {
        return this.api.get('/Books/SearchOnGoodreadsByIsbn/' + isbn);
    };
    return BookService;
}());
BookService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [api_service_1.ApiService, google_service_1.GoogleService])
], BookService);
exports.BookService = BookService;
