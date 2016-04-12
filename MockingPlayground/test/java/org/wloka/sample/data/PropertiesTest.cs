using data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class PropertiesTest
    {
        [TestMethod]
        public void hasPropertyWithExistinKeyReturnsTrue()
        {
            Properties testObj = new Properties().setValue("foo", new object());

            Assert.IsTrue(testObj.hasProperty("foo"));
        }

        [TestMethod]
        public void setValueWithValidKeyButNullValueDoesNotYieldProperty()
        {
            Properties testObj = new Properties().setValue("foo", null);

            Assert.IsFalse(testObj.hasProperty("foo"));
        }

        [TestMethod]
        public void getValueWithExistingKeyReturnsPropertyValue()
        {
            object expected = new object();
            Properties testObj = new Properties().setValue("foo", expected);

            object actual = testObj.getValue("foo");

            Assert.AreSame(expected, actual);
        }

        [TestMethod]
        public void getValueWithNonExistingKeyThrowsException()
        {
            try
            {
                new Properties().getValue("non-existing");
            }
            catch (InvalidDataException)
            {
                return;
            }

            Assert.Fail();
        }
    }
}