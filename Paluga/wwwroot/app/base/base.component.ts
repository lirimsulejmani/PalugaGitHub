import { Component } from '@angular/core';

@Component({
    selector: 'main-container',
    template: `<div class="main-container">
      <app-nav></app-nav>
      <main class="main">
         <router-outlet></router-outlet>
      </main>
      <app-footer></app-footer>
    </div>`
})

export class BaseComponent { }