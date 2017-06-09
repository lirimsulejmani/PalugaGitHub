import { Injectable } from '@angular/core';
import { ApiService } from '../base/api.service';
import { GoogleService } from './google.service';

@Injectable()
export class BookService {

    constructor(private api: ApiService, private googleService: GoogleService) { }

    getBooks(query: string, page: number) {
        return this.googleService.search(query, page);

        //return this.api.get('/Books/SearchOnGoodreads/' + query + "/" + page);
    }

    getById(id: string) {
        return this.googleService.getById(id);
    }

    getBookByIsbn(isbn: string) {
        return this.googleService.getByIsbn(isbn);
    }

    getGoodreadBookByIsbn(isbn: string) {
        return this.api.get('/Books/SearchOnGoodreadsByIsbn/' + isbn);
    }
}

