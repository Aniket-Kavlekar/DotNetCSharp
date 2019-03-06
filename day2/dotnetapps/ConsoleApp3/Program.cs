using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Net;

class Question // reference data type
{
    public string Statement { get; set; } //Auto Implemented Property
    public string Option1 { get; set; } //Auto Implemented Property
    public string Option2 { get; set; } //Auto Implemented Property
    public string Option3 { get; set; } //Auto Implemented Property
    public string Option4 { get; set; } //Auto Implemented Property
    public int CorrectAnswer { get; set; } //Auto Implemented Property
}

// reference type whose object cannot be created but reference variable can be created 
interface IStore // abstraction 
{
    List<Question> GetQuestions(/*this*/); //late binding 

}

//--------------------------------------------------------------------------------------------------------------------
#region Data Access Layer
// Varying implementations: what all these are doing is same but how they do it is different
// Implementation -1
class HardCodedQuestions : IStore // reference data type
{
    public List<Question> GetQuestions(/*this*/)
    {
        // questions will be created on the stack 
        // new will be created on the heap 
        List<Question> questions = new List<Question>();
        questions.Add(new Question() { Statement = "AAA", Option1 = "A1", Option2 = "A2", Option3 = "A3", Option4 = "A4", CorrectAnswer = 1 });
        questions.Add(new Question() { Statement = "BBB", Option1 = "B1", Option2 = "B2", Option3 = "B3", Option4 = "B4", CorrectAnswer = 2 });
        questions.Add(new Question() { Statement = "CCC", Option1 = "C1", Option2 = "C2", Option3 = "C3", Option4 = "C4", CorrectAnswer = 3 });
        questions.Add(new Question() { Statement = "DDD", Option1 = "D1", Option2 = "D2", Option3 = "D3", Option4 = "D4", CorrectAnswer = 4 });
        questions.Add(new Question() { Statement = "EEE", Option1 = "E1", Option2 = "E2", Option3 = "E3", Option4 = "E4", CorrectAnswer = 1 });
        return questions; // returning the reference of the list object i.e is just 8bytes in memory 
    }

}

// Implementation -2
class JSONFileQuestions : IStore
{
    public List<Question> GetQuestions()
    {
        StreamReader streamReader = new StreamReader("questions.js"); // object is on the heap
        //streamReader ref variable will be created on stack 

        // opens the file 
        string json = streamReader.ReadToEnd();

        List<Question> questionList = JsonConvert.DeserializeObject<List<Question>>(json);

        // closes the file 
        streamReader.Close();

        return questionList;

    }//streamReader ref variable will die here 
}

// Implementation -3 
class WebQuestions : IStore
{
    public List<Question> GetQuestions()
    {
        WebClient webClient = new WebClient();
        string json = webClient.DownloadString("http://leadows.com/questions.txt");
        List<Question> questionList = JsonConvert.DeserializeObject<List<Question>>(json);
        return questionList;
    }
}

class MSSqlServerQuestions
{

}
class XMLFileQuestions
{

}
#endregion

class Factory
{
    public static IStore GetStore()
    {
        return new WebQuestions();
    }
}

//--------------------------------------------------------------------------------------------------------------------
#region Business Logic Layer
class TestLogic // reference data type
{
    private List<Question> questionsList = new List<Question>(); // Instance data member are also created on the heap 
    private int index = 0; // Instance data member they are also created on the heap
    public int UserMarks { get; private set; }
    public int TotalMarks { get; private set; }

    // constructor: Is called just after the object is created 
    public TestLogic(/* TestLogic this = ref. of testlogic object*/)
    {
        // 1. Harcoded input 
        //HardCodedQuestions hardCodedQuestions = new HardCodedQuestions();
        //this.questionsList = hardCodedQuestions.GetQuestions();

        // 2. Input from file 
        //JSONFileQuestions jSONFileQuestions = new JSONFileQuestions();
        //this.questionsList = jSONFileQuestions.GetQuestions(); 

        // 3. Server input
        //WebQuestions jSONFileQuestions = new WebQuestions();
        //this.questionsList = jSONFileQuestions.GetQuestions();

        // 4. Abstraction 
        IStore store = Factory.GetStore(); // reference of implementation object is returned 
        this.questionsList = store.GetQuestions();
        //when the control reaches the store store.GetQuestions();
        // the ref. of the function is decided based on which implementation 
        // is being refered by the store i.e reference variable calling the function 

        this.TotalMarks = this.questionsList.Count;
    }

