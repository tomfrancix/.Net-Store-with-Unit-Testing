using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Tillascope.Domain.Abstract;
using Tillascope.Domain.Entities;
using Tillascope.Domain.Concrete;
using Ninject;
using System.Configuration;

namespace Tillascope.WebUI.Infrastructure
{

    //1.  Custom dependency resolver to instantiate objects across the application.
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //3. put bindings here
            kernel.Bind<IProductRepository>().To<EFProductRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                    .AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);
            /* Mock<IProductRepository> mock = new Mock<IProductRepository>();
             mock.Setup(m => m.Products).Returns(new List<Product>
             {
                 new Product { Name = "Michaela", Price = 25 },
                 new Product { Name = "Bernard", Price = 18 },
                 new Product { Name = "dfs", Price = 18 },
                 new Product { Name = "adfa", Price = 18 },
                 new Product { Name = "adfa", Price = 18 },
                 new Product { Name = "Maria", Price = 15 }
             });

             kernel.Bind<IProductRepository>().ToConstant(mock.Object);*/
        }
    }
    /*
     * 
     2. Now to make a bridge between this class and the MVC support for dependency injection
     *
     Go to App_Start/NinjectWebCommon.cs file
     *
    */
}