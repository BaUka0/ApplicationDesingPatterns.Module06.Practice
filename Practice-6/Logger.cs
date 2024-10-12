using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_6
{
    public enum LogLevel
    {
        INFO, WARNING, ERROR
    }

    internal class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();
        private string _logFilePath = "C:\\Users\\bauir\\OneDrive\\Рабочий стол\\log.txt";
        public static LogLevel _level = LogLevel.INFO;

        private Logger()
        {

        }

        public static Logger GetInstance()
        {
            if(_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }
            }
            return _instance;
        }

        public void Log(string message, LogLevel level)
        {
            if (_level <= level)
            {
                lock (_lock)
                {
                    if (_level == level)
                        File.AppendAllText(@"C:\Users\bauir\OneDrive\Рабочий стол\file.txt", level + " | " + message + Environment.NewLine);
                }
            }
        }
        public void SetLogLevel(LogLevel level)
        {
            _level = level;
        }
        public void SetLogFilePath(string path)
        {
            _logFilePath = path;
        }
        public void ReadLogs()
        {
            if (File.Exists(_logFilePath))
            {
                Console.WriteLine("Logs from file:");
                foreach (string line in File.ReadAllLines(_logFilePath))
                    Console.WriteLine(line);
            }
            else
                Console.WriteLine("Log file doesnt exist.");
        }
    }
}
