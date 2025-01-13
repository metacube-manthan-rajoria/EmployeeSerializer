using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeSerializer.Models;
using EmployeeSerializer.Services;

namespace EmployeeSerializer.Controllers;

public class EmployeeController : Controller
{
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.employees = EmployeeService.GetEmployeeList();
        return View();
    }

    public IActionResult Add(){
        return View();
    }

    [HttpPost]
    public IActionResult Add(Employee newEmployee){
        EmployeeService.AddEmployee(newEmployee);
        ViewBag.employees = EmployeeService.GetEmployeeList();
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
