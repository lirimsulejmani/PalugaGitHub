import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Book } from "./book.model";
import { BookService } from "./search.service";

@Component({
    selector: "search-container",
    templateUrl: `./search.view.html?v=${Date()}`
})
export class BooksComponent implements OnInit {
    books: Array<Book>;
    book: Book;
    totalItems: number;
    page = 1;
    query: string;
    bookId: string;
    showLoadMoreButton: Boolean = false;

    constructor(private bookService: BookService, private router: Router, private route: ActivatedRoute) { }  

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.query = params["query"];
            var isbn = this.query.replace('-', '').replace(' ', '').toString();
            if (this.IsISBN(this.query, isbn.length)) {
                this.router.navigate(['/search-details', isbn]);
            }
            else {
                this.bookService.getBooks(this.query, this.page)
                    .subscribe(response => {
                        this.books = response.items ? response.items : Array<Book>();
                        this.totalItems = response.totalItems;
                        this.toggleLoadMoreButton();
                    }, error => {
                        debugger;
                    });
            }
        });    
    }

    loadMore() {
        this.page++;
        this.bookService.getBooks(this.query, this.page)
            .subscribe(response => {
                this.books = this.books.concat(response.items);
                this.toggleLoadMoreButton();
            }, error => {
                debugger;
            });
    }

    toggleLoadMoreButton() {
        if (this.totalItems > this.books.length)
            this.showLoadMoreButton = true;
        else
            this.showLoadMoreButton = false;
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
