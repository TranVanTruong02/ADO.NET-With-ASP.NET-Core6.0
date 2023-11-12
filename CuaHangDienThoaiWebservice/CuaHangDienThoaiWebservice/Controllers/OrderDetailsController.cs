using CuaHangDienThoaiWebservice.Connections;
using CuaHangDienThoaiWebservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CuaHangDienThoaiWebservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IConfiguration _configuration; // Khởi tạo cấu hình và tên cấu hình

        public OrderDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Khởi tạo API insert thông tin đơn hàng 
        [HttpPost]
        [Route("orderdetails")]
        public Response OrderDetails(OrderDetails orderDetails)
        {
            Response response = new Response();
            ConnectOrderDetails connectOrderDetails = new ConnectOrderDetails();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectOrderDetails.orderdetails(orderDetails, connection);
            return response;
        }
    }
}
