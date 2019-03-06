using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie.Models
{
    public class Film
    {
        [Required]
        public int FilmId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        public string Zanrovi { get; set; }
        public ICollection<Genre> Genres { get; set; } 
    }
}