import { Injectable } from '@angular/core';
import { Headers, Http, Response, URLSearchParams } from '@angular/http';
import { ApiService } from '../base/api.service';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import 'rxjs/add/observable/throw';

@Injectable()
export class AuthService {
    headers: Headers = new Headers({
        'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8',
        Accept: 'application/json'
    });

    constructor(private http: Http, private apiService: ApiService) { }

    auth(email: string, password: string) {
        let data = new URLSearchParams();
        data.append('username', email);
        data.append('password', password);

        return this.http.post(`${this.apiService.apiUrl}/token`, data, { headers: this.headers })
            .map(this.checkForError)
            .catch(err => Observable.throw(err))
            .map(this.getJson);
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
}