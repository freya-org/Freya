using System.Collections.Generic;
using System.IO;
using Freya.Utils;
using System.Threading;

namespace Freya.Logger
{
    public class AsynLogger
    {
        private AutoResetEvent reset = new AutoResetEvent(false);
        private static AsynLogger _instance;
        private static Queue<LogEntry> _logQueue;
        private static string _file;
        private static int _frequency;
        private static string _format;

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

        public static AsynLogger getInstance
        {
            get
            {
                if (_instance == null)
                {
                    return null;
                }
                return _instance;
            }
        }

        private AsynLogger(string file, string format = "DateTime: {0} >> {1} >> {2}", int frequency = 1000)
        {
            _instance = new AsynLogger(file, format, frequency);
            _file = file;
            _format = format;
            _frequency = frequency;
            _logQueue = new Queue<LogEntry>();

            Thread loggingThread = new Thread(new ThreadStart(ProcessQueue));
            loggingThread.IsBackground = true;
            loggingThread.Start();
        }

        public void AddLog(LogEntry.LogType type, object value)
        {
            _logQueue.Enqueue(new LogEntry { Type = type, Value = value });
        }

        void ProcessQueue()
        {
            while (true)
            {
                reset.WaitOne(_frequency, true);
                lock (_logQueue)
                {
                    Flush(_logQueue);
                }
            }
        }    

        private bool Flush(Queue<LogEntry> logQueue)
        {
            try
            {
                while (logQueue.Count > 0)
                {
                    LogEntry entry = logQueue.Dequeue();

                    using (FileStream fs = System.IO.File.Open(_file, FileMode.Append, FileAccess.Write))
                    {
                        using (StreamWriter _writer = new StreamWriter(_file))
                        {
                            _writer.WriteLine(entry.Format, entry.DateTime.ToString(), entry.Type, entry.Value);
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
