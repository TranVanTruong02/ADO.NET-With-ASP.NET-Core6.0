using CuaHangDienThoaiWebservice.Models;
using MySql.Data.MySqlClient;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CuaHangDienThoaiWebservice.Connections
{
    public class ConnectProduct
    {
        public Response productAll(MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand sql = new MySqlCommand("sp_product_all", connection);
            sql.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql);

            // Sau khi lấy xong dữ liệu ta sẽ tạo ra 1 bảng dữ liệu mới
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            // Khởi tạo mảng hứng dữ liệu
            List<Product> arrayproducts = new List<Product>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Product pro = new Product();
                    pro.idsp = Convert.ToInt32(dataTable.Rows[i]["idsp"]);
                    pro.idloai = Convert.ToInt32(dataTable.Rows[i]["idloai"]);
                    pro.anhsp = Convert.ToString(dataTable.Rows[i]["anhsp"]);
                    pro.tensp = Convert.ToString(dataTable.Rows[i]["tensp"]);
                    pro.giasp = Convert.ToDouble(dataTable.Rows[i]["giasp"]);
                    pro.thongtinsp = Convert.ToString(dataTable.Rows[i]["thongtinsp"]);
                    pro.slsanpham = Convert.ToInt32(dataTable.Rows[i]["slsanpham"]);
                    // Gán dữ liệu vào mảng
                    arrayproducts.Add(pro);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayproducts.Count > 0)
            {
                // Thông báo thành công
                response.StatusCode = 200;
                response.StatusMessage = "Danh sách tất cả sản phẩm";
                response.arrayProduct = arrayproducts;
                return response;
            }
            else
            {
                return null;
            }
        }

        // Lấy ra 15 sản phẩm mới nhất
        public Response productnew(MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand sql = new MySqlCommand("sp_product_new", connection);
            sql.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql);

            // Sau khi lấy xong dữ liệu ta sẽ tạo ra 1 bảng dữ liệu mới
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            // Khởi tạo mảng hứng dữ liệu
            List<Product> arrayproducts = new List<Product>();
            if (dataTable.Rows.Count > 0) 
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Product pro = new Product();
                    pro.idsp = Convert.ToInt32(dataTable.Rows[i]["idsp"]);
                    pro.idloai = Convert.ToInt32(dataTable.Rows[i]["idloai"]);
                    pro.anhsp = Convert.ToString(dataTable.Rows[i]["anhsp"]);
                    pro.tensp = Convert.ToString(dataTable.Rows[i]["tensp"]);
                    pro.giasp = Convert.ToDouble(dataTable.Rows[i]["giasp"]);
                    pro.thongtinsp = Convert.ToString(dataTable.Rows[i]["thongtinsp"]);
                    pro.slsanpham = Convert.ToInt32(dataTable.Rows[i]["slsanpham"]);
                    // Gán dữ liệu vào mảng
                    arrayproducts.Add(pro);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayproducts.Count > 0)
            {
                // Thông báo thành công
                response.StatusCode = 200;
                response.StatusMessage = "Top 15 sản phẩm mới nhất";
                response.arrayProduct = arrayproducts;
                return response;
            }
            else
            {
                return null;
            }
        }

        // Lấy ra 5 sản phẩm laptop mới nhất
        public Response laptopnew(MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand sql = new MySqlCommand("sp_laptop_new", connection);
            sql.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql);

            // Sau khi lấy xong dữ liệu ta sẽ tạo ra 1 bảng dữ liệu mới
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            // Khởi tạo mảng hứng dữ liệu
            List<Product> arrayproducts = new List<Product>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Product pro = new Product();
                    pro.idsp = Convert.ToInt32(dataTable.Rows[i]["idsp"]);
                    pro.idloai = Convert.ToInt32(dataTable.Rows[i]["idloai"]);
                    pro.anhsp = Convert.ToString(dataTable.Rows[i]["anhsp"]);
                    pro.tensp = Convert.ToString(dataTable.Rows[i]["tensp"]);
                    pro.giasp = Convert.ToDouble(dataTable.Rows[i]["giasp"]);
                    pro.thongtinsp = Convert.ToString(dataTable.Rows[i]["thongtinsp"]);
                    pro.slsanpham = Convert.ToInt32(dataTable.Rows[i]["slsanpham"]);
                    // Gán dữ liệu vào mảng
                    arrayproducts.Add(pro);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayproducts.Count > 0)
            {
                // Thông báo thành công
                response.StatusCode = 200;
                response.StatusMessage = "Top 5 sản phẩm laptop mới nhất";
                response.arrayProduct = arrayproducts;
                return response;
            }
            else
            {
                return null;
            }
        }

        // Lấy ra toàn bộ sản phẩm là điện thoại
        public Response smartphone(MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand sql = new MySqlCommand("sp_smartphone", connection);
            sql.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql);

            // Sau khi lấy xong dữ liệu ta sẽ tạo ra 1 bảng dữ liệu mới
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            // Khởi tạo mảng hứng dữ liệu
            List<Product> arrayproducts = new List<Product>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Product pro = new Product();
                    pro.idsp = Convert.ToInt32(dataTable.Rows[i]["idsp"]);
                    pro.idloai = Convert.ToInt32(dataTable.Rows[i]["idloai"]);
                    pro.anhsp = Convert.ToString(dataTable.Rows[i]["anhsp"]);
                    pro.tensp = Convert.ToString(dataTable.Rows[i]["tensp"]);
                    pro.giasp = Convert.ToDouble(dataTable.Rows[i]["giasp"]);
                    pro.thongtinsp = Convert.ToString(dataTable.Rows[i]["thongtinsp"]);
                    pro.slsanpham = Convert.ToInt32(dataTable.Rows[i]["slsanpham"]);
                    // Gán dữ liệu vào mảng
                    arrayproducts.Add(pro);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayproducts.Count > 0)
            {
                // Thông báo thành công
                response.StatusCode = 200;
                response.StatusMessage = "Toàn bộ sản phẩm điện thoại";
                response.arrayProduct = arrayproducts;
                return response;
            }
            else
            {
                return null;
            }
        }

        // Lấy ra toàn bộ sản phẩm là laptop
        public Response laptop(MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand sql = new MySqlCommand("sp_laptop", connection);
            sql.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql);

            // Sau khi lấy xong dữ liệu ta sẽ tạo ra 1 bảng dữ liệu mới
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            // Khởi tạo mảng hứng dữ liệu
            List<Product> arrayproducts = new List<Product>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Product pro = new Product();
                    pro.idsp = Convert.ToInt32(dataTable.Rows[i]["idsp"]);
                    pro.idloai = Convert.ToInt32(dataTable.Rows[i]["idloai"]);
                    pro.anhsp = Convert.ToString(dataTable.Rows[i]["anhsp"]);
                    pro.tensp = Convert.ToString(dataTable.Rows[i]["tensp"]);
                    pro.giasp = Convert.ToDouble(dataTable.Rows[i]["giasp"]);
                    pro.thongtinsp = Convert.ToString(dataTable.Rows[i]["thongtinsp"]);
                    pro.slsanpham = Convert.ToInt32(dataTable.Rows[i]["slsanpham"]);
                    // Gán dữ liệu vào mảng
                    arrayproducts.Add(pro);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayproducts.Count > 0)
            {
                // Thông báo thành công
                response.StatusCode = 200;
                response.StatusMessage = "Toàn bộ sản phẩm laptop";
                response.arrayProduct = arrayproducts;
                return response;
            }
            else
            {
                return null;
            }
        }

        public Response getProductId(MySqlConnection connection, int idsp)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("sp_spchitiet", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idsp", idsp);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            // Mở kết nối
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            List<Product> arrayproducts = new List<Product>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Product pro = new Product();
                    pro.idsp = Convert.ToInt32(dataTable.Rows[i]["idsp"]);
                    pro.idloai = Convert.ToInt32(dataTable.Rows[i]["idloai"]);
                    pro.anhsp = Convert.ToString(dataTable.Rows[i]["anhsp"]);
                    pro.tensp = Convert.ToString(dataTable.Rows[i]["tensp"]);
                    pro.giasp = Convert.ToDouble(dataTable.Rows[i]["giasp"]);
                    pro.thongtinsp = Convert.ToString(dataTable.Rows[i]["thongtinsp"]);
                    pro.slsanpham = Convert.ToInt32(dataTable.Rows[i]["slsanpham"]);
                    // Gán dữ liệu vào mảng
                    arrayproducts.Add(pro);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayproducts.Count > 0)
            {
                // Thông báo thành công
                response.StatusCode = 200;
                response.StatusMessage = "Toàn bộ sản phẩm laptop";
                response.arrayProduct = arrayproducts;
                return response;
            }
            else
            {
                return null;
            }
        }

        // Thêm sản phẩm
        public Response addproduct(Product product, MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("sp_add_product", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idloai", product.idloai);
            command.Parameters.AddWithValue("IN_anhsp", product.anhsp);
            command.Parameters.AddWithValue("IN_tensp", product.tensp);
            command.Parameters.AddWithValue("IN_giasp", product.giasp);
            command.Parameters.AddWithValue("IN_thongtinsp", product.thongtinsp);
            command.Parameters.AddWithValue("IN_slsanpham", product.slsanpham);
            // Mở kết nối
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Thêm sản phẩm mới thành công";
                return response;
            }
            else
            {
                return null;
            }
        }

        // Sửa sản phẩm
        public Response updateproduct(Product product, MySqlConnection connection, int idsp)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("sp_update_product", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idsp", idsp);
            command.Parameters.AddWithValue("IN_idloai", product.idloai);
            command.Parameters.AddWithValue("IN_anhsp", product.anhsp);
            command.Parameters.AddWithValue("IN_tensp", product.tensp);
            command.Parameters.AddWithValue("IN_giasp", product.giasp);
            command.Parameters.AddWithValue("IN_thongtinsp", product.thongtinsp);
            command.Parameters.AddWithValue("IN_slsanpham", product.slsanpham);
            // Mở kết nối
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Cập nhật sản phẩm thành công";
                return response;
            }
            else
            {
                return null;
            }
        }

        // Xóa sản phẩm
        public Response deleteproduct(MySqlConnection connection, int idsp)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("sp_delete_product", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idsp", idsp);
            // Mở kết nối
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Xóa sản phẩm thành công";
                return response;
            }
            else
            {
                return null;
            }
        }
    }
}
