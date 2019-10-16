using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortener.Models
{
    /// <summary>
    /// Модель для  информации о созданной короткой ссылке
    /// </summary>
    public class UrlInfoModel
    {
        //todo: Плохо сущность использовать как Id, но так быстрее разрабатывать
        [Column("Id")]
        public string UrlInfoModelId { get; set; }

        [Display(Name = "Короткий URL")]
        [DataType(DataType.Url)]
        [UIHint("AbsoluteUrl")]
        public string ShortUrl => UrlInfoModelId;

        [Display(Name = "Исходный URL")]
        [DataType(DataType.Url)]
        [UIHint("NewWindowUrl")]
        public string LongUrl { get; set; }

        [Display(Name = "Создан")] 
        public DateTime Created { get; set; }

        [Display(Name = "Переходов")]
        public List<RedirectModel> Redirects { get; set; }
    }
}