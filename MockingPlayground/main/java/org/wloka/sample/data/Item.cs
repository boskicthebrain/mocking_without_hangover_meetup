using data;

public class Item
{
    private readonly string path;
    public string Path { get { return path; } }
    private Properties properties;
    public Properties Properties
    {
        get { return properties; }
        set
        {
            if (value == null)
            {
                throw new InvalidDataException();
            }
            properties = value;
        }
    }

    public Item(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new InvalidDataException();
        }
        this.path = path;
    }

    public Item setProperties(Properties props)
    {
        if (props == null)
        {
            throw new InvalidDataException();
        }
        this.properties = props;
        return this;
    }
}
