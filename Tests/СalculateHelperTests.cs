using System;
using AutoFixture;
using Calculator;
using Calculator.Enumerators;
using Calculator.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests
{
    [TestClass]
    public class СalculateHelperTests
    {
        private Fixture _fixture = new Fixture();


        [TestMethod]
        public void Calculate_AddOperation_ShouldReturnProperResult()
        {
            //arrange
            var сalculateHelper = new СalculateHelper();

            var leftValue = _fixture.Create<double>();
            var rightValue = _fixture.Create<double>();

            var leftOperator = new Mock<IOperator>();
            leftOperator.SetupGet(x => x.Result).Returns(leftValue);

            var rightOperator = new Mock<IOperator>();
            rightOperator.SetupGet(x => x.Result).Returns(rightValue);

            var mainOperator = new Mock<IOperator>();
            mainOperator.SetupGet(x => x.LeftOperand).Returns(leftOperator.Object);
            mainOperator.SetupGet(x => x.RightOperand).Returns(rightOperator.Object);
            mainOperator.SetupGet(x => x.Operation).Returns(Operation.Add);

            //act
            var actual = сalculateHelper.Calculate(mainOperator.Object);

            //assert
            Assert.AreEqual(leftValue + rightValue, actual);
        }
    }
}
