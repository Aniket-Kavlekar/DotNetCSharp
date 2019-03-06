
// 
struct Heap
{

}

// They contain data in it 
// We can perform some operations on the instance 
// Data type created using the class must be long lived that means it should be created on heap 
class Stack // Data Type 
{
    // 1. Instance data members or instance feilds 
    // (become a part of each and every data type)
    // Used for holding the data for each instance 

    int[] items = new int[1000];

    public int Top { get; private set; } //Auto implemented instance property

    //int top = 0; // even if we remove this its okay instance feilds get default values
    //public int Top // fully implemented property 
    //{
    //    get // int get_Top(stack this)
    //    {
    //        return top;
    //    }
    //    private set // void set_Top(stack this, int value)
    //    {
    //        top = value; 
    //    }
    //}

    // 2. Instance members 
    // (Are loaded only once in memory) 
    // perform operations on the instance feilds means they need the reference of the instance
    // which they receive in this. 
    // this is always there first paramter*/

    public void Push(/*this - ref of the Stack*/ int item)
    {
        if (Top < items.Length)
        {
            this.items[Top] = item;
            this.Top++;
        }
        else
            throw new System.Exception("stack is full");       
    }

    public int Pop(/*this - ref of the Stack*/)
    {
        if (Top > 0)
        {
            this.Top--;
            return this.items[Top];
        }
        else
            throw new System.Exception("stack is empty"); 
    }

    // 3. Instance Properties (are implemented as methods) 
    // (Are loaded only once in memory) 
    // perform operations on the instance feilds means they need the reference of the instance
    // which they receive in this. 
    // this is always there first paramter

    // read only property 
    //public int Top
    //{
    //    get // int get_Top(stack this)
    //    {
    //        return top; 
    //    }
    //}

    // 4. Instance Events 

}


class App4 // Data type 
{
    //CSC will mark the Main as the entry point, CLR calls this function 
    // as the first function 
    static void Main() // doesnt have this 
    {
        Stack s1 = new Stack();
        // s1 is a "reference variable" 
        // new creates an instance of the object 
        // new returns reference that is stored in s1 


        Stack s2 = new Stack();
        // s2 is a "reference variable"  
        // new creates an instance of the object 
        // new returns reference that is stored in s2

        s1.Push(1000);  // push (value of s1= ref. of the instance, 1000) 
        s2.Push(100);   // push (value of s2= ref. of the instance, 100) 


        System.Console.WriteLine(s1.Top); //s1.get_Top(); 


    } // s1 , s2 are short lived and will die after main is over 
    // new Stack() and new Stack() are long lived objects they die only after the 
}

// CLR will call: App4.Main()