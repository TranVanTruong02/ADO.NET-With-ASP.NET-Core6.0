using CuaHangDienThoaiWebservice.Models;
using MySql.Data.MySqlClient;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CuaHangDienThoaiWebservice.Connections
{
    public class ConnectProductType
    {
        // Lấy tất cả loại sản phẩm
        public Response productTpyeAll(MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand sql = new MySqlCommand("sp_productType_all", connection);
            sql.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql);

            // Sau khi lấy xong dữ liệu ta sẽ tạo ra 1 bảng dữ liệu mới
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            // Khởi tạo mảng hứng dữ liệu
            List<ProductType> arrayProductType = new List<ProductType>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    ProductType type = new ProductType();
                    type.idloai = Convert.ToInt32(dataTable.Rows[i]["idloai"]);
                    type.tenloai = Convert.ToString(dataTable.Rows[i]["tenloai"]);
                    // Gán dữ liệu vào mảng
                    arrayProductType.Add(type);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayProductType.Count > 0)
            {
                // Thông báo thành công
                response.StatusCode = 200;
                response.StatusMessage = "Danh sách tất cả loại sản phẩm";
                response.arrayProductType = arrayProductType;
                return response;
            }
            else
            {
                return null;
            }
        }
        public Response getProductTypeId(MySqlConnection connection, int idloai)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("type_typechitiet", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idloai", idloai);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            // Mở kết nối
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            List<ProductType> arrayProductType = new List<ProductType>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    ProductType type = new ProductType();
                    type.idloai = Convert.ToInt32(dataTable.Rows[i]["idloai"]);
                    type.tenloai = Convert.ToString(dataTable.Rows[i]["tenloai"]);
                    // Gán dữ liệu vào mảng
                    arrayProductType.Add(type);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayProductType.Count > 0)
            {
                // Thông báo thành công
                response.StatusCode = 200;
                response.StatusMessage = "Danh sách tất cả loại sản phẩm";
                response.arrayProductType = arrayProductType;
                return response;
            }
            else
            {
                return null;
            }
        }

        public Response addType(ProductType productType, MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("sp_type", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_tenloai", productType.tenloai);
            // Mở kết nối
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Thêm Loai mới thành công";
                return response;
            }
            else
            {
                return null;
            }
        }

        public Response updateType(ProductType productType, MySqlConnection connection, int idloai)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("type_update", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idloai", idloai);
            command.Parameters.AddWithValue("IN_tenloai", productType.tenloai);
            // Mở kết nối
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Cập nhật  thành công";
                return response;
            }
            else
            {
                return null;
            }
        }

        public Response deleteproductType(MySqlConnection connection, int idLoai)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("type_delete", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idsp", idLoai);
            // Mở kết nối
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Xóa thành công";
                return response;
            }
            else
            {
                return null;
            }
        }
    }
}
