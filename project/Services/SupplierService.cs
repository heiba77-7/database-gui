



using MySqlConnector;

public class SupplierService : ISupplierService
{
    readonly MySqlConnection _connection;  
    public SupplierService(MySqlConnection connection)
    {
        _connection = connection;
    }
    public Supplier AddSupplier(Supplier supplier)
    {
        string query = "INSERT INTO Suppliers (SupplierName, ContactNumber, Email) VALUES (@SupplierName, @ContactNumber, @Email)";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                cmd.Parameters.AddWithValue("@ContactNumber", supplier.ContactNumber);
                cmd.Parameters.AddWithValue("@Email", supplier.Email);

                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Supplier added successfully.");
                }
                else
                {
                    Console.WriteLine("No rows affected.");
                }

                return supplier;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public Supplier DeleteSupplier(int id)
    {
        string query = "DELETE FROM Suppliers WHERE SupplierID = @SupplierID";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@SupplierID", id);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Supplier deleted successfully.");
                }
                else
                {
                    Console.WriteLine("No rows affected.");
                }

                return new Supplier();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public Supplier GetSupplier(int id)
    {
        string query = "SELECT * FROM Suppliers WHERE SupplierID = @SupplierID";
        try{
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@SupplierID", id);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                MySqlDataReader reader = cmd.ExecuteReader();
                Supplier supplier = new Supplier();
                while (reader.Read())
                {
                    supplier.SupplierID = reader.GetInt32("SupplierID");
                    supplier.SupplierName = reader.GetString("SupplierName");
                    supplier.ContactNumber = reader.GetString("ContactNumber");
                    supplier.Email = reader.GetString("Email");
                }
                _connection.Close();
                return supplier;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public List<Supplier> GetSuppliers()
    {
        string query = "SELECT * FROM Suppliers";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Supplier> suppliers = new List<Supplier>();
                while (reader.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SupplierID = reader.GetInt32("SupplierID");
                    supplier.SupplierName = reader.GetString("SupplierName");
                    supplier.ContactNumber = reader.GetString("ContactNumber");
                    supplier.Email = reader.GetString("Email");
                    suppliers.Add(supplier);
                }
                _connection.Close();
                return suppliers;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public List<Supplier> GetSuppliersBySupplierName(string supplierName)
    {
        string query = "SELECT * FROM Suppliers WHERE SupplierName = @SupplierName";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@SupplierName", supplierName);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Supplier> suppliers = new List<Supplier>();
                while (reader.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.SupplierID = reader.GetInt32("SupplierID");
                    supplier.SupplierName = reader.GetString("SupplierName");
                    supplier.ContactNumber = reader.GetString("ContactNumber");
                    supplier.Email = reader.GetString("Email");
                    suppliers.Add(supplier);
                }
                _connection.Close();
                return suppliers;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public Supplier UpdateSupplier(Supplier supplier)
    {
        string query = "UPDATE Suppliers SET SupplierName = @SupplierName, ContactNumber = @ContactNumber, Email = @Email WHERE SupplierID = @SupplierID";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                cmd.Parameters.AddWithValue("@ContactNumber", supplier.ContactNumber);
                cmd.Parameters.AddWithValue("@Email", supplier.Email);
                cmd.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                cmd.ExecuteNonQuery();
                _connection.Close();
                return supplier;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}
