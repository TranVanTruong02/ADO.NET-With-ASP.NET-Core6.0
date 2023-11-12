using CuaHangDienThoaiWebservice.Connections;
using CuaHangDienThoaiWebservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CuaHangDienThoaiWebservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IConfiguration _configuration; // Khởi tạo cấu hình và tên cấu hình

        public ClientController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Khởi tạo API lấy dữ liệu khách hàng từ id khách hàng
        [HttpGet]
        [Route("client")]
        public Response Cart(int idkh)
        {
            Response response = new Response();
           ConnectClient connectClient = new ConnectClient();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectClient.client(connection, idkh);
            return response;
        }
        [HttpGet]
        [Route("clientAll")]
        public Response clientAll()
        {
            Response response = new Response();
            ConnectClient connectClient = new ConnectClient();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectClient.clientAll(connection);
            return response;
        }

        [HttpGet] // Ta có thể sử dụng Put or Patch. Chúng khác nhau put sẽ chỉ cập nhật cái ng dùng yêu cầu, patch thì cập nhật những cái yêu cầu và dữ nguyên cái khác
        [Route("GetClientId")]
        public Response GetClientID(int idkh)
        {
            Response response = new Response();
            ConnectClient connectClient = new ConnectClient();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectClient.getClientId(connection, idkh);
            return response;
        }

        [HttpPost]
        [Route("login")]
        public Response login(Client client)
        {
            Response response = new Response();
            ConnectClient connectClient = new ConnectClient();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectClient.login(client, connection);
            return response;
        }

        [HttpPost]
        [Route("Registraion")]
        public Response Registraion(Client client)
        {
            Response response = new Response();
            ConnectClient connectClient = new ConnectClient();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectClient.register(client, connection);
            return response;
        }
        
        [HttpPatch] // Ta có thể sử dụng Put or Patch. Chúng khác nhau put sẽ chỉ cập nhật cái ng dùng yêu cầu, patch thì cập nhật những cái yêu cầu và dữ nguyên cái khác
        [Route("updateClient")]
        public Response UpdateClient(Client client, int idkh)
        {
            Response response = new Response();
            ConnectClient connectClient = new ConnectClient();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectClient.updateClient(client, connection, idkh);
            return response;
        }

        // Khởi tạo API xóa khách hàng
        [HttpDelete]
        [Route("deleteClient")]
        public Response DeleteClient(int idkh)
        {
            Response response = new Response();
            ConnectClient connectClient = new ConnectClient();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectClient.deleteClient(connection, idkh);
            return response;
        }
    }
}
