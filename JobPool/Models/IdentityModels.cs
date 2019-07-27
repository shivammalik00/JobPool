using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobPool.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        //Recruiter Area
        [StringLength(150)]
        public string CompanyName { get; set; }

        [StringLength(150)]
        public string CompanyAddress { get; set; }
        [StringLength(50)]
        public string RecruiterName { get; set; }
        [StringLength(50)]
        public string RecruiterDesignation { get; set; }


        //Common 
        [StringLength(150)]
        public string Location { get; set; }

        public int MobileNumber { get; set; }

        //User Area
        public string FirstName { get; set; }        
        public string LastName { get; set; }

        [StringLength(20)]
        public string HighestQualification { get; set; }







    }
}