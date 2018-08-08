using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Distance.Validators;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Distance.Models
{
    public class IndexViewModel :DriverViewModels
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel : IPasswordViewModels
    {
        [Required]
        [StringLength(100, ErrorMessage = "Hasło musi zawierać przynajmniej 6 znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        [Distance.Validators.PasswordValidator]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Podane hasła nie pasują.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel : IPasswordViewModels
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Aktualne hasło")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Hasło musi zawierać przynajmniej 6 znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło")]
        [Validators.PasswordValidator]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Podane hasła nie pasują.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [PhoneNumberValidator]
        [Display(Name = "Numer telefonu")]
        public string Number { get; set; }

        [Display(Name ="Numer kierunkowy")]
        public string DirectPhoneNumber { get; set; }

        public System.Web.Mvc.SelectList Countries { get; set; }

        public class DirectPhones
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public string Country { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Kod")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}