using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MySqlConnector;
namespace MVC.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewData["product"] = "asdadas";
        ViewBag.productId = "122";

        return View();
    }
    public IActionResult NewProduct()
    {
        return View();
    }

    [HttpPost]
    public IActionResult NewProduct(Products p)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        using var connection = new MySqlConnection("Server=localhost;User ID=root;Password=password;Database=dotnet");
        connection.Open();
        string q = "INSERT INTO products VALUES('"+p.Name+"','"+p.Code+"','"+p.ID+"','"+p.Price+"')"; 
        Console.WriteLine(q);
        using var command = new MySqlCommand(q, connection);
        int reader = command.ExecuteNonQuery();
        Console.WriteLine(reader);
        ViewData["product"] = "Done";
        return View();
    }
}
