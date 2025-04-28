namespace PureAirPro.DBContext
{
	public class Contact
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string MobileNumber { get; set; }
		public string Message { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool IsDeleted { get; set; }
	}
}
