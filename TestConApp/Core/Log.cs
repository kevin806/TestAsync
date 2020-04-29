using System;
using System.Collections.Generic;
using System.Text;

namespace TestConApp.Core
{
    public static class Log
    {
        public static void Debug(string format, params object[] arg)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms") + " " + format, arg);
        }


    }
}
