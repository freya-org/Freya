using System;

namespace Freya.Logger
{
    public class LogEntry
    {
        private string format;
        private DateTime dateTime;
        private BaseLogger.LogType logType;
        private object value;

        public LogEntry()
        {
            dateTime = DateTime.Now;
        }

        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
        }

        public BaseLogger.LogType LogType
        {
            get { return logType; }
            set { logType = value; }
        }

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
