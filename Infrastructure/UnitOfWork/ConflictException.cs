using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HodorTutor.Infrastructure.UnitOfWork
{
	public class ConflictException : ApplicationException
	{
		private static readonly string _defaultMessage = "データの操作中に競合が発生しました。";

		public ConflictException()
			: base(_defaultMessage, null)
		{
		}

		public ConflictException(string message)
			: base(message, null)
		{
		}

		public ConflictException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