    public Question GetNextQuestion(/* TestLogic this = ref. of testlogic object*/)
    {
        if (this.index < this.questionsList.Count)
        {
            return this.questionsList[this.index++];
        }
        else
        {
            return null;
        }
    }

    public void CheckAnswer(int option)
    {
        if (option == this.questionsList[this.index - 1].CorrectAnswer)
        {
            this.UserMarks += 1; //each correct ans has 1 marks
        }
    }
}
#endregion

//--------------------------------------------------------------------------------------------------------------------
#region Presentation Layer
class ConsoleUI // reference data type
{
    private void DisplayQuestion(Question question)
    {
        Console.WriteLine(question.Statement); //question.get_statement() is called 
        Console.WriteLine($"1: {question.Option1}");
        Console.WriteLine($"2: {question.Option2}");
        Console.WriteLine($"3: {question.Option3}");
        Console.WriteLine($"4: {question.Option4}");
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

    public void Show()
    {
        Console.WriteLine("Please wait while we load the questions from the server....");

        TestLogic testLogic = new TestLogic(); // long lived object
        // 1. Object is created with instance data members in it 
        // 2. constructor is called with the ref. of the object 
        // 3. reference of the object is stored in testLogic reference variable 

        while (true)
        {
            Question question = testLogic.GetNextQuestion();
            // question is a reference variable that receives reference of the Question object

            if (question != null)
            {
                Console.Clear();
                DisplayQuestion(question);
                int option = this.GetOptionFromUser();
                testLogic.CheckAnswer(option);
            }
            else
                break;
        }

        Console.Clear();
        Console.WriteLine($"You obtained {testLogic.UserMarks} out of {testLogic.TotalMarks}");
        Console.ReadLine();
    }
}

#endregion

//--------------------------------------------------------------------------------------------------------------------
#region Application Start
class Program
{
    static void Main()
    {
        ConsoleUI consoleUI = new ConsoleUI();
        consoleUI.Show();
    }
}
#endregion

//--------------------------------------------------------------------------------------------------------------------
// My trail 
////DL



////BL 
//class Question
//{
//    public string Statement { get; set; } //Auto Implemented Property
//    public string Option1 { get; set; } //Auto Implemented Property
//    public string Option2 { get; set; } //Auto Implemented Property
//    public string Option3 { get; set; } //Auto Implemented Property
//    public string Option4 { get; set; } //Auto Implemented Property
//    public string Correct { get; set; } //Auto Implemented Property
//}

//class QuestionLogic
//{
//    List<Question> questions = new List<Question>();


//    public int Count
//    {
//        get
//        {
//            return questions.Count;
//        }
//    }

//    public Question this[int index]
//    {
//        get
//        {
//            return this.questions[index];
//        }
//    }

//    public void Add(string statement, string op1, string op2, string op3, string op4, string correct)
//    {
//        Question question = new Question { Statement = statement, Option1 = op1, Option2 = op2, Option3 = op3, Option4 = op4, Correct = correct }; 
//        this.questions.Add(question); 
//    }

//    public bool ValidateAnswer(int option)
//    {
//        bool res = false; 
//        switch(option)
//        {
//            case 1:
//                break;
//            case 2:
//                break;
//            case 3:
//                break;
//            case 4:
//                break; 
//        }

//        return res;
//    }
//}


////PL 
//class ConsoleUI
//{
//    QuestionLogic questionLogic = new QuestionLogic();


//    public int TakeInput(/* ConsoleUI this*/)
//    {
//        while (true)
//        {
//            int option;
//            if (Int32.TryParse(Console.ReadLine(), out option))
//            {
//                if (option >= 1 && option <= 4)
//                    return option;
//                else
//                    Console.WriteLine("Option can be 1, 2, 3, or 4");
//            }
//            else
//            {
//                Console.WriteLine("Input could not be converted to number");
//            }
//        }
//    }


//    public int DisplayQuestion(int index)
//    {
//        Console.Clear();
//        Console.WriteLine(questionLogic[index].Statement); 
//        Console.WriteLine(questionLogic[index].Option1);
//        Console.WriteLine(questionLogic[index].Option2);
//        Console.WriteLine(questionLogic[index].Option3);
//        Console.WriteLine(questionLogic[index].Option4);
//        Console.Write("Select an option: 1, 2, 3 or 4 ");
//        return this.TakeInput();
//    }

//    public void Start()
//    {
//        for(int i = 0; i < this.questionLogic.Count; i++ )
//        {
//            int option = this.DisplayQuestion(i);

//        }
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        ConsoleUI cui = new ConsoleUI();
//        cui.Start(); 
//    }
//}

