

public interface IMenuItemService
{
    List<MenuItem> GetMenuItems();
    MenuItem GetMenuItem(int id);
    MenuItem AddMenuItem(MenuItem menuItem);
    MenuItem UpdateMenuItem(MenuItem menuItem);
    MenuItem DeleteMenuItem(int id);

    List<MenuItem> GetMenuItemsByItemName(string itemName);
}