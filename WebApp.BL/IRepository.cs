using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.BL
{
   public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);
        T  Add(T entity);
        T Update(T entity);
        T Delete(int id);
    }
}
