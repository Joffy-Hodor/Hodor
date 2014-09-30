using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NHibernate;

namespace HodorTutor.Repository.NHibernate.SessionStorage
{
	public class ThreadSessionStorage : ISessionStorage
	{
		private static readonly Hashtable _nhSessions = new Hashtable();

		public void Store(ISession session)
		{
			if (_nhSessions.Contains(GetThreadName()))
				_nhSessions[GetThreadName()] = session;
			else
				_nhSessions.Add(GetThreadName(), session);
		}

		public ISession Retrieve()
		{
			ISession nhSession = null;

			if (_nhSessions.Contains(GetThreadName()))
				nhSession = (ISession)_nhSessions[GetThreadName()];

			return nhSession;
		}

		private static string GetThreadName()
		{
			return Thread.CurrentThread.Name;
		}
	}
}
