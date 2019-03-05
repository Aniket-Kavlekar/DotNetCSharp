using System; // this provides the primitive data type 

// create a new data type 
// this will be an object 
// it will contain the code and the data on which it has to act 
// create a data type that multiple object type can be created from it 
class DynamicArray
{
    double[] numbers = new double[0]; // Instance data member or instance feild 
    // instance data members become part of each and every object 

    // NOTE:  method and properties are loaded only once in memory 
    // how will they come to know on which object to work on 
    // thwy will come to know by the ref. of the object coming by this 

    // property 
    // they actually become method internally 
    public int Length
    {
        get /*DynamicArray this = reference of calling the object*/
        {
            return numbers.Length; //this.numbers.length 
        }
    }

    // indexed property 
    public double this[int index]
    {
        get //get_[index] (/*this = ref. of the calling object*/)
        {
            return numbers[index];
        }
    }

 public void Add(/*DynamicArray this = reference of calling the object*/ double number)
    {
        // grow the array by one new location 
        double[] bigger = new double[numbers.Length + 1]; //this.numbers.length + 1

        // for copying the data from smaller array to a new bigger array 
        for (int i = 0; i < numbers.Length; i++) //this.numbers.length 
        {
            bigger[i] = numbers[i]; //this.numbers[i]
        }

        // numbers will start referencing to a new array object 
        numbers = bigger; //this.numbers = bigger;

        // storing the latest entered data in the last location 
        numbers[numbers.Length - 1] = number; //this.numbers[this.numbers.Length - 1] = number;
    }
    // instance method 
   
}

class Program
{
    // CSC marks the Main as the entry point of the application, 
    // so that CLR calls it at runtime or when we execute the code
    static void Main()
    {
        // Example 1 
        //double i, j;
        //i = 10.4; // 4 bytes 
        //j = 25.3; // 4 bytes 
        //double res = i + j;
        //Console.WriteLine(res);            


        // Example 2 
        //double x, y;
        //Console.WriteLine("Enter x"); 
        //x = Convert.ToDouble(Console.ReadLine()) ;
        //Console.WriteLine("Enter y");
        //y = Convert.ToDouble(Console.ReadLine());
        //Console.WriteLine("Sum of x + y");
        //Console.WriteLine(x + y); 

        // Example 3
        //// define array of double 
        //double[] numbers = new double[1000];
        //// numbers is a ref. variable that refers to the array object 
        //// the array object contains the length property and reference to the actual array of 1000 double 
        //// CLR uses a thread to call Main() - we call it as the main thread 

        //int index = 0;

        //while (true)
        //{     
        //    string input = Console.ReadLine();

        //    if (input == "quit" || input == "exit")
        //    {
        //        break;
        //    }

        //    try
        //    {
        //        double number = Convert.ToDouble(input);  // anything that cannot be converted to double 
        //                                                  // exception will be thrown by to double method
        //                                                  // FormatException, OverflowException
        //        numbers[index] = number;

        //        index++; // This will throw the exception when index > 1000 , IndexOutOfRangeException

        //    }
        //    catch (FormatException ex)
        //    {
        //        Console.WriteLine("Input is not in a number format");
        //    }
        //    catch (OverflowException ex)
        //    {
        //        Console.WriteLine("Input is exceeding the range");
        //    }
        //    catch(IndexOutOfRangeException ex)
        //    {
        //        Console.WriteLine("all 1000 locations are full");
        //        break; 
        //    }
        //}

        //double sum = 0; 
        //for (int i = 0; i < index; i++)
        //{
        //    sum += numbers[i]; 
        //}

        //Console.WriteLine(sum); 


        // Example 4 
        //double[] numbers = new double[0];
        //while (true)
        //{
        //    try
        //    {
        //        string input = Console.ReadLine();

        //        if (input == "quit")
        //        {
        //            break;
        //        }

        //        double number = Convert.ToDouble(input);

        //        // grow the array by one new location 
        //        double[] bigger = new double[numbers.Length + 1];

        //        // for copying the data from smaller array to a new bigger array 
        //        for (int i = 0; i < numbers.Length; i++)
        //        {
        //            bigger[i] = numbers[i];
        //        }

        //        // numbers will start referencing to a new array object 
        //        numbers = bigger;

        //        // storing the latest entered data in the last location 
        //        numbers[numbers.Length - 1] = number;               
        //    }
        //    catch (FormatException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    catch (OverflowException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //}

        //double sum = 0;
        //for(int i = 0; i < numbers.Length; i++)
        //{
        //    sum += numbers[i]; 
        //}

        //Console.WriteLine(sum); 

        // Example 5
        //double[] numbers = new double[0];

        DynamicArray dga = new DynamicArray();
        // dga is a reference to the dynamically growing array object created using new 

        while (true)
        {
            try
            {
                string input = Console.ReadLine();

                if (input == "quit")
                {
                    break;
                }

                double number = Convert.ToDouble(input);

                dga.Add(number); // Add (value of dga = ref. of the object, value of the number will be passed) 


                //// grow the array by one new location 
                //double[] bigger = new double[numbers.Length + 1];

                //// for copying the data from smaller array to a new bigger array 
                //for (int i = 0; i < numbers.Length; i++)
                //{
                //    bigger[i] = numbers[i];
                //}

                //// numbers will start referencing to a new array object 
                //numbers = bigger;

                //// storing the latest entered data in the last location 
                //numbers[numbers.Length - 1] = number;
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        double sum = 0;
        for (int i = 0; i < dga.Length; i++)
        {
            try
            {
                sum += dga[i];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                break;
            }
        }

        Console.WriteLine(sum);
    }
}

