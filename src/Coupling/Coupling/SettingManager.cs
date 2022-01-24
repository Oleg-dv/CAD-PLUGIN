using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KompasWrapper;

namespace Coupling
{
    /// <summary>
    /// Класс для сохранения/загрузки настроек
    /// </summary>
    public static class SettingManager
    {
        //TODO: RSDN
        /// <summary>
        /// Пусть сохранения настроек
        /// </summary>
        public static readonly string _directoryPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + @"\Coupling";

        //TODO: RSDN
        /// <summary>
        /// Имя файла с настройками
        /// </summary>
        public static readonly string _fileName = "CouplingParameters.json";

        /// <summary>
        /// Сохранения настроек
        /// </summary>
        /// <param name="couplingParameters">Параметры кольца</param>
        /// <param name="path">Путь к файлу</param>
        public static void SaveFile(CouplingParameters couplingParameters, string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            string parameters = JsonConvert.SerializeObject(couplingParameters);

            using (StreamWriter writer = new StreamWriter(Path.Combine(path, _fileName)))
            {
                writer.Write(parameters);
            }
        }

        /// <summary>
        /// Метод для загрузки настроек
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Настройки</returns>
        public static CouplingParameters LoadFile(string path)
        {
            if (!File.Exists(path))
            {
                return new CouplingParameters();
            }

            string parameters;

            using (StreamReader reader = new StreamReader(path))
            {
                parameters = reader.ReadToEnd();
            }

            try
            {
                var couplingParameters 
                    = JsonConvert.DeserializeObject<CouplingParameters>(parameters);

                return couplingParameters;
            }
            catch
            {
                return new CouplingParameters();
            }
        }
    }
}
