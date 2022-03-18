using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task6.Tests
{
    [TestClass]
    public class Form1Tests
    {
        [TestMethod]
        public void GetHashTest()
        {
            //Arrange
            Form1 form = new Form1();

            //Act
            string name = "Eugene";

            int age = 20;

            string car = "Toyota";

            int id = 1;

            string input = string.Concat(id.ToString(), name, age.ToString(), car);

            string expected = "W70536Kd004Fx2z7z6nt5g==";

            string result = form.GetHash(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetHashNotNullTest()
        {
            Form1 form = new Form1();

            string input = "sf";

            string result = form.GetHash(input);

            Assert.IsNotNull(result);
        }


    }
}
