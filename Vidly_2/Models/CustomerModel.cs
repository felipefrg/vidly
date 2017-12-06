using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly_2.Models
{
    [Table("Customers")]
    public class CustomerModel
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
        public MembershipTypeModel MembershipType { get; set; }


        public bool IsSubscribedToNewsLetter { get; set; }
    }
}   