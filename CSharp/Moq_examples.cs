using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntiMailApp;
using NUnit.Framework;
using Moq;
using NUnit.Framework.Internal;

namespace AntiMailAppTests
{


    [TestFixture]
    public class Class1Test
    {
        private Mock<ISimpleClass> moq;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            // https://github.com/Moq/moq4/wiki/Quickstart
            moq = new Mock<ISimpleClass>();

            moq.Setup(foo => foo.StringIsEmpty("hehe")).Returns(true);
            moq.Setup(foo => foo.StringIsEmpty(It.IsAny<string>())).Returns(true);

            // throwing when invoked with specific parameters
            moq.Setup(foo => foo.StringIsEmpty("reset")).Throws<InvalidOperationException>();
            moq.Setup(foo => foo.StringIsEmpty("")).Throws(new ArgumentException("command"));
        }

        [Test]
        public void TransferFunds()
        {

            Assert.Pass("Hello");
            Assert.Pass("Hello");
            //Assert.AreEqual(250m, destination.Balance);
            //Assert.AreEqual(100m, source.Balance);
        }

        [Test]
        public void MoqStringIsEmptyTest()
        {
            // Arrange

            // Act
            ISimpleClass targer = moq.Object;
            targer.StringIsEmpty("hehe");
  
            // Assert.
            moq.Verify(foo => foo.StringIsEmpty("hehe"), Times.Once);
        }

        [Test]
        public void MoqStringInvalidOperationExceptionOnReset()
        {
            // test InvalidOperationException() n "reset".

            // Arrange

            // Act
            ISimpleClass targer = moq.Object;

            Assert.Throws<InvalidOperationException>(() => targer.StringIsEmpty("reset"));

            // Assert.
            moq.Verify(foo => foo.StringIsEmpty("reset"), Times.Once);
        }

        [Test]
        public void MoqStringCommandException()
        {
            // test ArgumentException("command")

            // Arrange

            // Act
            ISimpleClass targer = moq.Object;

            Assert.Throws<ArgumentException>(() => targer.StringIsEmpty(String.Empty), "command");

            // Assert.
            moq.Verify(foo => foo.StringIsEmpty(String.Empty), Times.Once);
        }
    }
}

