using CuaHangDienThoaiWebservice.Connections;
using CuaHangDienThoaiWebservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace CuaHangDienThoaiWebservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly IConfiguration _configuration; // Khởi tạo cấu hình và tên cấu hình

        public CartController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Khởi tạo API lấy sản phẩm từ giỏ hàng
        [HttpGet]
        [Route("cart")]
        public Response Cart(int idkh)
        {
            Response response = new Response();
            ConnectCart connectCart = new ConnectCart();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectCart.cart(connection, idkh);
            return response;
        }

        // Khởi tạo API thêm sản phẩm vào trong giỏ hàng
        [HttpPost]
        [Route("addCart")]

        public Response AddCart(Cart cart)
        {
            Response response = new Response();
            ConnectCart connectCart = new ConnectCart();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectCart.addCart(cart, connection);
            return response;
        }

        // Khởi tạo API tăng số lượng sản phẩm chọn trong giỏ hàng
        [HttpPatch] 
        [Route("increasecart")]
        public Response IncreaseCart(Cart cart, int idgh)
        {
            Response response = new Response();
            ConnectCart connectCart = new ConnectCart();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectCart.increasecart(cart, connection, idgh);
            return response;
        }
        
        // Khởi tạo API giảm số lượng sản phẩm chọn trong giỏ hàng
        [HttpPatch] 
        [Route("reducecart")]
        public Response ReduceCart(Cart cart, int idgh)
        {
            Response response = new Response();
            ConnectCart connectCart = new ConnectCart();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectCart.reducecart(cart, connection, idgh);
            return response;
        }

        // Khởi tạo API xóa sản phẩm có trong giỏ hàng
        [HttpDelete]
        [Route("deletecart")]
        public Response DeleteCart(int idgh)
        {
            Response response = new Response();
            ConnectCart connectCart = new ConnectCart();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectCart.deletecart(connection, idgh);
            return response;
        }
    }
}
