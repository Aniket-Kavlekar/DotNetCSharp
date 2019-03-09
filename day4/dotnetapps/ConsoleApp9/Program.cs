using Hexagon.DataStructure;
using System;

class ConsoleUI
{
    public void Show()
    {
        Stack<double> stack = new Stack<double>(5);

        while (true)
        {
            Console.WriteLine("1. Push");
            Console.WriteLine("2. Pop");
            Console.WriteLine("0. Quit");
            Console.Write("Select an option: ");

            int option = Convert.ToInt32(Console.ReadLine());

            //int option;
            //if (int.TryParse(Console.ReadLine(), out option))
            // {
            switch (option)
            {
                case 1:
                    {
                        while (true)
                        {
                            try
                            {
                                Console.Write("Enter an item: ");
                                double item = Convert.ToDouble(Console.ReadLine());

                                stack.push(item);
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (StackFullException ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }
                        }
                    }
                    break;

                case 2:
                    {
                        try
                        {
                            Console.WriteLine(stack.pop());
                        }
                        catch (StackEmptyExcetion ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;
                case 0:
                    break;
            }
            //}

        }
    }
}


class Program
{
    static void Main()
    {
        ILogger logger = Factory.GetLogger("logger"); 

        try
        {
            ConsoleUI consoleUI = new ConsoleUI();
            consoleUI.Show();
        }
        catch (Exception ex) // unhandled exception 
        {
            // log the exception 
            logger.LogException(ex);

            Console.WriteLine("Exception occured- it is logged in log.txt");
        }
    }
}

