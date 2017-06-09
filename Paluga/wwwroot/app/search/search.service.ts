import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';
import { Jsonp, URLSearchParams } from '@angular/http'; 
import 'rxjs/add/operator/toPromise';

import { Book } from './book';

@Injectable()
export class BookService {

    private headers = new Headers({ 'Content-Type': 'application/json' });
    private booksUrl = 'api/Books/Get';  // URL to web api

    constructor(private http: Http) { }

    getBooks(): Promise<Book[]> {
        return this.http.get(this.booksUrl)
            .toPromise()
            .then(response => response.json().data as Book[])
            .catch(this.handleError);
    }


    getBook(id: number): Promise<Book> {
        const url = `${this.booksUrl}/${id}`;
        return this.http.get(url)
            .toPromise()
            .then(response => response.json().data as Book)
            .catch(this.handleError);
    }

    delete(id: string): Promise<void> {
        const url = `${this.booksUrl}/${id}`;
        return this.http.delete(url, { headers: this.headers })
            .toPromise()
            .then(() => null)
            .catch(this.handleError);
    }

    create(name: string): Promise<Book> {
        return this.http
            .post(this.booksUrl, JSON.stringify({ name: name }), { headers: this.headers })
            .toPromise()
            .then(res => res.json().data as Book)
            .catch(this.handleError);
    }

    update(Book: Book): Promise<Book> {
        const url = `${this.booksUrl}/${Book.isbn}`;
        return this.http
            .put(url, JSON.stringify(Book), { headers: this.headers })
            .toPromise()
            .then(() => Book)
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}

