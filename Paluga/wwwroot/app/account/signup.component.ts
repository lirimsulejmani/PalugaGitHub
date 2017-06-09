import { Component } from '@angular/core';
import { AccountService } from './account.service';
import { NgForm } from "@angular/forms";

@Component({
    selector: 'signup-container',
    templateUrl: './signup.view.html'
})

export class SignUpComponent {

    public Email: string;

    constructor(private accountService: AccountService) {
    }
    
    onSubmit(form: NgForm) {
        this.accountService.signUp(this.Email)
            .subscribe(resp => {

            });
    }
}