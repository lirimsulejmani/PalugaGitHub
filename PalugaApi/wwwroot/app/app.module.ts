import { NgModule }      from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { AppRoutes } from "./app.routes";
import { AuthGuard } from "./auth.guard/auth.guard";
import { ImageUploadModule } from 'ng2-imageupload';

import { AppComponent } from "./app.component";
import { BaseComponent } from "./base/base.component";
import { AppNavComponent } from "./base/app-nav.component";
import { FooterComponent } from "./base/footer.component";
import { HomeComponent } from "./home/home.component";
import { AboutComponent } from "./about/about.component";
import { SchoolsComponent } from "./school/schools.component";
import { LoginComponent } from "./account/login.component";
import { RegisterComponent } from "./account/register.component";
import { SignUpComponent } from "./account/signup.component";
import { ConfirmSignUpComponent } from "./account/confirm-signup.component";
import { VerifySignUpComponent } from "./account/verify-signup.component";
import { BooksComponent } from "./search/search.component";
import { BookDetailsComponent } from "./search/search-details.component";
import { WishlistComponent } from "./wishlist/wishlist.component";
import { SellBookComponent } from "./sellbooks/sellBook.component";
import { SellBookByIsbnComponent } from "./sellbooks/sellBookByIsbn.component";
import { BookPublishedComponent } from "./sellbooks/bookPublished.component";
import { UserProfileComponent } from "./user/user-profile.component";

import { ApiService } from "./base/api.service";
import { AuthService } from "./auth.guard/auth.service";
import { AccountService } from "./account/account.service";
import { SchoolService } from "./school/school.service";
import { BookService } from "./search/search.service";
import { BookDetailsService } from "./search/search-details.service";
import { WishlistService } from "./wishlist/wishlist.service";
import { SellBookByIsbnService } from "./sellbooks/sellBookByIsbn.service";
import { GoogleService } from "./search/google.service";



@NgModule({
    declarations: [AppComponent, BaseComponent, AppNavComponent, FooterComponent, HomeComponent, AboutComponent,
        SchoolsComponent, LoginComponent, RegisterComponent, SignUpComponent, ConfirmSignUpComponent,
        VerifySignUpComponent, BooksComponent, BookDetailsComponent, WishlistComponent, SellBookComponent, SellBookByIsbnComponent, UserProfileComponent, BookPublishedComponent],
    providers: [AuthGuard, ApiService, AuthService, AccountService, BookService, SchoolService, BookDetailsService, WishlistService, SellBookByIsbnService, GoogleService],
    imports: [BrowserModule, FormsModule, HttpModule, AppRoutes, ImageUploadModule],
    bootstrap:      [ AppComponent]
})

export class AppModule { }
