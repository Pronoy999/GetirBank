using System;

namespace GetirBank.Helpers
{
    public class Logger
    {
        public static void LogInformation(string Tag, string msg)
        {
            Console.WriteLine(Tag + " : " + msg);
        }

        public static void LogError(string Tag, string msg)
        {
            Console.WriteLine(Tag + " : " + msg);
        }
    }
}