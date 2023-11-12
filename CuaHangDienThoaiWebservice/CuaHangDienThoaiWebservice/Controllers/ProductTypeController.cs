using CuaHangDienThoaiWebservice.Connections;
using CuaHangDienThoaiWebservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CuaHangDienThoaiWebservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IConfiguration _configuration; // Khởi tạo cấu hình và tên cấu hình

        public ProductTypeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("getProductType")]
        public Response getProductType()
        {
            Response response = new Response();
            ConnectProductType connectProductType = new ConnectProductType();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectProductType.productTpyeAll(connection);
            return response;
        }
        [HttpGet] // Ta có thể sử dụng Put or Patch. Chúng khác nhau put sẽ chỉ cập nhật cái ng dùng yêu cầu, patch thì cập nhật những cái yêu cầu và dữ nguyên cái khác
        [Route("GetproductTypeId")]
        public Response GetProductTypeID(int idloai)
        {
            Response response = new Response();
            ConnectProductType connectProductType = new ConnectProductType();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectProductType.getProductTypeId(connection, idloai);
            return response;
        }

        [HttpPost]
        [Route("addtype")]

        public Response AddType(ProductType producttype)
        {
            Response response = new Response();
            ConnectProductType connectProductType = new ConnectProductType();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectProductType.addType(producttype, connection);
            return response;
        }

        // Khởi tạo API cập nhật sản phẩm
        [HttpPatch] // Ta có thể sử dụng Put or Patch. Chúng khác nhau put sẽ chỉ cập nhật cái ng dùng yêu cầu, patch thì cập nhật những cái yêu cầu và dữ nguyên cái khác
        [Route("updatetype")]
        public Response UpdateProduct(ProductType producttype, int idsp)
        {
            Response response = new Response();
            ConnectProductType connectProductType = new ConnectProductType();

            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectProductType.updateType(producttype, connection, idsp);
            return response;
        }

        [HttpDelete]
        [Route("deleteproductType")]
        public Response DeleteProductType(int idloai)
        {
            Response response = new Response();
            ConnectProductType connectProductType = new ConnectProductType();
            MySqlConnection connection = new MySqlConnection(_configuration.GetConnectionString("webservice").ToString());
            response = connectProductType.deleteproductType(connection, idloai);
            return response;
        }
    }
}
