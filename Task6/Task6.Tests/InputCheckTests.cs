using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task6.Tests
{
    [TestClass]
    public class InputCheckTests
    {
        [TestMethod]
        public void IsNumberTest()
        {
            InputCheck check = new InputCheck();

            string input = "1231";

            string input2 = "ASkkj";

            bool result = check.IsNumber(input);

            bool result2 = check.IsNumber(input2);

            Assert.IsTrue(result);

            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void AgeAcceptTest()
        {
            InputCheck check = new InputCheck();

            int age = 12;
            int age2 = 20;

            bool result = check.AgeAccept(age);
            bool result2 = check.AgeAccept(age2);

            Assert.IsFalse(result);
            Assert.IsTrue(result2);
        }
    }
}
