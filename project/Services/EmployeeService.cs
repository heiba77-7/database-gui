using MySqlConnector;
using System;

public class EmployeeService : IEmployeeService
{
    private readonly MySqlConnection _connection;

    public EmployeeService(MySqlConnection connection)
    {
        _connection = connection;
    }

    public Employee AddEmployee(Employee employee)
    {
        string query = "INSERT INTO Employees (FirstName, LastName, Position, PhoneNumber, Email) VALUES (@FirstName, @LastName, @Position, @PhoneNumber, @Email)";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Position", employee.Position);
                cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                cmd.ExecuteNonQuery();
                _connection.Close();

                Employee newEmployee = GetEmployeeByEmailAddress(employee.Email);
                return newEmployee;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Employee DeleteEmployee(int id)
    {
        string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", id);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                cmd.ExecuteNonQuery();
                _connection.Close();
                return new Employee();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Employee GetEmployee(int id)
    {
        string query = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", id);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                MySqlDataReader reader = cmd.ExecuteReader();
                Employee employee = new Employee();
                while (reader.Read())
                {
                    employee.EmployeeID = reader.GetInt32("EmployeeID");
                    employee.FirstName = reader.GetString("FirstName");
                    employee.LastName = reader.GetString("LastName");
                    employee.Position = reader.GetString("Position");
                    employee.PhoneNumber = reader.GetString("PhoneNumber");
                    employee.Email = reader.GetString("Email");
                }
                _connection.Close();
                return employee;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Employee GetEmployeeByEmailAddress(string email)
    {
        string query = "SELECT * FROM Employees WHERE Email = @Email";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                MySqlDataReader reader = cmd.ExecuteReader();
                Employee employee = new Employee();
                while (reader.Read())
                {
                    employee.EmployeeID = reader.GetInt32("EmployeeID");
                    employee.FirstName = reader.GetString("FirstName");
                    employee.LastName = reader.GetString("LastName");
                    employee.Position = reader.GetString("Position");
                    employee.PhoneNumber = reader.GetString("PhoneNumber");
                    employee.Email = reader.GetString("Email");
                }
                _connection.Close();
                return employee;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Employee GetEmployeeByFirstName(string firstName)
    {
        string query = "SELECT * FROM Employees WHERE FirstName = @FirstName";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                MySqlDataReader reader = cmd.ExecuteReader();
                Employee employee = new Employee();
                while (reader.Read())
                {
                    employee.EmployeeID = reader.GetInt32("EmployeeID");
                    employee.FirstName = reader.GetString("FirstName");
                    employee.LastName = reader.GetString("LastName");
                    employee.Position = reader.GetString("Position");
                    employee.PhoneNumber = reader.GetString("PhoneNumber");
                    employee.Email = reader.GetString("Email");
                }
                _connection.Close();
                return employee;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Employee GetEmployeeByLastName(string lastName)
    {
        string query = "SELECT * FROM Employees WHERE LastName = @LastName";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                MySqlDataReader reader = cmd.ExecuteReader();
                Employee employee = new Employee();
                while (reader.Read())
                {
                    employee.EmployeeID = reader.GetInt32("EmployeeID");
                    employee.FirstName = reader.GetString("FirstName");
                    employee.LastName = reader.GetString("LastName");
                    employee.Position = reader.GetString("Position");
                    employee.PhoneNumber = reader.GetString("PhoneNumber");
                    employee.Email = reader.GetString("Email");
                }
                _connection.Close();
                return employee;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }

    public List<Employee> GetEmployees()
    {
        string query = "SELECT * FROM Employees";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Employee> employees = new List<Employee>();
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeID = reader.GetInt32("EmployeeID");
                    employee.FirstName = reader.GetString("FirstName");
                    employee.LastName = reader.GetString("LastName");
                    employee.Position = reader.GetString("Position");
                    employee.PhoneNumber = reader.GetString("PhoneNumber");
                    employee.Email = reader.GetString("Email");
                    employees.Add(employee);
                }
                _connection.Close();
                return employees;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Employee UpdateEmployee(Employee employee)
    {
        string query = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Position = @Position, PhoneNumber = @PhoneNumber, Email = @Email WHERE EmployeeID = @EmployeeID";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Position", employee.Position);
                cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                cmd.ExecuteNonQuery();
                _connection.Close();
                return employee;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<Employee> GetAllEmployees(){
        string query = "SELECT * FROM Employees";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Employee> employees = new List<Employee>();
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeID = reader.GetInt32("EmployeeID");
                    employee.FirstName = reader.GetString("FirstName");
                    employee.LastName = reader.GetString("LastName");
                    employee.Position = reader.GetString("Position");
                    employee.PhoneNumber = reader.GetString("PhoneNumber");
                    employee.Email = reader.GetString("Email");
                    employees.Add(employee);
                }
                _connection.Close();
                return employees;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}