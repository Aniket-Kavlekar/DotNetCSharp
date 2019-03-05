using System;
using System.Collections.Generic; // provides the list generic class 

// 3 - layer architecture 

// data access layer 

// business layer 
class Book
{
    //1. 
    //private string title, author;   // instance feilds 
    //private double price;           // instance feilds 

    ////constructor
    //public Book()
    //{

    //}

    //2.
    // Instance Properties that gets and set the values of the instance methods 
    public string Title { get; set; } //Auto Implemented Property
    public string Author { get; set; } //Auto Implemented Property
    public double Price { get; set; } //Auto Implemented Property
}


//class DynamicallyGrowingArray<T> //Generic types or Generic class 
//{
//    public void Add(/* DynamicallyGrowingArray this*/ T item) // this makes it open to accept different types 
//    {

//    }
//}


// holding multiple books 
// performing certain operations on the book list
class BooksLogic
{
    // instance data memeber (becomes part of the object) 
    List<Book> bookList = new List<Book>();

    public int Count
    {
        get
        {
            return bookList.Count;
        }
    }

    public Book this[int index]
    {
        get
        {
            return this.bookList[index]; 
        }
    }

    public void Add(/* BooksLogic this*/string title, string author, double price)
    {
        Book book = new Book() { Title = title, Author = author, Price = price }; // Property intializer 
        this.bookList.Add(book);
    }
}


// presentation layer
class ConsoleUI // Pascal casing
{
    BooksLogic booksLogic = new BooksLogic();  // instance data member (if we create consoleUI 2 times this will become a part of it both the times)

    public int TakeInput(/* ConsoleUI this*/)
    {
        while (true)
        {
            int option;
            if (Int32.TryParse(Console.ReadLine(), out option))
            {
                if (option >= 0 && option <= 2)
                    return option;
                else
                    Console.WriteLine("Option can be 0, 1 or 2");
            }
            else
            {
                Console.WriteLine("Input could not be converted to number");
            }
        }
    }

    public int DisplayMainMenu(/* ConsoleUI this*/) // Instance method - these are meant to work on the object or for an object
    {
        Console.Clear();
        Console.WriteLine("0. Exit");
        Console.WriteLine("1. Add Book");
        Console.WriteLine("2. List Books");
        Console.Write("Select an option: ");
        return this.TakeInput();  // TakeInput {value of this = ref. of the object}
    }

    public void AddBook(/* ConsoleUI this*/)
    {
        while (true)
        {
            Console.Clear();

            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Author: ");
            string author = Console.ReadLine();

            double price;
            while (true)
            {
                Console.Write("Enter Price: ");
                string priceStr = Console.ReadLine();


                if (Double.TryParse(priceStr, out price))
                {
                    break;
                }
            }

            this.booksLogic.Add(title, author, price);

            Console.Write("Do you want to add more books? y or n: ");
            if (Console.ReadLine().ToLower() == "y")
                continue;
            else
                break;

        }
    }

    public void ListBooks(/* ConsoleUI this*/)
    {
        Console.Clear(); 

        for (int i = 0; i < this.booksLogic.Count; i++)
        {
            Book book = this.booksLogic[i];
            Console.WriteLine($"{book.Title} : {book.Author} : {book.Price}"); //string manipulation
        }

        Console.Write("Hit enter to contiue...");
        Console.ReadLine(); 
    }

    public void Start(/* ConsoleUI this*/) // Instance method
    {
        while (true)
        {
            int option = this.DisplayMainMenu(/* ConsoleUI this*/); // Instance method 

            if (option == 0)
                break;

            if (option == 1)
            {
                this.AddBook();
            }

            if (option == 2)
            {
                this.ListBooks();
            }

        }
    }
}

class Program
{
    static void Main()
    {
        ConsoleUI cui = new ConsoleUI();
        //new creates ConsoleUI object and returns reference of the object
        // the reference of the object will be stored in "cui" refernce variable
        cui.Start(); // start (value of cui = ref. of that object passed)
    }
}


//My Try 
//class DynamicArray
//{
//    string[] arr = new string[0]; 
//    public int Length
//    {
//        get 
//        {
//            return arr.Length; 
//        }
//    }

//    public string this[int index]
//    {
//        get 
//        {
//            return arr[index];
//        }
//    }

//    public void Add(string number)
//    {
//        // grow the array by one new location 
//        string[] bigger = new string[arr.Length + 1]; 

//        // for copying the data from smaller array to a new bigger array 
//        for (int i = 0; i < arr.Length; i++) 
//        {
//            bigger[i] = arr[i]; 
//        }

//        // numbers will start referencing to a new array object 
//        arr = bigger; 

//        // storing the latest entered data in the last location 
//        arr[arr.Length - 1] = number; 
//    }
//}


//class AddBook
//{
//    DynamicArray title = new DynamicArray();
//    DynamicArray author = new DynamicArray();
//    DynamicArray price = new DynamicArray();

//    public void Add(string t, string a, string p)
//    {
//        title.Add(t);
//        author.Add(a);
//        price.Add(p);
//    }

//    public void DisplayBookList()
//    {
//        for (int i = 0; i < title.Length; i++)
//        {
//            Console.WriteLine("Title: " + title[i] + ", " + "Author: " + author[i] + ", " + "Price: " + price[i]);
//        }
//    }

//}


//class Program
//{
//    static void addBook(AddBook addBook)
//    {

//        Console.WriteLine("Enter the below information");
//        Console.WriteLine("Enter Title");
//        string t = Console.ReadLine();
//        Console.WriteLine("Enter Author");
//        string a = Console.ReadLine();
//        Console.WriteLine("Enter Price");
//        string p = Console.ReadLine();       
//        addBook.Add(t, a, p);     
//    }

//    static void listBooks(AddBook addBook)
//    {
//        addBook.DisplayBookList();
//    }


//    static void Main()
//    {
//        bool testRun = true;
//        AddBook ab = new AddBook();
//        while (testRun)
//        {
//            try
//            {
//                Console.WriteLine("***************************************************");
//                Console.WriteLine("Select from the list of instructions below");
//                Console.WriteLine("1: Add book");
//                Console.WriteLine("2: List book");
//                Console.WriteLine("0: Quit app");
//                int menuInput = Convert.ToInt16(Console.ReadLine());
//                switch (menuInput)
//                {
//                    case 1:
//                        addBook(ab);
//                        break;
//                    case 2:
//                        listBooks(ab);
//                        break;
//                    case 0:
//                        testRun = false;
//                        break;
//                    default:
//                        Console.WriteLine("Enter valid input from the list");
//                        break;
//                }
//            }
//            catch(FormatException ex)
//            {
//                Console.WriteLine(ex.Message); 
//            }
//            catch (OverflowException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            catch (ArgumentOutOfRangeException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//        }
//    }
//}

