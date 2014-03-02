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


using System.IO;
using System.Reflection;

namespace Freya.Logger
{
    public class AsynLogger
    {
        private static string _file = "logFile.txt";
        private static string _dirlog = "/";

        public static string File
        {
            get { return _file; }
            set { _file = value; }
        }
        public static string Directory
        {
            get { return _dirlog; }
            set { _dirlog = value; }
        }

        static AsynLogger()
        {
            _dirlog = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        public static bool AddLog(LogEntry entry)
        {
            return Flush(entry);
        }

        private static bool Flush(LogEntry entry)
        {
            try
            {
                using (StreamWriter _writer = new StreamWriter(System.IO.Path.Combine(_dirlog, _file), true))
                {
                    _writer.WriteLine(entry.Format, entry.DateTime.ToString(), entry.Type, entry.Value);
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
