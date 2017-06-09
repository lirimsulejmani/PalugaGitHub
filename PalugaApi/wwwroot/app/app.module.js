"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
var app_routes_1 = require("./app.routes");
var auth_guard_1 = require("./auth.guard/auth.guard");
var ng2_imageupload_1 = require("ng2-imageupload");
var app_component_1 = require("./app.component");
var base_component_1 = require("./base/base.component");
var app_nav_component_1 = require("./base/app-nav.component");
var footer_component_1 = require("./base/footer.component");
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
var wishlist_component_1 = require("./wishlist/wishlist.component");
var sellBook_component_1 = require("./sellbooks/sellBook.component");
var sellBookByIsbn_component_1 = require("./sellbooks/sellBookByIsbn.component");
var bookPublished_component_1 = require("./sellbooks/bookPublished.component");
var user_profile_component_1 = require("./user/user-profile.component");
var api_service_1 = require("./base/api.service");
var auth_service_1 = require("./auth.guard/auth.service");
var account_service_1 = require("./account/account.service");
var school_service_1 = require("./school/school.service");
var search_service_1 = require("./search/search.service");
var search_details_service_1 = require("./search/search-details.service");
var wishlist_service_1 = require("./wishlist/wishlist.service");
var sellBookByIsbn_service_1 = require("./sellbooks/sellBookByIsbn.service");
var google_service_1 = require("./search/google.service");
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        declarations: [app_component_1.AppComponent, base_component_1.BaseComponent, app_nav_component_1.AppNavComponent, footer_component_1.FooterComponent, home_component_1.HomeComponent, about_component_1.AboutComponent,
            schools_component_1.SchoolsComponent, login_component_1.LoginComponent, register_component_1.RegisterComponent, signup_component_1.SignUpComponent, confirm_signup_component_1.ConfirmSignUpComponent,
            verify_signup_component_1.VerifySignUpComponent, search_component_1.BooksComponent, search_details_component_1.BookDetailsComponent, wishlist_component_1.WishlistComponent, sellBook_component_1.SellBookComponent, sellBookByIsbn_component_1.SellBookByIsbnComponent, user_profile_component_1.UserProfileComponent, bookPublished_component_1.BookPublishedComponent],
        providers: [auth_guard_1.AuthGuard, api_service_1.ApiService, auth_service_1.AuthService, account_service_1.AccountService, search_service_1.BookService, school_service_1.SchoolService, search_details_service_1.BookDetailsService, wishlist_service_1.WishlistService, sellBookByIsbn_service_1.SellBookByIsbnService, google_service_1.GoogleService],
        imports: [platform_browser_1.BrowserModule, forms_1.FormsModule, http_1.HttpModule, app_routes_1.AppRoutes, ng2_imageupload_1.ImageUploadModule],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
