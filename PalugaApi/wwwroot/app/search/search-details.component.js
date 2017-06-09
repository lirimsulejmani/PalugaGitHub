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
var book_model_1 = require("./book.model");
var search_service_1 = require("./search.service");
var search_details_service_1 = require("./search-details.service");
var wishlist_service_1 = require("../wishlist/wishlist.service");
var add_wishlist_model_1 = require("../wishlist/add-wishlist.model");
var BookDetailsComponent = (function () {
    function BookDetailsComponent(bookService, wishtlistService, bookDetailsService, router, route) {
        this.bookService = bookService;
        this.wishtlistService = wishtlistService;
        this.bookDetailsService = bookDetailsService;
        this.router = router;
        this.route = route;
        this.isInWishlist = false;
        this.book = new book_model_1.Book();
    }
    BookDetailsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.subscribe(function (params) {
            _this.bookId = params["bookId"];
            if (_this.IsISBN(_this.bookId, _this.bookId.length)) {
                _this.getBookByIsbn(_this.bookId);
            }
            else {
                _this.bookService.getById(_this.bookId)
                    .subscribe(function (response) {
                    _this.book = response;
                    var isbn13 = _this.book.volumeInfo.industryIdentifiers.find(function (obj) { return obj.type === "ISBN_13"; });
                    _this.checkIfIsWishlist(isbn13.identifier);
                }, function (error) {
                    debugger;
                });
            }
        });
    };
    BookDetailsComponent.prototype.checkIfIsWishlist = function (isbn) {
        var _this = this;
        this.wishtlistService.checkBookByIsbn(isbn).subscribe(function (response) {
            _this.isInWishlist = response.data;
        }, function (error) {
        });
    };
    BookDetailsComponent.prototype.addToWishlist = function () {
        var _this = this;
        var wishlist = new add_wishlist_model_1.AddWishlist();
        var isbn10 = this.book.volumeInfo.industryIdentifiers.find(function (obj) { return obj.type === "ISBN_10"; });
        var isbn13 = this.book.volumeInfo.industryIdentifiers.find(function (obj) { return obj.type === "ISBN_13"; });
        wishlist.BookISBN10 = isbn10.identifier;
        wishlist.BookISBN13 = isbn13.identifier;
        this.wishtlistService.addToList(wishlist).subscribe(function (response) {
            _this.message = response.message;
            _this.isInWishlist = true;
        }, function (error) {
            debugger;
        });
    };
    BookDetailsComponent.prototype.comparePrices = function () {
        var _this = this;
        this.bookDetailsService.comparePrices(this.Isbn13)
            .subscribe(function (response) {
            _this.bookComparePrices = response.data ? response.data : Array();
        }, function (error) {
            debugger;
        });
    };
    BookDetailsComponent.prototype.getBookByIsbn = function (isbn) {
        var _this = this;
        this.bookService.getBookByIsbn(isbn)
            .subscribe(function (response) {
            if (response.totalItems) {
                // There'll be only 1 book per ISBN
                _this.book = response.items[0];
                _this.Isbn10 = _this.book.volumeInfo.industryIdentifiers[0].identifier;
                _this.Isbn13 = _this.book.volumeInfo.industryIdentifiers[1].identifier;
                _this.checkIfIsWishlist(_this.Isbn13);
            }
            else {
                _this.bookService.getGoodreadBookByIsbn(isbn).subscribe(function (res) {
                    _this.book = res.data;
                    _this.Isbn10 = _this.book.Isbn;
                    _this.Isbn13 = _this.book.Isbn13;
                    _this.checkIfIsWishlist(_this.Isbn13);
                }, function (error) {
                    debugger;
                });
            }
        }, function (error) {
            debugger;
        });
    };
    BookDetailsComponent.prototype.IsISBN = function (isbn, type) {
        if (isbn.length == 0) {
            return false;
        }
        var type10 = 10, type13 = 13;
        if (type != type10 && type != type13) {
            return false;
        }
        var length = isbn.length - 1;
        var nine = 57, zero = 48;
        var char, counter = 0, sum = 0;
        switch (type) {
            case type10:
                {
                    char = isbn[length].charCodeAt(0);
                    if (char == 88 || char == 120) {
                        length--;
                        sum = 10;
                    }
                    counter = 10;
                    for (var i = 0; i <= length; i++) {
                        char = isbn[i].charCodeAt(0);
                        if (char < zero || char > nine) {
                            continue;
                        }
                        sum += (char - zero) * counter;
                        counter -= 1;
                    }
                    return sum % 11 == 0;
                }
            case type13:
                {
                    var one = 1, three = 3;
                    counter = one;
                    for (var i = 0; i <= length; i++) {
                        char = isbn[i].charCodeAt(0);
                        if (char < zero || char > nine) {
                            continue;
                        }
                        sum += (char - zero) * counter;
                        counter = (counter == one) ? three : one;
                    }
                    return sum % 10 == 0;
                }
        }
        return false;
    };
    return BookDetailsComponent;
}());
BookDetailsComponent = __decorate([
    core_1.Component({
        selector: "search-container",
        templateUrl: "./search-details.view.html?v=" + Date()
    }),
    __metadata("design:paramtypes", [search_service_1.BookService, wishlist_service_1.WishlistService, search_details_service_1.BookDetailsService, router_1.Router, router_1.ActivatedRoute])
], BookDetailsComponent);
exports.BookDetailsComponent = BookDetailsComponent;
