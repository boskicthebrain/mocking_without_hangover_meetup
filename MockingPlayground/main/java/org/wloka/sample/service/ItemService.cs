using db;

namespace domain
{
    public class ItemService
    {
        private readonly DB storage;

        /**
         * Hint: Don't initialize DB in a ctor. Ever.
         */
        public ItemService(DB db)
        {
            this.storage = db;
        }

        public Item createItem(Item item)
        {
            if (storage.exists(item))
            {
                throw new ItemResolverException();
            }
            storage.store(item);
            return item;
        }

        public Item getItem(string path)
        {
            Item result = storage.get(path);
            if (result == null)
            {
                throw new ItemResolverException();
            }
            return result;
        }

        public Item updateItem(Item item)
        {
            storage.store(item);
            return item;
        }
    }
}