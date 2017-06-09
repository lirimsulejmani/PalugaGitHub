import { Injectable } from "@angular/core";
import { Headers, Http, Response, URLSearchParams, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import 'rxjs/add/observable/throw';

@Injectable()
export class GoogleService {

    apiKey: string = '&key=AIzaSyDq3sRa9bLq4vUNPCtNbz_FtDdmyc2fxAc';
    country: string = '&country=US';
    apiUrl: string = "https://www.googleapis.com/books/v1/volumes";
    itemsPerPage: number = 24;
    itemsIndex: number = 0;
    startIndex: string = "&startIndex=";
    maxResults: string = `&maxResults=${this.itemsPerPage}`;

    constructor(private http: Http) {
    }

    private getJson(resp: Response) {
        return resp.json();
    }

    private checkForError(resp: Response): Response {
        if (resp.status >= 200 && resp.status < 300) {
            return resp;
        }
        else {
            const error = new Error(resp.statusText);
            error['response'] = resp;
            console.error(error);
            throw error;
        }
    }

    search(query: string, page: number): Observable<any> {
        this.itemsIndex = this.getItemsIndex(page);
        return this.http.get(`${this.apiUrl}?q=${query}${this.apiKey}${this.country}${this.maxResults}${this.startIndex}${this.itemsIndex}`)
            .map(this.checkForError)
            .catch(err => Observable.throw(err))
            .map(this.getJson);
    }

    getById(volumeId: string): Observable<any> {
        return this.http.get(`${this.apiUrl}/${volumeId}?${this.apiKey}${this.country}`)
            .map(this.checkForError)
            .catch(err => Observable.throw(err))
            .map(this.getJson);
    }

    getByIsbn(isbn: string): Observable<any> {
        return this.search("isbn:" + isbn, 1);

        /*return this.http.get(`${this.apiUrl}?q=isbn:${isbn}?${this.apiKey}${this.country}`)
            .map(this.checkForError)
            .catch(err => Observable.throw(err))
            .map(this.getJson);*/
    }

    getItemsIndex(page: number) {
        return (page - 1) * this.itemsPerPage;
    }
}