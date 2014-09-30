using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HodorTutor.Repository.NHibernate.SessionStorage
{
	public static class SessionStorageFactory
	{
		public static ISessionStorage GetSessionStorage()
		{
			if (HttpContext.Current != null)
				return new HttpContextSessionStorage();

			return new ThreadSessionStorage();
		}
	}
}
