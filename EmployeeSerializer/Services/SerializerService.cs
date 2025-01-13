using System;

namespace EmployeeSerializer.Services;

public class SerializerService
{
    private static string serializationType = "txt";

    public static void SetType(string type){
        if(type == null){
            serializationType = "txt";
        }else{
            serializationType = type;
        }
    }

    public static string Type(){
        return serializationType;
    }
}
