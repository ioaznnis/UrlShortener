using System;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    public class UrlInfoViewModel
    {
        [DataType(DataType.Url)]
        [UIHint("NewWindowUrl")]
        public string LongUrl { get; set; }

        [DataType(DataType.Url)]
        [UIHint("NewWindowUrl")]
        public string ShortUrl { get; set; }

        public DateTime Created { get; set; }
    }
}