using CuaHangDienThoaiWebservice.Connections;
using CuaHangDienThoaiWebservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CuaHangDienThoaiWebservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IConfiguration _configuration; // Khởi tạo cấu hình và tên cấu hình

        public OrderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Khởi tạo API lấy iddh đơn hàng mới nhất
        [HttpGet]
        [Route("orderiddh")]
        public Response OrderIDdh()
        {
            Response response = new Response();
            ConnectOrder connectOrder = new ConnectOrder();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectOrder.orderiddh(connection);
            return response;
        }

        [HttpGet]
        [Route("getOrder")]
        public Response getOrder()
        {
            Response response = new Response();
            ConnectOrder connectOrder = new ConnectOrder();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectOrder.orderAll(connection);
            return response;
        }

        // Khởi tạo API insert thông tin đơn hàng 
        [HttpPost]
        [Route("order")]
        public Response Order(Order order)
        {
            Response response = new Response();
            ConnectOrder connectOrder = new ConnectOrder();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectOrder.order(order, connection);
            return response;
        }
    }
}
