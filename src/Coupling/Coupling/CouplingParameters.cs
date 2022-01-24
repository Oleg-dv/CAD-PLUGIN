﻿using System;

//TODO: naming
namespace KompasWrapper
{
    /// <summary>
    /// Класс параметров кольца втулочно пальцевой муфты.
    /// </summary>
    public class CouplingParameters : IEquatable<CouplingParameters>
    {
        /// <summary>
        /// Минимальный диаметр центрального отверстия
        /// </summary>
        public const int MIN_CENTRAL_HOLE_DIAMETER = 10;

        /// <summary>
        /// Минимальное количество отверстий
        /// </summary>
        public const int MIN_COUNT_OF_SMALL_HOLES = 3;

        /// <summary>
        /// Максимальное количество отверстий 
        /// </summary>
        public const int MAX_COUNT_OF_SMALL_HOLES = 8;

        /// <summary>
        /// Минимальноый диаметр кольца
        /// </summary>
        public const double MIN_COUPLING_DIAMETER = 40;

        /// <summary>
        /// Максимальноый диаметр кольца
        /// </summary>
        public const double MAX_COUPLING_DIAMETER = 70;

        /// <summary>
        /// Минимальная ширина кольца
        /// </summary>
        public const double MIN_COUPLING_WIDTH = 10;

        /// <summary>
        /// Максимальная ширина кольца
        /// </summary>
        public const double MAX_COUPLING_WIDTH = 50;

        /// <summary>
        /// Минимальный диаметр малых отверстий
        /// </summary>
        public const int MIN_SMALL_HOLES_DIAMETER = 2;
        
        /// <summary>
        /// Поле ширины кольца
        /// </summary>
        private double _couplingWidth;

        /// <summary>
        /// Поле диаметра центрального отверстия
        /// </summary>
        private double _centralHoleDiameter = 10;

        /// <summary>
        /// Поле количества малых отверстий 
        /// </summary>
        private int _countOfSmallHoles = 3;

        /// <summary>
        /// Поле диаметра кольца втулочно-пальцевой муфты
        /// </summary>
        private double _couplingDiameter = 40;

        /// <summary>
        /// Поле диаметра малых отверстий
        /// </summary>
        private double _smallHolesDiameter;

        /// <summary>
        /// Поле максимально возможного диаметра малых отверстий
        /// </summary>
        private double _maxSmallHolesDiameter = 5;

        /// <summary>
        /// Поле диаметра круга, по которому располагаются малые отверстия
        /// </summary>
        private double _smallHoleCircleDiameter;

        /// <summary>
        /// Поле максимально возможного диаметра
        /// </summary>
        private double _maxCenterHoleDiameter = 30;

        /// <summary>
        /// Диаметр кольца втулочно-пальцевой муфты
        /// </summary>
        public double CouplingDiameter
        {
            get
            {
                return _couplingDiameter;
            }
            set
            {
                //TODO: дубль
                if (value > MAX_COUPLING_DIAMETER || value < MIN_COUPLING_DIAMETER)
                {
                    string parameterName = "диаметра кольца";
                    string unit = "мм.";

                    ExceptionMessage(parameterName, value,
                        MIN_COUPLING_DIAMETER,
                        MAX_COUPLING_DIAMETER, unit);
                }
                _couplingDiameter = value;

                SmallHoleCircleDiameter = (value + CentralHoleDiameter) / 2;

                MaxCenterHoleDiameter = Math.Round(value / (7 / 3), 1);

                MaxSmallHoleDiameter = MatchMaxSmallHoleDiameter();
            }
        }

        /// <summary>
        /// Диаметр центрального отверстия
        /// </summary>
        public double CentralHoleDiameter 
        { 
            get 
            {
                return _centralHoleDiameter;
            }
            set
            {
                //TODO: дубль
                if(value > MaxCenterHoleDiameter || value < MIN_CENTRAL_HOLE_DIAMETER)
                {
                    string parameterName = "центрального отверстия";
                    string unit = "мм.";

                    ExceptionMessage(parameterName, value,
                        MIN_CENTRAL_HOLE_DIAMETER, MaxCenterHoleDiameter, unit);
                }
                _centralHoleDiameter = value;

                MaxSmallHoleDiameter = MatchMaxSmallHoleDiameter();

                SmallHoleCircleDiameter = (value + CouplingDiameter) / 2;
            } 
        }

        /// <summary>
        /// Количество малых отверстий
        /// </summary>
        public int CountOfSmallHoles 
        { 
            get 
            {
                return _countOfSmallHoles;
            } 
            set 
            {
                //TODO: дубль
                if (value > MAX_COUNT_OF_SMALL_HOLES || value < MIN_COUNT_OF_SMALL_HOLES)
                {
                    string parameterName = "количества малых отверстий";
                    string unit = "шт.";

                    ExceptionMessage(parameterName, value, 
                        MAX_COUNT_OF_SMALL_HOLES,
                        MIN_COUNT_OF_SMALL_HOLES, unit);
                }
                _countOfSmallHoles = value;

                MaxSmallHoleDiameter = MatchMaxSmallHoleDiameter();

            } 
        }

