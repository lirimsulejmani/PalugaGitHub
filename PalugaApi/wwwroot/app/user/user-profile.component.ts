import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { UpdateProfile } from "./update-profile.model";
import { School } from "../school/school.model";
import { AccountService } from "../account/account.service";
import {SchoolService} from "../school/school.service";

@Component({
  selector: "user-profile-container",
  templateUrl: `./profile.view.html?v=${Date()}`
})
export class UserProfileComponent implements OnInit {
    profile: UpdateProfile;
    schools: Array<School>;
    message: string;

    constructor(private accountService: AccountService, private schoolService: SchoolService) {
        this.schools = new Array<School>();
    }

    ngOnInit() {
        this.accountService.user().subscribe(response => {
                this.profile = response.data;
            },
            error => {
                debugger;
            });
        this.schoolService.getSchools().subscribe(res => this.schools = res.data);
    }

    onSubmit(form: NgForm) {
        this.accountService.updateProfile(this.profile).subscribe(response => {

                this.message = response.message;
            },
            error => {
                debugger;
            });
    }
}
