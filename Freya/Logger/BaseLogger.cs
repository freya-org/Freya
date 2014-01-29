using System.Collections.Generic;
using System.IO;
using Freya.Utils;

namespace Freya.Logger
{
    public abstract class BaseLogger
    {
        protected StreamWriter _writer;
        protected List<LogEntry> _logEntryList;
        protected string _file;
        protected int _frequency;
        protected string _format;

        public string File
        {
            get { return _file; }
            set { _file = value; }
        }

        public string Format
        {
            get { return _format; }
            set { _format = value; }
        }

        public int Frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }

        public BaseLogger(string file, string format = "DateTime: {0} >> {1} >> {2}", int frequency = 1000)
        {
            _file = file;
            _format = format;
            _frequency = frequency;
            _logEntryList = new List<LogEntry>();
            _writer = new StreamWriter(_file);
        }

        public void AddLog(LogType type, object value)
        {
            _logEntryList.Add(new LogEntry { LogType = type, Value = value });
        }

        public bool Flush(List<LogEntry> list)
        {
            try
            {
                using (_writer)
                {
                    foreach (LogEntry entry in list)
                    {
                        _writer.WriteLine(entry.Format, entry.DateTime, entry.LogType, entry.Value);
                        list.Remove(entry);
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public enum LogType
        {
            INFO,
            WARNING,
            ERROR,
            DEBUG,
        }
    }
}
