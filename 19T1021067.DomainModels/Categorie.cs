using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021067.DomainModels
{
    public class Categorie
    {
        /// <summary>
        /// id loại
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// tên loại
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        ///  mô tả
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ParentCategoryId { get; set; }

      
    }
}

