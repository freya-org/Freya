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

namespace Freya.Utils
{
    public class Validators
    {
        public static void ValidateNotNull(object value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        internal static void ValidateEnum(Type enumType, object value, string name)
        {
            if (!Enum.IsDefined(enumType, value))
            {
                throw new ArgumentException("The argument should be a valid enumerator", name);
            }
        }

        internal static void ValidatePositive(double value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentException("The argument should be non-zero positive", name);
            }
        }

        internal static void ValidateNotNegative(double value, string name)
        {
            if (value < 0)
            {
                throw new ArgumentException("The argument should be non-negative", name);
            }
        }

        internal static void ValidateWithinRange(double value, double min, double max, string name)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(name);
            }
        }
    }
}
