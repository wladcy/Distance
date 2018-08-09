using Distance.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Distance.Models
{
    public class DriverViewModels : IPersonalDataViewModels, IPhoneNumberViewModel, IPasswordViewModels, IAddressViewModel
    {
        [Required]
        [EmailValidator]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [PhoneNumberValidator]
        [Display(Name = "Numer telefonu")]
        public string Number { get; set; }

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

        public string Id { get; set; }

        public string Title
        {
            get
            {
                if (!string.IsNullOrEmpty(Id))
                    return "Edytuj dane kierowcy";

                return "Dodaj nowego kierowce";
            }
        }

        public string Button
        {
            get
            {
                if (!string.IsNullOrEmpty(Id))
                    return "Edytuj";
                return "Dodaj";
            }
        }

        public bool IsEditMode { get; set; }
    }
}