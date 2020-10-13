using System;
using System.ComponentModel.DataAnnotations;

namespace Masny.Blazor.ServerSide.Data
{
    public class JobApplication
    {
        [Required]
        public string FullName { get; set; }

        [StringLength(500, ErrorMessage = "Desc error")]
        public string Description { get; set; }

        [Required]
        [Range(1000, 1500, ErrorMessage = "Salary error")]
        public int Salary { get; set; }

        [Required]
        public bool IsOpenSource { get; set; }

        [Required]
        public DateTime Availability { get; set; }
    }
}
