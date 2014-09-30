using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace HodorTutor.Infrastructure.Configuration
{
	public class AppConfigApplicationSettings : IApplicationSettings
	{
		public const string _connectionStringKey = "ConnectionString";
		private const string _systemNameKey = "SystemName";
	
		public bool IsDebug
		{
			get { throw new NotImplementedException(); }
		}

		public string SystemName
		{
			get
			{
				return ConfigurationManager.AppSettings[_systemNameKey];
			}
		}

		public string ConnectionString
		{
			get {
				return ConfigurationManager.AppSettings[_connectionStringKey];
			}
		}
	}
}
