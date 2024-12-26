using MySqlConnector;
using System;

public class MenuItemService : IMenuItemService
{
    private readonly MySqlConnection _connection;

    public MenuItemService(MySqlConnection connection)
    {
        _connection = connection;
    }

    public MenuItem AddMenuItem(MenuItem menuItem)
    {
        string query = "INSERT INTO MenuItems (ItemName, Price, Description) VALUES (@ItemName, @Price, @Description)";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@ItemName", menuItem.ItemName);
                cmd.Parameters.AddWithValue("@Price", menuItem.Price);
                cmd.Parameters.AddWithValue("@Description", menuItem.Description);

                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Menu item added successfully.");
                }
                else
                {
                    Console.WriteLine("No rows affected.");
                }

                return menuItem;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public MenuItem DeleteMenuItem(int id)
    {
        string query = "DELETE FROM MenuItems WHERE MenuItemID = @MenuItemID";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@MenuItemID", id);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                cmd.ExecuteNonQuery();
                _connection.Close();
                return new MenuItem();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public MenuItem GetMenuItem(int id)
    {
        string query = "SELECT * FROM MenuItems WHERE MenuItemID = @MenuItemID";
        MySqlCommand cmd = new MySqlCommand(query, _connection);
        cmd.Parameters.AddWithValue("@MenuItemID", id);
        if (_connection.State == System.Data.ConnectionState.Closed)
        {
            _connection.Open();
        }
        MySqlDataReader reader = cmd.ExecuteReader();
        MenuItem menuItem = new MenuItem();
        while (reader.Read())
        {
            menuItem.MenuItemID = reader.GetInt32("MenuItemID");
            menuItem.ItemName = reader.GetString("ItemName");
            menuItem.Price = reader.GetDecimal("Price");
            menuItem.Description = reader.GetString("Description");
        }
        _connection.Close();
        return menuItem;
    }

    public List<MenuItem> GetMenuItems()
    {
        string query = "SELECT * FROM MenuItems";
        MySqlCommand cmd = new MySqlCommand(query, _connection);
        if (_connection.State == System.Data.ConnectionState.Closed)
        {
            _connection.Open();
        }
        MySqlDataReader reader = cmd.ExecuteReader();
        List<MenuItem> menuItems = new List<MenuItem>();
        while (reader.Read())
        {
            MenuItem menuItem = new MenuItem
            {
                MenuItemID = reader.GetInt32("MenuItemID"),
                ItemName = reader.GetString("ItemName"),
                Price = reader.GetDecimal("Price"),
                Description = reader.GetString("Description")
            };
            menuItems.Add(menuItem);
        }
        _connection.Close();
        return menuItems;
    }

    public List<MenuItem> GetMenuItemsByItemName(string itemName)
    {
        string query = "SELECT * FROM MenuItems WHERE ItemName = @ItemName";
        MySqlCommand cmd = new MySqlCommand(query, _connection);
        cmd.Parameters.AddWithValue("@ItemName", itemName);
        if (_connection.State == System.Data.ConnectionState.Closed)
        {
            _connection.Open();
        }
        MySqlDataReader reader = cmd.ExecuteReader();
        List<MenuItem> menuItems = new List<MenuItem>();
        while (reader.Read())
        {
            MenuItem menuItem = new MenuItem
            {
                MenuItemID = reader.GetInt32("MenuItemID"),
                ItemName = reader.GetString("ItemName"),
                Price = reader.GetDecimal("Price"),
                Description = reader.GetString("Description")
            };
            menuItems.Add(menuItem);
        }
        _connection.Close();
        return menuItems;
    }

    public MenuItem UpdateMenuItem(MenuItem menuItem)
    {
        string query = "UPDATE MenuItems SET ItemName = @ItemName, Price = @Price, Description = @Description WHERE MenuItemID = @MenuItemID";
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@ItemName", menuItem.ItemName);
                cmd.Parameters.AddWithValue("@Price", menuItem.Price);
                cmd.Parameters.AddWithValue("@Description", menuItem.Description);
                cmd.Parameters.AddWithValue("@MenuItemID", menuItem.MenuItemID);
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
                cmd.ExecuteNonQuery();
                _connection.Close();
                return menuItem;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
