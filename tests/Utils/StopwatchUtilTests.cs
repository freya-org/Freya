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


using Freya.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tests.Utils
{
    [TestClass]
    public class StopwatchUtilTests
    {
        [TestMethod]
        public void isTimeSpan()
        {
            TimeSpan time = StopwatchUtil.Time(() =>
            {
                // Do something
            });
            TimeSpan time2 = new TimeSpan();

            Assert.AreEqual(time.GetType(), time2.GetType());
        }
    }
}
