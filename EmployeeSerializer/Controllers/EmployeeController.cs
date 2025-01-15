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

    [HttpPost]
    public IActionResult Index(Serializer serial)
    {
        // Reading data from file
        SerializerService.SetType(serial.SerialType!);
        List<Employee> empList = SerializerService.DeserializeData();
        foreach(var employee in empList){
            EmployeeService.AddEmployee(employee);
        }

        ViewBag.employees = EmployeeService.GetEmployeeList();
        return View();
    }

    public IActionResult Add(){
        return View();
    }

    [HttpPost]
    public IActionResult Add(Employee newEmployee){
        if(ModelState.IsValid){
            newEmployee.Id = Guid.NewGuid();
            EmployeeService.AddEmployee(newEmployee);

            // Saving Data to file
            SerializerService.SerializeData(EmployeeService.GetEmployeeList());
        }else{
            ViewBag.error = "Employee not added - Enter valid details.";
        }
        ViewBag.employees = EmployeeService.GetEmployeeList();
        return View("Index");
    }

    public IActionResult Delete(Guid id){
        EmployeeService.RemoveEmployee(id);

        // Saving Data to file
        SerializerService.SerializeData(EmployeeService.GetEmployeeList());
        
        ViewBag.employees = EmployeeService.GetEmployeeList();
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
