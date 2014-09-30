using System.Diagnostics;

namespace HodorTutor.Infrastructure.Configuration 
{
	public class ApplicationSettingsFactory 
	{
		private static IApplicationSettings _applicationSettings;

		public static void InitializeApplicationSettingsFactory(IApplicationSettings applicationSettings) 
		{
			_applicationSettings = applicationSettings;
		}

		public static IApplicationSettings GetApplicationSettings() 
		{
			Debug.Assert(_applicationSettings != null);
			return _applicationSettings;
		}
	}
}
