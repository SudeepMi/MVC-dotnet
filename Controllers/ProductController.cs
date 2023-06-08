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
    private List<Products> products = new List<Products>();

    public IActionResult Index()
    {
        using var connection = new MySqlConnection("Server=localhost;User ID=root;Password=password;Database=dotnet");
        connection.Open();
        string q = "SELECT * from products"; 
        using var command = new MySqlCommand(q, connection);
        MySqlDataReader reader = command.ExecuteReader();
        while(reader.Read()){
            Products product = new Products();
            product.ID = reader["ID"].ToString();
            product.Code = reader["Code"].ToString();
            product.Name = reader["Name"].ToString();
            product.Price = Convert.ToDouble(reader["Price"]);
            products.Add(product);
        }
        return View(products);
    }
    public IActionResult NewProduct()
    {
      
        return View();
    }

    public IActionResult Detail(string id){
        using var connection = new MySqlConnection("Server=localhost;User ID=root;Password=password;Database=dotnet");
        connection.Open();
        string q = "SELECT * from products WHERE ID='"+id+"'"; 
        using var command = new MySqlCommand(q, connection);
        MySqlDataReader reader = command.ExecuteReader();
        Products product = new Products();
        while(reader.Read()){
            product.ID = reader["ID"].ToString();
            product.Code = reader["Code"].ToString();
            product.Name = reader["Name"].ToString();
            product.Price = Convert.ToDouble(reader["Price"]);
        }
        return View(product);
    }

    public IActionResult Edit(string id){
        using var connection = new MySqlConnection("Server=localhost;User ID=root;Password=password;Database=dotnet");
        connection.Open();
        string q = "SELECT * from products WHERE ID='"+id+"'"; 
        using var command = new MySqlCommand(q, connection);
        MySqlDataReader reader = command.ExecuteReader();
        Products product = new Products();
        while(reader.Read()){
            product.ID = reader["ID"].ToString();
            product.Code = reader["Code"].ToString();
            product.Name = reader["Name"].ToString();
            product.Price = Convert.ToDouble(reader["Price"]);
        }
        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Products p){
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        using var connection = new MySqlConnection("Server=localhost;User ID=root;Password=password;Database=dotnet");
        connection.Open();
        string q = "UPDATE products SET Name='"+p.Name+"', Code='"+p.Code+"',ID='"+p.ID+"',Price='"+p.Price+"'"; 
        Console.WriteLine(q);
        using var command = new MySqlCommand(q, connection);
        int reader = command.ExecuteNonQuery();
        Console.WriteLine(reader);
        ViewData["product"] = "Updated";
        return View();
    }

    public IActionResult Delete(Products p){
       
        using var connection = new MySqlConnection("Server=localhost;User ID=root;Password=password;Database=dotnet");
        connection.Open();
        string q = "DELETE from products WHERE ID='"+p.ID+"'"; 
        using var command = new MySqlCommand(q, connection);
        int reader = command.ExecuteNonQuery();
        Console.WriteLine(reader);
        ViewData["product"] = "Delete";
        return Redirect("/Product/");                         
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
        string q = "INSERT INTO products(Name,Code,ID,Price) VALUES('"+p.Name+"','"+p.Code+"','"+p.ID+"','"+p.Price+"')"; 
        Console.WriteLine(q);
        using var command = new MySqlCommand(q, connection);
        int reader = command.ExecuteNonQuery();
        Console.WriteLine(reader);
        ViewData["product"] = "Done";
        return Redirect("/Product/");        
    }
}
