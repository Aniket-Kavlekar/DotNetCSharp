using System;

enum WEEKDAYS : int
{
    Sunday = 0,
    Monday = 1, 
    Tuesday = 2,
    Wednesday = 3, 
    Thursday = 4,
    Friday = 5,
    Saturday = 6
}


class Program
{
    static void Main()
    {
        //Console.WriteLine(WEEKDAYS.Monday); //Monday

        //WEEKDAYS w1 = WEEKDAYS.Monday;
        //WEEKDAYS w2 = WEEKDAYS.Tuesday;

        //Console.WriteLine("WEEKDAYS.Monday == w1: " + (WEEKDAYS.Monday == w1)); //True
        //Console.WriteLine("WEEKDAYS.Monday == w2: " + (WEEKDAYS.Monday == w2)); //False

        //Console.WriteLine((int)WEEKDAYS.Monday); //1
        //Console.WriteLine("(int)WEEKDAYS.Monday == 1: " + ((int)WEEKDAYS.Monday == 1)); //true

        //int input = Convert.ToInt32(Console.ReadLine());
        //if ((int)w1 == input)
        //{
        //    Console.WriteLine("w1 == int: TRUE"); 
        //}

        //if(w1 == (WEEKDAYS)input)
        //{
        //    Console.WriteLine("w1 == (WEEKDAYS)int: TRUE");
        //}

        ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(); 
        if (consoleKeyInfo.Key == ConsoleKey.D0)
        {
            Console.WriteLine("\n\nWriting to File: "+ 48); 
        }

        int input = Convert.ToInt32(Console.ReadLine());
        if (input == (int)ConsoleKey.D0)
        {
            Console.WriteLine("\n\nReading to File: " + 0);
        }
    }
}

