using System;
using Hive_Kompas.Logic;
using NUnit.Framework;

namespace Hive_Kompas.UnitTests
{
    public class HiveParamsUnitTests
    {
        private HiveParams hiveParams;
        [SetUp]
        public void SetUp()
        {// TODO:один параметр на одну строчку
            //TODO: удали везде повторение
            hiveParams = new HiveParams(200, 
                300,
                300, 10, 50, 100, 100, 100);

        }
        [Test(Description = "Позитивный тест геттера Height")]
        public void TestHeightGet_CorrectValue()
        {
            var expected = 300;
            hiveParams.HiveHeight = expected;
            var actual = hiveParams.HiveHeight;
            Assert.AreEqual(expected, actual, "Геттер HiveHeight возвращает неправильное значение.");
        }

        //TODO: посмотри как у меня
        [Test(Description = "Негативный тест геттера Height")]
        public void TestHeightGet_BadValue()
        {
            var wrongHeight = 99999;
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

        [Test(Description = "Негативный тест геттера Length")]
        public void TestLengthGet_BadValue()
        {
            var wrongHeight = 99999;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            Assert.Throws<ArgumentException>(() => { hiveParams.HiveLength = wrongHeight; }, "-");
        }

        [Test(Description = "Позитивный тест геттера Width")]
        public void TestWidthGet_CorrectValue()
        {
            var expected = 400;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            hiveParams.HiveWidth = expected;
            var actual = hiveParams.HiveWidth;
            Assert.AreEqual(expected, actual, "Геттер HiveWidth возвращает неправильное значение.");
        }

        [Test(Description = "Негативный тест геттера Width")]
        public void TestWidthGet_BadValue()
        {
            var wrongHeight = 99999;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            Assert.Throws<ArgumentException>(() => { hiveParams.HiveWidth = wrongHeight; }, "-");
        }

        [Test(Description = "Позитивный тест геттера InLetDiameters")]
        public void TestInLetDiametersGet_CorrectValue()
        {
            var expected = 10;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            hiveParams.InletDiameters = expected;
            var actual = hiveParams.InletDiameters;
            Assert.AreEqual(expected, actual, "Геттер InLetDiameters возвращает неправильное значение.");
        }

        [Test(Description = "Негативный тест геттера InLetDiameters")]
        public void TestInLetDiametersGet_BadValue()
        {
            var wrongHeight = 99999;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            Assert.Throws<ArgumentException>(() => { hiveParams.InletDiameters = wrongHeight; }, "-");
        }

        [Test(Description = "Позитивный тест геттера LegHeight")]
        public void TestLegHeightGet_CorrectValue()
        {
            var expected = 400;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            hiveParams.LegHeight = expected;
            var actual = hiveParams.LegHeight;
            Assert.AreEqual(expected, actual, "Геттер LegHeight возвращает неправильное значение.");
        }

        [Test(Description = "Негативный тест геттера LegHeight")]
        public void TestLegHeightGet_BadValue()
        {
            var wrongHeight = 99999;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            Assert.Throws<ArgumentException>(() => { hiveParams.LegHeight = wrongHeight; }, "-");
        }

        [Test(Description = "Позитивный тест геттера LegLength")]
        public void TestLegLengthGet_CorrectValue()
        {
            var expected = 400;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            hiveParams.LegLength = expected;
            var actual = hiveParams.LegLength;
            Assert.AreEqual(expected, actual, "Геттер LegLength возвращает неправильное значение.");
        }

        [Test(Description = "Негативный тест геттера LegLength")]
        public void TestLegLengthGet_BadValue()
        {
            var wrongHeight = 99999;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            Assert.Throws<ArgumentException>(() => { hiveParams.LegLength = wrongHeight; }, "-");
        }

        [Test(Description = "Позитивный тест геттера LegWidth")]
        public void TestLegWidthGet_CorrectValue()
        {
            var expected = 400;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            hiveParams.LegWidth = expected;
            var actual = hiveParams.LegWidth;
            Assert.AreEqual(expected, actual, "Геттер LegWidth возвращает неправильное значение.");
        }

        [Test(Description = "Негативный тест геттера LegWidth")]
        public void TestLegWidthGet_BadValue()
        {
            var wrongHeight = 99999;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            Assert.Throws<ArgumentException>(() => { hiveParams.LegWidth = wrongHeight; }, "-");
        }

        [Test(Description = "Позитивный тест геттера RoofThickness")]
        public void TestRoofThicknessGet_CorrectValue()
        {
            var expected = 100;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            hiveParams.RoofThickness = expected;
            var actual = hiveParams.RoofThickness;
            Assert.AreEqual(expected, actual, "Геттер RoofThickness возвращает неправильное значение.");
        }

        [Test(Description = "Негативный тест геттера RoofThickness")]
        public void TestRoofThicknessGet_BadValue()
        {
            var wrongHeight = 99999;
            var hiveParams = new HiveParams(200, 300, 300, 10, 50, 100, 100, 100);
            Assert.Throws<ArgumentException>(() => { hiveParams.RoofThickness = wrongHeight; }, "-");
        }
    }
}
