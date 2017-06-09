"use strict";
var SellingBook = (function () {
    function SellingBook() {
    }
    return SellingBook;
}());
exports.SellingBook = SellingBook;
var BookConditionEnum;
(function (BookConditionEnum) {
    BookConditionEnum[BookConditionEnum["New"] = 0] = "New";
    BookConditionEnum[BookConditionEnum["BarelyUsed"] = 1] = "BarelyUsed";
    BookConditionEnum[BookConditionEnum["Used"] = 2] = "Used";
    BookConditionEnum[BookConditionEnum["HeavilyUsed"] = 3] = "HeavilyUsed";
})(BookConditionEnum = exports.BookConditionEnum || (exports.BookConditionEnum = {}));
