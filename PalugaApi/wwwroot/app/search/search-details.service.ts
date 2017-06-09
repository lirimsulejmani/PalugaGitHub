import { Injectable } from '@angular/core';
import { ApiService } from '../base/api.service';

@Injectable()
export class BookDetailsService {

    constructor(private api: ApiService) { }

    getBook(bookId: string) {
        return this.api.get('/Books/SearchOnGoodreadsById/' + bookId );
    }


    comparePrices(isbn: string) {
        return this.api.get('/Books/CompareBookPrices/' + isbn);
    }
}

