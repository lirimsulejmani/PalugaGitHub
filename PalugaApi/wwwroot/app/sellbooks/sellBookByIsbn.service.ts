import { Injectable } from '@angular/core';
import { ApiService } from '../base/api.service';
import { GoogleService } from '.././search/google.service';

@Injectable()
export class SellBookByIsbnService {

    constructor(private api: ApiService, private googleService: GoogleService) { }

    getBookByIsbn(isbn: string) {
        var q = "isbn:".concat(isbn);
        return this.googleService.search(q, 1);
      //  return this.api.get('/Books/SearchOnGoodreadsByIsbn/' + isbn);
    }

    getGoodreadBookByIsbn(isbn: string) {
          return this.api.get('/Books/SearchOnGoodreadsByIsbn/' + isbn);
    }

    sellBook(sellingBook: any) {
        return this.api.post("/sellingBook", sellingBook);
    }

    Upload(file: any) {
        return this.api.post("/sellingBook/upload", file);
    }

}

