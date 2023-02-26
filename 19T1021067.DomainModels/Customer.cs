using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021067.DomainModels
{
    public class Customer
    {
        /// <summary>
        /// id người dùng
        /// </summary>
        public int CustomerID { get; set; }
        /// <summary>
        /// teen người dùng
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        ///  địa chỉ
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        ///  địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        ///mã bưu điện
        /// </summary>
        public string City { get; set; }
        /// <summary>
        ///mã bưu điện
        /// </summary>
        public String PostalCode { get; set; }
        /// <summary>
        /// quốc gia
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }

       
    }
}
