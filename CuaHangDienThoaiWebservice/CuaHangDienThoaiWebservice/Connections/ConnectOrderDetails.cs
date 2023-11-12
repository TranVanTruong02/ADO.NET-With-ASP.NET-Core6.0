using CuaHangDienThoaiWebservice.Models;
using System.Data;
using MySql.Data.MySqlClient;

namespace CuaHangDienThoaiWebservice.Connections
{
    public class ConnectOrderDetails
    {
        // Thêm chi tiết hóa đơn
        public Response orderdetails(OrderDetails orderDetails, MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("sp_add_order_details", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_iddh", orderDetails.iddh);
            command.Parameters.AddWithValue("IN_idsp", orderDetails.idsp);
            command.Parameters.AddWithValue("IN_sldamua", orderDetails.sldamua);
        // Mở kết nối
        connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Thêm chi tiết hóa đơn mới thành công";
                return response;
            }
            else
            {
                return null;
            }
        }
    }
}
