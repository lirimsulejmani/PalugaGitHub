"use strict";
var router_1 = require("@angular/router");
var auth_guard_1 = require("./auth.guard/auth.guard");
var base_component_1 = require("./base/base.component");
var home_component_1 = require("./home/home.component");
var about_component_1 = require("./about/about.component");
var schools_component_1 = require("./school/schools.component");
var login_component_1 = require("./account/login.component");
var register_component_1 = require("./account/register.component");
var signup_component_1 = require("./account/signup.component");
var confirm_signup_component_1 = require("./account/confirm-signup.component");
var verify_signup_component_1 = require("./account/verify-signup.component");
var search_component_1 = require("./search/search.component");
var search_details_component_1 = require("./search/search-details.component");
var sellBook_component_1 = require("./sellbooks/sellBook.component");
var sellBookByIsbn_component_1 = require("./sellbooks/sellBookByIsbn.component");
var bookPublished_component_1 = require("./sellbooks/bookPublished.component");
var wishlist_component_1 = require("./wishlist/wishlist.component");
var user_profile_component_1 = require("./user/user-profile.component");
exports.AppRoutes = router_1.RouterModule.forRoot([
    {
        path: "",
        component: base_component_1.BaseComponent,
        children: [
            {
                path: "", component: home_component_1.HomeComponent
            },
            {
                path: "about", component: about_component_1.AboutComponent
            },
            {
                path: "schools", component: schools_component_1.SchoolsComponent
            },
            {
                path: "login", component: login_component_1.LoginComponent
            },
            {
                path: "signup", component: signup_component_1.SignUpComponent
            },
            {
                path: "confirm-signup", component: confirm_signup_component_1.ConfirmSignUpComponent //, canActivate: [AuthGuard]
            },
            {
                path: "verify/:token", component: verify_signup_component_1.VerifySignUpComponent
            },
            {
                path: "register", component: register_component_1.RegisterComponent
            },
            {
                path: "profile", component: user_profile_component_1.UserProfileComponent, canActivate: [auth_guard_1.AuthGuard]
            },
            {
                path: "search/:query", component: search_component_1.BooksComponent
            },
            {
                path: "search-details/:bookId", component: search_details_component_1.BookDetailsComponent
            },
            {
                path: "wishlist", component: wishlist_component_1.WishlistComponent, canActivate: [auth_guard_1.AuthGuard]
            },
            {
                path: 'sellBook', component: sellBook_component_1.SellBookComponent
            },
            {
                path: 'sellBookByIsbn/:isbn', component: sellBookByIsbn_component_1.SellBookByIsbnComponent
            },
            {
                path: 'bookPublished', component: bookPublished_component_1.BookPublishedComponent
            }
        ]
    },
    {
        path: "**", redirectTo: ""
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
