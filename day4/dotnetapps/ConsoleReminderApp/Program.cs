using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

//Design pattern followed here is Observer
//----------------------------------------

//  Develop reminder application, in which user supplies day, month, year, hour, minute and message
//  Application should monitor current date and time
//  Compare the current date and time with the user supplied date and time
//  If found same display the message.
//  Allow the user to supply date, time and message any number of times.Date and time can be same for multiple messages


#region DataLayer
class Reminder
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public int Hour { get; set; }
    public int Minute { get; set; }
    public string Message { get; set; }
}

class Timer
{

    public event Action Alarm;
    // event object that allows registration and unregistrations of the delegate object any time 


    public void Start(/*this = ref of timer object*/)
    {
        //MT 
        Task.Run(new Action(this.SecondaryThreadFunction)); //gets the thread from CLRs thread pool which is per process 
                                                            // Action is a delegate whose only function is to 
                                                            //1. hold the ref. of the method (SecondaryThreadFunction)
                                                            //2. the ref. of the object to call the function (this = ref of timer object)
    }//MT


    // Call back will happen in the secondary thread 
    async void SecondaryThreadFunction(/*this = ref of timer object*/)
    {
        while (true) //ST 
        {
            //1. Use of sleep 
            // blocks the thread 
            // Thread.Sleep(60000); 

            //2. Use Task 
            // returns the thread to the threading pool and returns the thread after 60s
            await Task.Delay(60000);

            // raise timer tick notification
            Alarm?.Invoke();
            //?. is a null check opeartor 
            // i.e only invoke when some has registered for it

        }
    }

    public void Stop(/*this = ref of timer object*/)
    {

    }
}
#endregion


#region BusinessLogic
class ReminderLogic
{
    private List<Reminder> reminders = new List<Reminder>(); // instance data member of reminderlogic object
    // this will create array of reminder reference variables 

    public Action<string> ReminderFound;

    Timer timer = new Timer(/*this-> ref. of reminderLogic object*/);  // instance data member of reminderlogic object

    //constructor 
    public ReminderLogic(/*this-> ref. of reminderLogic object*/)
    {
        timer.Start();
        // adding the event handler 
        timer.Alarm += new Action(this.CheckReminders); //ST
    }

    //ST
    void CheckReminders(/*this-> ref. of reminderLogic object*/)
    {
        DateTime current = DateTime.Now;
        for (int i = 0; i < reminders.Count;) //ST
        {
            Reminder reminder = this.reminders[i];

            if (reminder.Year == current.Year   &&
                reminder.Month == current.Month &&
                reminder.Day == current.Day     &&
                reminder.Hour == current.Hour   &&
                reminder.Minute == current.Minute)
            {
                //Console.WriteLine(reminder.Message);
                ReminderFound?.Invoke(reminder.Message);
                this.reminders.RemoveAt(i); // remaining objects will shift one position 
            }
            else
            {
                i++; // because we are removing the object from the list its better to increment the count here
            }
        }
    }

    public void Add(/*this-> ref. of reminderLogic object*/int day, int month, int year, int hour, int minute, string message)
    {
        // reminder ref variable is created on the stack 
        // reminder ref variable refers to the reminder object created on the heap 
        Reminder reminder = new Reminder()
        {
            Day = day,
            Month = month,
            Year = year,
            Hour = hour,
            Minute = minute,
            Message = message,
        };
        reminders.Add(reminder);
    } // reminder reference variable will die here   
}
#endregion


#region Presentation
// Focus: input and output with the user on the console
class ConsoleUI
{
    private ReminderLogic reminderLogic = new ReminderLogic();

    public ConsoleUI()
    {
        // adding the event handler 
        this.reminderLogic.ReminderFound += new Action<string>(this.DisplayMessage); //ST
    }

