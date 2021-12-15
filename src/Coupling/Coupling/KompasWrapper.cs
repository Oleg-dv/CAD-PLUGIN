using System;
using System.Runtime.InteropServices;
using Kompas6API5;
using Kompas6Constants3D;

namespace Coupling
{
    /// <summary>
    /// Класс для работы с Компас 3D
    /// </summary>
    public class KompasWrapper
    {
        /// <summary>
        /// Поле 3D документа
        /// </summary>
        private ksDocument3D _document3D;
        /// <summary>
        /// Поле 2D документа
        /// </summary>
        private ksDocument2D _document2D;
        /// <summary>
        /// 
        /// </summary>
        private ksPart _part;
        /// <summary>
        /// Поле с текущим эскизом
        /// </summary>
        private ksEntity _sketch;
        /// <summary>
        /// 
        /// </summary>
        private ksSketchDefinition _sketchDefinition;
        /// <summary>
        /// Поле текущего плана
        /// </summary>
        private ksEntity _currentPlan;

        // [i,0] - по х координаты [i, 1] - по у
        /// <summary>
        /// Диаметр по которому располагаются малые отверстия
        /// </summary>
        /// <param name="points">Массив точек
        /// для построения малых отвертий</param>
        /// <param name="diameter">Диаметр всего кольца</param>
        /// <param name="count">Количество точек</param>
        public void SmallCircleDiameter(ref double[,] points,
            double diameter, int count)
        {
            for (int i = 0; i < count; i++)
            {
                _document2D.ksMovePoint(ref points[i, 0],
                    ref points[i, 1], 360 / count * i, diameter / 2);
            }
        }
        /// <summary>
        /// Объект компас
        /// </summary>
        public KompasObject Kompas { get; }
        /// <summary>
        /// Вырезание
        /// </summary>
        /// <param name="depth">Глубина вырезания</param>
        public void CutExtrudeCircle(double depth)
        {
            var entityExtrude = 
                (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            // интерфейс базовой операции выдавливания
            var entityExtrudeDefinition = 
                (ksCutExtrusionDefinition)entityExtrude.GetDefinition();
            // интерфейс структуры параметров выдавливания
            ksExtrusionParam extrudeParameters = 
                (ksExtrusionParam)entityExtrudeDefinition.ExtrusionParam();
            extrudeParameters.direction = (short)Direction_Type.dtNormal;

            entityExtrudeDefinition.SetSketch(_sketch);
            extrudeParameters.typeNormal = (short)End_Type.etBlind;
            // глубина выдавливания
            extrudeParameters.depthNormal = -depth;
            entityExtrude.Create();
        }
        /// <summary>
        /// Выдавливание
        /// </summary>
        /// <param name="depth">Глубина выдавливания</param>
        public void ExtrudeCircle(double depth)
        {
            var entityExtrude = 
                (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            // интерфейс базовой операции выдавливания
            var entityExtrudeDefinition = 
                (ksBossExtrusionDefinition)entityExtrude.GetDefinition();
            // интерфейс структуры параметров выдавливания
            ksExtrusionParam extrudeParameters = 
                (ksExtrusionParam)entityExtrudeDefinition.ExtrusionParam();
            extrudeParameters.direction = (short)Direction_Type.dtNormal;

            entityExtrudeDefinition.SetSketch(_sketch);
            // тип выдавливания (строго на глубину)
            extrudeParameters.typeNormal = (short)End_Type.etBlind;
            // глубина выдавливания
            extrudeParameters.depthNormal = depth;

            entityExtrude.Create();
        }
        /// <summary>
        /// Отрисовка круга
        /// </summary>
        /// <param name="diameter">Диаметр</param>
        /// <param name="xc"></param>
        /// <param name="yc"></param>
        public void CreateCircle(double diameter, double xc = 0, double yc = 0)
        {
            // (short) 1 - еденица плоскость
            _currentPlan = (ksEntity)_part.GetDefaultEntity((short)1);
            _sketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            _sketchDefinition = (ksSketchDefinition)_sketch.GetDefinition();
            _sketchDefinition.SetPlane(_currentPlan);
            _sketch.Create();

            _document2D = (ksDocument2D)_sketchDefinition.BeginEdit();

            // 1 это стиль линии ksCircle это эскиз
            _document2D.ksCircle(xc, yc, diameter / 2, 1);

            _sketchDefinition.EndEdit();
        }
        /// <summary>
        /// Открытие компаса
        /// </summary>
        /// <returns></returns>
        private KompasObject OpenKompas()
        {
            if (!GetActiveKompass(out var kompas))
            {
                CreateActiveKompas(out kompas);
            }

            kompas.Visible = true;
            kompas.ActivateControllerAPI();
            return kompas;
        }
        /// <summary>
        /// Получение открытого Компаса.
        /// </summary>
        /// <param name="kompasObject">Объект Компаса.</param>
        /// <returns>Возвращает указатель на Компас</returns>
        private bool GetActiveKompass(out KompasObject kompasObject)
        {
            try
            {
                kompasObject = 
                    (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                return true;
            }
            catch (COMException)
            {
                kompasObject = null;
                return false;
            }
        }
        /// <summary>
        /// Открытие Компас.
        /// </summary>
        /// <param name="kompasObject">Объект Компас</param>
        /// <returns>Возвращает указатель на Компас</returns>
        private bool CreateActiveKompas(out KompasObject kompasObject)
        {
            try
            {
                Type type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                kompasObject = (KompasObject)Activator.CreateInstance(type);
                return true;
            }
            catch (COMException)
            {
                throw new COMException("Failed to open Kompas");
            }
        }
        /// <summary>
        /// Создание документа
        /// </summary>
        private void CreateDocument()
        {
            _document3D = (ksDocument3D)Kompas.Document3D();
            _document3D.Create(false, true);
            _document2D = (ksDocument2D)Kompas.Document2D();
            _part = (ksPart)_document3D.GetPart((int)Part_Type.pTop_Part);
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        public KompasWrapper()
        {
            Kompas = OpenKompas();
            CreateDocument();
        }

    }
}
