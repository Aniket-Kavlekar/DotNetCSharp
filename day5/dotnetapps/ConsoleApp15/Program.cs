using System;
using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json;

// Attribute can be applied to 
// 1. class 
// 2. Field 
// 3. event 
// 4. method 
// 5. assembly 

// attribute is used to provide some extra information to something -> check who is using it (CLR, compiler or SerializeObject) 
// attribute should always be used 


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
class DoNotDisplay : Attribute
{
}


class ConsoleUI
{
    public void Display(object obj)
    {
        // List all the properties of that object
        PropertyInfo[] properties = obj.GetType().GetProperties();
        foreach (var property in properties)
        {
            Attribute attribute = property.GetCustomAttribute(typeof(DoNotDisplay));
            if (attribute == null)
                Console.WriteLine(property.Name);
        }
    }
}

class Question
{
    [JsonIgnore] //Attribute provided by Newtonsoft.Json
    public int Id { get; set; }

    [DoNotDisplay]
    public string Statement { get; set; }

    public Question()
    {
        Statement = string.Empty;
    }
}

class Program
{
    [Conditional("DEBUG")]
    static void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red; 
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    static void Main()
    {

        // Ex 3 
        Debug.WriteLine("Hello"); // this call will be removed from release build 
        // Note these are sent to visual studios output window 
        //  [Conditional("DEBUG")] - compiler uses the attribute, removes all the calls happening in release build 


        // Ex 2
        //Log("Creating Question Object");
        //Question question = new Question();

        //Log("Creating console UI Object");
        //ConsoleUI consoleUI = new ConsoleUI();

        //Log("Calling Display");
        //consoleUI.Display(question);


        // Ex 1 
        //Question question = new Question();
        //string json = JsonConvert.SerializeObject(question);
        //Console.WriteLine(json); 
    }
}

