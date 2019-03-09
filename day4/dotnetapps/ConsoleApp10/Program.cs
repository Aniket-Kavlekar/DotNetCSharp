using System;
using System.Collections.Generic; 

class Program
{
    static void Main()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        dictionary["Jan"] = 31;
        dictionary["Feb"] = 28;
        dictionary["Mar"] = 30;
        dictionary["Apr"] = 31;

        Console.WriteLine(dictionary.ContainsKey("Jun"));
        Console.WriteLine(dictionary.ContainsKey("Jan"));
        Console.WriteLine(dictionary["Jan"]);
    }

    //TO DO:  how to remove the key from the dictionary 

}

