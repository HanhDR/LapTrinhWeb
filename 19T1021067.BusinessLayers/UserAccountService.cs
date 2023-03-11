using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021067.DataLayers;
using _19T1021067.DomainModels;
namespace _19T1021067.BusinessLayers
{
    /// <summary>
    /// Các chức năng tắc nghiệp liên quan đến tài khoản
    /// </summary>
   public static class UserAccountService
    {
        private static IUserAccountDAL employeeAccountDB;
        private static IUserAccountDAL customerAccountDB;
        
        static UserAccountService()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            employeeAccountDB = new DataLayers.SQLServer.EmployeeAccountDAL(connectionString);
            customerAccountDB = new DataLayers.SQLServer.CustomerAccountDAL(connectionString);
        }
        public static UserAccount Authorize(AccountTypes accountTypes,string userName,string password)
        {
            if (accountTypes == AccountTypes.Employee)
                return employeeAccountDB.Authorize(userName, password);
            else
                return customerAccountDB.Authorize(userName, password);
        }
        public static bool ChangePassword(AccountTypes accountTypes,string userName,string oldPassword,string newPassword)
        {
            if (accountTypes == AccountTypes.Employee)
                return employeeAccountDB.ChangePassword(userName, oldPassword, newPassword);
            else
                return customerAccountDB.ChangePassword(userName, oldPassword, newPassword);
        }
    }
}
