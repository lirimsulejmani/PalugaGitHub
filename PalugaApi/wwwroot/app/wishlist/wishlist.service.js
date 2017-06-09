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
var WishlistService = (function () {
    function WishlistService(apiService) {
        this.apiService = apiService;
    }
    WishlistService.prototype.getList = function () {
        return this.apiService.get("/wishlist");
    };
    WishlistService.prototype.addToList = function (wishlist) {
        return this.apiService.post("/wishlist/add", wishlist);
    };
    WishlistService.prototype.checkBookByIsbn = function (isbn) {
        return this.apiService.get("/wishlist/checkbook/" + isbn);
    };
    WishlistService.prototype.delete = function (wishlistId) {
        return this.apiService.delete("/wishlist/" + wishlistId);
    };
    return WishlistService;
}());
WishlistService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [api_service_1.ApiService])
], WishlistService);
exports.WishlistService = WishlistService;
