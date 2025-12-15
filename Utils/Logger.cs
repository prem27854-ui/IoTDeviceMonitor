using System;
using System.IO;

namespace Utils
{
    public static class Logger
    {
        private static readonly string logFile = "log.txt";

        public static void Log(string message)
        {
            using StreamWriter writer = new StreamWriter(logFile, append: true);
            writer.WriteLine($"{DateTime.Now} - {message}");
        }
    }
}

