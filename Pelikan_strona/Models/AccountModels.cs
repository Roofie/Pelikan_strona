using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Pelikan_strona.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
       // public DbSet<Klient> Klients { get; set; }
        public DbSet<CelUbezpieczeń> CelU { get; set; }
        public DbSet<NaŻycie> NaZ { get; set; }
        public DbSet<OdziałAgencji> Odzial { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<SumaUbezpieczenia> Sumy { get; set; }
        public DbSet<Szkoda> Szkody { get; set; }
        public DbSet<Turystyczne> UTurystyczne { get; set; }
        public DbSet<UmowaUbezpieczeniowa> Umowy { get; set; }
        public DbSet<Wiadomości> Wiadomość { get; set; }
        public DbSet<Zawód> Zawody { get; set; }


    }

    [Table("UserProfile")]
    public class UserProfile
    {
        public UserProfile()
        {
            this.UmowaUbezpieczeniowa = new HashSet<UmowaUbezpieczeniowa>();
            this.Wiadomości = new HashSet<Wiadomości>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Pesel { get; set; }
        public string Miasto { get; set; }
        public string KodPocztowy { get; set; }
        public string Ulica { get; set; }
        public Nullable<int> NrDomu { get; set; }
        public string NrMieszkania { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public Nullable<System.DateTime> DataUrodzenia { get; set; }
        public string EmailKlienta { get; set; }
     
    
        public virtual ICollection<UmowaUbezpieczeniowa> UmowaUbezpieczeniowa { get; set; }
        public virtual ICollection<Wiadomości> Wiadomości { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Imię")]
        public string Imie { get; set; }
        //[Required]
        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }
       // [Required]
        [Display(Name = "Pesel")]
        public string Pesel { get; set; }
       // [Required]
        [Display(Name = "Miasto")]
        public string Miasto { get; set; }
        //[Required]
        [Display(Name = "Kod pocztowy")]
        public string KodPocztowy { get; set; }
//[Required]
        [Display(Name = "Ulica")]
        public string Ulica { get; set; }
        //[Required]
        [Display(Name = "Numer domu")]
        public Nullable<int> NrDomu { get; set; }
        [Display(Name = "Numer mieszkania")]
        public string NrMieszkania { get; set; }
       // [Required]
        [Display(Name = "Data urodzenia")]
        public Nullable<System.DateTime> DataUrodzenia { get; set; }
        //[Required]
        [Display(Name = "E-mail")]
        public string EmailKlienta { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
