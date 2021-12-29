using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace KompasWrapper.UnitTest
{
    public class CouplingParametersTest
    {
        //TODO:
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

        [TestCase (5,TestName = "Проверка на введение значения меньше" +
            " минимально возможного диаметра центрального отверстия")]
        [TestCase(35, TestName = "Проверка на введение значения" +
                                 " диаметра центрального отверстия больше максимального")]
        public void TestSetCentralHoleDiameter_IncorrectValue_ArgumentException(double expectedValue)
        {
            //Arrange
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

        [TestCase(0, TestName = "Проверка на введение значения" +
            " количества отверстий меньше минимального")]
        [TestCase(10, TestName = "Проверка на введение значения количества" +
                             " отверстий больше максимального")]
        public void TestSetCountOfSmallHoles_IncorrectValue_ArgumentException(int expectedValue)
        {
            //Arrange
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

        [TestCase(0, TestName = "Проверка на введение значения диаметра кольца" + 
                                " меньше минимального")]
        [TestCase(80, TestName = "Проверка на введение значения диаметра кольца" +
                             " больше максимального")]
        public void TestSetCouplingDiameter_IncorrectValue_ArgumentException(double expectedValue)
        {
            //Arrange
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

        [TestCase(0, TestName = "Проверка на введение значения толщины меньше минимального")]
        [TestCase(80, TestName = "Проверка на введение значения толщины больше максимального")]
        public void TestSetCouplingWidth_IncorrectValue_ArgumentException(double expectedValue)
        {
            //Arrange
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
            var expectedValue = 2;
            var parameter = new CouplingParameters();

            //Act
            parameter.SmallHolesDiameter = expectedValue;

            //Assert
            Assert.AreEqual(expectedValue, parameter.SmallHolesDiameter);
        }

        [TestCase(0, TestName = "Проверка на введение значения" +
            " диаметра малых отверстий меньше минимального")]
        [TestCase(80, TestName = "Проверка на введение значения" +
                             " диаметра малых отверстий больше максимального")]
        public void TestSetSmallHolesDiameter_IncorrectValue_ArgumentException(double expectedValue)
        {
            //Arrange
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

        [TestCase(TestName = "Проверка на введение значения " +
                             "CouplingDiameter ")]
        public void TestSetCouplingDiameter_CorrectValue()
        {
            //Arrange
            var expectedValue = 45;
            var centralHoleDiameter = 15;
            var parameter = new CouplingParameters();

            //Act
            parameter.CouplingDiameter = expectedValue;
            parameter.CentralHoleDiameter = centralHoleDiameter;

            //Assert
            Assert.AreEqual(parameter.MaxSmallHoleDiameter, (
                parameter.CouplingDiameter - parameter.CentralHoleDiameter - 25));
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

        [TestCase(TestName = "Проверка условия else функции" +
                             " MatchMaxSmallHoleDiameter")]
        public void TestElseMatchMaxSmallDiameter_CorrectValue_ReturnValue()
        {
            //Arrange
            var expectedValue = 14.3;
            var couplingDiameter = 70;
            var countOfSmallHoles = 8;
            var parameter = new CouplingParameters();

            //Act
            parameter.CouplingDiameter = couplingDiameter;
            parameter.CountOfSmallHoles = countOfSmallHoles;

            //Assert
            Assert.AreEqual(expectedValue, parameter.MaxSmallHoleDiameter);
        }
    }
}