using System.Web.Mvc;
using ExpenseTrackerSystem.Controllers;
using ExpenseTrackerSystem.Interface;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace ExpenseTrackerSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IExpenseRepo,IExpenseRepo>();
            container.RegisterType<AccountController>(new InjectionConstructor());

            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}