using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    /// <summary>
    /// Модель для создаваемой короткой ссылки
    /// </summary>
    public class UrlModel
    {
        //todo: Проверка на корректность сокращаемого URL 
        [Display(ShortName = "Исходный URL")]
        public string LongUrl { get; set; }
    }
}
