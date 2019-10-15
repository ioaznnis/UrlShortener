using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using UrlShortener.Models;

namespace UrlShortener.BusinessLogic
{
    /// <summary>
    /// 
    /// </summary>
    public static class Service
    {
        private static Dictionary<string, UrlInfoViewModel> Data { get; } =
            new Dictionary<string, UrlInfoViewModel>();

        public static string Create(UrlViewModel model, HttpRequest request)
        {
            var id = Encode(Guid.NewGuid());

            var info = new UrlInfoViewModel
            {
                Id = id,
                Created = DateTime.Now,
                LongUrl = model.LongUrl,
                ShortUrl = $"{request.Scheme}://{request.Host}{request.PathBase}/{id}",
            };

            Data.Add(id, info);

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

        public static string Redirect(string url)
        {
            return Data[url].LongUrl;
        }

        public static UrlInfoViewModel Get(string id)
        {
            return Data[id];
        }

        public static IEnumerable<UrlInfoViewModel> GetAll()
        {
            return Data.Values;
        }

        public static void Delete(string id)
        {
            Data.Remove(id);
        }
    }
}