using System.Collections.Generic;
using Core.Discounts;
using NUnit.Framework;

namespace Core.Tests
{
    [TestFixture]
    public class ShoppingCartTests
    {
        #region Private Fields

        private ICalculate _valueCalculate;
        private IPercentage _valuePercentage1;
        private IPercentage _valuePercentage5;
        private IEnumerable<Product> _products;


        private ICart _cart;

        #endregion

        #region Initialization

        [SetUp]
        public void SetUp()
        {
            _valueCalculate = new ValueCalculator();
            _valuePercentage1 = new Discount_1();
            _valuePercentage5 = new Discount_5();

            _products = new List<Product>
            {
                new Product
                {
                    Name = "Product1",
                    Price = 70,
                    ProductID = 1
                },
                new Product
                {
                    Name = "Product2",
                    Price = 30,
                    ProductID = 2
                }
            };
        }

        #endregion

        #region Tests

        [Test]
        public void CalculateTotal_BySum100UseDiscount1_Return99()
        {
            //Arrange
            _cart = new ShoppingCart(_valuePercentage1, _valueCalculate) { Products = _products };

            //Act
            var result = _cart.CalculateTotal();

            //Assert
            Assert.AreEqual(99, result);
        }

        [Test]
        public void CalculateTotal_BySum100UseDiscount5_Return95()
        {
            //Arrange
            _cart = new ShoppingCart(_valuePercentage5, _valueCalculate) { Products = _products };

            //Act
            var result = _cart.CalculateTotal();

            //Assert
            Assert.AreEqual(95, result);
        }

        #endregion
    }
}