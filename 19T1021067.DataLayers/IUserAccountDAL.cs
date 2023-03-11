using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021067.DomainModels;
namespace _19T1021067.DataLayers
{
    /// <summary>
    /// Định nghĩa các phép xử lý dữ liệu liên quan đến tài khoản của người dùng
    /// 
    /// </summary>
    public  interface IUserAccountDAL
       
    {
        /// <summary>
        /// Kiểm tra xem tên đăng nhập và mật khẩu người dùng có hợp lệ ?
        /// Nếu hợp lệ thì trả về thông tin người dùng,ngược lại
        /// thì trả về null
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserAccount Authorize(string userName, string password);
        /// <summary>
        /// Đổi mật khẩu người dùng
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="oldPassword"></param>
        /// <param name="nowPassword"></param>
        /// <returns></returns>
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }
}
