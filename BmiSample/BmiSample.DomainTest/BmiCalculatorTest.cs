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
            var target = new BmiCalculator
            // 0‚ÍŽó‚¯•t‚¯‚È‚¢

        }

    }
}
