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


using Microsoft.VisualStudio.TestTools.UnitTesting;
using Freya.Utils;

namespace tests.Utils
{
    [TestClass]
    public class ParsersTests
    {
        enum Example{ example, }
        enum Example2 { example, }
        string example = "example";

        [TestMethod]
        public void EnumToString()
        {
            Assert.AreEqual(example, Example.example.ToString());
        }

        [TestMethod]
        public void StringToEnum()
        {
            Assert.AreEqual(example.ToEnum<Example>(), Example.example);
        }

        public void EnumToEnum()
        {
            Assert.AreEqual(Example2.example, Example.example.ToEnum<Example2>());
        }
    }
}
