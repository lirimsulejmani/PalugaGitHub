import { Component, OnInit } from '@angular/core';
import { WishlistService } from './wishlist.service';
import { GoogleService } from "../search/google.service";

@Component({
    selector: "wishlist-container",
    templateUrl: `./wishlist.view.html?v=${Date()}`
})

export class WishlistComponent implements OnInit {

    wishlist: Array<any>;
    books: Array<any>;
    constructor(private wishlistService: WishlistService, private googleService: GoogleService) {
        this.books = new Array<any>();
    }

    ngOnInit(): void {
        this.loadList();
    }

    loadList() {
        this.wishlistService.getList().subscribe(response => {
            this.wishlist = response.data;
            for (let i = 0; i < this.wishlist.length; i++) {
                this.loadBook(this.wishlist[i]);
            }
        }, error => {
            debugger;
        });
    }

    loadBook(item: any) {
        this.googleService.getByIsbn(item.BookISBN10).subscribe(resp => {
            const book = resp.items[0];
            for (let i = 0; i < this.wishlist.length; i++) {
                const isbn13 = book.volumeInfo.industryIdentifiers.find((obj: any) => obj.type === "ISBN_13");
                if (this.wishlist[i].BookISBN13 === isbn13.identifier) {
                    this.wishlist[i].book = book;
                    this.books.push(this.wishlist[i]);
                }
            }
        });
    }

    delete(item: any) {
        debugger;
        this.wishlistService.delete(item.Id).subscribe(response => {
                debugger;
                var index = this.books.indexOf(item);
                this.books.splice(index, 1);
            }, error => {
                debugger;
            });

    }
}