using CuaHangDienThoaiWebservice.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace CuaHangDienThoaiWebservice.Connections
{
    public class ConnectClient
    {
        public Response client(MySqlConnection connection, int idkh)
        {
            Response response = new Response();
            MySqlCommand sql = new MySqlCommand("sp_data_client", connection);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("IN_idkh", idkh);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql);

            // Sau khi lấy xong dữ liệu ta sẽ tạo ra 1 bảng dữ liệu mới
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            // Khởi tạo mảng hứng dữ liệu
            List<Client> arrayClient = new List<Client>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Client c = new Client();
                    c.idkh = Convert.ToInt32(dataTable.Rows[i]["idkh"]);
                    c.sdt = Convert.ToString(dataTable.Rows[i]["sdt"]);
                    c.matkhau = Convert.ToString(dataTable.Rows[i]["matkhau"]);
                    c.email = Convert.ToString(dataTable.Rows[i]["email"]);
                    c.hoten = Convert.ToString(dataTable.Rows[i]["hoten"]);
                    c.ngaysinh = Convert.ToDateTime(dataTable.Rows[i]["ngaysinh"]);
                    c.gioitinh = Convert.ToInt32(dataTable.Rows[i]["gioitinh"]);
                    c.diachi = Convert.ToString(dataTable.Rows[i]["diachi"]);
                    // Gán dữ liệu vào mảng
                    arrayClient.Add(c);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayClient.Count > 0)
            {
                // Thông báo thành công
                response.StatusCode = 200;
                response.StatusMessage = "Lấy ra người dùng thành công";
                response.arrayClient = arrayClient;
                return response;
            }
            else
            {
                return null;
            }
        }

        // Lấy tất cả khách hàng
        public Response clientAll(MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand sql = new MySqlCommand("sp_client_all", connection);
            sql.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql);

            // Sau khi lấy xong dữ liệu ta sẽ tạo ra 1 bảng dữ liệu mới
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            // Khởi tạo mảng hứng dữ liệu
            List<Client> arrayClient = new List<Client>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Client client = new Client();
                    client.idkh = Convert.ToInt32(dataTable.Rows[i]["idkh"]);
                    client.sdt = Convert.ToString(dataTable.Rows[i]["sdt"]);
                    client.matkhau = Convert.ToString(dataTable.Rows[i]["matkhau"]);
                    client.hoten = Convert.ToString(dataTable.Rows[i]["hoten"]);
                    client.ngaysinh = Convert.ToDateTime(dataTable.Rows[i]["ngaysinh"]);
                    client.gioitinh = Convert.ToInt32(dataTable.Rows[i]["gioitinh"]);
                    client.diachi = Convert.ToString(dataTable.Rows[i]["diachi"]);
                    client.email = Convert.ToString(dataTable.Rows[i]["email"]);
                    // Gán dữ liệu vào mảng
                    arrayClient.Add(client);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayClient.Count > 0)
            {
                response.arrayClient = arrayClient;
                return response;
            }
            else
            {
                return null;
            }
        }

        // Xóa người dùng
        public Response deleteClient(MySqlConnection connection, int idkh)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("sp_delete_client", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idkh", idkh);
            // Mở kết nối
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            return response;
        }

        public Response login(Client clinet, MySqlConnection connection)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("sp_login_client", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("IN_sdt", clinet.sdt);
            adapter.SelectCommand.Parameters.AddWithValue("IN_matkhau", clinet.matkhau);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Response response = new Response();
            List<Client> arrayClient = new List<Client>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Client client = new Client();
                    client.idkh = Convert.ToInt32(dt.Rows[i]["idkh"]);
                    client.sdt = Convert.ToString(dt.Rows[i]["sdt"]);
                    client.matkhau = Convert.ToString(dt.Rows[i]["matkhau"]);
                    client.hoten = Convert.ToString(dt.Rows[i]["hoten"]);
                    client.ngaysinh = Convert.ToDateTime(dt.Rows[i]["ngaysinh"]);
                    client.gioitinh = Convert.ToInt32(dt.Rows[i]["gioitinh"]);
                    client.diachi = Convert.ToString(dt.Rows[i]["diachi"]);
                    client.email = Convert.ToString(dt.Rows[i]["email"]);
                    // Gán dữ liệu vào mảng
                    arrayClient.Add(client);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayClient.Count > 0)
            {
                response.arrayClient = arrayClient;
                return response;
            }
            else
            {
                return null;
            }
        }
        public Response register(Client clinet, MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("sp_register_client", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("IN_sdt", clinet.sdt);
            cmd.Parameters.AddWithValue("IN_matkhau", clinet.matkhau);
            cmd.Parameters.AddWithValue("IN_hoten", clinet.hoten);
            cmd.Parameters.AddWithValue("IN_ngaysinh", clinet.ngaysinh);
            cmd.Parameters.AddWithValue("IN_gioitinh", clinet.gioitinh);
            cmd.Parameters.AddWithValue("IN_diachi", clinet.diachi);
            cmd.Parameters.AddWithValue("IN_email", clinet.email);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            return response;
        }
        public Response getClientId(MySqlConnection connection, int idkh)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("sp_getClient_id", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idkh", idkh);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            // Mở kết nối
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            List<Client> arrayClient = new List<Client>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Client client = new Client();
                    client.idkh = Convert.ToInt32(dataTable.Rows[i]["idkh"]);
                    client.sdt = Convert.ToString(dataTable.Rows[i]["sdt"]);
                    client.matkhau = Convert.ToString(dataTable.Rows[i]["matkhau"]);
                    client.hoten = Convert.ToString(dataTable.Rows[i]["hoten"]);
                    client.ngaysinh = Convert.ToDateTime(dataTable.Rows[i]["ngaysinh"]);
                    client.gioitinh = Convert.ToInt32(dataTable.Rows[i]["gioitinh"]);
                    client.diachi = Convert.ToString(dataTable.Rows[i]["diachi"]);
                    client.email = Convert.ToString(dataTable.Rows[i]["email"]);
                    // Gán dữ liệu vào mảng
                    arrayClient.Add(client);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayClient.Count > 0)
            {
                response.arrayClient = arrayClient;
                return response;
            }
            else
            {
                return null;
            }
        }
        public Response updateClient(Client client, MySqlConnection connection, int idkh)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("sp_update_client", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idkh", idkh);
            command.Parameters.AddWithValue("IN_sdt", client.sdt);
            command.Parameters.AddWithValue("IN_matkhau", client.matkhau);
            command.Parameters.AddWithValue("IN_hoten", client.hoten);
            command.Parameters.AddWithValue("IN_ngaysinh", client.ngaysinh);
            command.Parameters.AddWithValue("IN_gioitinh", client.gioitinh);
            command.Parameters.AddWithValue("IN_diachi", client.diachi);
            command.Parameters.AddWithValue("IN_email", client.email);
            // Mở kết nối
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            return response;
        }
    }
}
