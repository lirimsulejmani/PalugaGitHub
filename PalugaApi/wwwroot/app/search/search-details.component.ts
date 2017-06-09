
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Book, Author } from './book.model';
import { BookService } from './search.service';
import { BookDetailsService } from './search-details.service';
import { WishlistService } from '../wishlist/wishlist.service';
import { AddWishlist } from '../wishlist/add-wishlist.model';
import { BookComparePrice } from './compare-price.model';

@Component({
    selector: "search-container",
    templateUrl: `./search-details.view.html?v=${Date()}`
})
export class BookDetailsComponent implements OnInit {
    book: Book;
    message: string;
    bookId: string;
    isInWishlist: Boolean = false;
    Isbn10: string;
    Isbn13: string;
    bookComparePrices: Array<BookComparePrice>;

    constructor(private bookService: BookService, private wishtlistService: WishlistService, private bookDetailsService: BookDetailsService , private router: Router, private route: ActivatedRoute) {
        this.book = new Book();
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.bookId = params["bookId"];
            if (this.IsISBN(this.bookId, this.bookId.length)) {
                this.getBookByIsbn(this.bookId);
            }
            else {
                this.bookService.getById(this.bookId)
                    .subscribe(response => {
                        this.book = response;
                        const isbn13 = this.book.volumeInfo.industryIdentifiers.find((obj: any) => obj.type === "ISBN_13");
                        this.checkIfIsWishlist(isbn13.identifier);
                    }, error => {
                        debugger;
                    });
            }
        });
    }

    checkIfIsWishlist(isbn: string) {
        this.wishtlistService.checkBookByIsbn(isbn).subscribe(response => {
                this.isInWishlist = response.data;
            },
            error => {

            });
    }

    addToWishlist() {
        var wishlist = new AddWishlist();
        const isbn10 = this.book.volumeInfo.industryIdentifiers.find((obj: any) => obj.type === "ISBN_10");
        const isbn13 = this.book.volumeInfo.industryIdentifiers.find((obj: any) => obj.type === "ISBN_13");
        wishlist.BookISBN10 = isbn10.identifier;
        wishlist.BookISBN13 = isbn13.identifier;

        this.wishtlistService.addToList(wishlist).subscribe(response => {
            this.message = response.message;
            this.isInWishlist = true;
        }, error => {
            debugger;
        });
    }


    comparePrices() {
        this.bookDetailsService.comparePrices(this.Isbn13)
            .subscribe(response => {
                this.bookComparePrices = response.data ? response.data : Array<BookComparePrice>();
            }, error => {
                debugger;
            });
    }

    getBookByIsbn(isbn: string) {
        this.bookService.getBookByIsbn(isbn)
            .subscribe(response => {
                if (response.totalItems) {
                    // There'll be only 1 book per ISBN
                    this.book = response.items[0];
                    this.Isbn10 = this.book.volumeInfo.industryIdentifiers[0].identifier;
                    this.Isbn13 = this.book.volumeInfo.industryIdentifiers[1].identifier;
                    this.checkIfIsWishlist(this.Isbn13);
                }
                else {
                    this.bookService.getGoodreadBookByIsbn(isbn).subscribe(res => {
                        this.book = res.data;
                        this.Isbn10 = this.book.Isbn;
                        this.Isbn13 = this.book.Isbn13;
                        this.checkIfIsWishlist(this.Isbn13);
                    }, error => {
                        debugger;
                    });
                }

            }, error => {
                debugger;
            });
    }

    IsISBN(isbn: string, type: number): boolean {
    if (isbn.length == 0) {
        return false;
    }

    var type10: number = 10, type13: number = 13;
    if (type != type10 && type != type13) {
        return false;
    }

    var length = isbn.length - 1;

    var nine: number = 57, zero: number = 48;
    var char: number, counter: number = 0, sum: number = 0;
    switch (type) {
        case type10:
            {
                char = isbn[length].charCodeAt(0)
                if (char == 88 || char == 120) {
                    length--;
                    sum = 10;
                }
                counter = 10;
                for (var i: number = 0; i <= length; i++) {
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
                var one: number = 1, three: number = 3;
                counter = one;
                for (var i: number = 0; i <= length; i++) {
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
}

}
