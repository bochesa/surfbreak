using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Surfbreak.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress, MaxLength(500)]
        [Display(Name = "Email Addresse")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Kodeord")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Kodeord skal være ens")]
        [Display(Name = "Gentag kodeord")]
        public string ConfirmPassword { get; set; }
    }

}
