using System;
using System.Configuration;
using System.Data.SqlClient;

public class QuestionRepository
{
    //public string ConnectionString { get; }

    private string _connectionString;

    public string ConnectionString
    {
        get { return _connectionString; }
        private set { _connectionString = value; }
    }


    //public QuestionRepository()
    //{

    //}

    public QuestionRepository(string connectionStringName)
    {
        ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString; 
    }

    /// <summary>
    /// Adding Question to MS SQL Server "questions" Table
    /// </summary>
    /// <param name="statement"></param>
    /// <param name="option1"></param>
    /// <param name="option2"></param>
    /// <param name="option3"></param>
    /// <param name="option4"></param>
    /// <param name="correctAnswer"></param>
    /// <returns>Questions ID</returns>
    public int AddQuestion(string statement, string option1, string option2, string option3, string option4, int correctAnswer)
    {
        
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "insert into questions values (@statement,@option1,@option2,@option3,@option4,@correctanswer);select cast(scope_identity() as int);";  //parameterize query preparation
            command.Connection = connection;
            command.Parameters.AddWithValue("@statement", statement);
            command.Parameters.AddWithValue("@option1", option1);
            command.Parameters.AddWithValue("@option2", option2);
            command.Parameters.AddWithValue("@option3", option3);
            command.Parameters.AddWithValue("@option4", option4);
            command.Parameters.AddWithValue("@correctanswer", correctAnswer);

            connection.Open(); // connects to the database server

            // firing the query to the DB servers SQl processing Engine 
            int questionId = (int)command.ExecuteScalar();
            // reader gets the cursor to read the records 

            return questionId; 
        }  
    }

    /// <summary>
    /// This obtains data from MSSQL Server question table based on question ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Question Object</returns>
    public Question GetQuestionById(int id)
    {
        Question question = new Question();
        string connectionString = @"server=IN-PPM2320;database=dotnetdb1;intergrated security=true";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "select * from questions where id=@id"; //parameterize query preparation
            command.Connection = connection;
            command.Parameters.AddWithValue("@id", id);

            connection.Open(); // connects to the database server

            // firing the query to the DB servers SQl processing Engine 
            SqlDataReader reader = command.ExecuteReader();
            // reader gets the cursor to read the records 

            reader.Read(); //get the first record in reader object

            

            // Extracting data from the reader object per column bases 
            // and filling the data in Question Object
            question.Id = (int)reader["Id"];
            question.Statement = (string)reader["statement"];
            question.Option1 = (string)reader["option1"];
            question.Option2 = (string)reader["option2"];
            question.Option3 = (string)reader["option3"];
            question.Option4 = (string)reader["option4"];
            question.CorrectAnswer = (int)reader["correctanswer"];
        }

        return question;
    }
}

