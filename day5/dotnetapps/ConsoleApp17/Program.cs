using System;
using System.Threading.Tasks;

// Microsoft has provided several collection classes 
// by default collections are not synchronized
//  1.  Stack
//  2.  Linked List 
//  3.  Dictionary
//  4.  List

// synchronized 

class Counter
{
    private int count = 0;

    public int Increment()
    {
        return this.count++;
    }

    public int Decrement()
    {
        return this.count--;
    }
}


// Thread safe class 
// concrrent bag 
// concurrent dictionary 
// concurrent blocking collection 

class ConcurrentCounter
{
    private int count = 0;
    private object sync = new object(); 

    public int Increment()
    {
        lock (sync)
        {
            return ++this.count;
        }
       
    }

    public int Decrement()
    {
        lock (sync)
        {
            return --this.count;
        }      
    }
}



class Program
{
    static void Main(string[] args)
    {
        ConcurrentCounter counter = new ConcurrentCounter();

        Task.Run(() =>
        {
            counter.Increment();
            counter.Increment();
            counter.Increment();
            counter.Increment();

        });

        Task.Run(() =>
        {
            counter.Decrement();
            counter.Decrement();
            counter.Decrement();
            Console.WriteLine(counter.Decrement());
        });

        Console.ReadLine();
    }
}

