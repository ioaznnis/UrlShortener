using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using UrlShortener.Models;

namespace UrlShortener.BusinessLogic
{
    public class ApplicationContext : DbContext
    {
        public static string UserId { private get; set; }
        public static string Password { private get; set; }

        public DbSet<UrlInfoModel> Urls { get; set; }
        
        public DbSet<RedirectModel> Redirects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "db4free.net",
                Port = 3306,
                Database = "url_shortener",
                OldGuids = true,
                UserID = UserId,
                Password = Password
            };


            optionsBuilder.UseMySQL(builder.ConnectionString);
        }
    }
}