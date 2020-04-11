using System;
using NUnit.Framework;

namespace Hive_Kompas.UnitTests
{
    public class UnitTests
    {
        [Test(Description = "Позитивный тест геттера Height")]
        public void TestHeightGet_CorrectValue()
        {
            var expected = 300;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            hiveParams.HiveHeight = expected;
            var actual = hiveParams.HiveHeight;
            Assert.AreEqual(expected, actual, "Геттер HiveHeight возвращает неправильное значение.");
        }

        [Test(Description = "Негативный тест геттера Height")]
        public void TestHeightGet_BadValue()
        {
            var wrongHeight = 99999;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            Assert.Throws<ArgumentException>(() => { hiveParams.HiveHeight = wrongHeight; }, "-");
        }

        [Test(Description = "Позитивный тест геттера Length")]
        public void TestLengthGet_CorrectValue()
        {
            var expected = 400;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            hiveParams.HiveLength = expected;
            var actual = hiveParams.HiveLength;
            Assert.AreEqual(expected, actual, "Геттер HiveLength возвращает неправильное значение.");
        }

        [Test(Description = "Негативный тест геттера Height")]
        public void TestLengthGet_BadValue()
        {
            var wrongHeight = 99999;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            Assert.Throws<ArgumentException>(() => { hiveParams.HiveLength = wrongHeight; }, "-");
        }

    }
}
