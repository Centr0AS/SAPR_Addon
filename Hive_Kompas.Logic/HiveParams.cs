using System;

namespace Hive_Kompas.Logic
{
    /// <summary>
    /// Класс, который содержит в себе поля для параметров улья.
    /// </summary>
    public class HiveParams
    {
        private double _hiveHeight;

        private double _hiveLength;

        private double _hiveWidth;

        private double _inletDiameters;

        private double _legHeight;

        private double _legLength;

        private double _legWidth;

        private double _roofThickness;

        /// <summary>
        /// Конструктор класса HiveParams
        /// </summary>
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

        //Property;

        public double HiveHeight {
            get => _hiveHeight;
            set
            {
                if (value < 200 || value > 1800)
                {
                    throw new ArgumentException("Значение должно находиться в диапазоне от 200 до 1800");
                }

                _hiveHeight = value;
            }
        }
        public double HiveLength {
            get => _hiveLength;
            set
            {
                if (value < 300 || value > 1800)
                {
                    throw new ArgumentException("Значение должно находится в диапазоне от 300 до 1800");
                }

                _hiveLength = value;
            }
        }
        public double HiveWidth {
            get => _hiveWidth;
            set
            {
                if (value < 300 || value > 1800)
                {
                   throw new ArgumentException("Значение должно находится в диапазоне от 300 до 1800");
                }

                _hiveWidth = value;
            }
        }
        public double InletDiameters {
            get => _inletDiameters;
            set
            {
                if (value < 10 || value > 75)
                {
                    throw new ArgumentException("Значение должно находится в диапазоне от 10 до 75");
                }

                _inletDiameters = value;
            }
        }
        public double LegHeight {
            get =>_legHeight;
            set
            {
                if (value < 50 || value > 1000 )
                {
                    throw new ArgumentException("Значение должно находится в диапазоне от 50 до 1000");
                }

                _legHeight = value;
            }
        }
        public double LegLength {
            get => _legLength;
            set
            {
                if (value < 50 || value > 600)
                {
                    throw new ArgumentException("Значение должно находится в диапазоне от 50 до 600");
                }

                _legLength = value;
            }
        }
        public double LegWidth {
            get => _legWidth;
            set
            {
                if (value < 50 || value > 600)
                {
                    throw new ArgumentException("Значение должно находится в диапазоне от 50 до 600");
                }

                _legWidth = value;
            }
        }
        public double RoofThickness {
            get => _roofThickness;
            set
            {
                if (value < 5 || value > 50)
                {
                    throw new ArgumentException("Значение должно находится в диапазоне от 5 до 50");
                }

                _roofThickness = value;
            }
        }
    }
}
