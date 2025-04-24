using System.ComponentModel.DataAnnotations;

namespace PureAirPro.DBContext
{
    public class Users
    {
        public int UserID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        [Required (ErrorMessage = "Password field is required.")]
		[RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
		 ErrorMessage = "Password must meet requirements")]
		public string UserPassWord { get; set; }
        [Required]
        [Compare("UserPassWord",ErrorMessage = "'Confirm Password' and 'PassWord' do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
