using System;

namespace DatabaseLayer.Models
{
    public class Wishlist : BaseEntity
    {
        public string BookISBN10 { get; set; }

        public string BookISBN13 { get; set; }

        public Student Student { get; set; }

        public NotifiedStatusEnum NotifiedStatus { get; set; }

        public DateTime EntryDate { get; set; }
    }

    public enum NotifiedStatusEnum
    {
        Pending,
        Notified
    }
}
