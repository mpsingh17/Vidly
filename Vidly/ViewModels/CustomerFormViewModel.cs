using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        [CheckMin18Years]
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }

        public HttpPostedFileBase Image { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public string Title { get; set; }
    }
}