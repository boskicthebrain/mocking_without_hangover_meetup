using data;
using MockingPlayground.main.java.org.wloka.sample.service;
using store;
using System.Collections.Generic;

namespace db
{
    public class InMemoryPropertiesStore : IPropertiesStore
    {
        private readonly Dictionary<string, Properties> data;

        public InMemoryPropertiesStore()
        {
            this.data = new Dictionary<string, Properties>();
        }

        public Properties load(string path)
        {
            if (data.ContainsKey(path))
            {
                return data[path];
            }
            throw new DataAccessException();
        }

        public IPropertiesStore save(string path, Properties properties)
        {
            if (data.ContainsKey(path))
            {
                throw new DataAccessException();
            }
            data.Add(path, properties);
            return this;
        }

        public IPropertiesStore remove(string path)
        {
            data.Remove(path);
            return this;
        }
    }
}