import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutes } from './app.routes'
import { AppComponent } from './app.component';
import { Http } from '@angular/http';
import { Jsonp } from '@angular/http';

/////////////////ADDED//////////////////////////
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
// Imports for loading & configuring the in-memory web api

import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { BookService } from './search/search.service';
import { InMemoryDataService } from './search/in-memory-data.service';
///////////////////////////////////////////////////////////////

import { BaseComponent } from './base/base.component';
import { AppNavComponent } from './base/app-nav.component';
import { FooterComponent } from './base/footer.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { SchoolsComponent } from './school/schools.component';
import { LoginComponent } from './account/login.component';
import { RegisterComponent } from './account/register.component';
import { SignUpComponent } from './account/signup.component';
import { BooksComponent } from './search/search.component';


@NgModule({
    declarations: [AppComponent, BaseComponent, AppNavComponent, FooterComponent, HomeComponent, AboutComponent,
        SchoolsComponent, LoginComponent, RegisterComponent, SignUpComponent, BooksComponent],
    imports: [BrowserModule, AppRoutes, FormsModule,
        HttpModule,
        InMemoryWebApiModule.forRoot(InMemoryDataService)],
    providers: [BookService],
    bootstrap:      [ AppComponent]
})

export class AppModule { }
