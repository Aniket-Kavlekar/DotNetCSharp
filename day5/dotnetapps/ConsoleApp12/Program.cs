using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

#region DataLogic
class Question
{
    private string statement { get; set; }
    private string option1 { get; set; }
    private string option2 { get; set; }
    private string option3 { get; set; }
    private string option4 { get; set; }
    private int correctanswer { get; set; }

}
#endregion



#region BusinessLogic
class QuestionLogic
{
    private List<Question> questionsList = new List<Question>();

    public void AddQuestionToSQL(string s, string op1, string op2, string op3, string op4, int ca)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "INSERT INTO TableName (param1, param2, param3) " +
                    " VALUES (@param1, @param2, @param3)");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            cmd.Parameters.Add("@param1", DbType.String);
            cmd.Parameters.Add("@param2", DbType.String);
            cmd.Parameters.Add("@param3", DbType.String);

            foreach (var item in records)
            {
                cmd.Parameters[0].Value = item.param1;
                cmd.Parameters[1].Value = item.param2;
                cmd.Parameters[2].Value = item.param3;

                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    } 
}
#endregion


#region Presentation
class ConsoleUI
{
    QuestionLogic questionLogic = new QuestionLogic(); 

    void DisplayMenu()
    {
        Console.Clear();
        Console.Write("1. Add question");
        Console.Write("2. Delete question");
        Console.Write("3. Update question");
        Console.Write("4. List questions");
        Console.Write("Enter user option : ");
    }


    public void show()
    {
        bool runApplication = true;

        while (runApplication)
        {
            DisplayMenu();
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        this.addQuestion();
                        break;
                    case 2:
                        this.deleteQuestion();
                        break;
                    case 3:
                        this.updateQuestion();
                        break;
                    case 4:
                        this.listQuestions();
                        break;
                    case 5:
                        runApplication = false;
                        break;
                }
            }
            else
                Console.WriteLine("Enter choice either 1, 2, 3, or 4");
        }
    }

    private void listQuestions()
    {
        throw new NotImplementedException();
    }

    private void updateQuestion()
    {
        throw new NotImplementedException();
    }

    private void deleteQuestion()
    {
        throw new NotImplementedException();
    }

    private void addQuestion()
    {
        while (true)
        {
            Console.Write("Enter statement : ");
            string s = Console.ReadLine();

            Console.Write("Enter option 1 : ");
            string op1 = Console.ReadLine();

            Console.Write("Enter option 2 : ");
            string op2 = Console.ReadLine();

            Console.Write("Enter option 3 : ");
            string op3 = Console.ReadLine();

            Console.Write("Enter option 4 : ");
            string op4 = Console.ReadLine();

            Console.Write("Enter correct answer : ");
            int ca = Convert.ToInt32(Console.ReadLine());

            questionLogic.AddQuestionToSQL(s, op1, op2, op3, op4, ca);

            Console.Write("1. Add new question");
            Console.Write("2. Quit Command");
            int choice; 
            if (int.TryParse(Console.ReadLine(), out choice))
            {
               if(choice == 1)
                {
                    continue; 
                }

               if(choice == 2)
                {
                    break; 
                }
            }
            else
                Console.WriteLine("Choose either 1 or 2"); 
        }
    }



    private int GetOptionFromUser()
    {
        Console.Write("Select an option: ");
        int option; // option is an object, pass by value

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out option/*here option is ref. of the object*/))
            {
                if (option >= 1 || option <= 4)
                {
                    return option;
                }
                else
                    Console.WriteLine("an option can be 1, 2 ,3 or 4");
            }
            else
                Console.WriteLine("value could not be converted to number");
        }

    }
}
#endregion

class Program
{
    static void Main()
    {
        ConsoleUI consoleUI = new ConsoleUI();
        consoleUI.show(); 
    }
}

