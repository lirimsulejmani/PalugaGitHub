"use strict";
var router_1 = require("@angular/router");
var base_component_1 = require("./base/base.component");
var home_component_1 = require("./home/home.component");
var about_component_1 = require("./about/about.component");
var schools_component_1 = require("./school/schools.component");
var login_component_1 = require("./account/login.component");
var register_component_1 = require("./account/register.component");
var signup_component_1 = require("./account/signup.component");
var search_component_1 = require("./search/search.component");
exports.AppRoutes = router_1.RouterModule.forRoot([
    {
        path: '',
        component: base_component_1.BaseComponent,
        children: [
            {
                path: '', component: home_component_1.HomeComponent
            },
            {
                path: 'about', component: about_component_1.AboutComponent
            },
            {
                path: 'schools', component: schools_component_1.SchoolsComponent
            },
            {
                path: 'login', component: login_component_1.LoginComponent
            },
            {
                path: 'signup', component: signup_component_1.SignUpComponent
            },
            {
                path: 'register', component: register_component_1.RegisterComponent
            },
            {
                path: 'search', component: search_component_1.BooksComponent
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
//# sourceMappingURL=app.routes.js.map