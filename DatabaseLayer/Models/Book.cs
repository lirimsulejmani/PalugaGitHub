using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer.Models
{
    public class Book : BaseEntity
    {
        public string Isbn { get; set; }

        public string Isbn13 { get; set; }

        public string Title { get; set; }

        public string OriginalTitle { get; set; }

        public string Description { get; set; }

        public string Authors { get; set; }

        public string Edition { get; set; }

        public string Publisher { get; set; }

        public DateTime? PublicationDate { get; set; }

        public string Language { get; set; }

        public string ImageUrl { get; set; }

        public string LargeImageUrl { get; set; }

        public int Pages { get; set; }

        public int GoodreadId { get; set; }

        public string Url { get; set; }

        public DateTime EntryDate { get; set; }

    }
}
