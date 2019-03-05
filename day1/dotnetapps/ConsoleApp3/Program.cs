using System;
using System.Collections.Generic;

class Question
{
    public string Statement { get; set; } //Auto Implemented Property
    public string Option1 { get; set; } //Auto Implemented Property
    public string Option2 { get; set; } //Auto Implemented Property
    public string Option3 { get; set; } //Auto Implemented Property
    public string Option4 { get; set; } //Auto Implemented Property
    public int Correct { get; set; } //Auto Implemented Property
}


//DAL 
class MSSqlServerQuestions
{

}
class XMLFileQuestions
{

}
class HardCodedQuestions
{
    public List<Question> GetQuestions()
    {
        List<Question> questions = new List<Question>();
        questions.Add(new Question() { Statement = "AAA", Option1 = "A1", Option2 = "A2", Option3 = "A3", Option4 = "A4", Correct = 1 });
        questions.Add(new Question() { Statement = "BBB", Option1 = "B1", Option2 = "B2", Option3 = "B3", Option4 = "B4", Correct = 2 });
        questions.Add(new Question() { Statement = "CCC", Option1 = "C1", Option2 = "C2", Option3 = "C3", Option4 = "C4", Correct = 3 });
        questions.Add(new Question() { Statement = "DDD", Option1 = "D1", Option2 = "D2", Option3 = "D3", Option4 = "D4", Correct = 4 });
        questions.Add(new Question() { Statement = "EEE", Option1 = "E1", Option2 = "E2", Option3 = "E3", Option4 = "E4", Correct = 1 });
        return questions; // returning the reference of the list object i.e is just 8bytes in memory 
    }

}
class JSONFileQuestions
{

}


//--------------------------------------------------------------------------------------------------------------------
//BLL
class TestLogic
{
    private List<Question> questionsList = new List<Question>(); // Instance data member 
    private int index = 0; // Instance data member 

    // constructor: Is called just after the object is created 
    public TestLogic(/* TestLogic this = ref. of testlogic object*/)
    {
        HardCodedQuestions hardCodedQuestions = new HardCodedQuestions();
        this.questionsList = hardCodedQuestions.GetQuestions(); 
    }

    public Question GetNextQuestion(/* TestLogic this = ref. of testlogic object*/)
    {
        if(this.index < this.questionsList.Count)
        {
            return this.questionsList[this.index++];
        }
        else
        {
            return null; 
        }       
    }
}

//--------------------------------------------------------------------------------------------------------------------
//PL
class ConsoleUI
{
    public void Show()
    {
        TestLogic testLogic = new TestLogic(); 

        while (true)
        {
            Question question = testLogic.GetNextQuestion();

            if (question != null)
            {
                Console.WriteLine(question.Statement);
                Console.WriteLine(question.Option1);
                Console.WriteLine(question.Option2);
                Console.WriteLine(question.Option3);
                Console.WriteLine(question.Option4);
            }
            else
                break; 
        }
    }
}


class Program
{
    static void Main()
    {
        ConsoleUI consoleUI = new ConsoleUI();
        consoleUI.Show(); 
    }
}


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

