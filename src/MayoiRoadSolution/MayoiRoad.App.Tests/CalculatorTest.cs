using System.Numerics;
using Xunit;

namespace MayoiRoad.App.Tests
{
    public class CalculatorTest
    {
        public static object[][] Source = new object[][]
        {
            new object []{ 0, (BigInteger)0 },
            new object []{ 1, (BigInteger)2 },
            new object []{ 2, (BigInteger)2 },
            new object []{ 3, (BigInteger)7 },
            new object []{ 4, (BigInteger)7 },
            new object []{ 5, (BigInteger)20 },
            new object []{ 10, (BigInteger)143 },
            new object []{ 50, (BigInteger)32951280098 },
        };

        [Theory]
        [MemberData(nameof(Source))]
        public void Value(int n, BigInteger result)
        {
            var calculator = new Calculator();
            Assert.Equal(result, calculator.Execute(n));
        }
    }
}
