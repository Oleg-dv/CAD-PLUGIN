

namespace KompasWrapper
{
    /// <summary>
    /// Класс отвечающий за построение подели
    /// </summary>
    public class CouplingBuilder
    {
        /// <summary>
        /// Объект класса KompasWrapper
        /// </summary>
        private KompasWrapper _kompasWrapper;
        /// <summary>
        /// Создание модели
        /// </summary>
        /// <param name="parameters">Параметры кольца
        /// втулочно-пальцевой муфты</param>
        public void CreateModel(CouplingParameters parameters)
        {
            _kompasWrapper = new KompasWrapper();

            _kompasWrapper.CreateCircle(parameters.CouplingDiameter);
            _kompasWrapper.ExtrudeCircle(parameters.CouplingWidth);

            _kompasWrapper.CreateCircle(parameters.CentralHoleDiameter);
            _kompasWrapper.CutExtrudeCircle(parameters.CouplingWidth);

            double[,] points =  new double[parameters.CountOfSmallHoles, 2];

            _kompasWrapper.SmallCircleDiameter(ref points,
                parameters.SmallHoleCircleDiameter,
                parameters.CountOfSmallHoles);

            for (int i = 0; i < parameters.CountOfSmallHoles; i++)
            {
                _kompasWrapper.CreateCircle(parameters.SmallHolesDiameter,
                    points[i, 0],
                    points[i, 1]);
                _kompasWrapper.CutExtrudeCircle(parameters.CouplingWidth);
            }
        }
    }
}
