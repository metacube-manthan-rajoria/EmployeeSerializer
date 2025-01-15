using System;
using System.Text.Json;
using System.Xml.Serialization;
using EmployeeSerializer.Models;

namespace EmployeeSerializer.Services;

public class SerializerService
{
    private static string serializationType = "txt";

    public static void SetType(string type){
        if(type == null || type.Length == 0){
            serializationType = "txt";
        }else{
            serializationType = type;
        }
    }

    public static string Type(){
        return serializationType;
    }

    public static bool SerializeData(List<Employee> employees){
        switch(serializationType){
            case "txt":
                return SerializeXML(employees);
            case "xml":
                return SerializeXML(employees);
            case "json":
                return SerializeJSON(employees);
            default:
                return SerializeXML(employees);
        }
    }

    public static List<Employee> DeserializeData(){
        switch(serializationType){
            case "txt":
                return DeserializeXML();
            case "xml":
                return DeserializeXML();
            case "json":
                return DeserializeJSON();
            default:
                return DeserializeXML();
        }
    }

    private static bool SerializeXML(List<Employee> employees){
        XmlSerializer xs = new XmlSerializer(typeof(List<Employee>));

        var mode = FileMode.Create;
        if(File.Exists("employee.xml")) mode = FileMode.Truncate;
        FileStream fs = new FileStream("employee.xml", mode, FileAccess.Write, FileShare.None);

        try{
            using (fs){
                xs.Serialize(fs, employees);
            }
        }catch{
            return false;
        }finally{
            fs.Close();
        }

        return true;
    }
    private static List<Employee> DeserializeXML(){
        if(!File.Exists("employee.xml")) return new List<Employee>();

        XmlSerializer xs = new XmlSerializer(typeof(List<Employee>));

        var mode = FileMode.Open;
        FileStream fs = new FileStream("employee.xml", mode, FileAccess.Read, FileShare.None);

        try{
            using (fs){
                List<Employee> employeeList;
                employeeList = (List<Employee>)xs.Deserialize(fs)!;
                return employeeList;
            }
        }catch{
            return new List<Employee>();
        }finally{
            fs.Close();
        }
    }
    
    public static bool SerializeJSON(List<Employee> employees){
        JsonSerializerOptions options = new(JsonSerializerDefaults.Web){
            WriteIndented = true
        };
        var result = JsonSerializer.Serialize<List<Employee>>(employees, options);

        try
        {
            File.WriteAllText("employee.json", result);
        }catch{
            return false;
        }
        return true;
    } 

    public static List<Employee> DeserializeJSON(){
        try{
            string data = File.ReadAllText("employee.json");
            var result = JsonSerializer.Deserialize<List<Employee>>(data);

            if(result == null || result.Count == 0){
                return new List<Employee>();
            }
            return result;
        }catch(FileNotFoundException){
            return new List<Employee>();
        }
    } 
}
