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
    function BooksComponent(bookService, router) {
        this.bookService = bookService;
        this.router = router;
    }
    BooksComponent.prototype.getBooks = function () {
        var _this = this;
        this.bookService
            .getBooks()
            .then(function (books) { return _this.books = books; });
    };
    BooksComponent.prototype.add = function (name) {
        var _this = this;
        name = name.trim();
        if (!name) {
            return;
        }
        this.bookService.create(name)
            .then(function (book) {
            _this.books.push(book);
            _this.selectedBook = null;
        });
    };
    BooksComponent.prototype.delete = function (book) {
        var _this = this;
        this.bookService
            .delete(book.isbn)
            .then(function () {
            _this.books = _this.books.filter(function (h) { return h !== book; });
            if (_this.selectedBook === book) {
                _this.selectedBook = null;
            }
        });
    };
    BooksComponent.prototype.ngOnInit = function () {
        this.getBooks();
    };
    BooksComponent.prototype.onSelect = function (book) {
        this.selectedBook = book;
    };
    BooksComponent.prototype.gotoDetail = function () {
        this.router.navigate(['/detail', this.selectedBook.isbn]);
    };
    return BooksComponent;
}());
BooksComponent = __decorate([
    core_1.Component({
        selector: 'search-container',
        templateUrl: './search.component.html'
    }),
    __metadata("design:paramtypes", [search_service_1.BookService, typeof (_a = typeof router_1.Router !== "undefined" && router_1.Router) === "function" && _a || Object])
], BooksComponent);
exports.BooksComponent = BooksComponent;
var _a;
//# sourceMappingURL=search.component.js.map