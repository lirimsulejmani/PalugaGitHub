import { Component } from '@angular/core';
import { Router } from '@angular/router'
import { NgForm } from "@angular/forms";

@Component({
    selector: 'sell-container',
    templateUrl: `./sellBook.view.html?v=${Date()}`
})

export class SellBookComponent {
    name = 'Paluga';
    isbn: string;

    constructor(private router: Router) {
    }

    onSearch(form: NgForm) {
        this.router.navigate(['/sellBookByIsbn', this.isbn]);
        //this.router.navigate(['/search'], { queryParams: { query: this.search } }); 
    }
}
