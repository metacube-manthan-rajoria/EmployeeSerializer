using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeSerializer.Models;
using EmployeeSerializer.Services;

namespace EmployeeSerializer.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(Serializer serial)
    {
        SerializerService.SetType(serial.SerialType!);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
