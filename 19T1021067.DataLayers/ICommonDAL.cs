using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19T1021067.DomainModels;
namespace _19T1021067.DataLayers
{/// <summary>
 /// định nghĩa các phép xử lý dữ liệu chung
 /// </summary>
    public interface ICommonDAL<T> where T : class
    {
        /// <summary>
        /// tìm kiếm và hiển thị danh sách dữ liệu dưới dạng phân trang(pagination)
        /// </summary>
        /// <param name="page">trang cần hiển thị</param>
        /// <param name="pageSize">số dòng xử lý trên mỗi trang(bằng 0 nếu không phân trang)</param>
        /// <param name="searchValue">giá trị cần tìm(chuỗi rỗng nếu không tìm kiếm)</param>
        /// <returns></returns>
        IList<T> List(int page = 1, int pageSize = 0, string searchValue = "");
        int Count(string searchValue = "");
        /// <summary>
        /// lấy một dòng dữ liệu  dựa vào id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);
        /// <summary>
        /// bổ sung dữ liệu vào csdl
        /// </summary>
        /// <param name="data"></param>
        /// <returns>ID của dữ liêu vừa được bổ sung</returns>
        int Add(T data);
        /// <summary>
        /// cập nhật dữ liêu
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(T data);
        /// <summary>
        /// xóa dữ liệu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// kiểm tra xem hiện có dữ liệu khác liên quan dến dữ liệu có mã là id hay không
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool InUsed(int id);
        
    }
}
