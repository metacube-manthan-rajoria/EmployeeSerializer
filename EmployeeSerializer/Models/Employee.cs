using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSerializer.Models;

[Serializable]
public class Employee
{
    [Required]
    public Guid Id {get; set;}

    [Required]
    [MaxLength(30)]
    public string? EmployeeName {get; set;}

    [Required]
    public string? EmployeeDepartment {get; set;}

    [Required]
    public double EmployeeSalary {get; set;}

    public string? SerialType {get; set;}
}
