using System.Runtime.Serialization;

namespace AppExample.Service.Dto
{
	[DataContract]
	public class ChangePasswordDto
	{
		[DataMember]
		public string Email { get; set; }
		[DataMember]
		public string Password { get; set; }
		[DataMember]
		public string PasswordNew { get; set; }
		[DataMember]
		public string ConfirmPasswordNew { get; set; }
	}
}
