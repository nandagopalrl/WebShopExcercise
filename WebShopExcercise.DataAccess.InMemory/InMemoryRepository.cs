using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using WebShopExcercise.Core.Models;
using WebShopExcercise.Core.Contracts;

namespace WebShopExcercise.DataAccess.InMemory
{
    public class InMemoryRepository<T> : Core.Contracts.IRepository<T> where T : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        public InMemoryRepository()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;
            if(items == null)
            {
                items = new List<T>();
            }
        }

        public void Commit()
        {
            cache[className] = items;
        }

        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Update(T t)
        {
            T update = items.Find(p => p.Id == t.Id);

            if (update != null)
            {
                update = t;
            }
            else
            {
                throw new Exception("Item not found");
            }
        }

        public T Find(string id)
        {
            T searched = items.Find(p => p.Id == id);

            if (searched != null)
            {
                return searched;
            }
            else
            {
                throw new Exception("Item not found");
            }
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(T item)
        {
            T delete = items.Find(p => p.Id == item.Id);

            if (delete != null)
            {
                items.Remove(delete);
            }
            else
            {
                throw new Exception("Item not found");
            }
        }
    }
}
