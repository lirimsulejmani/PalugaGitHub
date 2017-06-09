import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Jsonp } from '@angular/http';
import { Book } from './book';
import { BookService } from './search.service';

@Component({
    selector: 'search-container',
    templateUrl: './search.component.html'
})
export class BooksComponent implements OnInit {
    books: Book[];
    selectedBook: Book;

    constructor(
        private bookService: BookService,
        private router: Router) { }

    getBooks(): void {
        this.bookService
            .getBooks()
            .then(books => this.books = books);
    }

    add(name: string): void {
        name = name.trim();
        if (!name) { return; }
        this.bookService.create(name)
            .then(book => {
                this.books.push(book);
                this.selectedBook = null;
            });
    }

    delete(book: Book): void {
        this.bookService
            .delete(book.isbn)
            .then(() => {
                this.books = this.books.filter(h => h !== book);
                if (this.selectedBook === book) { this.selectedBook = null; }
            });
    }

    ngOnInit(): void {
        this.getBooks();
    }

    onSelect(book: Book): void {
        this.selectedBook = book;
    }

    gotoDetail(): void {
        this.router.navigate(['/detail', this.selectedBook.isbn]);
    }
}
