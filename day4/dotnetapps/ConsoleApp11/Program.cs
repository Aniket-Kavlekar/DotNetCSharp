using System;
using System.IO; 

class Program
{
    
    static void Main()
    {
        try
        {
            //2. try- finally both packaged in using 
            using (StreamReader streamReader = new StreamReader("app11.exe.config")) 
                //should only contain the object inheriting from IDisposable
                // finally block internally closes the object as seen in example 1 
            {
                string content = streamReader.ReadToEnd();
                Console.WriteLine(content);
            }
        }       
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message); 
        }
            
      

        //1. 
        //StreamReader streamReader = null; 
        //try
        //{
        //    streamReader = new StreamReader("app11.exe.txt");
        //    string content = streamReader.ReadToEnd();
        //    Console.WriteLine(content);          
        //}
        //finally
        //{
        //    streamReader.Close();
        //}
    }
}

