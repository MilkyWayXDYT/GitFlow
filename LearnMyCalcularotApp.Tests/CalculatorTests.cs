﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearnMyCalculatorApp;
using FluentAssertions;
using Moq;

namespace LearnMyCalcularotApp.Tests
{
    [TestClass]
    public sealed class CalculatorTests
    {
        public interface ICalculator
        {
            int Add(int x, int y);
            int Subtract(int x, int y);
            int Multiply(int x, int y);
            int? Divide(int x, int y);

        }

        [TestMethod]
        public void DivideByZeroWithMoq()
        {
            var mock = new Mock<ICalculator>();
            mock.Setup(foo => foo.Divide(1, 0)).Returns(1);

            ICalculator calculator = mock.Object;

            var actual = calculator.Divide(1, 0);

            Assert.AreEqual(1, actual);
        }

        [DataTestMethod]
        [DataRow(1, 1, 1)]
        [DataRow(2, 1, 2)]
        [DataRow(9, 3, 3)]
        //[DataRow(0, 0, 1)] // The test run with this row fails
        public void DivideByZeroWithMoqData(int x, int y, int expected)
        {
            var mock = new Mock<ICalculator>();
            mock.Setup(foo => foo.Divide(x, y)).Returns(expected);

            ICalculator calculator = mock.Object;

            var actual = calculator.Divide(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatorNullTest()
        {
            var calculator = new Calculator();
            Assert.IsNotNull(calculator);

            Assert.IsTrue(false);
        }

        [TestMethod]
        public void AddTest()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Add(1, 1);

            // Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void SubtractTest()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Subtract(1, 1);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Multiply(1, 1);

            // Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void DivideTest()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Divide(1, 1);

            // Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void DivideByZeroTest()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Divide(1, 0);

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void AddTestFluentassertion()
        {
            var calculator = new Calculator();
            var actual = calculator.Add(1, 1);

            // Non-fluent asserts:
            // Assert.AreEqual(actual, 2);
            // Assert.AreNotEqual(actual, 1);

            // Same asserts as what is commented out above, but using Fluent Assertions
            actual.Should().Be(2).And.NotBe(1);
        }

        [DataTestMethod]
        [DataRow(1, 1, 2)]
        [DataRow(2, 2, 4)]
        [DataRow(3, 3, 6)]
        [DataRow(0, 0, 1)] // The test run with this row fails
        public void AddDataTests(int x, int y, int expected)
        {
            var calculator = new Calculator();
            var actual = calculator.Add(x, y);
            Assert.AreEqual(expected, actual);
        }
    }
}
