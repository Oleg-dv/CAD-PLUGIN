using System;

namespace Coupling
{
    /// <summary>
    /// Класс параметров кольца втулочно пальцевой муфты.
    /// </summary>
    public class CouplingParameters
    {
        #region [Parameters and property]
        /// <summary>
        /// Поле ширины кольца
        /// </summary>
        private double _couplingWidth;
        /// <summary>
        /// Поле диаметра центрального отверстия
        /// </summary>
        private double _centralHoleDiameter;
        /// <summary>
        /// Поле максимально возможного диаметра
        /// </summary>
        private double _maxCenterHoleDiameter = 30;
        /// <summary>
        /// Поле количества малых отверстий 
        /// </summary>
        private int _countOfSmallHoles;
        /// <summary>
        /// Поле диаметра кольца втулочно-пальцевой муфты
        /// </summary>
        private double _couplingDiameter;
        /// <summary>
        /// Поле диаметра малых отверстий
        /// </summary>
        private double _smallHolesDiameter;
        /// <summary>
        /// Поле максимально возможного диаметра малых отверстий
        /// </summary>
        private double _maxSmallHolesDiameter = 24;
        /// <summary>
        /// Поле диаметра круга, по которому располагаются малые отверстия
        /// </summary>
        private double _smallHoleCircleDiameter;
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
                if(value > MaxCenterHoleDiameter || value < 10)
                {
                    throw new ArgumentException("" +
                        "Неверное значение = " + value + " " +
                        "мм. Область допустимых значений: 10 мм - " 
                        + MaxCenterHoleDiameter + " мм!");
                }
                _centralHoleDiameter = value;

                if(CouplingDiameter != 0)
                {
                    MaxSmallHoleDiameter = CouplingDiameter - value - 10;
                }

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
                if (value > 8 || value < 3)
                {
                    throw new ArgumentException("" +
                        "Неверное значение = " + value + " " +
                        "шт. Область допустимых значений: 3 шт - 8 шт!");
                }

                _countOfSmallHoles = value;
            } 
        }
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
                if (value > 70 || value < 40)
                {

                    throw new ArgumentException("" +
                        "Неверное значение = " + value + " " +
                        "мм. Область допустимых значений: 40 мм - 70 мм!");
                }
                _couplingDiameter = value;

                SmallHoleCircleDiameter = (value + CentralHoleDiameter) / 2;

                MaxCenterHoleDiameter = Math.Round(value / (7/3), 1);

                MaxSmallHoleDiameter = value - 10 - MaxCenterHoleDiameter;
            }
        }
        /// <summary>
        /// Ширина кольца втулочно-пальцевой муфты
        /// </summary>
        public double CouplingWidth 
        { 
            get 
            {
                return _couplingWidth;    
            } 
            set 
            {
                if (value > 50 || value < 10)
                {
                    throw new ArgumentException("" +
                        "Неверное значение = " + value + " " +
                        "мм. Область допустимых значений: 10 мм - 50 мм!");
                }

                _couplingWidth = value;
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
                if (value > MaxSmallHoleDiameter || value < 6)
                {
                    throw new ArgumentException("" +
                        "Неверное значение = " + value + " " +
                        "мм. Область допустимых значений: 6 мм - " 
                        + MaxSmallHoleDiameter + "мм!");

                }
                _smallHolesDiameter = value;

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
                if (value < 0)
                {
                    ArgumentException();
                }

                _smallHoleCircleDiameter = value;
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
                if (value < 0)
                {
                    ArgumentException();
                }

                _maxCenterHoleDiameter = value;
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
                if (value < 0)
                {
                    ArgumentException();
                }

                _maxSmallHolesDiameter = value;
            }
        }
        /// <summary>
        /// Исключение
        /// </summary>
        private static void ArgumentException()
        {
            throw new ArgumentException($"Значение должно быть больше нуля");
        }

        #endregion
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public CouplingParameters()
        {

        }
    }
}
