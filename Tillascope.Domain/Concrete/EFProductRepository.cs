using Tillascope.Domain.Abstract;
using Tillascope.Domain.Entities;
using System.Collections.Generic;

namespace Tillascope.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products;  }
        }
    }
}
