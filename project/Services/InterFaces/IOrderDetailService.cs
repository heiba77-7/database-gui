 public interface IOrderDetailService
 {
     List<OrderDetail> GetOrderDetails();
     OrderDetail GetOrderDetail(int id);
     OrderDetail AddOrderDetail(OrderDetail orderDetail);
     OrderDetail UpdateOrderDetail(OrderDetail orderDetail);
     OrderDetail DeleteOrderDetail(int id);

    List<OrderDetail> GetOrderDetailsByOrderID(int orderID);

 }