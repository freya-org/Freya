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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Freya.Utils;

namespace tests.Utils
{
    [TestClass]
    public class ValidatorsTests
    {
        enum Example { example, }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Test")]
        public void ValidateNotNull()
        {
            Validators.ValidateNotNull(null, "Test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Test")]
        public void ValidateEnum()
        {
            string name = "example2";
            Validators.ValidateEnum(typeof(Example), name, "Test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Test")]
        public void ValidatePositivy()
        {
            Validators.ValidatePositive(0, "Test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Test")]
        public void ValidateNotNegative()
        {
            Validators.ValidateNotNegative(-1, "Test");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Test")]
        public void ValidateWithinRange()
        {
            Validators.ValidateWithinRange(-5, 5, 10, "Test");
        }
    }
}
