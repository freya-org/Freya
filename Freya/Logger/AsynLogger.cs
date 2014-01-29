/***********************************************************************************************
 COPYRIGHT 2014 Drahník Lukáš
 --------------------------

 This file is part of Freya.
 (Project Website: https://github.com/freya-org)

 Freya is a free software. You can redistribute it and/or modify it under the terms of
 the GNU General Public License as published by the Free Software Foundation, either version 3
 of the License, or (at your option) any later version.

 Freya is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 (See the GNU General Public License for more details: http://www.gnu.org/licenses/)

 ***********************************************************************************************/


using System.Collections.Generic;
using System.IO;
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

        private void ProcessQueue()
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
