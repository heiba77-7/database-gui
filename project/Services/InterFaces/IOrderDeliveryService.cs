public interface IOrderDeliveryService{

    OrderDelivery GetOrderDelivery(int id);

    OrderDelivery AddOrderDelivery(OrderDelivery orderDelivery);

    OrderDelivery UpdateOrderDelivery(OrderDelivery orderDelivery);
    
    OrderDelivery DeleteOrderDelivery(int id);



}