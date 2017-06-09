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
var search_service_1 = require("./search.service");
var BooksComponent = (function () {
    function BooksComponent(bookService, router, route) {
        this.bookService = bookService;
        this.router = router;
        this.route = route;
        this.page = 1;
        this.showLoadMoreButton = false;
    }
    BooksComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.subscribe(function (params) {
            _this.query = params["query"];
            var isbn = _this.query.replace('-', '').replace(' ', '').toString();
            if (_this.IsISBN(_this.query, isbn.length)) {
                _this.router.navigate(['/search-details', isbn]);
            }
            else {
                _this.bookService.getBooks(_this.query, _this.page)
                    .subscribe(function (response) {
                    _this.books = response.items ? response.items : Array();
                    _this.totalItems = response.totalItems;
                    _this.toggleLoadMoreButton();
                }, function (error) {
                    debugger;
                });
            }
        });
    };
    BooksComponent.prototype.loadMore = function () {
        var _this = this;
        this.page++;
        this.bookService.getBooks(this.query, this.page)
            .subscribe(function (response) {
            _this.books = _this.books.concat(response.items);
            _this.toggleLoadMoreButton();
        }, function (error) {
            debugger;
        });
    };
    BooksComponent.prototype.toggleLoadMoreButton = function () {
        if (this.totalItems > this.books.length)
            this.showLoadMoreButton = true;
        else
            this.showLoadMoreButton = false;
    };
    BooksComponent.prototype.IsISBN = function (isbn, type) {
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
    return BooksComponent;
}());
BooksComponent = __decorate([
    core_1.Component({
        selector: "search-container",
        templateUrl: "./search.view.html?v=" + Date()
    }),
    __metadata("design:paramtypes", [search_service_1.BookService, router_1.Router, router_1.ActivatedRoute])
], BooksComponent);
exports.BooksComponent = BooksComponent;
