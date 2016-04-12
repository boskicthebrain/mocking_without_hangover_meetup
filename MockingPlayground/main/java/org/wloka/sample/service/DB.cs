using MockingPlayground.main.java.org.wloka.sample.service;
using store;

namespace db
{
    public class DB
    {
        private static DB singleton = null;
        private IPropertiesStore data;

        // In the productive code this could probably be downgraded to internal to protect the API
        public static DB init(IPropertiesStore propertiesStore)
        {
            if (singleton == null)
            {
                singleton = new DB();
            }
            
            // this ensures the sandbox between tests/different contexts in which the DB object is used.
            singleton.data = propertiesStore;
            return singleton;
        }

        // this is for the productive use.
        public static DB Instance {
            get { 
                if (singleton == null)
                {
                    throw new NotInitializedException();
                }

                return singleton;
            }
        }

        private DB() { }

        public Item get(string path)
        {
            try
            {
                return new Item(path).setProperties(data.load(path));
            }
            catch (InvalidDataException)
            {
                return null;
            }
            catch (DataAccessException)
            { 
                return null; 
            }
        }

        public DB store(Item item)
        {
            if (item != null)
            {
                try
                {
                    data.save(item.Path, item.Properties);
                }
                catch (DataAccessException)
                {
                    // falls through
                    // This is probably something we don't really want, but I am leaving it for testing purposes.
                }
            }
            return this;
        }

        public DB delete(string path)
        {
            if (path != null)
            {
                try
                {
                    data.remove(path);
                }
                catch (DataAccessException)
                {
                    // falls through
                    // This is probably something we don't really want, but I am leaving it for testing purposes.
                }
            }
            return this;
        }

        public bool exists(Item item)
        {
            try
            {
                return data.load(item.Path) != null;
            }
            catch (DataAccessException)
            {
                return false;
            }
        }
    }
}