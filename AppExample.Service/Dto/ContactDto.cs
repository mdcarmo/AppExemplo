using System;
using System.Runtime.Serialization;

namespace AppExample.Service.Dto
{
	[DataContract]
	public class ContactDto
	{
		[DataMember]
		public Guid Id { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public string Email { get; set; }
		[DataMember]
		public string Phone { get; set; }
	}
}
