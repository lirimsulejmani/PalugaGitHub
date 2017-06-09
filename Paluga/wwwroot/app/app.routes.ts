import { RouterModule, Routes } from '@angular/router';
import { ModuleWithProviders, NgModule } from '@angular/core';

import { BaseComponent } from './base/base.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { SchoolsComponent } from './school/schools.component';
import { LoginComponent } from './account/login.component';
import { RegisterComponent } from './account/register.component';
import { SignUpComponent } from './account/signup.component';
import { BooksComponent } from './search/search.component';

export const AppRoutes: ModuleWithProviders = RouterModule.forRoot([
    {
        path: '',
        component: BaseComponent,
        children: [
            {
                path: '', component: HomeComponent
            },
            {
                path: 'about', component: AboutComponent
            },
            {
                path: 'schools', component: SchoolsComponent
            },
            {
                path: 'login', component: LoginComponent
            },
            {
                path: 'signup', component: SignUpComponent
            },
            {
                path: 'register', component: RegisterComponent
            }
            ,
            {
                path: 'search', component: BooksComponent
            }
        ]
    },
    {
        path: "**", redirectTo: ''
    }
]);



//const appRoutes: Routes = [
//    {
//        path: '', component: HomeComponent,
//        children: [
//            { path: '', component: HomeComponent },
//            { path: 'home', component: HomeComponent },
//            { path: 'about', component: AboutComponent },
//            { path: 'schools', component: SchoolComponent }
//        ]
//    },
//    { path: '**', redirectTo: '' }
//];

//export const AppRoutes = RouterModule.forRoot(appRoutes);