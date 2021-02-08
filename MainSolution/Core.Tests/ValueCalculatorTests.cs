using System.Collections.Generic;
using NUnit.Framework;

namespace Core.Tests
{
    [TestFixture]
    public class ValueCalculatorTests
    {

        #region Private Fields

        private ICalculate Calculate;
        private IEnumerable<Product> Products;

        #endregion

        #region Initialization

        [SetUp]
        public void SetUp()
        {
            Products = new List<Product>
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
        public void ValueCalc_UseInitializeProductWithPrice70and30_100returned()
        {
            //Arrange
            Calculate=new ValueCalculator();
            //Act
            var result = Calculate.ValueCalc(Products);
            //Assert

            Assert.AreEqual(100,result);
        }

       #endregion
    }
}