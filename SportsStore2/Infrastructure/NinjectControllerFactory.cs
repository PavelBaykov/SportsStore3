using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Models;
using Models.Abstract;
using Models.Concrete;
using Moq;
using Ninject;

namespace SportsStore2.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel=new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext,
            Type controllerType)
        {
            // получение объекта контроллера из контейнера
            // используя его тип
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }

        public void AddBindings()
        {
            /*Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                new List<Product>()
                {
                    new Product()
                    {
                        Name = "Ball",
                        Category = "Soccer",
                        Description = "Ball description",
                        Price = 112,
                        ProductID = 1
                    }
                }.AsQueryable());

            ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);
            */

            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}