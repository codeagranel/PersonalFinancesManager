using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using System.Web.Http;
using PersonalFinancesManager.Repositories.Interfaces;
using PersonalFinancesManager.Repositories;

namespace PersonalFinancesManager
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            //Registrem as classes injetáveis aqui
            //Ex: container.RegisterType<ITestService, TestService>();            

            container.RegisterType<ICategories, Categories>();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            return container;
        }
    }
}