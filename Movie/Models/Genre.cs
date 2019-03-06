using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie.Models
{
    public class Genre
    {
        [Required]
        public int GenreId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Zanrovi { get; set; }

        public int FilmId { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}