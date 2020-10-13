using System;
using System.ComponentModel.DataAnnotations;

namespace Masny.Blazor.ClientSide.Models
{
    public class FormModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        [Required]
        //[CompareProperty("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Accept Ts & Cs is required")]
        public bool AcceptTerms { get; set; }
    }
}
