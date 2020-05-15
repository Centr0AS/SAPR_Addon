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
        {
            hiveParams = new HiveParams(200, 
                300,
                300, 
                10,
                50,
                100,
                100,
                5);

        }

        [Test(Description = "Проверка высоты улья")]
        public void TestHeightGet_CorrectValue()
        {
            var expected = 200;
            hiveParams.HiveHeight = expected;
            var actual = hiveParams.HiveHeight;
            Assert.AreEqual(expected, actual, "Геттер HiveHeight возвращает неправильное значение.");
        }

        [Test(Description = "Проверка длины улья")]
        public void TestLengthGet_CorrectValue()
        {
            var expected = 400;
            hiveParams.HiveLength = expected;
            var actual = hiveParams.HiveLength;
            Assert.AreEqual(expected, actual, 
                "Проверка на правильные значения");
        }

        [Test(Description = "Проверка ширины улья")]
        public void TestWidthGet_CorrectValue()
        {
            var expected = 400;
            hiveParams.HiveWidth = expected;
            var actual = hiveParams.HiveWidth;
            Assert.AreEqual(expected, actual, 
                "Проверка на правильные значения");
        }

        [Test(Description = "Проверка диаметра входных отверстий для пчёл")]
        public void TestInLetDiametersGet_CorrectValue()
        {
            var expected = 10;
            hiveParams.InletDiameters = expected;
            var actual = hiveParams.InletDiameters;
            Assert.AreEqual(expected, actual, 
                "Проверка на правильные значения");
        }

        [Test(Description = "Проверка размера высоты ножек")]
        public void TestLegHeightGet_CorrectValue()
        {
            var expected = 400;
            hiveParams.LegHeight = expected;
            var actual = hiveParams.LegHeight;
            Assert.AreEqual(expected, actual, 
                "Проверка на правильные значения");
        }

        [Test(Description = "Проверка размера длины ножек")]
        public void TestLegLengthGet_CorrectValue()
        {
            var expected = 50;
            hiveParams.LegLength = expected;
            var actual = hiveParams.LegLength;
            Assert.AreEqual(expected, actual, 
                "Проверка на правильные значения");
        }

        [Test(Description = "Проверка размера ширины ножек")]
        public void TestLegWidthGet_CorrectValue()
        {
            var expected = 50;
            hiveParams.LegWidth = expected;
            var actual = hiveParams.LegWidth;
            Assert.AreEqual(expected, actual, 
                "Проверка на правильные значения");
        }

        [Test(Description = "Проверка размера толщины крыши")]
        public void TestRoofThicknessGet_CorrectValue()
        {
            var expected = 5;
            hiveParams.RoofThickness = expected;
            var actual = hiveParams.RoofThickness;
            Assert.AreEqual(expected, actual, 
                "Проверка на правильные значения");
        }

        [TestCase(1, "Исключение, если число меньше граничных значений",
          TestName = "Присвоение меньшего числа - Высота улья")]
        [TestCase(1801, "Исключение, если число больше граничных значений",
          TestName = "Присвоение большего числа - Высота улья")]
        public void TestBorderHeightSet_ArgumentException(int wrongParam, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { hiveParams.HiveHeight = wrongParam; },
                message);
        }

        [TestCase(1, "Исключение, если число меньше граничных значений",
        TestName = "Присвоение меньшего числа - Длина улья")]
        [TestCase(1801, "Исключение, если число больше граничных значений",
        TestName = "Присвоение большего числа - Длина улья")]
        public void TestBorderLengthSet_ArgumentException(int wrongParam, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { hiveParams.HiveLength = wrongParam; },
                message);
        }

        [TestCase(1, "Исключение, если число меньше граничных значений",
        TestName = "Присвоение меньшего числа - Ширина улья")]
        [TestCase(1801, "Исключение, если число больше граничных значений",
        TestName = "Присвоение большего числа - Ширина улья")]
        public void TestBorderWidthSet_ArgumentException(int wrongParam, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { hiveParams.HiveWidth = wrongParam; },
                message);
        }

        [TestCase(1, "Исключение, если число меньше граничных значений",
        TestName = "Присвоение меньшего числа - Диаметр входных отверстий")]
        [TestCase(101, "Исключение, если число больше граничных значений",
        TestName = "Присвоение большего числа - Диаметр входных отверстий")]
        public void TestBorderInLetSet_ArgumentException(int wrongParam, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { hiveParams.InletDiameters = wrongParam; },
                message);
        }

        [TestCase(1, "Исключение, если число меньше граничных значений",
        TestName = "Присвоение меньшего числа - Высота ножек")]
        [TestCase(1001, "Исключение, если число больше граничных значений",
        TestName = "Присвоение большего числа - Высота ножек")]
        public void TestBorderLegHeightSet_ArgumentException(int wrongParam, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { hiveParams.LegHeight = wrongParam; },
                message);
        }

        [TestCase(1, "Исключение, если число меньше граничных значений",
      TestName = "Присвоение меньшего числа - Длина ножек")]
        [TestCase(1001, "Исключение, если число больше граничных значений",
      TestName = "Присвоение большего числа - Длина ножек")]
        public void TestBorderLegLengthSet_ArgumentException(int wrongParam, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { hiveParams.LegLength = wrongParam; },
                message);
        }

        [TestCase(1, "Исключение, если число меньше граничных значений",
      TestName = "Присвоение меньшего числа - Ширина ножек")]
        [TestCase(601, "Исключение, если число больше граничных значений",
      TestName = "Присвоение большего числа - Ширина ножек")]
        public void TestBorderLegWidthSet_ArgumentException(int wrongParam, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { hiveParams.LegWidth = wrongParam; },
                message);
        }

        [TestCase(1, "Исключение, если число меньше граничных значений",
      TestName = "Присвоение меньшего числа - Толщина крыши")]
        [TestCase(101, "Исключение, если число больше граничных значений",
      TestName = "Присвоение большего числа - Толщина крыши")]
        public void TestBorderRoofThicknessSet_ArgumentException(int wrongParam, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { hiveParams.RoofThickness = wrongParam; },
                message);
        }
    }
}
