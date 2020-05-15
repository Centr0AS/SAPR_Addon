using System;

namespace Hive_Kompas.Logic
{
    /// <summary>
    /// Класс, который содержит в себе поля для параметров улья.
    /// </summary>
    public class HiveParams
    {
        /// <summary>
        /// Высота улья.
        /// </summary>
        private double _hiveHeight;

        /// <summary>
        /// Длина улья.
        /// </summary>
        private double _hiveLength;

        /// <summary>
        /// Ширина улья.
        /// </summary>
        private double _hiveWidth;

        /// <summary>
        /// Диаметр отверстий для пчёл.
        /// </summary>
        private double _inletDiameters;

        /// <summary>
        /// Высота ножки улья.
        /// </summary>
        private double _legHeight;

        /// <summary>
        /// Длина ножки улья.
        /// </summary>
        private double _legLength;

        /// <summary>
        /// Ширина ножки улья.
        /// </summary>
        private double _legWidth;

        /// <summary>
        /// Толщина крыши.
        /// </summary>
        private double _roofThickness;

        ///// <summary>
        ///// Конструктор класса HiveParams
        ///// </summary>
        /// <param name="hiveHeight"> Высота улья</param>
        /// <param name="hiveLength"> Длина улья</param>
        /// <param name="hiveWidth"> Ширина улья</param>
        /// <param name="inletDiameters"> Диаметры отверстий для пчёл</param>
        /// <param name="legHeight"> Высота ножек улья</param>
        /// <param name="legLength"> Длина ножек улья</param>
        /// <param name="legWidth"> Ширина ножек улья</param>
        /// <param name="roofThickness"> Толщина крыши</param>
        public HiveParams(double hiveHeight, double hiveLength, double hiveWidth, double inletDiameters, double legHeight, double legLength,
            double legWidth, double roofThickness)
        {
            HiveHeight = hiveHeight;
            HiveLength = hiveLength;
            HiveWidth = hiveWidth;
            InletDiameters = inletDiameters;
            LegHeight = legHeight;
            LegLength = legLength;
            LegWidth = legWidth;
            RoofThickness = roofThickness;
        }

        //public HiveParams_defaultValues()
        //{
        //    HiveHeight = 300;
        //    HiveLength = 300;
        //    HiveWidth = 300;
        //    InletDiameters = 10;
        //    LegHeight = 100;
        //    LegLength = 50;
        //    LegWidth = 50;
        //    RoofThickness = 5;
        //}

        //Property;

        /// <summary>
        /// Высота улья.
        /// </summary>
        public double HiveHeight
        {
            get => _hiveHeight;

            set
            {
               SetParams(200, 1800, value);
                _hiveHeight = value;
            }
        }

        /// <summary>
        /// Длина улья.
        /// </summary>
        public double HiveLength
        {
            get => _hiveLength;

            set
            {
                SetParams(300, 1800, value);
                _hiveLength = value;
            }
        }

        /// <summary>
        /// Ширина улья.
        /// </summary>
        public double HiveWidth
        {
            get => _hiveWidth;

            set
            {
                SetParams(300, 1800, value);
                _hiveWidth = value;
            }
        }

        /// <summary>
        /// Высота улья.
        /// </summary>
        public double InletDiameters
        {
            get => _inletDiameters;

            set
            {
                SetParams(10, 75, value);

                _inletDiameters = value;
            }
        }

        /// <summary>
        /// Высота ножек.
        /// </summary>
        public double LegHeight
        {
            get =>_legHeight;

            set
            {
                SetParams(50, 1000, value);
                _legHeight = value;
            }
        }

        /// <summary>
        /// Длина ножек.
        /// </summary>
        public double LegLength
        {
            get => _legLength;

            set
            {
                if (value < 50 || value > 600 || (value - 1) >= _hiveLength)
                {
                    throw new ArgumentException("Значение должно находится в диапазоне от 50 до 600 " +
                        "длина ножек должна быть меньше в 3 раза чем длина улья");
                }

                _legLength = value;
            }
        }

        /// <summary>
        /// Ширина ножек.
        /// </summary>
        public double LegWidth
        {
            get => _legWidth;

            set
            {
                if (value < 50 || value > 600 || (value - 1) >= _hiveWidth)
                {
                    throw new ArgumentException("Значение должно находится в диапазоне от 50 до 600 " +
                        "ширина ножек должна быть меньше в 3 раза чем ширина улья");
                }

                _legWidth = value;
            }
        }

        /// <summary>
        /// Толщина крыши.
        /// </summary>
        public double RoofThickness
        {
            get => _roofThickness;

            set
            {
                SetParams(5, 50, value);
                _roofThickness = value;
            }
        }

        private double SetParams(int min, int max, double value)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException("Неправильный ввод, значение ( " + value +
                                            " ) должно находиться в диапазоне от " +
                                            min + " до " + max);
            }
            return value;
        }
    }
}
