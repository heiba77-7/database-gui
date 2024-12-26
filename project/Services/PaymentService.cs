


using System.Data;
using MySqlConnector;

public class PaymentService : IPaymentService
{
    readonly MySqlConnection _connection;

    public PaymentService(MySqlConnection connection)
    {
        _connection = connection;
    }
    public Payment AddPayment(Payment payment)
    {
        string query = "INSERT INTO Payments (OrderID, PaymentMethod, PaymentStatus, PaymentDate) VALUES (@OrderID, @PaymentMethod, @PaymentStatus, @PaymentDate)";
        try{
            _connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderID", payment.OrderID);
                cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                cmd.Parameters.AddWithValue("@PaymentStatus", payment.PaymentStatus);
                cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                cmd.ExecuteNonQuery();
            }
            _connection.Close();
            return payment;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Payment DeletePayment(int id)
    {
        string query = "DELETE FROM Payments WHERE PaymentID = @Payment";
        try{
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@PaymentID", id);
                cmd.ExecuteNonQuery();
            }
            _connection.Close();
            return GetPayment(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    
    }

    public List<Payment> GetAllPayments()
    {
        string query = "SELECT * FROM Payments";
        try{
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                {
                    List<Payment> payments = new List<Payment>();
                    while (dataReader.Read())
                    {
                        Payment payment = new Payment();
                        payment.PaymentID = dataReader.GetInt32("PaymentID");
                        payment.OrderID = dataReader.GetInt32("OrderID");
                        payment.PaymentMethod = dataReader.GetString("PaymentMethod");
                        payment.PaymentStatus = dataReader.GetString("PaymentStatus");
                        payment.PaymentDate = dataReader.GetDateTime("PaymentDate");
                        payments.Add(payment);
                    }
                    return payments;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Payment GetByOrderID(int orderID)
    {
        string query = "SELECT * FROM Payments WHERE OrderID = @OrderID";
        try{
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderID);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Payment payment = new Payment();
                        payment.PaymentID = reader.GetInt32("PaymentID");
                        payment.OrderID = reader.GetInt32("OrderID");
                        payment.PaymentMethod = reader.GetString("PaymentMethod");
                        payment.PaymentStatus = reader.GetString("PaymentStatus");
                        payment.PaymentDate = reader.GetDateTime("PaymentDate");
                        return payment;
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

    public Payment GetPayment(int id)
    {
        string query = "SELECT * FROM Payments WHERE PaymentID = @Payment";
        try{ if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@PaymentID", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Payment payment = new Payment();
                        payment.PaymentID = reader.GetInt32("PaymentID");
                        payment.OrderID = reader.GetInt32("OrderID");
                        payment.PaymentMethod = reader.GetString("PaymentMethod");
                        payment.PaymentStatus = reader.GetString("PaymentStatus");
                        payment.PaymentDate = reader.GetDateTime("PaymentDate");
                        return payment;
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

    public Payment UpdatePayment(Payment payment)
    {
        string query = "UPDATE Payments SET OrderID = @OrderID, PaymentMethod = @PaymentMethod, PaymentStatus = @PaymentStatus, PaymentDate = @PaymentDate WHERE PaymentID = @PaymentID";
        try{ 
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@OrderID", payment.OrderID);
                cmd.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                cmd.Parameters.AddWithValue("@PaymentStatus", payment.PaymentStatus);
                cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                cmd.Parameters.AddWithValue("@PaymentID", payment.PaymentID);
                cmd.ExecuteNonQuery();
            }
            _connection.Close();
            return payment;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    
}
