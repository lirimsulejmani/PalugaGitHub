import { Component } from '@angular/core';
import { Router } from '@angular/router'
import { NgForm } from "@angular/forms";

@Component({
  selector: 'home-container',
  templateUrl: `./index.view.html?v=${Date()}`
})

export class HomeComponent  {
    name = 'Paluga';
    search: string;

    constructor(private router: Router) {
    }

    onSearch(form: NgForm) {
        this.router.navigate(['/search', this.search]); 
        //this.router.navigate(['/search'], { queryParams: { query: this.search } }); 
    }
}
