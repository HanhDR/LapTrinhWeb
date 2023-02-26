using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021067.DomainModels;
namespace _19T1021067.DataLayers
{/// <summary>
 /// định nghĩa phép xử lý dữ liệu liên quan đến quốc gia
 /// </summary>
    public interface ICountryDAL
    { /// <summary>
      /// lấy danh sách quốc gia
      /// </summary>
        IList<Country> List();
    }
}
