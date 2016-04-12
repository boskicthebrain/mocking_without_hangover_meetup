using data;
using db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockingPlayground.main.java.org.wloka.sample.service;
using Moq;
using store;

namespace tests
{
    [TestClass]
    public class DbTest
    {
        [TestMethod]
        public void storeWithValidPathSavesItemInDatabase()
        {
            string target = "/path";
            Item item = new Item(target);
            var storeMock = new Mock<IPropertiesStore>();
            var db = DB.init(storeMock.Object);

            db.store(item);

            storeMock.Verify(s => s.save(It.IsAny<string>(), It.IsAny<Properties>()), Times.Once());
        }

        [TestMethod]
        public void storeWithNullItemDoesNotSaveItemInDatabase()
        {
            var storeMock = new Mock<IPropertiesStore>();
            var db = DB.init(storeMock.Object);

            db.store(null);

            storeMock.Verify(s => s.save(It.IsAny<string>(), It.IsAny<Properties>()), Times.Never());
        }

        [TestMethod]
        public void getWithValidPathLoadsItemFromDatabase()
        {
            string target = "/path/to/item";
            var storeMock = new Mock<IPropertiesStore>();
            var db = DB.init(storeMock.Object);
            storeMock.Setup(s => s.load(It.IsAny<string>()));

            db.get(target);

            storeMock.Verify(s => s.load(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        public void storeWherePropertyStoreThrowsAnExpetionOnSave()
        {
            var storeMock = new Mock<IPropertiesStore>();
            storeMock.Setup(s => s.save(It.IsAny<string>(), It.IsAny<Properties>())).Throws<DataAccessException>();
            var db = DB.init(storeMock.Object);

            db.store(new Item("path"));

            storeMock.Verify(s => s.save(It.IsAny<string>(), It.IsAny<Properties>()), Times.Once(), "No exceptions thrown. The DB takes care of it.");
        }

        [TestMethod]
        public void deleteWherePropertyStoreThrowsAnExpetionOnDelete()
        {
            var storeMock = new Mock<IPropertiesStore>();
            storeMock.Setup(s => s.remove(It.IsAny<string>())).Throws<DataAccessException>();
            var db = DB.init(storeMock.Object);

            db.delete("path");

            storeMock.Verify(s => s.remove(It.IsAny<string>()), Times.Once(), "No exceptions thrown. The DB takes care of it.");
        }
    }
}