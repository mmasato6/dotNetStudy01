using System;
using System.Collections.Generic;
using BmiSample.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BmiSample.DomainTest
{
    [TestClass]
    public class BmiCalculatorTest
    {
        [TestMethod]
        public void CalculatTest()
        {
            // Arrange
            var testData = new List<(int heightCm, int weightKg, double expectedResult)>();
            testData.Add((100, 1, 1.0));
            testData.Add((150, 45, 20.0));
            testData.Add((200,100,25.0));
            var target = new BmiCalculator();

            foreach (var pattern in testData)
            {
                // Act
                double actual = target.Calculate(pattern.heightCm, pattern.weightKg);
                // Assert
                Assert.AreEqual(pattern.expectedResult, actual,$"height:{pattern.heightCm},weight:{pattern.weightKg},expected:{pattern.expectedResult},actual:{actual}");
            }
        }

        [TestMethod]
        public void CalculateExceptionTest()
        {
            var target = new BmiCalculator();
            // 身長
            // 0はダメ
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => target.Calculate(0, 1), "height 0");
            // マイナスもダメ
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => target.Calculate(-1, 1), "height -1");
            // 1～はOK
            var h1 = target.Calculate(1, 1);
            var h2 = target.Calculate(160, 1);
            var h3 = target.Calculate(999, 1);
            //体重
            //0はダメ
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => target.Calculate(1, 0), "weight 0");
            // マイナスもダメ
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => target.Calculate(1, -1), "weight -1");
            // 1～はOK
            var w1 = target.Calculate(1, 1);
            var w2 = target.Calculate(1, 50);
            var w3 = target.Calculate(1, 100);

        }

    }
}
