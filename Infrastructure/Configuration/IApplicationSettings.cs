using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HodorTutor.Infrastructure.Configuration 
{
	public interface IApplicationSettings 
	{
		bool IsDebug { get; }

		string SystemName { get; }

		string ConnectionString { get; }
	}
}
