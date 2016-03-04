using System;
using System.Runtime.Serialization;

namespace AppExample.Service.Dto
{
	[DataContract]
	public class UserDto
	{
		[DataMember]
		public Guid UserId { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public string Email { get; set; }
		[DataMember]
		public string Password { get; set; }
	}
}
