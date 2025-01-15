using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSerializer.Models;

[Serializable]
public class Employee
{
    [Required(ErrorMessage = "Unique Id is required.")]
    public Guid Id {get; set;}

    [Required(ErrorMessage = "Employee Name is required.")]
    [MaxLength(30)]
    public string? EmployeeName {get; set;}

    [Required(ErrorMessage = "Employee Department is required.")]
    public string? EmployeeDepartment {get; set;}

    [Required(ErrorMessage = "Employee Salary is required.")]
    public double EmployeeSalary {get; set;}
}
