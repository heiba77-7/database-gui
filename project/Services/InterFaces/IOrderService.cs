

public interface IOrderService
{
    List<Order> GetOrders();
    Order GetOrder(int id);
    Order AddOrder(Order order);
    Order UpdateOrder(Order order);

    Order DeleteOrder(int id);
    
}