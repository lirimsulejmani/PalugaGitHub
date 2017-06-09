export class SellingBook {

    BookId: string;
    Isbn10: string;
    Isbn13: string;
    BookConditionId: number;
    Price: number;
    Comment: string;
}

export enum BookConditionEnum {
    New,
    BarelyUsed,
    Used,
    HeavilyUsed
}