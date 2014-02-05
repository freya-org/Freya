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
