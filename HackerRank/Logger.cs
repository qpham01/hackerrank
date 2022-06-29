using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public enum LogLevel
    {
        Debug,
        Info,
        Error
    }

    public interface ILogger
    {
        string Topic { get; }
        LogLevel LogLevel { get; set; }
        void LogDebug(string message);
        void LogInfo(string message);
        void LogError(string message);
    }

    public class ConsoleLogger : ILogger
    {
        private const string Debug = "DEBUG";
        private const string Info = "INFO";
        private const string Error = "ERROR";

        public LogLevel LogLevel { get; set; }
        public string Topic { get; }

        public ConsoleLogger(string topic)
        {
            LogLevel = LogLevel.Info;
            Topic = topic;
        }

        public void LogDebug(string message)
        {
            if (LogLevel >= LogLevel.Debug)
                Log(Debug, message);
        }

        public void LogInfo(string message)
        {
            if (LogLevel >= LogLevel.Info)
                Log(Info, message);
        }

        public void LogError(string message)
        {
            if (LogLevel >= LogLevel.Error)
                Log(Error, message);
        }

        private void Log(string level, string message)
        {
            Console.WriteLine($"[{level}] {Topic}: {message}");
        }
    }
}