    public void show(/*this ref. of the ConsoleUI object*/)
    {
        while (true) //Main Thread 
        {
            Console.Write("Enter Day: ");
            int day = Convert.ToInt32(Console.ReadLine());  //MT note: console.Readline is a blocking call 

            Console.Write("Enter Month: ");
            int month = Convert.ToInt32(Console.ReadLine()); //MT

            Console.Write("Enter Year: ");
            int year = Convert.ToInt32(Console.ReadLine()); //MT

            Console.Write("Enter Hour: ");
            int hour = Convert.ToInt32(Console.ReadLine()); //MT

            Console.Write("Enter Minute: ");
            int min = Convert.ToInt32(Console.ReadLine());  //MT

            Console.Write("Enter Message: ");
            string message = Console.ReadLine(); //MT

            this.reminderLogic.Add(/*this-> ref. of reminderLogic object*/day, month, year, hour, min, message);

            

            //Console.Write("Do you want to enter new reminder ? y or n :");
            //string option = Console.ReadLine().ToLower();
            //if (option == "y")
            //    continue;
            //else
            //    break;
        }
    }

    void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}
#endregion


class Program
{
    static void Main() // doesn't have this
    {
        ConsoleUI consoleUI = new ConsoleUI();
        consoleUI.show(/*this ref. of the ConsoleUI object*/);
    }
}
















// my trial 
//using System;
//using System.Collections.Generic;

//struct Date
//{
//    public int Day { get; set; }
//    public int Month { get; set; }
//    public int Year { get; set; }
//}

//struct Time
//{
//    public int Hour { get; set; }
//    public int Minute { get; set; }
//}

//#region Data Access Layer
//class CurrentDateTime
//{
//    public Date date { get; private set; }
//    public Time time { get; private set; }

//    // constructor 
//    public CurrentDateTime()
//    {
//        DateTime dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, 
//            TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
//        date = new Date { Day = dateTime.Day, Month = dateTime.Month, Year = dateTime.Year };
//        time = new Time { Hour = dateTime.Hour, Minute = dateTime.Minute }; 
//    }
//}

//class ReminderData
//{
//    public Date DayMonthYear { get; set; }
//    public Time HourTime { get; set; }
//    public string Message { get; set; }
//}
//#endregion

////BL
//class ReminderLogic
//{
//    ReminderData reminderData = new ReminderData(); 

//    void SetReminderData(Date userDate, Time userTime, string userMessage)
//    {
//        reminderData.DayMonthYear = userDate;
//        reminderData.HourTime = userTime;
//        reminderData.Message = userMessage; 
//    }

//    void GetCurrentDate()
//    {

//    }

//    void GetCurrentTime()
//    {

//    }


//    public string DisplayMessage()
//    {
//        while (true)
//        {
//            //if(reminderData.DateMonthYear )
//        }
//    }
//}


////PL
//// take and display the result 
//class Presentation
//{
//    public void Start()
//    {
//        ReminderLogic reminderLogic = new ReminderLogic();
//        GetUserInput();
//        string mess = reminderLogic.DisplayMessage(); 
//    }


//    void GetUserInput()
//    {
//        Console.Clear();
//        GetUserDate();
//        GetUserTime();
//        GetUserMessage();      
//    }

//    Date GetUserDate()
//    {         
//        while (true)
//        {            
//            Console.Write("Enter Date Month Year in format DD-MM-YY: ");
//            reminderData.DateMonthYear = Console.ReadLine();
//            if (reminderData.DateMonthYear != null)
//                break;
//            else
//                Console.WriteLine("Enter in format DD-MM-YY");           
//        }
//    }

//    void GetUserTime(ReminderData reminderData)
//    {         
//        while (true)
//        {
//            Console.Write("Enter Hour and Minute in format HH.MM: ");
//            float input; 
//            if(float.TryParse(Console.ReadLine(), out input))
//            {
//                reminderData.HourMinute = input;
//                break; 
//            }                     
//            else
//                Console.WriteLine("Enter in format HH.MM");
//        }
//    }

//    void GetUserTime(ReminderData reminderData)
//    {
//        while (true)
//        {
//            Console.Write("Enter the reminder message :");
//            reminderData.DateMonthYear = Console.ReadLine();
//            if (reminderData.DateMonthYear != null)
//                break;
//            else
//                Console.WriteLine("Enter message");
//        }
//    }
//}




//class Program
//{
//    static void Main()
//    {
//        Presentation presentation = new Presentation();
//        //DateTime dateTime = DateTime.UtcNow;
//        DateTime dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

//        int day = dateTime.Day; 
//        //presentation.Start(); 
//    }
//}

