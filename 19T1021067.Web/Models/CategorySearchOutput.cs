using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _19T1021067.DomainModels;
namespace _19T1021067.Web.Models
{
    public class CategorySearchOutput : PaginationSearchOutput
    {
        public List<Categorie> Data { get; set; }
    }
}