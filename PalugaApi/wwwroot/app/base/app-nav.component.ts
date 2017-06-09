import { Component, OnInit } from '@angular/core'
import { Student } from '../account/student.model';

@Component({
    selector: 'app-nav',
    templateUrl: './app-nav.view.html?v=' + Date()
})

export class AppNavComponent implements OnInit {
    Student: Student;

    ngOnInit() {
        if (localStorage.getItem("user")) {
            return this.Student = JSON.parse(localStorage.getItem("user"));
        }
        return this.Student = null;
    }
}