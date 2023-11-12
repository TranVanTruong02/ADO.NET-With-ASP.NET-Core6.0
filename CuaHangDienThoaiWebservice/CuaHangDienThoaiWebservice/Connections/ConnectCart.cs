using CuaHangDienThoaiWebservice.Models;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using MySql.Data.MySqlClient;

namespace CuaHangDienThoaiWebservice.Connections
{
    public class ConnectCart
    {
        // Hiển thị sản phẩm trong giỏ hàng
        public Response cart(MySqlConnection connection, int idkh)
        {
            Response response = new Response();
            MySqlCommand sql = new MySqlCommand("sp_cart", connection);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("IN_idkh", idkh);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql);

            // Sau khi lấy xong dữ liệu ta sẽ tạo ra 1 bảng dữ liệu mới
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            // Khởi tạo mảng hứng dữ liệu
            List<Cart> arrayCart = new List<Cart>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Cart c = new Cart();
                    c.idgh = Convert.ToInt32(dataTable.Rows[i]["idgh"]);
                    c.idkh = Convert.ToInt32(dataTable.Rows[i]["idkh"]);
                    c.idsp = Convert.ToInt32(dataTable.Rows[i]["idsp"]);
                    c.idloai = Convert.ToInt32(dataTable.Rows[i]["idloai"]);
                    c.tensp = Convert.ToString(dataTable.Rows[i]["tensp"]);
                    c.anhsp = Convert.ToString(dataTable.Rows[i]["anhsp"]);
                    c.giasp = Convert.ToDouble(dataTable.Rows[i]["giasp"]);
                    c.thongtinsp = Convert.ToString(dataTable.Rows[i]["thongtinsp"]);
                    c.slsanpham = Convert.ToInt32(dataTable.Rows[i]["slsanpham"]);
                    c.slchon = Convert.ToInt32(dataTable.Rows[i]["slchon"]);
                    // Gán dữ liệu vào mảng
                    arrayCart.Add(c);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayCart.Count > 0)
            {
                // Thông báo thành công
                response.StatusCode = 200;
                response.StatusMessage = "Tất cả sản phẩm có trong giỏ hàng";
                response.arrayCart = arrayCart;
                return response;
            }
            else
            {
                return null;
            }
        }

        // Tăng số lượng sản phẩm chọn
        public Response increasecart(Cart cart, MySqlConnection connection, int idgh)
        {
            Response response = new Response();
            
            MySqlCommand command = new MySqlCommand("sp_increase_cart", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idgh", idgh);
            // Mở kết nối
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Tăng số lượng chọn thành công";
                return response;
            }
            else
            {
                return null;
            }
        }

        // Giảm số lượng sản phẩm chọn
        public Response reducecart(Cart cart, MySqlConnection connection, int idgh)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("sp_reduce_cart", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idgh", idgh);
            // Mở kết nối
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Giảm số lượng chọn thành công";
                return response;
            }
            else
            {
                return null;
            }
        }

        // Xóa sản phẩm có trong giỏ hàng
        public Response deletecart(MySqlConnection connection, int idgh)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("sp_delete_cart", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idgh", idgh);
            // Mở kết nối
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Chúc mừng, bạn đã xóa sản phẩm thành công";
                return response;
            }
            else
            {
                return null;
            }
        }

        // Thêm Giỏ Hàng
        public Response addCart(Cart cart, MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("post_cart", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idkh", cart.idkh);
            command.Parameters.AddWithValue("IN_idsp", cart.idsp);
            command.Parameters.AddWithValue("IN_slchon", cart.slchon);
            // Mở kết nối
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Thêm sản phẩm vào giỏ hàng thành công";
                return response;
            }
            else
            {
                return null;
            }
        }
    }
}
