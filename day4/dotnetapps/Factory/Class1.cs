using System.Configuration;
using System.Reflection;
using System; 

// helps in creating implementing object so that client can obtain refernce 
public class Factory
{
    public static ILogger GetLogger(string key)
    {
        // use reflection to create logger implementation object 

        string value = ConfigurationManager.AppSettings[key];
        string[] items = value.Split(',');

        Assembly dll = Assembly.LoadFrom(items[0]); // load the DLL 
        Type type = dll.GetType(items[1]);          // load the class from the DLL 

        return Activator.CreateInstance(type) as ILogger; 
        // the class whose object is being created here
        // if doesn't implement ILogger "as" will return null 
        // if implements ILogger "as" will return the reference of the object 
        // typeasted(downcasting) to ILogger from System.Object

    }
}

