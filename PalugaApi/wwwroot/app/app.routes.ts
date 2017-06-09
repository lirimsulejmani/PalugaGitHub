import { RouterModule } from "@angular/router";
import { ModuleWithProviders } from "@angular/core";

import { AuthGuard } from "./auth.guard/auth.guard";
import { BaseComponent } from "./base/base.component";
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
import { SellBookComponent } from "./sellbooks/sellBook.component";
import { SellBookByIsbnComponent } from "./sellbooks/sellBookByIsbn.component";
import { BookPublishedComponent } from "./sellbooks/bookPublished.component";
import { WishlistComponent } from "./wishlist/wishlist.component";
import { UserProfileComponent } from "./user/user-profile.component";

export const AppRoutes: ModuleWithProviders = RouterModule.forRoot([
    {
        path: "",
        component: BaseComponent,
        children: [
            {
                path: "", component: HomeComponent
            },
            {
                path: "about", component: AboutComponent
            },
            {
                path: "schools", component: SchoolsComponent
            },
            {
                path: "login", component: LoginComponent
            },
            {
                path: "signup", component: SignUpComponent
            },
            {
                path: "confirm-signup", component: ConfirmSignUpComponent//, canActivate: [AuthGuard]
            },
            {
                path: "verify/:token", component: VerifySignUpComponent
            },
            {
                path: "register", component: RegisterComponent
            },
            {
                path: "profile", component: UserProfileComponent, canActivate: [AuthGuard]
            },
            {
                path: "search/:query", component: BooksComponent
            },
            {
                path: "search-details/:bookId", component: BookDetailsComponent
            },
            {
                path: "wishlist", component: WishlistComponent, canActivate: [AuthGuard]
            },
            {
                path: 'sellBook', component: SellBookComponent
            }
            ,
            {
                path: 'sellBookByIsbn/:isbn', component: SellBookByIsbnComponent
            },
            {
                path: 'bookPublished', component: BookPublishedComponent
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