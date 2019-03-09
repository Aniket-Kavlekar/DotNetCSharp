using System;

// Two access modifiers can be applied to class 
// 1. internal: accessible only within the assembly we using 
// 2. public: accessible out side the dll 
// by default all access modifiers for class is internal 

// DLL 
// DLL will be the physical container of the class 
// DLL contains definition of methods belonging to the class 
// DLL contains declaration of the class as well as whatever the class conatins .. Metadata 
// Metadata is readable programmatically - Reflection


// Note only class names have changed
namespace Hexagon.DataStructure
{
    public class StackFullException : Exception
    {
        // initially first when we create stackfullexception object 
        // ctor of stackfullexception will call the base class Exception ctor then the thread will continue executing the stackfullexception block
        public StackFullException(/*this*/string message) : base(/*value of this*/message)
        {

        }
    }

    public class StackEmptyExcetion : Exception
    {

        public StackEmptyExcetion(/*this*/string message) : base(/*value of this*/message)
        {

        }
    }

    // Note here the data type could be anything so we are making use of generics 
    // T- that can be of any type 
    // owner of the data which should know and work on the data not others 
    public class Stack<T>
    {
        // For all the objects this will be common
        private T[] items; // reference variable that can refer to the array object
        private uint top = 0;

        // constructor to change the value of individual object
        public Stack(/*this ref. of the Stack object*/uint size) //uint the size cannot be negative 
        {
            this.items = new T[size];

        }

        /// <summary>
        /// Push helps in adding items at the end of stack 
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="StackFullException">when stack is full</exception>
        public void push(/*this ref. of the Stack object*/T item)
        {
            if (this.top < this.items.Length)
            {
                this.items[this.top] = item;
                this.top++;
            }
            else
            {
                // CLR manages the exception 
                // in exception object alot of informaton is stored 
                // it bubbles up 
                // all exceptions should be handled by presentation layer
                throw new StackFullException("stack is full");
            }

        }

        public T pop(/*this ref. of the Stack object*/)
        {
            if (this.top > 0)
            {
                this.top--;
                return this.items[this.top];              
            }
            else
                throw new StackEmptyExcetion("stack is empty");
        }
    }
}

