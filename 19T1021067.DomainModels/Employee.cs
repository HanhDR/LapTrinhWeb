using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021067.DomainModels
{
    public class Employee
    {
        /// <summary>
        /// id nhân viên
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        /// teen nhan vien
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        ///  ho nhan vien
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        ///ngay sinh
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// ảnh
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// ghi chú
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }

        public string Phone { get; set; }

        public static int Count(string searchValue)
        {
            throw new NotImplementedException();
        }
    }
}
