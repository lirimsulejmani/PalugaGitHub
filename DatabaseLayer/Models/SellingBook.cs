using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatabaseLayer.Models
{
    public class SellingBook : BaseEntity
    {
        public Student Student { get; set; }

        //public Book Book { get; set; }

        public string BookId { get; set; }
        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }

        public BookConditionEnum BookCondition { get; set; }

        [MaxLength(200)]
        public string Comment { get; set; }

        public decimal Price { get; set; }

        public StatusEnum Status { get; set; }

        public DateTime EntryDate { get; set; }

    }

    public enum BookConditionEnum {
        New,
        BarelyUsed,
        Used,
        HeavilyUsed
    }

    public enum StatusEnum
    {
        Selling,
        Pending,
        Sold
    }
}
