using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly_2.Models
{
    [Table("Movies")]
    public class MovieModel
    {        
        [Required]
        public int Id { get; set; }
            
        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 1)]
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