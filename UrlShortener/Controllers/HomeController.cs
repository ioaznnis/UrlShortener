using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.BusinessLogic;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    /// <summary>
    /// Контроллер, в той или иной мере реализующий CRUD для коротких ссылок
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var collection = Service.GetAll();
            return View(collection);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }


        /// <summary>
        /// Форма для создания короткой ссылки
        /// </summary>
        /// <returns></returns>
        public IActionResult Create() => View();

        /// <summary>
        /// Обработка создания короткой ссылки
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(UrlViewModel model)
        {
            var id = Service.Create(model, this.Request);
            return RedirectToAction(nameof(Details), new {id = id});
        }

        /// <summary>
        /// Форма для отображения информации о короткой ссылки
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(string id)
        {
            var viewModel = Service.Get(id);
            return View(viewModel);
        }

        /// <summary>
        /// Действие удаления короткой ссылки
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(string id)
        {
            Service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}