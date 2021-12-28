using System;

//TODO: RSDN
namespace KompasWrapper
{
    /// <summary>
    /// Класс параметров кольца втулочно пальцевой муфты.
    /// </summary>
    public class CouplingParameters
    {
        //TODO:
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
        /// Поле минимального значения диаметра центрального отверстия
        /// </summary>
        private double _minCentralHoleDiameter = 10;

        /// <summary>
        /// Поле минимального количества отверстий
        /// </summary>
        private int _minCountOfSmallHoles = 3;

        /// <summary>
        /// Поле максимального количества отверстий
        /// </summary>
        private int _maxCountOfSmallHoles = 8;

        /// <summary>
        /// Поле минимального диаметра кольца
        /// </summary>
        private double _minCouplingDiameter = 40;

        /// <summary>
        /// Поле максимального диаметра кольца
        /// </summary>
        private double _maxCouplingDiameter = 70;

        /// <summary>
        /// Поле минимальной ширины кольца
        /// </summary>
        private double _minCouplingWidth = 10;
        
        /// <summary>
        /// Поле максимальной ширины кольца
        /// </summary>
        private double _maxCouplingWidth = 50;

        /// <summary>
        /// Поле минимального диаметра малых отверстий
        /// </summary>
        private double _minSmallHolesDiameter = 6;

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
                //TODO:
                if(value > MaxCenterHoleDiameter || value < MinCentralHoleDiameter)
                {
                    throw new ArgumentException("Неверное значение " +
                        "диаметра центрального отверстия = " +
                        $@"{value} мм. Область допустимых значений: " +
                        $@"{MinCentralHoleDiameter} мм. - {MaxCenterHoleDiameter} мм.");
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
                //TODO:
                if (value > MaxCountOfSmallHoles || value < MinCountOfSmallHoles)
                {
                    throw new ArgumentException(
                        $@"Неверное значение = {value} шт. 
                        Область допустимых значений: {MinCountOfSmallHoles} шт
                        - {MaxCountOfSmallHoles} шт!");
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
                //TODO:
                if (value > MaxCouplingDiameter || value < MinCouplingDiameter)
                {
                    throw new ArgumentException("Неверное значение " +
                        "диаметра кольца = " +
                        $@"{value} мм. Область допустимых значений: " +
                        $@"{MinCouplingDiameter} мм. - {MaxCouplingDiameter} мм.");
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
                //TODO:
                if (value > MaxCouplingWidth || value < MinCouplingWidth)
                {
                    throw new ArgumentException("Неверное значение " +
                        "ширины кольца = " +
                        $@"{value} мм. Область допустимых значений: " +
                        $@"{MinCouplingWidth} мм. - {MaxCouplingWidth} мм.");
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
                if (value > MaxSmallHoleDiameter || value < MinSmallHolesDiameter)
                {
                    throw new ArgumentException("Неверное значение " +
                        "диаметра малых отверстий = " +
                        $@"{value} мм. Область допустимых значений: " +
                        $@"{MinSmallHolesDiameter} мм. - {MaxSmallHoleDiameter} мм.");
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
                if (ArgumentException(value))
                {
                    _smallHoleCircleDiameter = value;
                }
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

        /// <summary>
        /// Исключение
        /// </summary>
        private static bool ArgumentException(double value)
        {
            //TODO: занести всю проверку
            if (value < 0)
            {
                throw new ArgumentException($"Значение должно быть больше нуля");
            }
            return true;
        }

        /// <summary>
        /// Минимальный диаметр центрального отверстия
        /// </summary>
        private double MinCentralHoleDiameter
        {
            get => _minCentralHoleDiameter;
        }

        /// <summary>
        /// Минимальное количество малых отверстий
        /// </summary>
        private int MinCountOfSmallHoles
        {
            get => _minCountOfSmallHoles;
        }

        /// <summary>
        /// Максимальное количество малых отверстий
        /// </summary>
        private int MaxCountOfSmallHoles
        {
            get => _maxCountOfSmallHoles;
        }

        /// <summary>
        /// Минимальное значение диаметра цольца
        /// </summary>
        private double MinCouplingDiameter
        {
            get => _minCouplingDiameter;
        }

        /// <summary>
        /// Максимальное значение диаметра кольца
        /// </summary>
        private double MaxCouplingDiameter
        {
            get => _maxCouplingDiameter;
        }

        /// <summary>
        /// Минимальное значение толщины кольца
        /// </summary>
        private double MinCouplingWidth
        {
            get => _minCouplingWidth;
        }

        /// <summary>
        /// Максимальное значение толщины кольца
        /// </summary>
        private double MaxCouplingWidth
        {
            get => _maxCouplingWidth;
        }

        /// <summary>
        /// Минимальное значение диаметра малых отверстий
        /// </summary>
        private double MinSmallHolesDiameter
        {
            get => _minSmallHolesDiameter;
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public CouplingParameters()
        {
            _countOfSmallHoles = 3;
            _smallHolesDiameter = 6;
            _centralHoleDiameter = 10;
            _couplingDiameter = 40;
            _couplingWidth = 10;
        }
    }
}
