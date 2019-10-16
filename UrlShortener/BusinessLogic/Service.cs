using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;

namespace UrlShortener.BusinessLogic
{
    /// <summary>
    /// Основная бизнес-логика сервиса
    /// </summary>
    //todo: Добавить использование CancellationToken
    public static class Service
    {
        public static async Task<string> Create(UrlModel model)
        {
            var id = Encode(Guid.NewGuid());

            using (var db = new ApplicationContext())
            {
                await db.Urls.AddAsync(
                    new UrlInfoModel
                    {
                        UrlInfoModelId = id,
                        Created = DateTime.Now,
                        LongUrl = model.LongUrl,
                    });
                await db.SaveChangesAsync();
            }

            return id;
        }

        /// <summary>
        /// Encodes the given Guid as a base64 string that is 22
        /// characters long.
        /// </summary>
        /// <param name="guid">The Guid to encode</param>
        /// <returns></returns>
        private static string Encode(Guid guid)
        {
            var encoded = Convert.ToBase64String(guid.ToByteArray());
            encoded = encoded
                .Replace("/", "_")
                .Replace("+", "-");
            return encoded.Substring(0, 22);
        }

        public static async Task<string> Redirect(string url)
        {
            using (var db = new ApplicationContext())
            {
                db.Redirects.Add(new RedirectModel() {RedirectDate = DateTime.Now, UrlInfoModelId = url});
                await db.SaveChangesAsync();

                return (await db.Urls.SingleAsync(x => x.UrlInfoModelId == url)).LongUrl;
            }
        }

        public static async Task<UrlInfoModel> Get(string id)
        {
            using (var db = new ApplicationContext())
            {
                //todo: заменить на SingleOrDefaultAsync c обработкой ошибок
                return await db.Urls.SingleAsync(x => x.UrlInfoModelId == id);
            }
        }

        public static async Task<IReadOnlyCollection<IndexModel>> GetAll()
        {
            using (var db = new ApplicationContext())
            {
                return await db.Urls.Select(x => new IndexModel(x, x.Redirects.Count())).ToListAsync();
            }
        }

        public static async Task Delete(string id)
        {
            using (var db = new ApplicationContext())
            {
                var item = await db.Urls.SingleAsync(x => x.UrlInfoModelId == id);
                db.Urls.Remove(item);
                await db.SaveChangesAsync();
            }
        }
    }
}