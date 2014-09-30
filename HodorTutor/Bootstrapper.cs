using HodorTutor.Infrastructure.Configuration;
using HodorTutor.Infrastructure.UnitOfWork;
using HodorTutor.Model.Tutors;
using HodorTutor.Repository.NHibernate;
using HodorTutor.Repository.NHibernate.Repositories;
using HodorTutor.Services.Implementations;
using HodorTutor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Configuration.DSL;
using HodorTutor.Infrastructure.Mapping.Mappers;

namespace HodorTutor
{
    public static class Bootstrapper
    {
       public static void ConfigureDependencies() 
		{
			ObjectFactory.Initialize(x => {
				x.AddRegistry<ControllerRegistry>();
				
				x.PullConfigurationFromAppConfig = true; 
			});
		}

		public class ControllerRegistry : Registry 
		{
            public ControllerRegistry()
            {
                // AppConfig
                For<IApplicationSettings>().Use<WebConfigApplicationSettings>();
                For<IMapper>().Use<AutoMappersMapper>();

                //IUnitOfWork
                For<IUnitOfWork>().Use<NHUnitOfWork>();

                ////service
                For<ITutorService>().Use<TutorService>();

                ////repository
                For<ITutorRepository>().Use<TutorRepository>();
            }
        }
    }
}