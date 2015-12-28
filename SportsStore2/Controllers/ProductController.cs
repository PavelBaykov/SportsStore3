using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.Abstract;


namespace SportsStore2.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repo;
        // GET: Product

        private int pageSize=4;
        public ProductController(IProductRepository repository)
        {
            this.repo = repository;
        }
        public ViewResult List(int page = 1)
        {
            return View(this.repo.Products.OrderBy(p => p.ProductID).Skip((page - 1)*pageSize).Take(pageSize));
            //return View(repo.Products);
        }
    }
}