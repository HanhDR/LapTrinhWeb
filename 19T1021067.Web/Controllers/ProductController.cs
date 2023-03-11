﻿using _19T1021067.BusinessLayers;
using _19T1021067.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19T1021067.Web.Controllers
{/// <summary>
 /// 
 /// </summary>
    [Authorize]
    [RoutePrefix("product")]
    public class ProductController : Controller
    {
        private const string PRODUCT_SEARCH = "ProductSearchCondition";
        private const int PAGE_SIZE = 5;
        /// <summary>
        /// Tìm kiếm, hiển thị mặt hàng dưới dạng phân trang
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Models.ProductSearchInput condition = Session[PRODUCT_SEARCH] as Models.ProductSearchInput;
            if (condition == null)
            {
                condition = new Models.ProductSearchInput()
                {
                    Page = 1,
                    PageSize = PAGE_SIZE,
                    SearchValue = "",
                    CategoryID = 0,
                    SupplierID=0
                    
                };
            }
            Session[PRODUCT_SEARCH] = condition;
            return View(condition);
        }
        public ActionResult Search(Models.ProductSearchInput condition)
        {
            int rowCount = 0;
            var data =ProductDataService.ListProducts(condition.Page, condition.PageSize,condition.SearchValue,condition.CategoryID,condition.SupplierID, out rowCount);
            Models.ProductSearchOutput result = new Models.ProductSearchOutput()
            {
                Page = condition.Page,
                PageSize = condition.PageSize,
                SearchValue = condition.SearchValue,
                RowCount = rowCount,
                Data = data
            };
            Session["ProductSearchCondition"] = condition;
            return View(result);
        }
        /// <summary>
        /// Tạo mặt hàng mới
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(Product data, HttpPostedFileBase uploadPhoto)
        {
            if (Request.HttpMethod == "GET")
            {
                ViewBag.Title = "Bổ sung khách hàng";
                return View(data);
            }
            if (string.IsNullOrWhiteSpace(data.ProductName))
                ModelState.AddModelError(nameof(data.ProductName), "*");
            if (string.IsNullOrWhiteSpace(data.Unit))
                ModelState.AddModelError(nameof(data.Unit), "*");
            if (data.Price==0)
                ModelState.AddModelError(nameof(data.Price), "*");
            if (data.CategoryID==0)
                ModelState.AddModelError(nameof(data.SupplierID), "*");
            if (data.SupplierID==0)
                ModelState.AddModelError(nameof(data.CategoryID), "*");
            data.Photo = data.Photo ?? "";
            if (ModelState.IsValid == false)
            {
              
                return View(data);
            }
            if (uploadPhoto != null)
            {
                string fileName = $"{DateTime.Now.Ticks}_{uploadPhoto.FileName}";
                string path = Server.MapPath("~/Images/Products");
                string filePath = System.IO.Path.Combine(path, fileName);
                uploadPhoto.SaveAs(filePath);
                data.Photo = $"Images/Products/{fileName}";
            }

             ProductDataService.AddProduct(data);


            return RedirectToAction("Index");
        }
        /// <summary>
        /// Cập nhật thông tin mặt hàng, 
        /// Hiển thị danh sách ảnh và thuộc tính của mặt hàng, điều hướng đến các chức năng
        /// quản lý ảnh và thuộc tính của mặt hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>        
        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
                return RedirectToAction("Index");

            var dataProduct = ProductDataService.GetProduct(id);
            if (dataProduct == null)
                return RedirectToAction("Index");

            var dataPhotos = ProductDataService.ListPhotos(id);
            var dataAttribute = ProductDataService.ListAttributes(id);

            Models.ProductEditModel result = new Models.ProductEditModel()
            {
                ProductID = dataProduct.ProductID,
                ProductName = dataProduct.ProductName,
                SupplierID = dataProduct.SupplierID,
                CategoryID = dataProduct.CategoryID,
                Unit = dataProduct.Unit,
                Price = dataProduct.Price,
                Photo = dataProduct.Photo,
                ListOfAttributes = dataAttribute,
                ListOfPhoto = dataPhotos,
            };

            return View(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="uploadPhoto"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken] //Xac dinh nguon data co tu form cua minh hay tu ngoai vao
        [HttpPost]
        public ActionResult Save(Product data, HttpPostedFileBase uploadPhoto)
        {
            if (uploadPhoto != null)
            {
                string fileName = $"{DateTime.Now.Ticks}_{uploadPhoto.FileName}";
                string path = Server.MapPath("~/Images/Products");
                string filePath = System.IO.Path.Combine(path, fileName);
                uploadPhoto.SaveAs(filePath);
                data.Photo = $"Images/Products/{fileName}";
            }

            bool result = ProductDataService.UpdateProduct(data);

            return RedirectToAction("Index");
        }
        /// <summary>
        /// Xóa mặt hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>        
        public ActionResult Delete(int id = 0)
        {
           if (Request.HttpMethod == "POST")
            {
                ProductDataService.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            var data = ProductDataService.GetProduct(id);
            if(data == null)
                return RedirectToAction("Index");

            return View(data);
        }

        /// <summary>
        /// Các chức năng quản lý ảnh của mặt hàng
        /// </summary>
        /// <param name="method"></param>
        /// <param name="productID"></param>
        /// <param name="photoID"></param>
        /// <returns></returns>
        [Route("photo/{method?}/{productID?}/{photoID?}")]
        public ActionResult Photo(string method = "add", int productID = 0, long photoID = 0)
        {
            var data = new ProductPhoto()
            {
                PhotoID = 0,
                ProductID = productID,
            };

            if (photoID > 0)
            {
             data = ProductDataService.GetPhoto(photoID);
            }
            switch (method)
            {
                case "add":
                    ViewBag.Title = "Bổ sung ảnh";
                    return View(data);
                case "edit":
                    ViewBag.Title = "Thay đổi ảnh";
                    return View(data);
                case "delete":
                    //ProductDataService.DeletePhoto(photoID);
                    ProductDataService.DeletePhoto(photoID);
                    return RedirectToAction($"Edit/{productID}"); //return RedirectToAction("Edit", new { productID = productID });
                default:
                    return RedirectToAction("Index");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="uploadPhoto"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken] //Xac dinh nguon data co tu form cua minh hay tu ngoai vao
        public ActionResult SavePhoto(ProductPhoto data, HttpPostedFileBase uploadPhoto)
        {
            if (uploadPhoto != null)
            {
                string fileName = $"{DateTime.Now.Ticks}_{uploadPhoto.FileName}";
                string path = Server.MapPath("~/Images/Products");
                string filePath = System.IO.Path.Combine(path, fileName);
                uploadPhoto.SaveAs(filePath);
                data.Photo = $"Images/Products/{fileName}";
            }


            if (data.PhotoID == 0)
            {
                ProductDataService.AddPhoto(data);
            }
            else
            {
                ProductDataService.UpdatePhoto(data);
            }

            return RedirectToAction($"Edit/{data.ProductID}");
        }


        /// <summary>
        /// Các chức năng quản lý thuộc tính của mặt hàng
        /// </summary>
        /// <param name="method"></param>
        /// <param name="productID"></param>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        [Route("attribute/{method?}/{productID}/{attributeID?}")]
        public ActionResult Attribute(string method = "add", int productID = 0, int attributeID = 0)
        {
            var data = new ProductAttribute();
            switch (method)
            {
                case "add":
                    data = new ProductAttribute()
                    {
                        AttributeID = 0,
                        ProductID = productID,
                    };
                    ViewBag.Title = "Bổ sung thuộc tính";
                    return View(data);
                case "edit":
                    data = ProductDataService.GetAttribute(attributeID);
                    ViewBag.Title = "Thay đổi thuộc tính";
                    return View(data);
                case "delete":
                    //ProductDataService.DeleteAttribute(attributeID);
                    ProductDataService.DeleteAttribute(attributeID);
                    return RedirectToAction($"Edit/{productID}"); //return RedirectToAction("Edit", new { productID = productID });
                default:
                    return RedirectToAction("Index");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken] //Xac dinh nguon data co tu form cua minh hay tu ngoai vao
        public ActionResult SaveAttibute(ProductAttribute data)
        {
            if (data.AttributeID == 0)
            {
                ProductDataService.AddAttribute(data);
            }
            else
            {
                ProductDataService.UpdateAttribute(data);
            }

            return RedirectToAction($"Edit/{data.ProductID}");
        }
    }
}