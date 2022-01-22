using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KompasWrapper;
using NUnit.Framework;
using System.IO;


namespace Coupling.UnitTest
{
    public class SettingManagerTest
    {
        private const string CorrectCouplingParametersPath 
            = @"TestData\CorrectCouplingParameters.json";

        [TestCase(TestName = "Загрузка настроек, позитив")]
        public void SettingManager_LoadTest_CorrectParameters()
        {
            // Setup
            var expectedParameters = new CouplingParameters();

            // Act
            var actualParameters = SettingManager.LoadFile(CorrectCouplingParametersPath);

            // Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestCase(@"TestData\UncorrectGuideParameters.json", TestName = "Загрузка параметров, исключение")]
        [TestCase(@"TestData\Null.json", TestName = "Загрузка параметров, файл не существует")]
        public void SettingManager_LoadTest_Exception(string path)
        {
            //Setup
            var expectedParameters = new CouplingParameters();
            //Act
            var actualParameters = SettingManager.LoadFile(path);

            //Assert
            Assert.AreEqual(expectedParameters, actualParameters);
        }

        [TestCase(TestName = "Сохранение параметров, позитив")]
        public void FileManager_SaveTest_Positive()
        {
            //Setup
            var savingParameters = new CouplingParameters();

            DirectoryInfo directoryInfo = new DirectoryInfo(@"Output");

            if (directoryInfo.Exists)
            {
                Directory.Delete(@"Output", true);
            }

            //Act
            SettingManager.SaveFile(savingParameters, @"Output");

            //Assert
            var actual = File.ReadAllText(@"Output\CouplingParameters.json");
            var expected = File.ReadAllText(@"TestData\CorrectCouplingParameters.json");

            Assert.AreEqual(expected, actual);
        }
    }
}
