using _19T1021067.BusinessLayers;
using _19T1021067.DomainModels;
using System;
using System.Web;
using System.Web.Mvc;

namespace _19T1021067.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private const string SUPPLIER_SEARCH = "EmployeeSearchCondition";
        private const int PAGE_SIZE = 5;
        //// GET: Employee
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult Index(int page = 1,string searchValue="")
        //{
        //    int rowCount = 0;
        //    var data = CommonDataService.ListOfEmployees(page, PAGE_SIZE, searchValue, out rowCount);
        //    int pageCount = rowCount / PAGE_SIZE;
        //    if (rowCount % PAGE_SIZE > 0)
        //        pageCount += 1;
        //    ViewBag.Page = page;
        //    ViewBag.RowCount = rowCount;
        //    ViewBag.PageCount = pageCount;
        //    ViewBag.SearchValue = searchValue;
        //    return View(data);//
        //    return View();
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
            var data = CommonDataService.ListOfEmployees(condition.Page, condition.PageSize, condition.SearchValue, out rowCount);
            Models.EmployeeSearchOutput result = new Models.EmployeeSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };
            Session["EmployeeSearchCondition"] = condition;
            return View(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var data = new Employee()
            {
               EmployeeID = 0,

            };
            ViewBag.Title = "Bổ sung nhân viên";
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
            var data = CommonDataService.GetEmployee(id);
            if (data == null)
                return RedirectToAction("Index");


            ViewBag.Title = "Cập nhật thông tin nhân viên";
            return View(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Employee data,string birthday,HttpPostedFileBase uploadPhoto)
        {
            DateTime? d = Converter.DMYStringtoDataTime(birthday);
            if (d == null)
                ModelState.AddModelError("BirthDate", "*");
            else
                data.BirthDate = d.Value;
            //Kiểm soát dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(data.LastName))
                ModelState.AddModelError(nameof(data.LastName), "*");
            if (string.IsNullOrWhiteSpace(data.FirstName))
                ModelState.AddModelError(nameof(data.FirstName), "*");
            if (string.IsNullOrWhiteSpace(data.BirthDate.ToString()))
                 ModelState.AddModelError(nameof(data.BirthDate), "*");
            if (string.IsNullOrWhiteSpace(data.Email))
                ModelState.AddModelError(nameof(data.Email), "*");
            data.Notes = data.Notes?? "";
            data.Photo = data.Photo?? "";

            
            if (ModelState.IsValid == false)
            {
                ViewBag.Title = data.EmployeeID== 0 ? "Bổ sung nhân viên" : "Cập nhật nhân viên";
                return View("Edit", data);
            }
            if(uploadPhoto != null)
            {
                string path = Server.MapPath("~/Images/Employees");
                string fileName = $"{DateTime.Now.Ticks}_{uploadPhoto.FileName}";
                string filePath = System.IO.Path.Combine(path, fileName);
                uploadPhoto.SaveAs(filePath);
                data.Photo = $"Images/Employees/{fileName}";
            }
            if (data.EmployeeID == 0)
            {
                CommonDataService.AddEmployee(data);
            }
            else
            {
                CommonDataService.UpdateEmployee(data);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id=0)
        {
            if (id <= 0)
                return RedirectToAction("Index");
            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            var data = CommonDataService.GetEmployee(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            return View(data);
           
        }
    }
}