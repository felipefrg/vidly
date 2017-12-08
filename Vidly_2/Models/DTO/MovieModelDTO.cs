using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_2.Models.DTO
{
    public class MovieModelDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Genre Type")]
        public int GenreId { get; set; }
        public GenreModel Genre { get; set; }
    }
}