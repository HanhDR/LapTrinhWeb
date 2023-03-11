using _19T1021067.DataLayers;
using _19T1021067.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace _19T1021067.BusinessLayers
{
    /// <summary>
    /// cung cấp các chức năng nghiệp vụ xử lý dữ liêu chung liên quan đến:
    /// quốc gia , nhà cung cấp , khách hàng , người giao hàng, nhân viên , loại hàng
    /// </summary>
    public class CommonDataService
    {
        private static ICountryDAL countryDB;
        private static ICommonDAL<Supplier> supplierDB;
        private static ICommonDAL<Employee> employeeDB;
        private static ICommonDAL<Categorie> categoryDB;
        private static ICommonDAL<Shipper> shipperDB;
        private static ICommonDAL<Customer> customerDB;

        /// <summary>
        /// Contructer
        /// </summary>
        static CommonDataService()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            countryDB = new DataLayers.SQLServer.CountryDAL(connectionString);
            supplierDB = new DataLayers.SQLServer.SupplierDAL(connectionString);
            employeeDB = new DataLayers.SQLServer.EmployeeDAL(connectionString);
            categoryDB = new DataLayers.SQLServer.CategorieDAL(connectionString);
            shipperDB =  new DataLayers.SQLServer.ShipperDAL(connectionString);
            customerDB = new DataLayers.SQLServer.CustomerDAL(connectionString);
        }

        #region xuwe lý liên quan đến quốc gia
        public static List<Country> ListOfCountries()
        {
            return countryDB.List().ToList();
        }
       
        /// <summary>
        /// Nha Cung Cap
        /// tim kiem lay danh sach nha cung cap co phan trang
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(int page,int pageSize,string searchValue,out int rowCount)
        {
            rowCount = supplierDB.Count(searchValue);
            return supplierDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// tim kiem va lay danh sach nha cung cap (khong phan trang)
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers(string searchValue = "")
        {
            
            return supplierDB.List(1,0,searchValue).ToList();
        }
        /// <summary>
        /// lay thonbg tin cua 1 nha cung cap dua vao ma
        /// </summary>
        /// <param name="SupplierID"></param>
        /// <returns></returns>
        public static Supplier GetSupplier(int supplierID)
        {
            return supplierDB.Get(supplierID);
        }
        /// <summary>
        /// bo sung  nha cung cap,ham tra ve ma nha cung cap duoc bo sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddSupplier(Supplier data)
        {
            return supplierDB.Add(data);
        }
        
        /// <summary>
        /// Cap nhat nha cung cap
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateSupplier(Supplier data)
        {
            return supplierDB.Update(data);
        }
        /// <summary>
        /// Xoa nha cung cap
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static bool DeleteSupplier(int supplierID)
        {
            return supplierDB.Delete(supplierID);
        }
        /// <summary>
        /// kiem tra xem nha cung cap co du lieu lien quan hay khong
        /// </summary>
        /// <param name="supplerID"></param>
        /// <returns></returns>
        public static bool InUseSupplier(int supplerID)
        {
            return supplierDB.InUsed(supplerID);
        }
        #endregion
        /// <summary>
        /// Khach Hang
        /// timf kieem lay danh sach khach hang co phan trang
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers(int page,int pageSize,string searchValue,out int rowCount)
        {
            rowCount = customerDB.Count(searchValue);
            return customerDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// timf kieem lay danh sach khach hang khong phan trang
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers(string searchValue = "")
        {
            return customerDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// lay thonbg tin cua 1 khach hang dua vao ma
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static Customer GetCustomer(int customerID)
        {
            return customerDB.Get(customerID);
        }
        /// <summary>
        /// Bo sung khach hang ,ham tra ve ma khach hang duoc bo sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCustomer(Customer data)
        {
            return customerDB.Add(data);
        }
        /// <summary>
        /// Cap nhat thong tin khach hang
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
         public static bool UpdateCustomer(Customer data) {
            return customerDB.Update(data);
        }
        /// <summary>
        /// Xoa thong tin khach hang
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool DeleteCustomer(int customerID)
        {
            return customerDB.Delete(customerID);
        }
        /// <summary>
        /// Kiem tra xem khach hang co du lieu lien quan hay khong
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool InUseCustomer(int customerID)
        {
            return customerDB.InUsed(customerID);
        }
        /// <summary>
        /// Loai Hang
        ///  tim kiem va lay danh sach loai hang (phan trang)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Categorie> ListOfCategories(int page, int pageSize, string searchValue, out int rowCount)
        {

            rowCount = categoryDB.Count(searchValue);
            return categoryDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// tim kiem va lay danh sach loai hang (khong phan trang)
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Categorie> ListOfCategories(string searchValue = "")
        {
            return categoryDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// lay thon tin cua 1 loai hang 
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static Categorie GetCategory(int categoryID)
        {
            return categoryDB.Get(categoryID);
        }
        /// <summary>
        /// bo sung thong tin loai hang
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCategory(Categorie data)
        {
            return categoryDB.Add(data);
        }
        /// <summary>
        /// Cap nhat thong tin loai hang
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCategory(Categorie data)
        {
            return categoryDB.Update(data);
        }
        /// <summary>
        /// xoa loai hang
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static bool DeleteCategory(int categoryID)
        {
            return categoryDB.Delete(categoryID);
        }
        /// <summary>
        /// kiem tra xem 1 loai hang co du lieu lien quan hay khong
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static bool InUseCategory(int categoryID)
        {
            return categoryDB.InUsed(categoryID);
        }
        /// <summary>
        /// Nhan Vien
        /// Tim kiem va lay danh sach nhan vien (phan trang)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(int page, int pageSize, string searchValue, out int rowCount)
        {

            rowCount = employeeDB.Count(searchValue);
            return employeeDB.List(page, pageSize, searchValue).ToList();
        }

    /// <summary>
    /// tim kiem va lay danh sach nhan vien (co phan trang)
    /// </summary>
    /// <param name="searchValue"></param>
    /// <returns></returns>
        public static List<Employee> ListOfEmployees(string searchValue = "")
        {
            return employeeDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// lay 1 thong tin nhan vien
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static Employee GetEmployee(int employeeID)
        {
            return employeeDB.Get(employeeID);
        }
        /// <summary>
        /// Bo sung nhan vien
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddEmployee(Employee data)
        {
            return employeeDB.Add(data);
        }
        /// <summary>
        /// cap nhat thong tin nhan vien
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateEmployee(Employee data)
        {
            return employeeDB.Update(data);
        }
        /// <summary>
        /// xoa nhan vien
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static bool DeleteEmployee(int employeeID)
        {
            return employeeDB.Delete(employeeID);
        }
        /// <summary>
        /// kiem tra xem 1 nhan vien hien co du lieu lien quan hay khong
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static bool InUseEmployee(int employeeID)
        {
            return employeeDB.InUsed(employeeID);
        }
        /// <summary>
        /// Shippeer
        /// Tim kiem va lay danh sach nguoi giao hang(co phan trang)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers(int page, int pageSize, string searchValue, out int rowCount)
        {

            rowCount =shipperDB.Count(searchValue);
            return shipperDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// Tim kiem va lay danh sach nguoi giao hang(khong phan trang)
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers(string searchValue = "")
        {
            return shipperDB.List(1, 0, searchValue).ToList();
        }
        /// <summary>
        /// lay thong tin 1 nguoi giao hang
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static Shipper GetShipper(int shipperID)
        {
            return shipperDB.Get(shipperID);
        }
        /// <summary>
        /// Bo sung nguoi giao hang
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddShipper(Shipper data)
        {
            return shipperDB.Add(data);
        }
        /// <summary>
        /// cap nhat nguoi giao hang
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateShipper(Shipper data)
        {
            return shipperDB.Update(data);
        }
        /// <summary>
        /// Xoa shipper
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static bool DeleteShipper(int shipperID)
        {
            return shipperDB.Delete(shipperID);
        }
        /// <summary>
        /// Kiem tra xem 1 shipper hien co du lieu lien quan hay khong
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static bool InUseShipper(int shipperID)
        {
            return shipperDB.InUsed(shipperID);
        }

       

    }

}
