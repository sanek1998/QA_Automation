using Core.Discounts;
using NUnit.Framework;

namespace Core.Tests
{
    [TestFixture]
    public class Discount_5Tests
    {

        #region Tests
        [Test]

        public void PercentageValue_5PercentOf100_Return95()
        {
            //Arrange
            decimal a = 100;
            var discount = new Discount_5();
            //Act
            var result = discount.PercentageValue(a);
            //Assert
            Assert.AreEqual(95, result);
        }

        #endregion
    }
}