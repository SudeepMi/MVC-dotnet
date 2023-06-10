using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MySqlConnector;
namespace MVC.Controllers;


public class UserController : Controller
{

    private readonly UserContext _context;
    public UserController(UserContext context)
    {
        _context = context;
    }


    public IActionResult Index()
    {
        var products = _context.Users.ToArray();
        return View(products);
    }

    public IActionResult NewUser()
    {

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> NewUser(User user)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                ViewData["message"] = "Done";
                return RedirectToAction(nameof(Index));
            }
        }
        catch (Exception /* ex */)
        {
            //Log the error (uncomment ex variable name and write a log.
            ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");
        }

        return View();
    }






}
