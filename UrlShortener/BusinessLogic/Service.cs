using System;
using System.Collections.Generic;
using UrlShortener.Models;

namespace UrlShortener.BusinessLogic
{
    /// <summary>
    /// 
    /// </summary>
    public static class Service
    {
        public static Dictionary<string, UrlInfoViewModel> Dictionary { get; } =
            new Dictionary<string, UrlInfoViewModel>();

        public static UrlInfoViewModel Save(UrlViewModel model)
        {
            var info = new UrlInfoViewModel()
            {
                Created = DateTime.Now,
                LongUrl = model.LongUrl,
                ShortUrl = Encode(Guid.NewGuid())
            };

            Dictionary.Add(info.ShortUrl, info);
            return info;
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


        /// <summary>
        /// Decodes the given base64 string
        /// </summary>
        /// <param name="value">The base64 encoded string of a Guid</param>
        /// <returns>A new Guid</returns>
        public static Guid Decode(string value)
        {
            value = value
                .Replace("_", "/")
                .Replace("-", "+");
            var buffer = Convert.FromBase64String(value + "==");
            return new Guid(buffer);
        }
    }
}