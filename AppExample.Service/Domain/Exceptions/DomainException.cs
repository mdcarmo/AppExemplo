using System;

namespace AppExample.Service.Domain.Exceptions
{
	public class DomainException : Exception
	{
		public DomainException()
		{

		}
		public DomainException(string mensagem)
			: base(mensagem)
		{

		}
	}
}
