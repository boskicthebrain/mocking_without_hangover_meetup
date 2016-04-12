using System.Collections.Generic;

namespace data
{
    public class Properties
    {
        private readonly Dictionary<object, object> data;

        public Properties()
            : this(new Dictionary<object, object>())
        {
        }

        public Properties(Dictionary<object, object> data)
        {
            this.data = data;
        }

        public bool hasProperty(object key)
        {
            return data.ContainsKey(key);
        }

        public Properties setValue(object key, object value)
        {
            if (key != null && value != null)
            {
                data.Add(key, value);
            }
            return this;
        }

        public object getValue(object key)
        {
            if (hasProperty(key))
            {
                return data[key];
            }
            throw new InvalidDataException();
        }
    }
}