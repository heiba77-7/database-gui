using MySqlConnector;
using System.Collections.Generic;

public class OrderService : IOrderService
{
    private readonly MySqlConnection _connection;

    public OrderService(MySqlConnection connection)
    {
        _connection = connection;
    }

    public Order AddOrder(Order order)
    {
        string query = "INSERT INTO Orders (CustomerName, CustomerPhone, OrderDate) VALUES (@CustomerName, @CustomerPhone, @OrderDate )";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerPhone", order.CustomerPhone);
                cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                if(_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
                order.OrderID = (int)cmd.LastInsertedId;
                return order;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Order DeleteOrder(int id)
    {
        string query = "DELETE FROM Orders WHERE OrderID = @OrderID";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderID", id);
                if(_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
                return new Order();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Order GetOrder(int id)
    {
        Order order = null;
        string query = "SELECT * FROM Orders WHERE OrderID = @OrderID";
        MySqlCommand cmd = new MySqlCommand(query, _connection);
        cmd.Parameters.AddWithValue("@OrderID", id);

        if (_connection.State == System.Data.ConnectionState.Closed)
        {
            _connection.Open();
        }

        using (var reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
                order = new Order
                {
                    OrderID = reader.GetInt32("OrderID"),
                    CustomerName = reader.GetString("CustomerName"),
                    CustomerPhone = reader.GetString("CustomerPhone"),
                    OrderDate = reader.GetDateTime("OrderDate"),
                };
            }
        }

        _connection.Close();
        return order;
    }

    public List<Order> GetOrders()
    {
        List<Order> orders = new List<Order>();

        string query = "SELECT * FROM Orders";
        MySqlCommand cmd = new MySqlCommand(query, _connection);

        if (_connection.State == System.Data.ConnectionState.Closed)
        {
            _connection.Open();
        }

        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Order order = new Order
                {
                    OrderID = reader.GetInt32("OrderID"),
                    CustomerName = reader.GetString("CustomerName"),
                    CustomerPhone = reader.GetString("CustomerPhone"),
                    OrderDate = reader.GetDateTime("OrderDate"),
                };
                orders.Add(order);
            }
        }

        _connection.Close();
        return orders;
    }

    public Order UpdateOrder(Order order)
    {
        string query = "UPDATE Orders SET CustomerName = @CustomerName, CustomerPhone = @CustomerPhone, OrderDate = @OrderDate  WHERE OrderID = @OrderID";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderID", order.OrderID);
                cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerPhone", order.CustomerPhone);
                cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                if(_connection.State == System.Data.ConnectionState.Closed)
                    _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
                return order;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}