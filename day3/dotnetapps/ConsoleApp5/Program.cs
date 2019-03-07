using System;


// create data type as value type if 
// 1. size of object <= 16 bytes 
// 2. value type objects cannot be returned from the function by reference 
// 3. value type object wehn created inside the function they are created on the executing thread's stack 
//    when multiple threads are executing, value type ojects are created on all the threads 
// 4. value type cannot inherit any other type 
// 5. value type cannot be inherited 
// 6. value type by default inherit value types 
// 7. value type objects can be passed by value or by reference to another function 
// 8. value type can be returned by value from the function 
// 9. when value type objects are used in late binding calls, they are moved from stack to heap. This is called boxing. 
//    this happens when we implement the interface in value and assign value type object to reference variable of interface
// 10. we can create array of value type objects
// 11. when an array of value type is created, array of objects are created 
// 12. whereas, when array of reference type is created an array of reference varaiable are created 
// 13. reference type variables when created inside the function they are created on stack, but objects are created on heap, that is done using new 
// 14. reference type objects are long lived. they can be returned by ref. from the function and passed as ref to the function 
// 15. primitive types: int, float, double, bool , char and types created using struct 
// 16. reference types: string, array and types created using class 
// 17. reference types can inherit any types, refernce types and can be inherited from other reference types 
// 


struct Point2D // value type 
{
    int x, y; 
}

struct Line2D
{
    Point2D startPoint, endPoint; 
}

class Program
{
    // CLR calls main using the main thread 
    static void Main()
    {
        // compiler decides how much memory to allocated

        // 1. for value type without assigning default value 
        //int x; 

        //2. value type can be assigned default value 
        //int x = 10; // x is an object, created on main thread 

        int x = new int();

        // compiler decides how much memory to allocated
        Point2D p1 = new Point2D(); // p1 is an object, created on main thread stack
        // p1 contains x and y 

        Line2D l1 = new Line2D(); 



    } // compiler decides when to deallocate the memory
}

