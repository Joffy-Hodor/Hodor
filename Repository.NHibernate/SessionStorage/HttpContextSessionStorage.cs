using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NHibernate;

namespace HodorTutor.Repository.NHibernate.SessionStorage
{
	public class HttpContextSessionStorage : ISessionStorage
	{
		public HttpContextSessionStorage()
		{
			_httpContext = HttpContext.Current;
		}

		private static string NHSessionKey = "NHSession";
		private readonly HttpContext _httpContext;

		public void Store(ISession session)
		{
			if (_httpContext.Items.Contains(NHSessionKey))
				_httpContext.Items[NHSessionKey] = session;
			else
				_httpContext.Items.Add(NHSessionKey, session);
		}

		public ISession Retrieve()
		{
			if (!_httpContext.Items.Contains(NHSessionKey))
				return null;

			return (ISession)_httpContext.Items[NHSessionKey];
		}
	}
}
