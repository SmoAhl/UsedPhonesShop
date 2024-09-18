using System.ComponentModel.DataAnnotations;


namespace UsedPhonesShop.Shared
{

    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }

}