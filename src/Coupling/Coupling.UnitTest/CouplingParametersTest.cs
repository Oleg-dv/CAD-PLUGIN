using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Coupling.UnitTest
{
    public class CouplingParametersTest
    {
        //Центральное отверстие
        [TestCase(TestName = "Проверка геттера и сеттера у диаметра центрального отверстия")]
        public void TestSetCentralHoleDiameter_CorrectValue_ResultCorrectSet()
        {
            //Arrange
            var expectedValue = 10;
            var parameter = new CouplingParameters();

            //Act
            parameter.CentralHoleDiameter = expectedValue;

            //Assert
            Assert.AreEqual(expectedValue, parameter.CentralHoleDiameter);
        }

        [TestCase(TestName = "Проверка на введение значения меньше" +
            " минимально возможного диаметра центрального отверстия")]
        public void TestSetCentralHoleDiameter_IncorrectValueLess10_ArgumentException()
        {
            //Arrange
            var expectedValue = 5;
            var parameter = new CouplingParameters();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.CentralHoleDiameter = expectedValue;
            });
        }

        [TestCase(TestName = "Проверка на введение значения" +
            " диаметра центрального отверстия больше максимального")]
        public void TestSetCentralHoleDiameter_IncorrectValueMore30_ArgumentException()
        {
            //Arrange
            var expectedValue = 35;
            var parameter = new CouplingParameters();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.CentralHoleDiameter = expectedValue;
            });
        }

        // Количество отверстий
        [TestCase(TestName = "Проверка геттера и сеттера у количества отверстий")]
        public void TestSetCountOfSmallHoles_CorrectValue_ResultCorrectSet()
        {
            //Arrange
            var expectedValue = 4;
            var parameter = new CouplingParameters();

            //Act
            parameter.CountOfSmallHoles = expectedValue;

            //Assert
            Assert.AreEqual(expectedValue, parameter.CountOfSmallHoles);
        }

        [TestCase(TestName = "Проверка на введение значения" +
            " количества отверстий меньше минимального")]
        public void TestSetCountOfSmallHoles_IncorrectValueLess3_ArgumentException()
        {
            //Arrange
            var expectedValue = 0;
            var parameter = new CouplingParameters();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.CountOfSmallHoles = expectedValue;
            });
        }

        [TestCase(TestName = "Проверка на введение значения количества" +
            " отверстий больше максимального")]
        public void TestSetCountOfSmallHoles_IncorrectValueMore8_ArgumentException()
        {
            //Arrange
            var expectedValue = 10;
            var parameter = new CouplingParameters();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.CountOfSmallHoles = expectedValue;
            });
        }

        // Диаметр детали
        [TestCase(TestName = "Проверка геттера и сеттера у главного диаметра")]
        public void TestSetCouplingDiameter_CorrectValue_ResultCorrectSet()
        {
            //Arrange
            var expectedValue = 50;
            var parameter = new CouplingParameters();

            //Act
            parameter.CouplingDiameter = expectedValue;

            //Assert
            Assert.AreEqual(expectedValue, parameter.CouplingDiameter);
        }

        [TestCase(TestName = "Проверка на введение значения диаметра кольца" +
    " меньше минимального")]
        public void TestSetCouplingDiameter_IncorrectValueLess40_ArgumentException()
        {
            //Arrange
            var expectedValue = 0;
            var parameter = new CouplingParameters();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.CouplingDiameter = expectedValue;
            });
        }

        [TestCase(TestName = "Проверка на введение значения диаметра кольца" +
            " больше максимального")]
        public void TestSetCouplingDiameter_IncorrectValueMore70_ArgumentException()
        {
            //Arrange
            var expectedValue = 80;
            var parameter = new CouplingParameters();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.CouplingDiameter = expectedValue;
            });
        }

        // Ширина кольца
        [TestCase(TestName = "Проверка геттера и сеттера у главного диаметра")]
        public void TestSetCouplingWidth_CorrectValue_ResultCorrectSet()
        {
            //Arrange
            var expectedValue = 30;
            var parameter = new CouplingParameters();

            //Act
            parameter.CouplingWidth = expectedValue;

            //Assert
            Assert.AreEqual(expectedValue, parameter.CouplingWidth);
        }

        [TestCase(TestName = "Проверка на введение значения толщины меньше минимального")]
        public void TestSetCouplingWidth_IncorrectValueLess10_ArgumentException()
        {
            //Arrange
            var expectedValue = 0;
            var parameter = new CouplingParameters();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.CouplingWidth = expectedValue;
            });
        }

        [TestCase(TestName = "Проверка на введение значения толщины больше максимального")]
        public void TestSetCouplingWidth_IncorrectValueMore50_ArgumentException()
        {
            //Arrange
            var expectedValue = 80;
            var parameter = new CouplingParameters();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.CouplingWidth = expectedValue;
            });
        }

        //Диаметр малых отверстий 
        [TestCase(TestName = "Проверка геттера и сеттера у диаметра малых отвертий")]
        public void TestSetSmallHolesDiameter_CorrectValue_ResultCorrectSet()
        {
            //Arrange
            var expectedValue = 10;
            var parameter = new CouplingParameters();

            //Act
            parameter.SmallHolesDiameter = expectedValue;

            //Assert
            Assert.AreEqual(expectedValue, parameter.SmallHolesDiameter);
        }

        [TestCase(TestName = "Проверка на введение значения" +
            " диаметра малых отверстий меньше минимального")]
        public void TestSetSmallHolesDiameter_IncorrectValueLess6_ArgumentException()
        {
            //Arrange
            var expectedValue = 0;
            var parameter = new CouplingParameters();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.SmallHolesDiameter = expectedValue;
            });
        }

        [TestCase(TestName = "Проверка на введение значения" +
            " диаметра малых отверстий больше максимального")]
        public void TestSetSmallHolesDiameter_IncorrectValueMore24_ArgumentException()
        {
            //Arrange
            var expectedValue = 80;
            var parameter = new CouplingParameters();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.SmallHolesDiameter = expectedValue;
            });
        }

        //Окружность по которой располагаются малые отверстия
        [TestCase(TestName = "Проверка геттера и сеттера у SmallHoleCircleDiameter")]
        public void TestSetSmallHoleCircleDiameter_CorrectValue_ResultCorrectSet()
        {
            //Arrange
            var expectedValue = 10;
            var parameter = new CouplingParameters();

            //Act
            parameter.SmallHoleCircleDiameter = expectedValue;

            //Assert
            Assert.AreEqual(expectedValue, parameter.SmallHoleCircleDiameter);
        }

        [TestCase(TestName = "Проверка на введение значения" +
            " SmallHoleCircleDiameter меньше 0")]
        public void TestSetSmallHoleCircleDiameter_IncorrectValueLess0_ArgumentException()
        {
            //Arrange
            var expectedValue = -10;
            var parameter = new CouplingParameters();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.SmallHoleCircleDiameter = expectedValue;
            });
        }

        //Максимальный диаметр центрального отверстия
        [TestCase(TestName = "Проверка геттера и сеттера у MaxCenterHoleDiameter")]
        public void TestSetMaxCenterHoleDiameter_CorrectValue_ResultCorrectSet()
        {
            //Arrange
            var expectedValue = 10;
            var parameter = new CouplingParameters();

            //Act
            parameter.MaxCenterHoleDiameter = expectedValue;

            //Assert
            Assert.AreEqual(expectedValue, parameter.MaxCenterHoleDiameter);
        }

        [TestCase(TestName = "Проверка на введение значения" +
            " MaxCenterHoleDiameter меньше 0")]
        public void TestSetMaxCenterHoleDiameter_IncorrectValueLess0_ArgumentException()
        {
            //Arrange
            var expectedValue = -10;
            var parameter = new CouplingParameters();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.MaxCenterHoleDiameter = expectedValue;
            });
        }

        //Максимальный диаметр малых отверстий
        [TestCase(TestName = "Проверка геттера и сеттера у MaxSmallHoleDiameter")]
        public void TestSetMaxSmallHoleDiameter_CorrectValue_ResultCorrectSet()
        {
            //Arrange
            var expectedValue = 10;
            var parameter = new CouplingParameters();

            //Act
            parameter.MaxSmallHoleDiameter = expectedValue;

            //Assert
            Assert.AreEqual(expectedValue, parameter.MaxSmallHoleDiameter);
        }

        [TestCase(TestName = "Проверка на введение значения" +
            " MaxSmallHoleDiameter меньше 0")]
        public void TestSetMaxSmallHoleDiameter_IncorrectValueLess0_ArgumentException()
        {
            //Arrange
            var expectedValue = -10;
            var parameter = new CouplingParameters();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                parameter.MaxSmallHoleDiameter = expectedValue;
            });
        }
    }
}