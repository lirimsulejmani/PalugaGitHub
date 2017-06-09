import { Injectable } from '@angular/core';
import { UpdateProfile } from "../user/update-profile.model";
import { ApiService } from '../base/api.service';
import { AuthService } from '../auth.guard/auth.service';

@Injectable()
export class AccountService {
    constructor(private api: ApiService, private authService: AuthService) { }

    login(email: string, password: string) {
        return this.authService.auth(email, password);
    }

    signUp(student: any) {
        return this.api.post("/signup", student);
    }

    verify(token: string) {
        return this.api.get("/signup/verify/" + token);
    }

    register(register: any) {
        return this.api.post("/signup/register", register);
    }

    user() {
        return this.api.get("/auth/user");
    }

    updateProfile(profile: UpdateProfile) {
        return this.api.put("/student/update-profile", profile.Id, profile);
    }
}