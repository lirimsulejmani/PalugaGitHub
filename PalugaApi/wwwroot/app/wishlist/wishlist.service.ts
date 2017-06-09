import { Injectable } from '@angular/core';
import { ApiService } from '../base/api.service';
import { AddWishlist } from '../wishlist/add-wishlist.model';

@Injectable()
export class WishlistService {

    constructor(private apiService: ApiService) { }

    getList() {
        return this.apiService.get("/wishlist");
    }

    addToList(wishlist: AddWishlist) {
        return this.apiService.post("/wishlist/add", wishlist);
    }

    checkBookByIsbn(isbn: string) {
        return this.apiService.get(`/wishlist/checkbook/${isbn}`);
    }

    delete(wishlistId: string) {
        return this.apiService.delete(`/wishlist/${wishlistId}`);
    }
}