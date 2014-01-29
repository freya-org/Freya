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


using System;

namespace Freya.Logger
{
    /// <summary>
    /// A LogEntry class to store the message info
    /// </summary>
    public class LogEntry
    {
        private string format;
        private DateTime dateTime;
        private LogType type;
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

        public LogType Type
        {
            get { return type; }
            set { type = value; }
        }

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
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
