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
var wishlist_service_1 = require("./wishlist.service");
var google_service_1 = require("../search/google.service");
var WishlistComponent = (function () {
    function WishlistComponent(wishlistService, googleService) {
        this.wishlistService = wishlistService;
        this.googleService = googleService;
        this.books = new Array();
    }
    WishlistComponent.prototype.ngOnInit = function () {
        this.loadList();
    };
    WishlistComponent.prototype.loadList = function () {
        var _this = this;
        this.wishlistService.getList().subscribe(function (response) {
            _this.wishlist = response.data;
            for (var i = 0; i < _this.wishlist.length; i++) {
                _this.loadBook(_this.wishlist[i]);
            }
        }, function (error) {
            debugger;
        });
    };
    WishlistComponent.prototype.loadBook = function (item) {
        var _this = this;
        this.googleService.getByIsbn(item.BookISBN10).subscribe(function (resp) {
            var book = resp.items[0];
            for (var i = 0; i < _this.wishlist.length; i++) {
                var isbn13 = book.volumeInfo.industryIdentifiers.find(function (obj) { return obj.type === "ISBN_13"; });
                if (_this.wishlist[i].BookISBN13 === isbn13.identifier) {
                    _this.wishlist[i].book = book;
                    _this.books.push(_this.wishlist[i]);
                }
            }
        });
    };
    WishlistComponent.prototype.delete = function (item) {
        var _this = this;
        debugger;
        this.wishlistService.delete(item.Id).subscribe(function (response) {
            debugger;
            var index = _this.books.indexOf(item);
            _this.books.splice(index, 1);
        }, function (error) {
            debugger;
        });
    };
    return WishlistComponent;
}());
WishlistComponent = __decorate([
    core_1.Component({
        selector: "wishlist-container",
        templateUrl: "./wishlist.view.html?v=" + Date()
    }),
    __metadata("design:paramtypes", [wishlist_service_1.WishlistService, google_service_1.GoogleService])
], WishlistComponent);
exports.WishlistComponent = WishlistComponent;
