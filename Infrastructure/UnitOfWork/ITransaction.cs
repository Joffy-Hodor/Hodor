using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HodorTutor.Infrastructure.UnitOfWork
{
	public interface ITransaction : IDisposable
	{
		void Commit();
	}
}
