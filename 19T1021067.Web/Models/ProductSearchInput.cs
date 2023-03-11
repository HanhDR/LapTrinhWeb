using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021067.Web.Models
{
    public class ProductSearchInput :PagigationSearchInput
    {
        
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
    }
}