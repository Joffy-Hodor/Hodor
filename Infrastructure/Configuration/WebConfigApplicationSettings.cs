using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace HodorTutor.Infrastructure.Configuration 
{
	public class WebConfigApplicationSettings : IApplicationSettings 
	{
		private const string _isDebugKey = "isDebug";
		private const string _systemNameKey = "SystemName";
        private const string _connectionStringKey = "ApplicationServices";

		public bool IsDebug
		{
			get { return Convert.ToBoolean(Convert.ToInt32(ConfigurationManager.AppSettings[_isDebugKey])); }
		}

		public string SystemName 
		{
			get { return ConfigurationManager.AppSettings[_systemNameKey]; }
		}

        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings[_connectionStringKey].ConnectionString; }
        }
	}
}
