using System;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    /// <summary>
    /// Модель для  информации о созданной короткой ссылке
    /// </summary>
    public class UrlInfoViewModel
    {
        //todo: Плохо сущность использовать как Id, но так быстрее разрабатывать
        [Key]
        public string Id { get; set; }

        [Display(Name = "Короткий URL")]
        [DataType(DataType.Url)]
        [UIHint("AbsoluteUrl")]
        public string ShortUrl => Id;

        [Display(Name = "Исходный URL")]
        [DataType(DataType.Url)]
        [UIHint("NewWindowUrl")]
        public string LongUrl { get; set; }

        [Display(Name = "Создан")]
        public DateTime Created { get; set; }

    }
}