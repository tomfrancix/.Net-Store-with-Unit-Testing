using System;
using System.Collections.Generic;
using Tillascope.Domain.Entities;

namespace Tillascope.Domain.Abstract
{
    /*
        This "ABSTRACT" interface allows a caller to obtain a sequence of Product objects, without saying how or where the data is stored or retrieved. 
    */
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
