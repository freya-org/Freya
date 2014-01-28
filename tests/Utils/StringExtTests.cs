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

namespace tests
{
    [TestClass]
    public class StringExtTests
    {
        [TestMethod]
        public void ContainsInvariant_false()
        {
            string text = "bbbb";
            string filter = "B";
            Assert.AreEqual(false, text.ContainsInvariant(filter));
        }

        [TestMethod]
        public void ContainsInvariant_true()
        {
            string text = "bbbb";
            string filter = "b";
            Assert.AreEqual(true, text.ContainsInvariant(filter));
        }
    }
}
