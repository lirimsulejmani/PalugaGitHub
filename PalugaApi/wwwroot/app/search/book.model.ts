export class Book {
    id: string;
    volumeInfo: {
        authors: Array<any>;
        categories: Array<any>;
        description: string;
        industryIdentifiers: Array<any>;
        imageLinks: {
            smallThumbnail: string;
            thumbnail: string;
        },
        pageCount: number;
        publishedDate: string;
        publisher: string;
        title: string;
    }
    
    Id: number;
    Title: string;
    Description: string;
    Isbn: string;
    Isbn13: string;
    CountryCode: string;
    ImageUrl: string;
    SmallImageUrl: string;
    PublicationDate: Date;
    Publisher: string;
    LanguageCode: string;
    Pages: number;
    Format: string;
    EditionInformation: string;
    Url: string;
    Authors: Array<Author>;
    BookLinks: number;
    BuyLinks: number;
    SimilarBooks: number;
    //fields not from provider
    SearchText: string;
    AuthorName: string;
    LargeImageUrl: string;
    Language: string;
}

export class Author{
    Id: number;
    Name: string;
    Link: string;
}

export class PaginationModel{

    Start: number;
    End: number;
    TotalItems: number;
}

export class GoodreadBook {

    Id: number;
    Title: string;
    Description: string;
    Isbn: string;
    Isbn13: string;
    CountryCode: string;
    ImageUrl: string;
    SmallImageUrl: string;
    PublicationDate: Date;
    Publisher: string;
    LanguageCode: string;
    Pages: number;
    Format: string;
    EditionInformation: string;
    Url: string;
    Authors: Array<Author>;
    BookLinks: number;
    BuyLinks: number;
    SimilarBooks: number;
    //fields not from provider
    SearchText: string;
    AuthorName: string;
    LargeImageUrl: string;
    Language: string;
}

export class Work{

    Id: number;
    BooksCount: number;
    BestBookId: number;
    BestBook: BestBook;
    UserPosition: string; 
    ReviewsCount: number;
    RatingsSum: number;
    RatingsCount: number;
    TextReviewsCount: number;
    OriginalPublicationDate: Date;
    OriginalTitle: string;
    OriginalLanguageId: number;
    MediaType: string;
   // RatingDistribution: number[][];
}

export class BestBook 
{
    Id: number;
    Title: string;
    AuthorId: number;
    AuthorName: string;
    ImageUrl: string;
}