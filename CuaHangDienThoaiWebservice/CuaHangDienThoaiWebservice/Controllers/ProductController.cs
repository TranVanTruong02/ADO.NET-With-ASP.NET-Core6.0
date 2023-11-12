using CuaHangDienThoaiWebservice.Connections;
using CuaHangDienThoaiWebservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;

namespace CuaHangDienThoaiWebservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration; // Khởi tạo cấu hình và tên cấu hình

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("all")]

        public Response all()
        {
            Response response = new Response();
            ConnectProduct connectProduct = new ConnectProduct();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectProduct.productAll(connection);
            return response;
        }

        // Khởi tạo API lấy dữ liệu 15 sản phẩm mới nhất
        [HttpGet]
        [Route("product_new")]
        public Response ProductNew()
        {
            Response response = new Response();
            ConnectProduct connectProduct = new ConnectProduct();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectProduct.productnew(connection);
            return response;
        }

        // Khởi tạo API lấy dữ liệu 5 sản phẩm laptop mới nhất
        [HttpGet]
        [Route("laptop_new")]
        public Response LaptopNew()
        {
            Response response = new Response();
            ConnectProduct connectProduct = new ConnectProduct();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectProduct.laptopnew(connection);
            return response;
        }

        // Khởi tạo API lấy toàn bộ sản phẩm điện thoại
        [HttpGet]
        [Route("dienthoai")]

        public Response SmartPhone()
        {
            Response response = new Response();
            ConnectProduct connectProduct = new ConnectProduct();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectProduct.smartphone(connection);
            return response;
        }

        // Khởi tạo API lấy toàn bộ sản phẩm laptop
        [HttpGet]
        [Route("laptop")]
        public Response LapTop()
        {
            Response response = new Response();
            ConnectProduct connectProduct = new ConnectProduct();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectProduct.laptop(connection);
            return response;
        }

        [HttpGet] // Ta có thể sử dụng Put or Patch. Chúng khác nhau put sẽ chỉ cập nhật cái ng dùng yêu cầu, patch thì cập nhật những cái yêu cầu và dữ nguyên cái khác
        [Route("GetproductId")]
        public Response GetProductID(int idsp)
        {
            Response response = new Response();
            ConnectProduct connectProduct = new ConnectProduct();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectProduct.getProductId(connection, idsp);
            return response;
        }

        // Khởi tạo API thêm sản phẩm
        [HttpPost]
        [Route("addproduct")]

        public Response AddProduct(Product product)
        {
            Response response = new Response();
            ConnectProduct connectProduct = new ConnectProduct();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectProduct.addproduct(product, connection);
            return response;
        }
        
        // Khởi tạo API cập nhật sản phẩm
        [HttpPatch] // Ta có thể sử dụng Put or Patch. Chúng khác nhau put sẽ chỉ cập nhật cái ng dùng yêu cầu, patch thì cập nhật những cái yêu cầu và dữ nguyên cái khác
        [Route("updateproduct")]
        public Response UpdateProduct(Product product, int idsp)
        {
            Response response = new Response();
            ConnectProduct connectProduct = new ConnectProduct();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectProduct.updateproduct(product, connection, idsp);
            return response;
        }

        // Khởi tạo API xóa sản phẩm
        [HttpDelete] 
        [Route("deleteproduct")]
        public Response DeleteProduct(int idsp)
        {
            Response response = new Response();
            ConnectProduct connectProduct = new ConnectProduct();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectProduct.deleteproduct(connection, idsp);
            return response;
        }


    }
}
