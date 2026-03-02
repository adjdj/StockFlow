using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StockFlow.RazorApi.Models;

namespace StockFlow.RazorApi.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
