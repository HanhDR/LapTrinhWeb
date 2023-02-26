using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021067.DomainModels
{  /// <summary>
/// nhà cung cấp
/// </summary>
    public class Supplier
    {/// <summary>
     /// id
     /// </summary>
        public int SupplierID { get; set; }
        /// <summary>
        /// teen ncc
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        ///  tên liên hệ
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// đia chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// thành phố
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// mã bưu điện
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// quốc gia
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// điện thoại
        /// </summary>
        public string Phone { get; set; }
    }
}
