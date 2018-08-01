using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Distance.Models
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
    }

    public class DicCountries
    {
        [Key]
        public int CountryID { get; set; }

        public string CountryName { get; set; }
        public string CountryCodeA2 { get; set; }
        public string CountryCodeA3 { get; set; }
        public byte[] CountryFlagData { get; set; }
        public string CountryFlagMimeType { get; set; }
        public string CountryDirectPhoneNumber { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
    }

    public class Company
    {
        [Key]
        public int CompanyID { get; set; }

        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string NIP { get; set; }
    }

    public class UserInCompany
    {
        [Key, Column(Order = 0)]
        public int CompanyId { get; set; }
        [Key, Column(Order = 1)]
        public string UserId { get; set; }

        [ForeignKey("CompanyId")]
        public Company CompanyID { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<DriverViewModels> Drivers { get; set; }
        public DbSet<CarViewModels> Cars { get; set; }
        public DbSet<AccountTypeViewModels> AccountTypes { get; set; }
        public DbSet<CarStatusViewModels> CarStatuses { get; set; }
        public DbSet<DicCountries> DicCountries { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<UserInCompany> UserInCompany { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}