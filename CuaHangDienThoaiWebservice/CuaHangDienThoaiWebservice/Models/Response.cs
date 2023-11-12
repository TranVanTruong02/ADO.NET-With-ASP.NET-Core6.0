namespace CuaHangDienThoaiWebservice.Models
{
    public class Response // Phản hồi
    {
        // Thông báo kết nối thành công hay chưa
       public int StatusCode { get; set; }

        public string StatusMessage { get; set; }
        
        // Quản Lý
        public List<Manage> arrayManage { get; set; }

        public Manage manage { get; set; }

        // Khách Hàng
        public List<Client> arrayClient { get; set; }

        public Client client { get; set; }


        // Loại sản phẩm
        public List<ProductType> arrayProductType { get; set; }

        public ProductType productType { get; set; }
        
        // Sản phẩm
        public List<Product> arrayProduct { get; set; }

        public Product product { get; set; }

        
        // Giỏ Hàng
        public List<Cart> arrayCart { get; set; }

        public Cart cart { get; set; }

        // Đơn Hàng
        public List<Order> arrayOrder { get; set; }

        public Order order { get; set; }

        public int iddh { get; set; }

        // Chi tiết đơn hàng
        public List<OrderDetails> arrayOrderDetails { get; set; }

        public OrderDetails orderDetails { get; set; }

    }
}
