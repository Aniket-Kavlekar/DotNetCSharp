using System;
using System.Collections.Generic;


//DAL

struct Date
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
}

class CurrentDate
{
    public Date date { get; set; }

    // constructor 
    public CurrentDate()
    {
        DateTime dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, 
            TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        date = new Date { Day = dateTime.Day, Month = dateTime.Month, Year = dateTime.Year }; 
    }
}

class ReminderData
{
    public Date DayMonthYear { get; set; }

    //public float HourMinute { get; set; }
    public string Message { get; set; }

    //public 

}


//BL
class ReminderLogic
{
    ReminderData reminderData = new ReminderData(); 

    void GetCurrentDate()
    {
        DateTime dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        reminderData.DayMonthYear.Day = dateTime.Day;
        reminderData.DayMonthYear.Month = dateTime.Month;
        reminderData.DayMonthYear.Year = dateTime.Year;
    }


    public string DisplayMessage()
    {
        while (true)
        {
            //if(reminderData.DateMonthYear )
        }
    }
}


//PL
// take and display the result 
class Presentation
{
    public void Start()
    {
        ReminderLogic reminderLogic = new ReminderLogic();
        SetReminder();
        string mess = reminderLogic.DisplayMessage(); 
    }


    void SetReminder()
    {
        ReminderData reminderData = new ReminderData();
        Console.Clear();
        SetDateMonthYear(reminderData);
        SetHourMinute(reminderData);
        SetMessage(reminderData);      
    }

    void SetDateMonthYear(ReminderData reminderData)
    {         
        while (true)
        {            
            Console.Write("Enter Date Month Year in format DD-MM-YY: ");
            reminderData.DateMonthYear = Console.ReadLine();
            if (reminderData.DateMonthYear != null)
                break;
            else
                Console.WriteLine("Enter in format DD-MM-YY");           
        }
    }

    void SetHourMinute(ReminderData reminderData)
    {         
        while (true)
        {
            Console.Write("Enter Hour and Minute in format HH.MM: ");
            float input; 
            if(float.TryParse(Console.ReadLine(), out input))
            {
                reminderData.HourMinute = input;
                break; 
            }                     
            else
                Console.WriteLine("Enter in format HH.MM");
        }
    }

    void SetMessage(ReminderData reminderData)
    {
        while (true)
        {
            Console.Write("Enter the reminder message :");
            reminderData.DateMonthYear = Console.ReadLine();
            if (reminderData.DateMonthYear != null)
                break;
            else
                Console.WriteLine("Enter message");
        }
    }
}




class Program
{
    static void Main()
    {
        Presentation presentation = new Presentation();
        //DateTime dateTime = DateTime.UtcNow;
        DateTime dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        
        int day = dateTime.Day; 
        //presentation.Start(); 
    }
}

