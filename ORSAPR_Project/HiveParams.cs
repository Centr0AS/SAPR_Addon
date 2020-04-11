using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hive_Kompas
{
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
                    throw new ArgumentException("Значение должно находиться в диапазоне от 100 до 1800");
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
                if (value < 10 || value > 100)
                {
                    throw new ArgumentException("Значение должно находится в диапазоне от 10 до 100");
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
                if (value < 50 || value > 1000)
                {
                    throw new ArgumentException("Значение должно находится в диапазоне от 50 до 1000");
                }

                _legLength = value;
            }
        }
        public double LegWidth {
            get => _legWidth;
            set
            {
                if (value < 50 || value > 1000)
                {
                    throw new ArgumentException("Значение должно находится в диапазоне от 50 до 1000");
                }

                _legWidth = value;
            }
        }
        public double RoofThickness {
            get => _roofThickness;
            set
            {
                if (value < 100 || value > 350)
                {
                    throw new ArgumentException("Значение должно находится в диапазоне от 100 до 350");
                }

                _roofThickness = value;
            }
        }
    }
}
