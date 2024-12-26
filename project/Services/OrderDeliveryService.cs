
using System.Data;
using MySqlConnector;

public class OrderDeliveryService : IOrderDeliveryService
{
    readonly  MySqlConnection _connection;

    public OrderDeliveryService(MySqlConnection connection)
    {
        _connection = connection;
    }
    public OrderDelivery GetByOrderId(int id){
        string query = "SELECT * FROM OrderDelivery WHERE OrderID = @OrderID";
        try{
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderID", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        OrderDelivery orderDelivery = new OrderDelivery();
                        orderDelivery.DeliveryID = reader.GetInt32("DeliveryID");
                        orderDelivery.OrderID = reader.GetInt32("OrderID");
                        orderDelivery.EmployeeID = reader.GetInt32("EmployeeID");
                        orderDelivery.DeliveryAddress = reader.GetString("DeliveryAddress");
                        orderDelivery.DeliveryStatus = reader.GetString("DeliveryStatus");
                        orderDelivery.DeliveryDate = reader.GetDateTime("DeliveryDate");
                        return orderDelivery;
                    }
                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public OrderDelivery AddOrderDelivery(OrderDelivery orderDelivery)
    {
        string query = "INSERT INTO OrderDelivery (OrderID, EmployeeID, DeliveryAddress, DeliveryStatus, DeliveryDate) VALUES (@OrderID, @EmployeeID, @DeliveryAddress, @DeliveryStatus, @DeliveryDate)";
        try{
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderDelivery.OrderID);
                cmd.Parameters.AddWithValue("@EmployeeID", orderDelivery.EmployeeID);
                cmd.Parameters.AddWithValue("@DeliveryAddress", orderDelivery.DeliveryAddress);
                cmd.Parameters.AddWithValue("@DeliveryStatus", orderDelivery.DeliveryStatus);
                cmd.Parameters.AddWithValue("@DeliveryDate", orderDelivery.DeliveryDate);
                cmd.ExecuteNonQuery();
            }
            _connection.Close();
            return orderDelivery;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public OrderDelivery DeleteOrderDelivery(int id)
    {
        string query = "DELETE FROM OrderDelivery WHERE DeliveryID = @Delivery";
        try{
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@DeliveryID", id);
                cmd.ExecuteNonQuery();
            }
            _connection.Close();
            return GetOrderDelivery(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public OrderDelivery GetOrderDelivery(int id)
    {
        string query = "SELECT * FROM OrderDelivery WHERE DeliveryID = @Delivery";
        try{
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@DeliveryID", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        OrderDelivery orderDelivery = new OrderDelivery();
                        orderDelivery.DeliveryID = reader.GetInt32("DeliveryID");
                        orderDelivery.OrderID = reader.GetInt32("OrderID");
                        orderDelivery.EmployeeID = reader.GetInt32("EmployeeID");
                        orderDelivery.DeliveryAddress = reader.GetString("DeliveryAddress");
                        orderDelivery.DeliveryStatus = reader.GetString("DeliveryStatus");
                        orderDelivery.DeliveryDate = reader.GetDateTime("DeliveryDate");
                        return orderDelivery;
                    }
                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public OrderDelivery UpdateOrderDelivery(OrderDelivery orderDelivery)
    {
        string query = "UPDATE OrderDelivery SET OrderID = @OrderID, EmployeeID = @EmployeeID, DeliveryAddress = @DeliveryAddress, DeliveryStatus = @DeliveryStatus, DeliveryDate = @DeliveryDate WHERE DeliveryID = @DeliveryID";
        try{
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderDelivery.OrderID);
                cmd.Parameters.AddWithValue("@EmployeeID", orderDelivery.EmployeeID);
                cmd.Parameters.AddWithValue("@DeliveryAddress", orderDelivery.DeliveryAddress);
                cmd.Parameters.AddWithValue("@DeliveryStatus", orderDelivery.DeliveryStatus);
                cmd.Parameters.AddWithValue("@DeliveryDate", orderDelivery.DeliveryDate);
                cmd.Parameters.AddWithValue("@DeliveryID", orderDelivery.DeliveryID);
                cmd.ExecuteNonQuery();
            }
            _connection.Close();
            return orderDelivery;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}