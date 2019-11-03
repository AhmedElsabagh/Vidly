using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Customers
    {
        [Key]
        public int customerId { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Name")]
        public string customerName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? birthdate { get; set; }

        public bool isSubscripedToNewsletter { get; set; }

        public MembershipType membershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte membershipTypeId { get; set; }
    }
}