using System;

class Program
{
    static void MutiplicationTable(int number, Action<int, int, int> Callback/*ref of the delegate object*/)
    {
        for(int i = 1; i<= 10; i++)
        {
            int result = number * i;
            //Console.WriteLine($"{number} x {i} = {result}"); 
            Callback(number, i, result); 
        }
    }

    static void Receiver1(int number, int index, int result)
    {
        Console.WriteLine($"{number} x {index} = {result}");
    }

    static void Receiver2(int number, int index, int result)
    {
        Console.WriteLine($"{result}");
    }


    static void Main()
    {
        MutiplicationTable(5, new Action<int, int, int>(Receiver1)/*passing the reference of the object*/); // callback to the caller 
        // Note here receiver will receive the callback and can do how the output can be printed 

        MutiplicationTable(5, new Action<int, int, int>(Receiver2)/*passing the reference of the object*/);
    }
}

