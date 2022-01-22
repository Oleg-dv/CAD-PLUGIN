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
    public static class SettingManager
    {
        public static readonly string _directoryPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + @"\Coupling";

        public static readonly string _fileName = "CouplingParameters.json";

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

        public static CouplingParameters LoadFile(string path)
        {
            if (!File.Exists(Path.Combine(path, _fileName)))
            {
                return new CouplingParameters();
            }

            string parameters;

            using (StreamReader reader = new StreamReader(Path.Combine(path, _fileName)))
            {
                parameters = reader.ReadToEnd();
            }

            var couplingParameters = JsonConvert.DeserializeObject<CouplingParameters>(parameters);

            return couplingParameters;
        }
    }
}
