using System.Collections.Generic;
using System.IO;

namespace Freya.Logger
{
    public class BaseLogger
    {
        private List<LogEntry> _LogEntryList;
        private string _file;
        private string _format = "DateTime: {0} >> {1} >> {2}";

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

        public BaseLogger(string file, string format = null)
        {
            _file = file;
            if (format != null) _format = format;
            _LogEntryList = new List<LogEntry>();
        }

        public void Add(LogType type, object value)
        {
            _LogEntryList.Add(new LogEntry { LogType = type, Value = value });
        }

        public bool FlushToFile()
        {
            List<LogEntry> backup = new List<LogEntry>();
            backup = _LogEntryList;
            _LogEntryList.Clear();

            try
            {
                using (StreamWriter writer = new StreamWriter(_file))
                {
                    foreach (LogEntry entry in backup)
                    {
                        writer.WriteLine(entry.Format, entry.DateTime, entry.LogType, entry.Value);
                        backup.Remove(entry);
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
