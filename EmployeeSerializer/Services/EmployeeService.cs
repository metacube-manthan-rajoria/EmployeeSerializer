using System;
using EmployeeSerializer.Models;

namespace EmployeeSerializer.Services;

public class EmployeeService
{
    private static List<Employee> employees = new List<Employee>();

    public static List<Employee> GetEmployeeList(){
        return employees;
    }

    public static bool AddEmployee(Employee newEmployee){
        foreach(var employee in employees){
            if(employee.Equals(newEmployee)){
                return false;
            }
        }
        employees.Add(newEmployee);
        return true;
    }

    public static bool RemoveEmployee(Guid id){
        Employee? employeeToRemove = null;
        foreach(var employee in employees){
            if(employee.Id == id){
                employeeToRemove = employee;
            }
        }
        if(employeeToRemove != null){
            employees.Remove(employeeToRemove);
            return true;
        }
        return false;
    }

    public static Employee? FindFriend(Guid id){
        foreach(var employee in employees){
            if(employee.Id == id){
                return employee;
            }
        }
        return null;
    }

    public static void ClearEmployeeList(){
        employees.Clear();
    }
}
