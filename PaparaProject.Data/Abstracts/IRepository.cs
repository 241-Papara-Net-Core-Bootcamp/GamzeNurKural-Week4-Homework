using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaparaProject.Data.Abstracts
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        int Update(T entity, int id);
        int Delete(int id);
        int HardDelete(int id);
    }
}
