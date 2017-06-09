
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from "@angular/forms";
import { Book, Author } from '../search/book.model';
import { SellBookByIsbnService } from './sellBookByIsbn.service';
import { SellingBook, BookConditionEnum } from './sellingBook';

//for upload method fileChange
import { Headers, Http, Response, URLSearchParams, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import 'rxjs/add/observable/throw';
import { ImageResult, ResizeOptions } from 'ng2-imageupload';

@Component({
    selector: 'sellBookByIsbn-container',
    templateUrl: `./sellBookByIsbn.view.html?v=${Date()}`
})
export class SellBookByIsbnComponent implements OnInit {
    book: Book;
    errorMessage: string;
    isbn: string;
    apiEndPoint: string = "http://localhost:54213/api/sellingbook";
    noImageAvailable: string = "../../images/no_cover_thumb.png";
    src: string = "../../images/no_cover_thumb.png";
    resizeOptions: ResizeOptions = {
        resizeMaxHeight: 340,
        resizeMaxWidth: 240
    };
    nophoto: string = "nophoto";
    ISBN10: string = "ISBN_10";
    sellingBook: SellingBook;
    selectedEntry: number;
   // filesToUpload: File;
    filesToUpload: Array<File>;

    private BookCondition = BookConditionEnum;
    private BookConditionNames = Object.keys(this.BookCondition).filter(v => typeof v === "string") as string[];
    private BookConditionValues = Object.keys(this.BookCondition).filter(e => typeof (e) == "number");

    keys(): Array<string> {
        var keys = Object.keys(this.BookCondition);
        return keys.slice(keys.length / 2);
    }

    constructor(private sellBookService: SellBookByIsbnService, private router: Router, private route: ActivatedRoute, private http: Http) {
        this.book = new Book();
        this.sellingBook = new SellingBook();

        this.filesToUpload = [];
        //this.book.Authors = new Array<Author>();
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.isbn = params['isbn'];
            this.sellBookService.getBookByIsbn(this.isbn)
                .subscribe(response => {
                    if (response.totalItems) {
                        // There'll be only 1 book per ISBN
                        this.book = response.items[0];
                        this.sellingBook.BookId = this.book.id;
                        this.sellingBook.Isbn10 = this.book.volumeInfo.industryIdentifiers[0].identifier;
                        this.sellingBook.Isbn13 = this.book.volumeInfo.industryIdentifiers[1].identifier;
                    }
                    else
                    {
                        this.sellBookService.getGoodreadBookByIsbn(this.isbn).subscribe(res => {
                            this.book = res.data;
                            this.sellingBook.BookId = this.book.Id.toString();
                            this.sellingBook.Isbn10 = this.book.Isbn;
                            this.sellingBook.Isbn13 = this.book.Isbn13;
                        }, error => {
                            debugger;
                        });
                    }
                 
                }, error => {
                    debugger;
                });
        });
    }

    selected(imageResult: ImageResult) {
        debugger;
        this.src = imageResult.resized
            && imageResult.resized.dataURL
            || imageResult.dataURL;

      //  this.filesToUpload = <File>imageResult.file;
      //  this.fileChange(this.filesToUpload);
    }

    onSelectionChange(entry: any) {
        this.sellingBook.BookConditionId = entry;
    }

    onSubmit(form: NgForm) {
        debugger;
        this.sellBookService.sellBook(this.sellingBook)
            .subscribe(res => {
                debugger;
                this.sellingBook = res.data;
                this.router.navigate(['/bookPublished']);
            }, error => {
                debugger;
                console.log(error);
                this.errorMessage = JSON.parse(error._body).error;
            });
    }

 

    fileChangeEvent(fileInput: any) {
        debugger;
        this.filesToUpload = <Array<File>>fileInput.target.files;
    }
    

    fileChange(event: any) {
        debugger;
        let fileList: FileList = event.target.files;
        if (fileList.length > 0) {
            let file: File = fileList[0];
            let formData: FormData = new FormData();
            formData.append('uploadFile', file, file.name);
            let headers = new Headers();
            headers.append('Content-Type', 'multipart/form-data');
            headers.append('Accept', 'application/json');
            let options = new RequestOptions({ headers: headers });
            debugger;

            this.http.post(`${this.apiEndPoint}`, formData, options)           
                .map(res => {
                    debugger;
                    res.json()
                })
                .catch(error => Observable.throw(error))
                .subscribe(
                data => {
                    debugger;
                    console.log('success')
                },
                error => {
                    debugger;
                    console.log(error)
                }
                )
        }
    }

}
