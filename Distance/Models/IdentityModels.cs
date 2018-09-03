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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModyfiTime { get; set; }

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
        public DateTime CreateTime { get; set; }
        public DateTime ModyfiTime { get; set; }
    }

    public class UserInCompany
    {
        [Key, Column(Order = 0)]
        public int CompanyId { get; set; }
        [Key, Column(Order = 1)]
        public string UserId { get; set; }

        [ForeignKey("CompanyId")]
        public Company CompanyID { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime ModyfiTime { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }

    public class CarStatuses
    {
        [Key]
        public byte Id { get; set; }

        public string Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModyfiTime { get; set; }
    }

    public class Cars
    {
        [Key]
        public int Id { get; set; } //id
        
        public string Name { get; set; } //marka auta        
        public string Model { get; set; } //model auta       
        public string CarPlate { get; set; } //numer rejestracji   
        public float EngineCapacity { get; set; }
        public int KmAge { get; set; } //przebieg w km
        public byte CarStatusId { get; set; } //FK dla CarStatus
        public int CompanyId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModyfiTime { get; set; }

        [ForeignKey("CarStatusId")]
        public CarStatuses CarStatus { get; set; }    

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }

    public class Travel
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public int CarId { get; set; }
        public int CarMileageStart { get; set; }
        public int CarMileageStop { get; set; }
        public DateTime TravelDate { get; set; }
        public string Purpose { get; set; }
        public string Notes { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModyfiTime { get; set; }

        [ForeignKey("CarId")]
        public Cars Car { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {        
        public virtual DbSet<Cars> Cars { get; set; }        
        public virtual DbSet<CarStatuses> CarStatuses { get; set; }
        public DbSet<DicCountries> DicCountries { get; set; }
        public DbSet<Company> Company { get; set; }
        public virtual DbSet<UserInCompany> UserInCompany { get; set; }
        public DbSet<Travel> Travel { get; set; }
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