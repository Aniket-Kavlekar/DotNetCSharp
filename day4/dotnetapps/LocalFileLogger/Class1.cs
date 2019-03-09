using System;
using System.IO;


public class LocalFileLogger : ILogger
{
    public void LogException(Exception ex)
    {
        StreamWriter streamWriter = new StreamWriter("log.txt", true);
        streamWriter.WriteLine(ex.ToString());
        streamWriter.WriteLine("----------------------------------------");
        streamWriter.Close();
    }
}

