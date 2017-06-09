"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var app_routes_1 = require("./app.routes");
var app_component_1 = require("./app.component");
/////////////////ADDED//////////////////////////
var http_1 = require("@angular/http");
var forms_1 = require("@angular/forms");
// Imports for loading & configuring the in-memory web api
var angular_in_memory_web_api_1 = require("angular-in-memory-web-api");
var search_service_1 = require("./search/search.service");
var in_memory_data_service_1 = require("./search/in-memory-data.service");
///////////////////////////////////////////////////////////////
var base_component_1 = require("./base/base.component");
var app_nav_component_1 = require("./base/app-nav.component");
var footer_component_1 = require("./base/footer.component");
var home_component_1 = require("./home/home.component");
var about_component_1 = require("./about/about.component");
var schools_component_1 = require("./school/schools.component");
var login_component_1 = require("./account/login.component");
var register_component_1 = require("./account/register.component");
var signup_component_1 = require("./account/signup.component");
var search_component_1 = require("./search/search.component");
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        declarations: [app_component_1.AppComponent, base_component_1.BaseComponent, app_nav_component_1.AppNavComponent, footer_component_1.FooterComponent, home_component_1.HomeComponent, about_component_1.AboutComponent,
            schools_component_1.SchoolsComponent, login_component_1.LoginComponent, register_component_1.RegisterComponent, signup_component_1.SignUpComponent, search_component_1.BooksComponent],
        imports: [platform_browser_1.BrowserModule, app_routes_1.AppRoutes, forms_1.FormsModule,
            http_1.HttpModule,
            angular_in_memory_web_api_1.InMemoryWebApiModule.forRoot(in_memory_data_service_1.InMemoryDataService)],
        providers: [search_service_1.BookService],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map