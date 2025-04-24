using System.ComponentModel.DataAnnotations;

namespace PureAirPro.DBContext.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string PassWord { get; set; }
    }
}
