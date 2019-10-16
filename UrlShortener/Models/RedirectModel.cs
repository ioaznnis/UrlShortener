using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortener.Models
{
    public class RedirectModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int RedirectModelId { get; set; }
        
        [Column("UrlOf")]
        public string UrlInfoModelId { get; set; }

        public DateTime RedirectDate { get; set; }
    }
}