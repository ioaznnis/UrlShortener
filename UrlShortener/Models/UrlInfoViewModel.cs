using System;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    /// <summary>
    /// Модель для  информации о созданной короткой ссылке
    /// </summary>
    public class UrlInfoViewModel
    {
        [Display(Name = "Исходный URL")]
        [DataType(DataType.Url)]
        [UIHint("NewWindowUrl")]
        public string LongUrl { get; set; }

        [Display(Name = "Короткий URL")]
        [DataType(DataType.Url)]
        [UIHint("NewWindowUrl")]
        public string ShortUrl { get; set; }

        [Display(Name = "Создан")]
        public DateTime Created { get; set; }

        public string Id { get; set; }
    }
}