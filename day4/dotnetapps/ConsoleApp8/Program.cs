using System;
using System.IO;
using Hexagon.DataStructure;
//1. 
//using System.Collections.Generic; 

//2. 
using Mic = System.Collections.Generic;

// Rules of Inheritance 
// 1. The class that inherits is called the derived class or sub class 
// 2. The class that inherited is called the base class or super class 
// 3. all the instance data members of the base class become part of the derived class object including all the accessors 
// 4. all the instance properties and methods, including the ctor of the base class can work on derived class object
// 5. reference variable of base class type can refer to the derived class object
// 6. using the base class reference variable refering to the derived class object,
//    we can call the methods on the base, 
//    these methods will work on derived class object 
// 7. using the base class reference variable refering to the derived class object,
//    we can call methods defined in the base class, these methods can be virtual 
//    and overriden in the derived class, that derived class method will get called 
//    which will work on derived class object .. Runtime Polymorphism 
//  NOTE: all methods in interface are virtual  - Late Binding 
// 8. 



//class Employee
//{
//    private string FirstName;
//    private string SecondName;
//    private string FullName()
//    {
//        return FirstName + " " + SecondName;
//    }
//}

//class PartTimeEmployee : Employee
//{
//    private int HourlyWage;
//}

//class FullTimeEmployee : Employee
//{
//    private int YearlyWage;
//}


//class StackFullException : Exception
//{
//    // initially first when we create stackfullexception object 
//    // ctor of stackfullexception will call the base class Exception ctor then the thread will continue executing the stackfullexception block
//    public StackFullException(/*this*/string message) : base(/*value of this*/message)
//    {

//    }
//}

//class StackEmptyExcetion : Exception
//{

//    public StackEmptyExcetion(/*this*/string message) : base(/*value of this*/message)
//    {

//    }
//}

//// Note here the data type could be anything so we are making use of generics 
//// T- that can be of any type 
//// owner of the data which should know and work on the data not others 
//class Stack<T>
//{
//    // For all the objects this will be common
//    private T[] items; // reference variable that can refer to the array object
//    private uint top = 0;

//    // constructor to change the value of individual object
//    public Stack(/*this ref. of the Stack object*/uint size) //uint the size cannot be negative 
//    {
//        this.items = new T[size];

//    }

//    public void push(/*this ref. of the Stack object*/T item)
//    {
//        if (this.top < this.items.Length)
//        {
//            this.items[this.top] = item;
//            this.top++;
//        }
//        else
//        {
//            // CLR manages the exception 
//            // in exception object alot of informaton is stored 
//            // it bubbles up 
//            // all exceptions should be handled by presentation layer
//            throw new StackFullException("stack is full");
//        }

//    }

//    public T pop(/*this ref. of the Stack object*/)
//    {
//        if (this.top > 0)
//        {
//            this.top--;
//            return this.items[this.top];
//        }
//        else
//            throw new StackEmptyExcetion("stack is empty");
//    }
//}


//PL 
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

// Abstraction - interface 
// 1. whose object is not created 
// 2. Helps the client to make late bound calls 
// 3. Client means the object that enters the implementation 
// 4. Helps in creating the reference variable that can hold the reference of implementation object 
// 5. Helps in having different implementation perform same work in different ways 
// 6. Helps in hiding the implementation to make client extensible or loosely coupled
interface ILogger
{
    void LogException(Exception ex); //virtual method 
}


// Implementation that implements the interface 
// its object reference can be stored in interface reference variable 
// Hiding implemenatation behind abstraction is called Encapsulation 
class LocalFileLogger: ILogger
{
    public void LogException(Exception ex)
    {
        StreamWriter streamWriter = new StreamWriter("log.txt", true);
        streamWriter.WriteLine(ex.ToString());
        streamWriter.WriteLine("----------------------------------------");
        streamWriter.Close(); 
    }
}

// helps in creating the implemenatation object 
// So that client can get the reference of it 
class Factory
{
    public static ILogger GetLogger()
    {
        return new LocalFileLogger();
    }
}


class Program
{
    static void Main()
    {
        ILogger logger = Factory.GetLogger(); 

        try
        {
            ConsoleUI consoleUI = new ConsoleUI();
            consoleUI.Show();
        }
        catch(Exception ex) // unhandled exception 
        {
            // log the exception 
            logger.LogException(ex); 

            Console.WriteLine("Exception occured- it is logged in log.txt"); 
        }
       
        // Example explaing the namespace 
        ////1.
        ////System.Collections.Generic.Stack<int> p = new System.Collections.Generic.Stack<int>(2);  // use fullly qualified name to remove any sort of ambiguity

        ////2. by defining a varaible
        //Mic.Stack<int> p = new Mic.Stack<int>(2); 

        //Stack<int> s = new Stack<int>(2);

        //try
        //{
        //    s.push(100);
        //    s.push(200);
        //    s.push(300);
        //}
        //catch (StackFullException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}

        //try
        //{
        //    Console.WriteLine(s.pop());
        //    Console.WriteLine(s.pop());
        //    Console.WriteLine(s.pop());

        //}
        //catch (StackEmptyExcetion ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
    }
}

