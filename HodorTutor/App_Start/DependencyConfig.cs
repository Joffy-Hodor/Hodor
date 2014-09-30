using HodorTutor.Infrastructure.Configuration;
using HodorTutor.Infrastructure.UnitOfWork;
using HodorTutor.Model.Announces;
using HodorTutor.Model.Provinces;
using HodorTutor.Model.Tutors;
using HodorTutor.Model.Users;
using HodorTutor.Repository.NHibernate;
using HodorTutor.Repository.NHibernate.Repositories;
using HodorTutor.Services.Implementations;
using HodorTutor.Services.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HodorTutor
{
    public class DependencyConfig
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            // Unity ServiceLocator
            var serviceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);

            // MVC
            DependencyResolver.SetResolver(new Unity.Mvc3.UnityDependencyResolver(container));

            // WebAPI
            //GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
			//GlobalConfiguration.Configuration.Formatters
			//GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            //configure
            container.RegisterType<IApplicationSettings, WebConfigApplicationSettings>();
            container.RegisterType<ITransaction, NHTransaction>();
            container.RegisterType<IUnitOfWork, NHUnitOfWork>();

            ////service
            container.RegisterType<ITutorService, TutorService>();
            container.RegisterType<IProvinceService, ProvinceService>();
            container.RegisterType<IAnnounceService, AnnounceService>();

            ////repository
            container.RegisterType<ITutorRepository, TutorRepository>();
            container.RegisterType<IProvinceRepository, ProvinceRepository>();
            container.RegisterType<IAnnounceRepository, AnnounceRepository>();
            container.RegisterType<IUserProfileRepository, UserProfileRepository>();

            return container;
        }
    }
}