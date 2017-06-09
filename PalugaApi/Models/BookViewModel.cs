using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalugaApi.Models
{
    public class BookViewModel
    {
        public string Isbn { get; set; }

        public string Isbn13 { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<AuthorViewModel> Authors { get; set; }

        public string Edition { get; set; }

        public string Publisher { get; set; }

        public DateTime? PublicationDate { get; set; }

        public string Language { get; set; }

        public string ImageUrl { get; set; }

        public int Pages { get; set; }

        public int GoodreadId { get; set; }

        public string Url { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
