using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tillascope.Domain.Abstract;

namespace Tillascope.WebUI.Controllers
{
    public class CategoryListController : Controller
    {
        private IProductRepository repository;

        public CategoryListController(IProductRepository repo)
        {
            repository = repo;
        }
        // GET: CategoryList
        public PartialViewResult Menu(string category = null)
        {
            // Send the selected category to the view with viewbag.
            ViewBag.SelectedCategory = category;

            /*return ("Hello from the categoryList Controller");*/
            IEnumerable<string> categories = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}