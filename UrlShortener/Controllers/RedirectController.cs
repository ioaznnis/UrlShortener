using Microsoft.AspNetCore.Mvc;
using UrlShortener.BusinessLogic;

namespace UrlShortener.Controllers
{
    /// <summary>
    /// Контролер переадресации коротких URL на полные URL
    /// </summary>
    public class RedirectController : Controller
    {
        /// <summary>
        /// Основной метод переадресации
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public IActionResult NavigateTo(string url) => Redirect(Service.Redirect(url));
    }
}