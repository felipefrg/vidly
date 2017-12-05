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
        public byte Id { get; set; }
            
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}