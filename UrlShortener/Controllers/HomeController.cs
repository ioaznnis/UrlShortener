using System.Diagnostics;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {
            var collection = await Service.GetAll();
            return View(collection);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
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
        public async Task<IActionResult> Create(UrlModel model)
        {
            var id = await Service.Create(model);
            return RedirectToAction(nameof(Details), new {id = id});
        }

        /// <summary>
        /// Форма для отображения информации о короткой ссылки
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(string id)
        {
            var viewModel = await Service.Get(id);
            return View(viewModel);
        }

        /// <summary>
        /// Действие удаления короткой ссылки
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(string id)
        {
            await Service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}