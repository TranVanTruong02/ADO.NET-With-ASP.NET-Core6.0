using CuaHangDienThoaiWebservice.Models;
using System.Data;
using MySql.Data.MySqlClient;

namespace CuaHangDienThoaiWebservice.Connections
{
    public class ConnectOrder
    {

        // lấy iddh mới nhất
        public Response orderiddh(MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand sql = new MySqlCommand("sp_iddh", connection);
            sql.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            int iddh = 0;
            if (dataTable.Rows.Count > 0)
            {
                iddh = Convert.ToInt32(dataTable.Rows[0]["iddh"]);
                response.iddh = iddh;
                return response;
            }
            else
            {
                return null;
            }
        }

        // Lấy tất cả sản phẩm
        public Response orderAll(MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand sql = new MySqlCommand("sp_order_all", connection);
            sql.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql);

            // Sau khi lấy xong dữ liệu ta sẽ tạo ra 1 bảng dữ liệu mới
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            // Khởi tạo mảng hứng dữ liệu
            List<Order> arrayOrder = new List<Order>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Order order = new Order();
                    order.iddh = Convert.ToInt32(dataTable.Rows[i]["iddh"]);
                    order.idkh = Convert.ToInt32(dataTable.Rows[i]["idkh"]);
                    order.idql = Convert.ToInt32(dataTable.Rows[i]["idql"]);
                    order.hoten = Convert.ToString(dataTable.Rows[i]["hoten"]);
                    order.diachi = Convert.ToString(dataTable.Rows[i]["diachi"]);
                    order.sdt = Convert.ToString(dataTable.Rows[i]["sdt"]);
                    order.email = Convert.ToString(dataTable.Rows[i]["email"]);
                    order.ngaylap = Convert.ToDateTime(dataTable.Rows[i]["ngaylap"]);
                    // Gán dữ liệu vào mảng
                    arrayOrder.Add(order);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayOrder.Count > 0)
            {
                // Thông báo thành công
                response.StatusCode = 200;
                response.StatusMessage = "Danh sách tất cả đơn hàng";
                response.arrayOrder = arrayOrder;
                return response;
            }
            else
            {
                return null;
            }
        }

        // Thêm hóa đơn
        public Response order(Order order, MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("sp_add_order", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idkh", order.idkh);
            command.Parameters.AddWithValue("IN_idql", order.idql);
            command.Parameters.AddWithValue("IN_hoten", order.hoten);
            command.Parameters.AddWithValue("IN_diachi", order.diachi);
            command.Parameters.AddWithValue("IN_sdt", order.sdt);
            command.Parameters.AddWithValue("IN_email", order.email);
            // Mở kết nối
            connection.Open();
            int i = command.ExecuteNonQuery();
            // Lấy ra iddh mới nhất
            MySqlCommand sql = new MySqlCommand("sp_iddh", connection);
            sql.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();
            int iddh = 0;
            if (dataTable.Rows.Count > 0)
            {
                iddh = Convert.ToInt32(dataTable.Rows[0]["iddh"]);
                response.iddh = iddh;
            }
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Thêm hóa đơn mới thành công";
                return response;
            }
            else
            {
                return null;
            }
        }
    }
}
