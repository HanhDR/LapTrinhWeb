using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021067.Web.Models
{
    public class OrderSearchIntput :PagigationSearchInput
    {
        public int Status { get; set; }
    }
}