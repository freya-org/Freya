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
using Freya.Utils;

namespace Freya
{
    public class FConsole
    {
        private static ConsoleColor _fg;
        private static ConsoleColor _bg;

        public static void Write(object value, FConsoleColor fg = FConsoleColor.Default, FConsoleColor bg = FConsoleColor.Default)
        {
            if (fg != FConsoleColor.Default) To(fg, bg);
            Console.Write(value);
            if (fg != FConsoleColor.Default) Restore();
        }

        public static void WriteLine(object value, FConsoleColor fg = FConsoleColor.Default, FConsoleColor bg = FConsoleColor.Default)
        {
            if (fg != FConsoleColor.Default) To(fg, bg);
            Console.WriteLine(value);
            if (fg != FConsoleColor.Default) Restore();
        }

        public static void WriteLine(string format, FConsoleColor fg = FConsoleColor.Default, FConsoleColor bg = FConsoleColor.Default, params object[] arg)
        {
            if (fg != FConsoleColor.Default) To(fg, bg);
            Console.WriteLine(format, arg);
            if (fg != FConsoleColor.Default) Restore();
        }

        private static void To(FConsoleColor fg, FConsoleColor bg)
        {
            _fg = Console.ForegroundColor;
            Console.ForegroundColor = fg.ToEnum<ConsoleColor>();
            _bg = Console.BackgroundColor;
            Console.BackgroundColor = bg.ToEnum<ConsoleColor>();
        }

        private static void Restore()
        {
            Console.ForegroundColor = _fg;
            Console.BackgroundColor = _bg;
        }
    }
}
