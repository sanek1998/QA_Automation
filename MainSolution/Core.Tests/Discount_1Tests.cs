using Core.Discounts;
using NUnit.Framework;

namespace Core.Tests
{
    [TestFixture]
    public class Discount_1Tests
    {
        #region Tests
        [Test]

        public void PercentageValue_1PercentOf100_Return99()
        {
            //Arrange
            decimal a = 100;
            var discount = new Discount_1();
            //Act
            var result = discount.PercentageValue(a);
            //Assert
            Assert.AreEqual(99, result);
        }

        #endregion
    }
}