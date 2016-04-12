using data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        public void ctorWithValidStringYieldsItemWithPath()
        {
            Item testObj = new Item("expected");

            Assert.AreEqual("expected", testObj.Path);
        }

        [TestMethod]
        public void ctorWithInvalidStringThrowsException()
        {
            try
            {
                new Item("");
            }
            catch (InvalidDataException)
            {
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void setPropertiesWithValidPropertiesYieldsNewProperties()
        {
            Properties expected = new Properties();

            Item testObj = new Item("/path");
            testObj.Properties = expected;

            Assert.AreSame(expected, testObj.Properties);
        }

        [TestMethod]
        public void setPropertiesWithInvalidPropertiesThrowsException()
        {
            try
            {
                new Item("/path").Properties = null;
            }
            catch (InvalidDataException)
            {
                return;
            }

            Assert.Fail();
        }
    }
}