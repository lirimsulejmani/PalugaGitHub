import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from "@angular/forms";
import { AccountService } from './account.service';
import { Student } from './student.model';
import { Register } from './register.model';

@Component({
    selector: 'verify-signup-container',
    templateUrl: './verify-signup.view.html?v=' + Date()
})

export class VerifySignUpComponent implements OnInit {
    Student: Student;
    Register: Register;
    ErrorMessage: string;
    private token: string;
    constructor(private accountService: AccountService, private router: Router, private route: ActivatedRoute) {
        this.Register = new Register();
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.token = params['token'];
            this.accountService.verify(this.token).subscribe(res => {
                this.Student = res.data;
                this.Register.Email = this.Student.Email;
                this.Register.Token = this.Student.ApiToken;
            }, error => {
                this.router.navigate(['/login']);
            });
        });
    }

    onSubmit(form: NgForm) {
        this.accountService.register(this.Register).subscribe(res => {
            debugger;
            this.router.navigate(['/login']);
        }, err => {
            debugger;
            this.ErrorMessage = JSON.parse(err._body).error;
        });
    }
}