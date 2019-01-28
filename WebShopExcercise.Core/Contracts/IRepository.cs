using System.Linq;
using WebShopExcercise.Core.Models;

namespace WebShopExcercise.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(T item);
        T Find(string id);
        void Insert(T t);
        void Update(T t);
    }
}