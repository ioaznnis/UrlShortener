using System;
using System.Collections.Generic;
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
        public static async Task<string> Create(UrlViewModel model)
        {
            var id = Encode(Guid.NewGuid());

            using (var db = new ApplicationContext())
            {
                await db.Urls.AddAsync(
                    new UrlInfoViewModel
                    {
                        Id = id,
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
            return (await Get(url)).LongUrl;
        }

        public static async Task<UrlInfoViewModel> Get(string id)
        {
            using (var db = new ApplicationContext())
            {
                //todo: заменить на SingleOrDefaultAsync c обработкой ошибок
                return await db.Urls.SingleAsync(x => x.Id == id);
            }
        }

        public static async Task<IReadOnlyCollection<UrlInfoViewModel>> GetAll()
        {
            using (var db = new ApplicationContext())
            {
                return await db.Urls.ToListAsync();
            }
        }

        public static async Task Delete(string id)
        {
            using (var db = new ApplicationContext())
            {
                var item = await db.Urls.SingleAsync(x => x.Id == id);
                db.Urls.Remove(item);
                await db.SaveChangesAsync();
            }
        }
    }
}