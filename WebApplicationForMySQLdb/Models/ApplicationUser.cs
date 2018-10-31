using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApplicationForMySQLdb.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //[StringLength(45)]
        //public string Name { get; set; }
        //[StringLength(45)]
        //public string LastName { get; set; }
        //[StringLength(255)]
        //public string Identificator { get; set; }
    }
}
