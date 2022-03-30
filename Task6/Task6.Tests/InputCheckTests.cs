using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task6.Tests
{
    [TestClass]
    public class InputCheckTests
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void IsNull(string value)
        {
            InputCheck check = new InputCheck();

            var results = check.IsNull(value);

            Assert.IsTrue(results);
        }

        [TestMethod]
        [DataRow("20")]
        public void AgeAcceptTest(string value)
        {
            InputCheck check = new InputCheck();

            var results = check.AgeAccept(value);

            Assert.IsTrue(results);
        }

        [TestMethod]
        [DataRow("100")]
        [DataRow("0")]
        [DataRow("-1")]
        [DataRow(null)]
        [DataRow("2")]
        [DataRow("one")]
        [DataRow("2 5")]
        public void NotAgeAcceptTest(string value)
        {
            InputCheck check = new InputCheck();

            var results = check.AgeAccept(value);

            Assert.IsFalse(results);
        }
    }
}
