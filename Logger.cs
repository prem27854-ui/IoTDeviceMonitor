using System.IO;

public static class Logger
{
    public static void Log(string message)
    {
        File.AppendAllText("log.txt", $"{System.DateTime.Now} - {message}\n");
    }
}
