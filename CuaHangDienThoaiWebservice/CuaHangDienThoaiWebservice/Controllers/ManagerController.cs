using CuaHangDienThoaiWebservice.Connections;
using CuaHangDienThoaiWebservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CuaHangDienThoaiWebservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IConfiguration _configuration; // Khởi tạo cấu hình và tên cấu hình

        public ManagerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("getManager")]
        public Response managerAll()
        {
            Response response = new Response();
            ConnectManager connectManager = new ConnectManager();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectManager.managerAll(connection);
            return response;
        }


        [HttpGet] // Ta có thể sử dụng Put or Patch. Chúng khác nhau put sẽ chỉ cập nhật cái ng dùng yêu cầu, patch thì cập nhật những cái yêu cầu và dữ nguyên cái khác
        [Route("GetManagerId")]
        public Response GetManagerID(int idql)
        {
            Response response = new Response();
            ConnectManager connectManager = new ConnectManager();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectManager.getManagerId(connection, idql);
            return response;
        }

        [HttpPost]
        [Route("login")]
        public Response login(Manage manage)
        {
            Response response = new Response();
            ConnectManager connectManager = new ConnectManager();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectManager.login(manage, connection);
            return response;
        }

        [HttpPost]
        [Route("Registraion")]
        public Response Registraion(Manage manage)
        {
            Response response = new Response();
            ConnectManager connectManager = new ConnectManager();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectManager.register(manage, connection);
            return response;
        }

        [HttpPatch] // Ta có thể sử dụng Put or Patch. Chúng khác nhau put sẽ chỉ cập nhật cái ng dùng yêu cầu, patch thì cập nhật những cái yêu cầu và dữ nguyên cái khác
        [Route("updateManager")]
        public Response UpdateManager(Manage manager, int idql)
        {
            Response response = new Response();
            ConnectManager connectManager = new ConnectManager();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectManager.updatemanager(manager, connection, idql);
            return response;
        }


        [HttpDelete]
        [Route("deleteManager")]
        public Response DeleteManager(int idql)
        {
            Response response = new Response();
            ConnectManager connectManager = new ConnectManager();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectManager.deleteManager(connection, idql);
            return response;
        }
    }
}
