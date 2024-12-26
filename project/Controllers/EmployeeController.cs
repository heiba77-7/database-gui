using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

[ApiController]
[Route("/employee")]
public class EmployeeController:Controller{
    private readonly MySqlConnection _connection;
    public EmployeeController(MySqlConnection connection){
        _connection = connection;
    }
    [HttpGet]
    
    public IActionResult Index(){
        List<Employee> employees = new EmployeeService(_connection).GetEmployees();
        ViewData["Employees"] = employees;
        return View();
    }

    

    [HttpGet("{id}")]

    public IActionResult GetEmployee(int id){
        Employee employee = new EmployeeService(_connection).GetEmployee(id);
        ViewData["Employee"] = employee;
        return View();
    }
    [HttpGet("add")]
    public IActionResult AddEmployee(){
        return View();
    }

    [HttpPost("add")]

    public IActionResult AddEmployee([FromForm]Employee employee){
        if(!ModelState.IsValid){
            Employee id = new EmployeeService(_connection).AddEmployee(employee);
        }
        return RedirectToAction("Index");
    }

    [HttpGet("update/{id}")]
    public IActionResult UpdateEmployee(int id){
        Employee employee = new EmployeeService(_connection).GetEmployee(id);
        ViewData["Employee"] = employee;
        return View();
    }

    [HttpPost("update")]
    public IActionResult UpdateEmployee([FromForm]Employee employee, int id){
        employee.EmployeeID = id;
        Employee emp = new EmployeeService(_connection).UpdateEmployee(employee);
        return RedirectToAction("Index");
    }
}
