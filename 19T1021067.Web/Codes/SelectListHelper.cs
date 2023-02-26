using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _19T1021067.BusinessLayers;
using _19T1021067.DomainModels;
using System.Web.Mvc;
namespace _19T1021067.Web
{
    /// <summary>
/// 
/// </summary>
    public static class SelectListHelper
    {
        /// <summary>
        /// Danh sách quốc gia
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> Countries()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
             Value="",
             Text="--Chọn quốc gia--"
            });
            foreach(var item in CommonDataService.ListOfCountries())
            {
                list.Add(new SelectListItem()
                {
                    Value=item.CountryName,
                    Text=item.CountryName
                });
            }
            return list;
        }

    }
}