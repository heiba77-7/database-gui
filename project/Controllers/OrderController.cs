using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Collections.Generic;


[ApiController]
[Route("/order")]
[Route("/")]
public class OrdersController : Controller
{
    private readonly MySqlConnection _connection;

    public OrdersController(IConfiguration configuration)
    {
        _connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Order> orders = new OrderService(_connection).GetOrders();
        return View(orders);
    }

    [HttpGet("{id}")]
    public IActionResult GetOrder(int id)
    {
        Order order = new OrderService(_connection).GetOrder(id);
        List<OrderDetail> orderDetails = new OrderDetailService(_connection).GetOrderDetailsByOrderID(id);
        List<MenuItem> menuItems = new List<MenuItem>();
        Payment payment = new PaymentService(_connection).GetByOrderID(id);

        foreach (OrderDetail orderDetail in orderDetails)
        {
            MenuItem menuItem = new MenuItemService(_connection).GetMenuItem(orderDetail.MenuItemID);
            menuItems.Add(menuItem);
        }
        ViewData["OrderDetails"] = orderDetails;
        ViewData["MenuItems"] = menuItems;
        ViewData["Payment"] = payment;
        return View(order);
    }

    [HttpGet("add")]
    public IActionResult AddOrder()
    {
        ViewData["MenuItems"] = new MenuItemService(_connection).GetMenuItems();
        ViewData["Employees"] = new EmployeeService(_connection).GetEmployees();
        return View();
    }

    [HttpPost("add")]
    public IActionResult AddOrder([FromBody] AddOrder order)
    {
        Order newOrder = new OrderService(_connection).AddOrder(order.order);
        Console.WriteLine(newOrder.OrderID);
        order.payment.OrderID = newOrder.OrderID;
        new PaymentService(_connection).AddPayment(order.payment);
        order.orderDelivery.OrderID = newOrder.OrderID;
        new OrderDeliveryService(_connection).AddOrderDelivery(order.orderDelivery);
        foreach (OrderDetail orderDetail in order.orderDetails)
        {
            orderDetail.OrderID = newOrder.OrderID;
            new OrderDetailService(_connection).AddOrderDetail(orderDetail);
        }
        return RedirectToAction("Index");
    }

    [HttpGet("update")]
    public IActionResult UpdateOrder(int id)
    {
        ViewData["MenuItems"] = new MenuItemService(_connection).GetMenuItems();
        ViewData["Employees"] = new EmployeeService(_connection).GetEmployees();
        AddOrder order = new AddOrder();
        order.order = new OrderService(_connection).GetOrder(id);
        order.payment = new PaymentService(_connection).GetByOrderID(id);
        order.orderDelivery = new OrderDeliveryService(_connection).GetByOrderId(id);
        order.orderDetails = new OrderDetailService(_connection).GetOrderDetailsByOrderID(id);
        ViewData["Order"] = order;
        return View();
    }


    [HttpPost("update")]
    public IActionResult UpdateOrder([FromBody] AddOrder order)
    {
        new OrderService(_connection).UpdateOrder(order.order);
        List<OrderDetail> orderDetails = new OrderDetailService(_connection).GetOrderDetailsByOrderID(order.order.OrderID);
        new PaymentService(_connection).UpdatePayment(order.payment);
        new OrderDeliveryService(_connection).UpdateOrderDelivery(order.orderDelivery);
        foreach (OrderDetail orderDetail in order.orderDetails)
        {
            orderDetail.OrderID = order.order.OrderID;
            if(orderDetails.Select(x => x.OrderDetailID).Contains(orderDetail.OrderDetailID))
            {
                new OrderDetailService(_connection).UpdateOrderDetail(orderDetail);
            }else if(!orderDetails.Contains(orderDetail)){
                new OrderDetailService(_connection).AddOrderDetail(orderDetail);
            }
        }
        List<OrderDetail> newOrderDetails = new OrderDetailService(_connection).GetOrderDetailsByOrderID(order.order.OrderID);
        foreach (OrderDetail orderDetail in newOrderDetails)
        {
            if(!order.orderDetails.Select(x => x.OrderDetailID).Contains(orderDetail.OrderDetailID))
            {
                new OrderDetailService(_connection).DeleteOrderDetail(orderDetail.OrderDetailID);
            }
        }
        return RedirectToAction("Index");
    }
}