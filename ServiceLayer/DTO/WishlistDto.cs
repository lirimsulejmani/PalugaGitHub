using System;

namespace ServiceLayer.DTO
{
    public class WishlistDto
    {
        public Guid Id { get; set; }

        public string BookISBN10 { get; set; }

        public string BookISBN13 { get; set; }

        public Guid StudentId { get; set; }

        public int NotifiedStatus { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
