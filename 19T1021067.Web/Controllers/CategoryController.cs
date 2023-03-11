using _19T1021067.BusinessLayers;
using _19T1021067.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19T1021067.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private const string SUPPLIER_SEARCH = "CategorySearchCondition";
        private const int PAGE_SIZE = 5;
        //// GET: Category
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult Index(int page = 1,string searchValue="")
        //{
        //    int rowCount = 0;
        //    var data = CommonDataService.ListOfCategories(page, PAGE_SIZE, searchValue, out rowCount);
        //    int pageCount = rowCount / PAGE_SIZE;
        //    if (rowCount % PAGE_SIZE > 0)
        //        pageCount += 1;
        //    ViewBag.Page = page;
        //    ViewBag.RowCount = rowCount;
        //    ViewBag.PageCount = pageCount;
        //    ViewBag.SearchValue = searchValue;
        //    return View(data);//truyen du lieu bang Model

        //}
        public ActionResult Index()
        {
            Models.PagigationSearchInput condition = Session[SUPPLIER_SEARCH] as Models.PagigationSearchInput;
            if (condition == null)
            {
                condition = new Models.PagigationSearchInput()
                {
                    Page = 1,
                    PageSize = PAGE_SIZE,
                    SearchValue = ""
                };
            }

            return View(condition);
        }
        public ActionResult Search(Models.PagigationSearchInput condition)
        {
            int rowCount = 0;
            var data = CommonDataService.ListOfCategories(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);
            Models.CategorySearchOutput result = new Models.CategorySearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };
            Session["CategorySearchCondition"] = condition;
            return View(result);
        }
        public ActionResult Create()
        {

            var data = new Categorie()
            {
                CategoryID = 0,

            };
            ViewBag.Title = "Bổ sung loại hàng";
            return View("Edit",data);
        }
        public ActionResult Delete(int id=0)
        {
            if (id <= 0)
                return RedirectToAction("Index");
            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetCategory(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            return View(data);
           
        }
        public ActionResult Edit(int id=0)
        {
            if (id <= 0)
                return RedirectToAction("Index");
            var data = CommonDataService.GetCategory(id);
            if (data == null)
                return RedirectToAction("Index");


            ViewBag.Title = "Cập nhật loại hàng";
            return View(data);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
      
        public ActionResult Save(Categorie data)
        {
            //Kiểm soát dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(data.CategoryName))
                ModelState.AddModelError(nameof(data.CategoryName), "*");
            if (string.IsNullOrWhiteSpace(data.Description))
                ModelState.AddModelError(nameof(data.Description), "*");
 
          
            if (ModelState.IsValid == false)
            {
                ViewBag.Title = data.CategoryID == 0 ? "Bổ sung loại hàng" : "Cập nhật loại hàng";
                return View("Edit", data);
            }
            if (data.CategoryID == 0)
            {
                CommonDataService.AddCategory(data);
            }
            else
            {
                CommonDataService.UpdateCategory(data);
            }
            return RedirectToAction("Index");
        }
    }
}