using data;

namespace store
{
    public interface IPropertiesStore
    {
        Properties load(string path);
        IPropertiesStore save(string path, Properties properties);
        IPropertiesStore remove(string path);
    }
}
