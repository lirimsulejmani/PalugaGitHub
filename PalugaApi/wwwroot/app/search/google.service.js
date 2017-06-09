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
var Observable_1 = require("rxjs/Observable");
require("rxjs/Rx");
require("rxjs/add/observable/throw");
var GoogleService = (function () {
    function GoogleService(http) {
        this.http = http;
        this.apiKey = '&key=AIzaSyDq3sRa9bLq4vUNPCtNbz_FtDdmyc2fxAc';
        this.country = '&country=US';
        this.apiUrl = "https://www.googleapis.com/books/v1/volumes";
        this.itemsPerPage = 24;
        this.itemsIndex = 0;
        this.startIndex = "&startIndex=";
        this.maxResults = "&maxResults=" + this.itemsPerPage;
    }
    GoogleService.prototype.getJson = function (resp) {
        return resp.json();
    };
    GoogleService.prototype.checkForError = function (resp) {
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
    GoogleService.prototype.search = function (query, page) {
        this.itemsIndex = this.getItemsIndex(page);
        return this.http.get(this.apiUrl + "?q=" + query + this.apiKey + this.country + this.maxResults + this.startIndex + this.itemsIndex)
            .map(this.checkForError)
            .catch(function (err) { return Observable_1.Observable.throw(err); })
            .map(this.getJson);
    };
    GoogleService.prototype.getById = function (volumeId) {
        return this.http.get(this.apiUrl + "/" + volumeId + "?" + this.apiKey + this.country)
            .map(this.checkForError)
            .catch(function (err) { return Observable_1.Observable.throw(err); })
            .map(this.getJson);
    };
    GoogleService.prototype.getByIsbn = function (isbn) {
        return this.search("isbn:" + isbn, 1);
        /*return this.http.get(`${this.apiUrl}?q=isbn:${isbn}?${this.apiKey}${this.country}`)
            .map(this.checkForError)
            .catch(err => Observable.throw(err))
            .map(this.getJson);*/
    };
    GoogleService.prototype.getItemsIndex = function (page) {
        return (page - 1) * this.itemsPerPage;
    };
    return GoogleService;
}());
GoogleService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], GoogleService);
exports.GoogleService = GoogleService;
