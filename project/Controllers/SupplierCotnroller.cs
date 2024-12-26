

using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

[ApiController]
[Route("/supplier")]
public class SupplierController:Controller{
    private readonly MySqlConnection _connection;
    public SupplierController(MySqlConnection connection){
        _connection = connection;
    }

    [HttpGet]
    public IActionResult Index(){
        List<Supplier> suppliers = new SupplierService(_connection).GetSuppliers();
        ViewData["Suppliers"] = suppliers;
        return View();
    }

    [HttpGet("{id}")]
    public IActionResult GetSupplier(int id){
        Supplier supplier = new SupplierService(_connection).GetSupplier(id);
        ViewData["Supplier"] = supplier;
        return View();
    }
    [HttpGet("add")]
    public IActionResult AddSupplier(){
        return View();
    }
    [HttpPost("add")]
    public IActionResult AddSupplier([FromForm]Supplier supplier){
        Supplier id = new SupplierService(_connection).AddSupplier(supplier);
        return RedirectToAction("Index");
    }
    [HttpGet("update")]
    public IActionResult UpdateSupplier(int id){
        Supplier supplier = new SupplierService(_connection).GetSupplier(id);
        ViewData["Supplier"] = supplier;
        return View();
    }
    
    [HttpPost("update")]
    public IActionResult UpdateSupplier([FromForm]Supplier supplier){
        Supplier id = new SupplierService(_connection).UpdateSupplier(supplier);
        return RedirectToAction("Index");
    }
    
}