using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models.CustomValidationAttributes;

namespace Vidly.Models
{
    public enum MembershipCode
    { Unknown, PayAsYouGo, Monthly, Quarterly, Annually}
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsforMembership]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [NotMapped]
        public MembershipCode MembershipCode {
            get { return (MembershipCode)MembershipTypeId; }
        }
    }
}