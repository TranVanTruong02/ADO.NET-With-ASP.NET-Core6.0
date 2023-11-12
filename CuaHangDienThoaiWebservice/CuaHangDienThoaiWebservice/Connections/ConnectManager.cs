using CuaHangDienThoaiWebservice.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace CuaHangDienThoaiWebservice.Connections
{
    public class ConnectManager
    {
        // Lấy tất cả người quản lý
        public Response managerAll(MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand sql = new MySqlCommand("sp_manager_all", connection);
            sql.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql);

            // Sau khi lấy xong dữ liệu ta sẽ tạo ra 1 bảng dữ liệu mới
            DataTable dataTable = new DataTable();
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            // Khởi tạo mảng hứng dữ liệu
            List<Manage> arrayManager = new List<Manage>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Manage mana = new Manage();
                    mana.idql = Convert.ToInt32(dataTable.Rows[i]["idql"]);
                    mana.sdt = Convert.ToString(dataTable.Rows[i]["sdt"]);
                    mana.matkhau = Convert.ToString(dataTable.Rows[i]["matkhau"]);
                    mana.hoten = Convert.ToString(dataTable.Rows[i]["hoten"]);
                    mana.ngaysinh = Convert.ToDateTime(dataTable.Rows[i]["ngaysinh"]);
                    mana.gioitinh = Convert.ToBoolean(dataTable.Rows[i]["gioitinh"]);
                    mana.diachi = Convert.ToString(dataTable.Rows[i]["diachi"]);
                    mana.email = Convert.ToString(dataTable.Rows[i]["email"]);
                    // Gán dữ liệu vào mảng
                    arrayManager.Add(mana);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayManager.Count > 0)
            {
                // Thông báo thành công
                response.StatusCode = 200;
                response.StatusMessage = "Danh sách tất cả người quản lý";
                response.arrayManage = arrayManager;
                return response;
            }
            else
            {
                return null;
            }
        }

        // Xóa người quàn lý
        public Response deleteManager(MySqlConnection connection, int idql)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("sp_delete_manager", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idql", idql);
            // Mở kết nối
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Xóa người quản lý thành công";
                return response;
            }
            else
            {
                return null;
            }
        }

        public Response login(Manage manage, MySqlConnection connection)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("sp_login_admin", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("IN_sdt", manage.sdt);
            adapter.SelectCommand.Parameters.AddWithValue("IN_matkhau", manage.matkhau);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            Response response = new Response();
            List<Manage> arrayManager = new List<Manage>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Manage mana = new Manage();
                    mana.idql = Convert.ToInt32(dataTable.Rows[i]["idql"]);
                    mana.sdt = Convert.ToString(dataTable.Rows[i]["sdt"]);
                    mana.matkhau = Convert.ToString(dataTable.Rows[i]["matkhau"]);
                    mana.hoten = Convert.ToString(dataTable.Rows[i]["hoten"]);
                    mana.ngaysinh = Convert.ToDateTime(dataTable.Rows[i]["ngaysinh"]);
                    mana.gioitinh = Convert.ToBoolean(dataTable.Rows[i]["gioitinh"]);
                    mana.diachi = Convert.ToString(dataTable.Rows[i]["diachi"]);
                    mana.email = Convert.ToString(dataTable.Rows[i]["email"]);
                    // Gán dữ liệu vào mảng
                    arrayManager.Add(mana);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arrayManager.Count > 0)
            {
                // Thông báo thành công
                response.StatusCode = 200;
                response.StatusMessage = "Đăng nhập thành công !";
                response.arrayManage = arrayManager;
                return response;
            }
            else
            {
                return null;
            }
        }
        public Response register(Manage manage, MySqlConnection connection)
        {
            Response response = new Response();
            MySqlCommand cmd = new MySqlCommand("sp_register_admin", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("IN_sdt", manage.sdt);
            cmd.Parameters.AddWithValue("IN_matkhau", manage.matkhau);
            cmd.Parameters.AddWithValue("IN_hoten", manage.hoten);
            cmd.Parameters.AddWithValue("IN_ngaysinh", manage.ngaysinh);
            cmd.Parameters.AddWithValue("IN_gioitinh", manage.gioitinh);
            cmd.Parameters.AddWithValue("IN_diachi", manage.diachi);
            cmd.Parameters.AddWithValue("IN_email", manage.email);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Đăng ký thành công";
                return response;
            }
            else
            {
                return null;
            }
        }


        public Response getManagerId(MySqlConnection connection, int idsp)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("ql_qlchitiet", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idql", idsp);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            // Mở kết nối
            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();
            List<Manage> arraymanager = new List<Manage>();
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Manage mana = new Manage();
                    mana.idql = Convert.ToInt32(dataTable.Rows[i]["idql"]);
                    mana.sdt = Convert.ToString(dataTable.Rows[i]["sdt"]);
                    mana.matkhau = Convert.ToString(dataTable.Rows[i]["matkhau"]);
                    mana.hoten = Convert.ToString(dataTable.Rows[i]["hoten"]);
                    mana.ngaysinh = Convert.ToDateTime(dataTable.Rows[i]["ngaysinh"]);
                    mana.gioitinh = Convert.ToBoolean(dataTable.Rows[i]["gioitinh"]);
                    mana.diachi = Convert.ToString(dataTable.Rows[i]["diachi"]);
                    mana.email = Convert.ToString(dataTable.Rows[i]["email"]);
                    // Gán dữ liệu vào mảng
                    arraymanager.Add(mana);
                }
            }
            // Kiểm tra nếu mảng có dữ liệu
            if (arraymanager.Count > 0)
            {
                // Thông báo thành công
                response.StatusCode = 200;
                response.StatusMessage = "Quản lý chi tiết";
                response.arrayManage = arraymanager;
                return response;
            }
            else
            {
                return null;
            }
        }

        public Response updatemanager(Manage manager, MySqlConnection connection, int idql)
        {
            Response response = new Response();
            MySqlCommand command = new MySqlCommand("ql_update", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("IN_idql", idql);
            command.Parameters.AddWithValue("IN_sdt", manager.sdt);
            command.Parameters.AddWithValue("IN_matkhau", manager.matkhau);
            command.Parameters.AddWithValue("IN_hoten", manager.hoten);
            command.Parameters.AddWithValue("IN_ngaysinh", manager.ngaysinh);
            command.Parameters.AddWithValue("IN_gioitinh", manager.gioitinh);
            command.Parameters.AddWithValue("IN_diachi", manager.diachi);
            command.Parameters.AddWithValue("IN_email", manager.email);
            // Mở kết nối
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Cập nhật quản lý thành công";
                return response;
            }
            else
            {
                return null;
            }
        }
    }
}
