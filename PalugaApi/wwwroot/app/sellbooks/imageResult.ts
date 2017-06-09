interface ImageResult {
    file: File;
    url: string;
    error?: string;
    dataURL?: string;
    resized?: {
        dataURL: string;
        type: string;
    }
}