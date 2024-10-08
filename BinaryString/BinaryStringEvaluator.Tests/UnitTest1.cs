using NUnit.Framework;  


namespace BinaryStringEvaluator.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_EmptyString_ShouldReturnFalse()
        {
            Assert.False(Program.IsGoodBinaryString(""));
        }

        [Test]
        public void Test_SingleZero_ShouldReturnFalse()
        {
            Assert.False(Program.IsGoodBinaryString("0"));
        }

        [Test]
        public void Test_SingleOne_ShouldReturnFalse()
        {
            Assert.False(Program.IsGoodBinaryString("1"));
        }

        [Test]
        public void Test_BalancedButInvalidPrefix_ShouldReturnFalse()
        {
            Assert.False(Program.IsGoodBinaryString("0011"));
        }

        [Test]
        public void Test_PerfectlyBalanced_ShouldReturnTrue()
        {
            Assert.True(Program.IsGoodBinaryString("101010"));
        }

        [Test]
        public void Test_ImbalancedLongerString_ShouldReturnFalse()
        {
            Assert.False(Program.IsGoodBinaryString("1110000011"));
        }

        [Test]
        public void Test_LargeValidString_ShouldReturnTrue()
        {
            Assert.True(Program.IsGoodBinaryString("1100110011001100"));
        }

        [Test]
        public void Test_VeryLongInvalidString_ShouldReturnFalse()
        {
            Assert.False(Program.IsGoodBinaryString("1110001110001110000000"));
        }

        [Test]
        public void Test_ValidString_ShouldReturnTrue()
        {
            Assert.True(Program.IsGoodBinaryString("1100"));
        }

        [Test]
        public void Test_ValidStringWithBalancedOnesAndZeros_ShouldReturnTrue()
        {
            Assert.True(Program.IsGoodBinaryString("111000111000"));
        }
    }
}