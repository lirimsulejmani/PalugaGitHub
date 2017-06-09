import { Component, OnInit } from '@angular/core'
import { NgForm } from "@angular/forms";
import { Router } from '@angular/router';
import { AccountService } from './account.service';

@Component({
    selector: 'login-container',
    templateUrl: './login.view.html'
})

export class LoginComponent implements OnInit {
    Email: string;
    Password: string;
    ErrorMessage: string;

    constructor(private accountService: AccountService, private router: Router) {
    }

    ngOnInit() {
    }

    login(form: NgForm) {
        this.accountService.login(this.Email, this.Password)
            .subscribe(res => {
                //this.Student = res.data;
                localStorage.setItem("jwt", JSON.stringify(res));
                this.getAuthUser();
                this.router.navigate(['']);
            }, error => {
                console.log(error);
                this.ErrorMessage = JSON.parse(error._body).error;
            });
    }

    getAuthUser() {
        this.accountService.user().subscribe(res => {
            debugger;
            localStorage.setItem("user", JSON.stringify(res.data));
        }, error => {
            debugger;
        })
    }
}