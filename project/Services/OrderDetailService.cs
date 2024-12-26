


using MySqlConnector;

public class OrderDetailService : IOrderDetailService
{
    readonly MySqlConnection _connection;

    public OrderDetailService(MySqlConnection connection)
    {
        _connection = connection;
    }
    public OrderDetail AddOrderDetail(OrderDetail orderDetail)
    {
        string query = "INSERT INTO OrderDetails (OrderID, MenuItemID, Quantity, Price) VALUES (@OrderID, @MenuItemID, @Quantity, @Price)";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderDetail.OrderID);
                cmd.Parameters.AddWithValue("@MenuItemID", orderDetail.MenuItemID);
                cmd.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
                cmd.Parameters.AddWithValue("@Price", orderDetail.Price);
                if(_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
                return orderDetail;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public OrderDetail DeleteOrderDetail(int id)
    {
        string query = "DELETE FROM OrderDetails WHERE OrderDetailID = @OrderDetailID";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderDetailID", id);
                if(_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
                return new OrderDetail();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public OrderDetail GetOrderDetail(int id)
    {
        string query = "SELECT * FROM OrderDetails WHERE OrderDetailID = @OrderDetailID";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderDetailID", id);
                if(_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    OrderDetail orderDetail = new OrderDetail();
                    while (reader.Read())
                    {
                        orderDetail.OrderDetailID = reader.GetInt32("OrderDetailID");
                        orderDetail.OrderID = reader.GetInt32("OrderID");
                        orderDetail.MenuItemID = reader.GetInt32("MenuItemID");
                        orderDetail.Quantity = reader.GetInt32("Quantity");
                        orderDetail.Price = reader.GetDecimal("Price");
                    }
                    _connection.Close();
                    return orderDetail;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<OrderDetail> GetOrderDetails()
    {
        string query = "SELECT * FROM OrderDetails";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                _connection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    List<OrderDetail> orderDetails = new List<OrderDetail>();
                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailID = reader.GetInt32("OrderDetailID");
                        orderDetail.OrderID = reader.GetInt32("OrderID");
                        orderDetail.MenuItemID = reader.GetInt32("MenuItemID");
                        orderDetail.Quantity = reader.GetInt32("Quantity");
                        orderDetail.Price = reader.GetDecimal("Price");
                        orderDetails.Add(orderDetail);
                    }
                    _connection.Close();
                    return orderDetails;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<OrderDetail> GetOrderDetailsByOrderID(int orderID)
    {
        string query = "SELECT * FROM OrderDetails WHERE OrderID = @OrderID";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderID);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    List<OrderDetail> orderDetails = new List<OrderDetail>();
                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailID = reader.GetInt32("OrderDetailID");
                        orderDetail.OrderID = reader.GetInt32("OrderID");
                        orderDetail.MenuItemID = reader.GetInt32("MenuItemID");
                        orderDetail.Quantity = reader.GetInt32("Quantity");
                        orderDetail.Price = reader.GetDecimal("Price");
                        orderDetails.Add(orderDetail);
                    }
                    _connection.Close();
                    return orderDetails;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public OrderDetail UpdateOrderDetail(OrderDetail orderDetail)
    {
        string query = "UPDATE OrderDetails SET OrderID = @OrderID, MenuItemID = @MenuItemID, Quantity = @Quantity, Price = @Price WHERE OrderDetailID = @OrderDetailID";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderDetail.OrderID);
                cmd.Parameters.AddWithValue("@MenuItemID", orderDetail.MenuItemID);
                cmd.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
                cmd.Parameters.AddWithValue("@Price", orderDetail.Price);
                cmd.Parameters.AddWithValue("@OrderDetailID", orderDetail.OrderDetailID);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                cmd.ExecuteNonQuery();
                _connection.Close();
                return orderDetail;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<OrderDetail> GetOrderDetailsByMenuItemIDAndOrderID(int menuItemID, int orderID){
        string query = "SELECT * FROM OrderDetails WHERE MenuItemID = @MenuItemID AND OrderID = @OrderID";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@MenuItemID", menuItemID);
                cmd.Parameters.AddWithValue("@OrderID", orderID);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    List<OrderDetail> orderDetails = new List<OrderDetail>();
                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderDetailID = reader.GetInt32("OrderDetailID");
                        orderDetail.OrderID = reader.GetInt32("OrderID");
                        orderDetail.MenuItemID = reader.GetInt32("MenuItemID");
                        orderDetail.Quantity = reader.GetInt32("Quantity");
                        orderDetail.Price = reader.GetDecimal("Price");
                        orderDetails.Add(orderDetail);
                    }
                    _connection.Close();
                    return orderDetails;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}