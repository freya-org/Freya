using System.Threading;

namespace Freya.Logger
{
    public class AsynLogger : BaseLogger
    {
        AutoResetEvent reset = new AutoResetEvent(false);

        public AsynLogger(string file, string format, int frequency)
            : base(file, format, frequency)
        {
            Thread loggingThread = new Thread(new ThreadStart(ProcessQueue));
            loggingThread.IsBackground = true;
            loggingThread.Start();
        }

        void ProcessQueue()
        {
            while (true)
            {
                reset.WaitOne(_frequency, true);
                Flush(_logEntryList);
            }
        }
    }
}
