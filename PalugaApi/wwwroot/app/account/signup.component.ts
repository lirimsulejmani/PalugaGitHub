import { Component, OnInit } from '@angular/core';
import { NgForm } from "@angular/forms";
import { Router } from '@angular/router';
import { AccountService } from './account.service';
import { SchoolService } from '../school/school.service';
import { Student } from './student.model';
import { School } from '../school/school.model';

@Component({
    selector: 'signup-container',
    templateUrl: `./signup.view.html?v=${Date()}`
})

export class SignUpComponent implements OnInit {
    student: Student;
    errorMessage: string;
    schools: Array<School>;

    constructor(private accountService: AccountService, private schoolService: SchoolService, private router: Router) {
        this.student = new Student();
    }

    ngOnInit() {
        this.schoolService.getSchools().subscribe(res => this.schools = res.data);
    }

    onSubmit(form: NgForm) {
        debugger;
        this.accountService.signUp(this.student)
            .subscribe(res => {
                this.student = res.data;
                this.router.navigate(['/confirm-signup']);
            }, error => {
                debugger;
                console.log(error);
                this.errorMessage = JSON.parse(error._body).error;
            });
    }
}