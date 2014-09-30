using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace HodorTutor.Repository.NHibernate.SessionStorage
{
	public interface ISessionStorage
	{
		void Store(ISession session);
		ISession Retrieve();
	}
}
