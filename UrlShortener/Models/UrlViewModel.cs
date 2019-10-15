using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    /// <summary>
    /// Модель для создаваемой короткой ссылки
    /// </summary>
    public class UrlViewModel
    {
        [Display(ShortName = "Исходный URL")]
        public string LongUrl { get; set; }
    }
}
