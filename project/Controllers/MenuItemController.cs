
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

[ApiController]
[Route("/menuitem")]
public class MenuItemController:Controller{
    private readonly MySqlConnection _connection;
    public MenuItemController(MySqlConnection connection){
        _connection = connection;
    }
    [HttpGet]
    public IActionResult Index(){
        List<MenuItem> menuItems = new MenuItemService(_connection).GetMenuItems();
        ViewData["MenuItems"] = menuItems;
        return View();
    }

    [HttpGet("{id}")]
    public IActionResult GetMenuItem(int id){
        MenuItem menuItem = new MenuItemService(_connection).GetMenuItem(id);
        ViewData["MenuItem"] = menuItem;
        return View();
    }
    [HttpGet("add")]
    public IActionResult AddMenuItem(){
        return View();
    }

    [HttpPost("add")]
    public IActionResult AddMenuItem([FromForm]MenuItem menuItem){
        MenuItem id = new MenuItemService(_connection).AddMenuItem(menuItem);
        return RedirectToAction("Index");
    }

    [HttpGet("update")]
    public IActionResult UpdateMenuItem(int id){
        MenuItem menuItem = new MenuItemService(_connection).GetMenuItem(id);
        ViewData["MenuItem"] = menuItem;
        return View();
    }

    [HttpPost("update")]
    public IActionResult UpdateMenuItem([FromForm]MenuItem menuItem){
        MenuItem id = new MenuItemService(_connection).UpdateMenuItem(menuItem);
        return RedirectToAction("Index");
    }
}