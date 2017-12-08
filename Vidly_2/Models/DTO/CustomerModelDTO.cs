using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_2.Models.DTO
{
    public class CustomerModelDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime Birthday { get; set; }

        [Required]
        public byte MembershiptypeId { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
    }
}