using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Tillascope.WebUI.Models
{
    // This 'view model' is not part of the domain model. 
    
    // Its just a convenient place for passing data between the controller and the view.
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
        get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}