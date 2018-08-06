using Distance.Validators;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Distance.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Kod weryfikacyjny")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Zapamiętać przeglądarkę?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel : IPasswordViewModels, IAddressViewModel, IPersonalDataViewModels
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Hasło mus mieć przynajmniej 6 znaków długości.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        [PasswordValidator]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Podane hasła nie pasują do siebie.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        [Required]
        [FirstNameValidator]
        [Display(Name = "Imie")]
        public string FirstName { get; set; }

        [Required]
        [LastNameValidator]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Required]
        [NumberHouseValidator]
        [Display(Name = "Numer domu")]
        public string HouseNumber { get; set; }

        [NumberFlatValidator]
        [Display(Name = "Numer mieszkania")]
        public string FlatNumber { get; set; }

        [Required]
        [ZipCodeValidator]
        [Display(Name = "Kod pocztowy")]
        public string ZipCode { get; set; }

        [Required]
        [CityValidator]
        [Display(Name = "Miejscowość")]
        public string City { get; set; }
    }

    public class ResetPasswordViewModel : IPasswordViewModels
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Hasło musi mieć przynajmniej 6 znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        [PasswordValidator]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Podane hasła nie pasują.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public interface IPasswordViewModels
    {
        string Password { get; set; }
    }

    public interface IPersonalDataViewModels
    {
        string FirstName { get; set; }
        string LastName { get; set; }        
    }

    public interface IAddressViewModel
    {
        string Street { get; set; }
        string HouseNumber { get; set; }
        string FlatNumber { get; set; }
        string ZipCode { get; set; }
        string City { get; set; }
    }
}
