using System;
using System.Collections.Generic;
using System.Linq; //it has extension methods for IEnumerable<> interface 


// Extension methods are static methods of static class 
static class MyExtension
{
    // Extension methods 
    public static bool IsEven(this int i) //Compiler will take care of 
    {
        return i % 2 == 2;
    }

    // Extension methods 
    public static bool IsOdd(this int i)
    {
        return i % 2 != 2;
    }
}


class Program
{
    static void Main(string[] args)
    {

        // Example 3: Extension Method

        int[] numbers = { 10, 21, 30, 41, 50 }; // syntactic sugar 

        //1. Sum  : Extension Method provided by LINQ
        Console.WriteLine(numbers.Sum());


        //2. Where : Extension Method provided by LINQ
        // Provide me a condition 

        //2.1
        Console.WriteLine(numbers.Where(/*Internally uses callback*/ number => number % 2 != 0).Sum());

        //2.2
        //LINQ Way of writing the condition 
        Console.WriteLine((from number in numbers where number % 2 != 0 select number).Sum());

        //-------------------------------------------------------------
        int sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }

        Console.WriteLine(sum);
        //-------------------------------------------------------------
        // Internals of foreach
        IEnumerable<int> en = numbers;
        IEnumerator<int> et = en.GetEnumerator();       
        try
        {
            
            while (et.MoveNext())
            {
                int item = et.Current;
                sum += item;
            }
        }
        finally
        {
            et.Dispose();  // disposes the Enumerator 
        }
        Console.WriteLine(sum);

       


        //----------------------------------------------------------------------
        //Example 2 : Exyension Method
        int i = 10;
        Console.WriteLine(i.IsEven());
        Console.WriteLine(i.IsOdd());



        // Example 1 
        //List<int> numbers = new List<int>() { 1, 2, 3 };
        //Console.WriteLine(numbers.GetEnumerator().Current);
        //Console.WriteLine(numbers.GetEnumerator().MoveNext());
        //Console.WriteLine(numbers.GetEnumerator().Current);
    }
}

