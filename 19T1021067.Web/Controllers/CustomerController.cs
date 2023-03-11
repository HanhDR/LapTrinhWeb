using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _19T1021067.DomainModels;
using _19T1021067.BusinessLayers;
namespace _19T1021067.Web.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private const string CUSTOMER_SEARCH = "CustomerSearchCondition";
        private const int PAGE_SIZE = 10;
        // GET: Customer
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult Index(int page = 1, string searchValue = "")

        //{
        //    int rowCount = 0;
        //    var data = CommonDataService.ListOfCustomers(page, PAGE_SIZE, searchValue, out rowCount);
        //    int pageCount = rowCount / PAGE_SIZE;
        //    if (rowCount % PAGE_SIZE > 0)
        //        pageCount += 1;
        //    ViewBag.Page = page;
        //    ViewBag.RowCount = rowCount;
        //    ViewBag.PageCount = pageCount;
        //    ViewBag.SearchValue = searchValue;
        //    return View(data);//truyen du lieu bang Model

        //}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Models.PagigationSearchInput condition = Session[CUSTOMER_SEARCH] as Models.PagigationSearchInput;
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
            var data = CommonDataService.ListOfCustomers(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);
            Models.CustomerSearchOutput result = new Models.CustomerSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };
            Session["CustomerSearchCondition"] = condition;
            return View(result);
        }
        public ActionResult Create()
        {
            var data = new Customer()
            {
                CustomerID = 0,

            };
            ViewBag.Title = "Bổ sung khách hàng";

            return View("Edit",data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id=0)

        {
            if (id <= 0)
                return RedirectToAction("Index");
            var data = CommonDataService.GetCustomer(id);
            if (data == null)
                return RedirectToAction("Index");

            ViewBag.Title = "Cập nhật khách hàng";
            return View(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Customer data)
        {
            //Kiểm soát dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(data.CustomerName))
                ModelState.AddModelError(nameof(data.CustomerName), "*");
            if (string.IsNullOrWhiteSpace(data.ContactName))
                ModelState.AddModelError(nameof(data.ContactName), "*");
            if (string.IsNullOrWhiteSpace(data.Country))
                ModelState.AddModelError(nameof(data.Country), "Vui lòng chọn quốc gia");
            if (string.IsNullOrWhiteSpace(data.Email))
                ModelState.AddModelError(nameof(data.Email), "*");
            data.Address = data.Address ?? "";
            data.City = data.City ?? "";
            data.PostalCode = data.PostalCode ?? "";
            if (ModelState.IsValid == false)
            {
                ViewBag.Title = data.CustomerID == 0 ? "Bổ sung khách hàng" : "Cập nhật khách hàng";
                return View("Edit", data);
            }
            if (data.CustomerID== 0)
            {
                CommonDataService.AddCustomer(data);
            }
            else
            {
                CommonDataService.UpdateCustomer(data);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id=0)
        {
            if (id <= 0)
                return RedirectToAction("Index");
            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteCustomer(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetCustomer(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            return View(data);
            
        }

    }
}