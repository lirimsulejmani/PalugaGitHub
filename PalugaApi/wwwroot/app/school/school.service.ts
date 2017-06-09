import { Injectable } from '@angular/core';
import { ApiService } from '../base/api.service';

@Injectable()
export class SchoolService {
    constructor(private api: ApiService) { }

    getSchools() {
        return this.api.get("/schools");
    }
}