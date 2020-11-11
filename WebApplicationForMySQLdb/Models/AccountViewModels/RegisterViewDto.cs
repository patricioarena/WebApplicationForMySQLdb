using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationForMySQLdb.Models.AccountViewModels
{
    public class RegisterViewDto
    {
        [Required]
        [UserName]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        //[Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[Required]
        [EmailConfirmed]
        [Compare("Email", ErrorMessage = "The email and confirmation email do not match.")]
        [Display(Name = "Confirmar email")]
        [DataType(DataType.EmailAddress)]
        public string EmailConfirmed { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
       
        [Required]
        public string Rol { get; set; }
    }
}
