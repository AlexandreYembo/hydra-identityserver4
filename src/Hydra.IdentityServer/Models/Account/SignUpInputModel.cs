using System.ComponentModel.DataAnnotations;

namespace Hydra.IdentityServer
{
    public class SignUpInputModel
    {
        [Required(ErrorMessage = "Fied {0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fied {0} is required")]
        public string IdentityNumber { get; set; }

        [Required(ErrorMessage = "Fied {0} is required")]
        [EmailAddress(ErrorMessage="Field{0} has invalid characteres")]
        public string Email { get; set; }
       
        [Required(ErrorMessage = "Fied {0} is required")]
        [StringLength(100, ErrorMessage="Field migh have between {2} and {1} characteres", MinimumLength=6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage="Password does not match")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}