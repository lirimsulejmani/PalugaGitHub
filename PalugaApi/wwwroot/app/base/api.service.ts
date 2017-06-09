import { Injectable } from '@angular/core';
import { Headers, Http, Response, URLSearchParams, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import 'rxjs/add/observable/throw';

@Injectable()
export class ApiService {
    headers: Headers = new Headers({
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': this.getJWT()
    });

    getHeaders() {
        const headers = new Headers
            ({
                'Content-Type': "application/json",
                'Accept': 'application/json',
                'Authorization': this.getJWT()
            });
        return new RequestOptions({ headers });
    }

    apiUrl: string = "http://localhost:54213/api";

    constructor(private http: Http) {
    }

    getJWT() {
        if (localStorage.getItem("jwt")) {
            var auth = JSON.parse(localStorage.getItem("jwt"));
            return 'Bearer ' + auth.access_token;
        }
        return "";
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

    get(path: string): Observable<any> {
        return this.http.get(`${this.apiUrl}${path}`, this.getHeaders())
            .map(this.checkForError)
            .catch(err => Observable.throw(err))
            .map(this.getJson);
    }

    post(path: string, body: any): Observable<any> {
        return this.http.post(`${this.apiUrl}${path}`, JSON.stringify(body), this.getHeaders())
            .map(this.checkForError)
            .catch(err => Observable.throw(err))
            .map(this.getJson);
    }

    put(path: string, id: string, body: any): Observable<any> {
        return this.http.put(`${this.apiUrl}${path}/${id}`, JSON.stringify(body), this.getHeaders())
            .map(this.checkForError)
            .catch(err => Observable.throw(err))
            .map(this.getJson);
    }

    delete(path: string): Observable<any> {
        return this.http.delete(`${this.apiUrl}${path}`, this.getHeaders())
            .map(this.checkForError)
            .catch(err => Observable.throw(err))
            .map(this.getJson);
    }
}