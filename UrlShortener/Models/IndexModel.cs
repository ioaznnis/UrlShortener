using System;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    public class IndexModel
    {
        public IndexModel(UrlInfoModel model, int count)
        {
            Id = model.UrlInfoModelId;
            ShortUrl = model.ShortUrl;
            LongUrl = model.LongUrl;
            Created = model.Created;
            RedirectCount = count;
        }

        public string Id { get; set; }

        [Display(Name = "Короткий URL")]
        [DataType(DataType.Url)]
        [UIHint("AbsoluteUrl")]
        public string ShortUrl { get; set; }

        [Display(Name = "Исходный URL")]
        [DataType(DataType.Url)]
        [UIHint("NewWindowUrl")]
        public string LongUrl { get; set; }

        [Display(Name = "Создан")]
        public DateTime Created { get; set; }

        public int RedirectCount { get; set; }
    }
}