        /// <summary>
        /// Вычисляет максимальный диаметр малых отверстий
        /// </summary>
        /// <returns>Максимальный диаметр малых отверстий</returns>
        private double MatchMaxSmallHoleDiameter()
        {
            double maxSmallDiameterFromCoupling 
                = (CouplingDiameter - 20 - CentralHoleDiameter) / 2;

            double smallHoleCircleDiameterLength = SmallHoleCircleDiameter * Math.PI;
            double maxSmallDiameterFromCount;

            maxSmallDiameterFromCount = smallHoleCircleDiameterLength / CountOfSmallHoles / 1.1;

            if (maxSmallDiameterFromCoupling < maxSmallDiameterFromCount)
            {
                return Math.Round(maxSmallDiameterFromCoupling, 1);
            }
            else
            {
                return Math.Round(maxSmallDiameterFromCount, 1);
            }
        }

        /// <summary>
        /// Ширина кольца втулочно-пальцевой муфты
        /// </summary>
        public double CouplingWidth 
        { 
            get => _couplingWidth;
            set
            {
                //TODO: дубль
                if (!(value > MAX_COUPLING_WIDTH) && !(value < MIN_COUPLING_WIDTH))
                {
                    _couplingWidth = value;
                    return;
                }
                
                string parameterName = "ширины кольца";
                string unit = "мм.";

                ExceptionMessage(parameterName, value,
                    MIN_COUPLING_WIDTH,
                    MAX_COUPLING_WIDTH, unit);

            }
        }

        /// <summary>
        /// Диаметр малых отверстий
        /// </summary>
        public double SmallHolesDiameter 
        { 
            get 
            {
                return _smallHolesDiameter;
            }
            set 
            {
                //TODO: дубль
                if (value > MaxSmallHoleDiameter || value < MIN_SMALL_HOLES_DIAMETER)
                {
                    string parameterName = "диаметра малых отверстий";
                    string unit = "мм.";

                    ExceptionMessage(parameterName, value,
                        MIN_SMALL_HOLES_DIAMETER,
                        MaxSmallHoleDiameter, unit);
                }
                _smallHolesDiameter = value;
            }
        }

        /// <summary>
        /// Максимальный диаметр центрального отверстия
        /// </summary>
        public double MaxCenterHoleDiameter
        {
            get
            {
                return _maxCenterHoleDiameter;
            }
            set
            {
                if (ArgumentException(value))
                {
                    _maxCenterHoleDiameter = value;
                }
            }
        }

        /// <summary>
        /// Диаметр кольца по которому располагаются малые отверстия
        /// </summary>
        public double SmallHoleCircleDiameter
        {
            get
            {
                return _smallHoleCircleDiameter;
            }
            set
            {
                if (ArgumentException(value))
                {
                    _smallHoleCircleDiameter = value;
                }
            }
        }

        /// <summary>
        /// Максимально возможный диаметр малых отверстий
        /// </summary>
        public double MaxSmallHoleDiameter
        {
            get
            {
                return _maxSmallHolesDiameter;
            }
            set
            {
                if (ArgumentException(value))
                {
                    _maxSmallHolesDiameter = value;
                }
            }
        }

        //TODO: naming
        /// <summary>
        /// Исключение
        /// </summary>
        private static bool ArgumentException(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"Значение должно быть больше нуля!");
            }
            return true;
        }

        /// <summary>
        /// Присваевает текст сообщению ошибки.
        /// </summary>
        /// <param name="parameterName">Название параметра.</param>
        /// <param name="value">Значение параметра.</param>
        /// <param name="minValue">Минимальное значение параметра.</param>
        /// <param name="maxValue">Максимальное значение параметра.</param>
        /// <param name="unit">Еденицы измерения</param>
        private void ExceptionMessage(string parameterName,
            double value, double minValue, double maxValue, string unit)
        {
            throw new ArgumentException(
                $"Неверное значение {parameterName} = {value} {unit}.\n" +
                $"Область допустимых значений: {minValue} {unit} - {maxValue} {unit}!");
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public CouplingParameters()
        {
            CouplingDiameter = 40;
            CentralHoleDiameter = 10;
            SmallHolesDiameter = 2;
            CountOfSmallHoles = 3;
            CouplingWidth = 10;
        }

        //TODO: XML
        public bool Equals(CouplingParameters other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _couplingWidth.Equals(other._couplingWidth) 
                   && _centralHoleDiameter.Equals(other._centralHoleDiameter) 
                   && _countOfSmallHoles == other._countOfSmallHoles 
                   && _couplingDiameter.Equals(other._couplingDiameter) 
                   && _smallHolesDiameter.Equals(other._smallHolesDiameter) 
                   && _maxSmallHolesDiameter.Equals(other._maxSmallHolesDiameter) 
                   && _smallHoleCircleDiameter.Equals(other._smallHoleCircleDiameter) 
                   && _maxCenterHoleDiameter.Equals(other._maxCenterHoleDiameter);
        }
    }
}
