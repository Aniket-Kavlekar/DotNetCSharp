using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp13Test
{
    [TestClass]
    public class ConsoleApp13Test
    {
        // 1. Every test should cover a scenario(means our code is going to perform what opertions for the user) 
        //    in which our code is going to be used 
        // 2. the code that is tested must be based on the test 
        // 3. writing the test improves the quality of the code 

        [TestMethod]
        //[ExpectedException] 
        public void ReadingConnectionStringFromConfig()
        {
            QuestionRepository questionsRepository = new QuestionRepository("hexagondbconnection");
            Assert.AreEqual(@"server=IN-PPM2320;database=dotnetdb1;integrated security=true", questionsRepository.ConnectionString);
        }

        [TestMethod]
        public void AddQuestionToDataBase()
        {
            QuestionRepository questionsRepository = new QuestionRepository("hexagondbconnection");

            int id = questionsRepository.AddQuestion(statement: "AAA", option1: "A1", option2: "A2", option3: "A3", option4: "A4", correctAnswer: 1); // Named parametrization

            Question question = questionsRepository.GetQuestionById(id);

            Assert.AreEqual(id, question.Id);
            Assert.AreEqual("AAA", question.Statement);
            Assert.AreEqual("A1", question.Option1);
            Assert.AreEqual("A2", question.Option2);
            Assert.AreEqual("A3", question.Option3);
            Assert.AreEqual("A4", question.Option4);
            Assert.AreEqual(1, question.CorrectAnswer);


            // Hit the Database and GetQuestion out of it 
            //string connectionString = @"server=IN-PPM2320;database=dotnetdb1;intergrated security=true";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand command = new SqlCommand();
            //    command.CommandText = "select * from questions where id=@id"; //parameterize query preparation
            //    command.Connection = connection;
            //    command.Parameters.AddWithValue("@id", id); 

            //    connection.Open(); // connects to the database server

            //    // firing the query to the DB servers SQl processing Engine 
            //    SqlDataReader reader = command.ExecuteReader();  
            //    // reader gets the cursor to read the records 

            //    reader.Read(); //get the first record in reader object

            //    question = new Question();

            //    // Extracting data from the reader object per column bases 
            //    // and filling the data in Question Object
            //    question.Id = (int)reader["Id"];
            //    question.Statement = (string)reader["statement"];
            //    question.Option1 = (string)reader["option1"];
            //    question.Option2 = (string)reader["option2"];
            //    question.Option3 = (string)reader["option3"];
            //    question.Option4 = (string)reader["option4"];
            //    question.CorrectAnswer = (int)reader["correctanswer"];

            //    Assert.AreEqual(id, question.Id);
            //    Assert.AreEqual("AAA", question.Statement);
            //    Assert.AreEqual("A1", question.Option1);
            //    Assert.AreEqual("A2", question.Option2);
            //    Assert.AreEqual("A3", question.Option3);
            //    Assert.AreEqual("A4", question.Option4);
            //    Assert.AreEqual(1, question.CorrectAnswer);

            
        }

        [TestMethod]
        public void DeleteQuestion()
        {
        }
        [TestMethod]
        public void UpdateQuestion()
        {
        }
        [TestMethod]
        public void ListQuestion()
        {
        }
    }
}
