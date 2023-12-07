using UniversityManager.Entities;

namespace UniversityManager.Utilities
{
    public class GenericRepository<T> where T : BaseEntity
    {
        public Serialization<T> _serialization;

        string _filePath;

        List<T> _items;

        public GenericRepository(string filePath)
        {
            _filePath = filePath;
            _serialization = new Serialization<T>();
            _items = _serialization.DeserializeFromJsonFile(filePath);
        }

        public T Create(T entity)
        {
            try
            {
                _items.Add(entity);
                SaveChanges();
                return entity;
            }
            catch
            {
                throw new Exception("could not add");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var targetItem = GetByID(id);

                SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("could not  deleted");
            }
        }

        public List<T> GetAll()
        {
            return _items;
        }

        public void SaveChanges()
        {
            _serialization.SerializeToJsonFile(_filePath, _items);
        }

        public T Update(T entity)
        {
            try
            {
                var newItem = _items.FirstOrDefault(p => p.Id == entity.Id);
                newItem.Id = "0";
                SaveChanges();

                return newItem;
            }
            catch
            {

                throw new Exception("item not found");
            }

        }

        public T GetByID(string id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }
    }
}
