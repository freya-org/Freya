﻿/***********************************************************************************************
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
using System.Linq.Expressions;

namespace Freya
{
    public static class FConsoleExt
    {
        static void Print<T>(Expression<Func<T>> expression)
        {
            Console.WriteLine("{0}={1}", ((MemberExpression)expression.Body).Member.Name, expression.Compile()());
        }
    }
}
