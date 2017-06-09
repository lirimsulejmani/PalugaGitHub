import { Injectable } from '@angular/core';
import { ApiService } from '../base/api.service';

@Injectable()
export class AccountService {
    constructor(private api: ApiService) { }

    signUp(email: any) {
        return this.api.post("/signup", email);
    }
}