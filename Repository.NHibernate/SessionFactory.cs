using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HodorTutor.Infrastructure.Configuration;
using HodorTutor.Repository.NHibernate.SessionStorage;
using NHibernate;
using NHibernate.Cfg;

namespace HodorTutor.Repository.NHibernate
{
	public static class SessionFactory
	{
		private static ISessionFactory _sessionFactory;

		private static void Initialize()
		{
            var connectionString = ApplicationSettingsFactory.GetApplicationSettings().ConnectionString; //Global.asax need setting
			var config = CreateConfiguration(connectionString);
			config.AddAssembly("Repository.NHibernate");

			_sessionFactory = config.BuildSessionFactory();
		}

		private static Configuration CreateConfiguration(string connectionString)
		{
			var config = new Configuration();
			config.SetProperty("connection.driver_class", "NHibernate.Driver.SqlClientDriver");
			config.SetProperty("connection.connection_string", connectionString);
			config.SetProperty("adonet.batch_size", "10");
			config.SetProperty("dialect", "NHibernate.Dialect.MsSql2012Dialect");
			config.SetProperty("use_outer_join", "true");
			config.SetProperty("command_timeout", "60");
			config.SetProperty("query.substitutions", "true 1, false 0, yes 'Y', no 'N'");
			return config;
		}

		private static ISessionFactory GetSessionFactory()
		{
			if (_sessionFactory == null)
				Initialize();

			return _sessionFactory;
		}

		public static ISession GetNewSession()
		{
			return GetSessionFactory().OpenSession();
		}

		public static ISession GetCurrentSession()
		{
			ISessionStorage sessionStorage =
				SessionStorageFactory.GetSessionStorage();

			ISession currentSession = sessionStorage.Retrieve();

			if (currentSession == null)
			{
				currentSession = GetNewSession();
				sessionStorage.Store(currentSession);
			}
			
			return currentSession;
		}
	}
}
