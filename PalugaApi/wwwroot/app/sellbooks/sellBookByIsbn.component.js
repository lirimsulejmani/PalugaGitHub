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
var book_model_1 = require("../search/book.model");
var sellBookByIsbn_service_1 = require("./sellBookByIsbn.service");
var sellingBook_1 = require("./sellingBook");
//for upload method fileChange
var http_1 = require("@angular/http");
var Observable_1 = require("rxjs/Observable");
require("rxjs/Rx");
require("rxjs/add/observable/throw");
var SellBookByIsbnComponent = (function () {
    function SellBookByIsbnComponent(sellBookService, router, route, http) {
        this.sellBookService = sellBookService;
        this.router = router;
        this.route = route;
        this.http = http;
        this.apiEndPoint = "http://localhost:54213/api/sellingbook";
        this.noImageAvailable = "../../images/no_cover_thumb.png";
        this.src = "../../images/no_cover_thumb.png";
        this.resizeOptions = {
            resizeMaxHeight: 340,
            resizeMaxWidth: 240
        };
        this.nophoto = "nophoto";
        this.ISBN10 = "ISBN_10";
        this.BookCondition = sellingBook_1.BookConditionEnum;
        this.BookConditionNames = Object.keys(this.BookCondition).filter(function (v) { return typeof v === "string"; });
        this.BookConditionValues = Object.keys(this.BookCondition).filter(function (e) { return typeof (e) == "number"; });
        this.book = new book_model_1.Book();
        this.sellingBook = new sellingBook_1.SellingBook();
        this.filesToUpload = [];
        //this.book.Authors = new Array<Author>();
    }
    SellBookByIsbnComponent.prototype.keys = function () {
        var keys = Object.keys(this.BookCondition);
        return keys.slice(keys.length / 2);
    };
    SellBookByIsbnComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.subscribe(function (params) {
            _this.isbn = params['isbn'];
            _this.sellBookService.getBookByIsbn(_this.isbn)
                .subscribe(function (response) {
                if (response.totalItems) {
                    // There'll be only 1 book per ISBN
                    _this.book = response.items[0];
                    _this.sellingBook.BookId = _this.book.id;
                    _this.sellingBook.Isbn10 = _this.book.volumeInfo.industryIdentifiers[0].identifier;
                    _this.sellingBook.Isbn13 = _this.book.volumeInfo.industryIdentifiers[1].identifier;
                }
                else {
                    _this.sellBookService.getGoodreadBookByIsbn(_this.isbn).subscribe(function (res) {
                        _this.book = res.data;
                        _this.sellingBook.BookId = _this.book.Id.toString();
                        _this.sellingBook.Isbn10 = _this.book.Isbn;
                        _this.sellingBook.Isbn13 = _this.book.Isbn13;
                    }, function (error) {
                        debugger;
                    });
                }
            }, function (error) {
                debugger;
            });
        });
    };
    SellBookByIsbnComponent.prototype.selected = function (imageResult) {
        debugger;
        this.src = imageResult.resized
            && imageResult.resized.dataURL
            || imageResult.dataURL;
        //  this.filesToUpload = <File>imageResult.file;
        //  this.fileChange(this.filesToUpload);
    };
    SellBookByIsbnComponent.prototype.onSelectionChange = function (entry) {
        this.sellingBook.BookConditionId = entry;
    };
    SellBookByIsbnComponent.prototype.onSubmit = function (form) {
        var _this = this;
        debugger;
        this.sellBookService.sellBook(this.sellingBook)
            .subscribe(function (res) {
            debugger;
            _this.sellingBook = res.data;
            _this.router.navigate(['/bookPublished']);
        }, function (error) {
            debugger;
            console.log(error);
            _this.errorMessage = JSON.parse(error._body).error;
        });
    };
    SellBookByIsbnComponent.prototype.upload = function () {
        this.makeFileRequest(this.apiEndPoint, [], this.filesToUpload).then(function (result) {
            console.log(result);
        }, function (error) {
            console.error(error);
        });
    };
    SellBookByIsbnComponent.prototype.fileChangeEvent = function (fileInput) {
        debugger;
        this.filesToUpload = fileInput.target.files;
    };
    SellBookByIsbnComponent.prototype.fileChange = function (event) {
        debugger;
        var fileList = event.target.files;
        if (fileList.length > 0) {
            var file = fileList[0];
            var formData = new FormData();
            formData.append('uploadFile', file, file.name);
            var headers = new http_1.Headers();
            headers.append('Content-Type', 'multipart/form-data');
            headers.append('Accept', 'application/json');
            var options = new http_1.RequestOptions({ headers: headers });
            debugger;
            this.http.post("" + this.apiEndPoint, formData, options)
                .map(function (res) {
                debugger;
                res.json();
            })
                .catch(function (error) { return Observable_1.Observable.throw(error); })
                .subscribe(function (data) {
                debugger;
                console.log('success');
            }, function (error) {
                debugger;
                console.log(error);
            });
        }
    };
    return SellBookByIsbnComponent;
}());
SellBookByIsbnComponent = __decorate([
    core_1.Component({
        selector: 'sellBookByIsbn-container',
        templateUrl: "./sellBookByIsbn.view.html?v=" + Date()
    }),
    __metadata("design:paramtypes", [sellBookByIsbn_service_1.SellBookByIsbnService, router_1.Router, router_1.ActivatedRoute, http_1.Http])
], SellBookByIsbnComponent);
exports.SellBookByIsbnComponent = SellBookByIsbnComponent;
