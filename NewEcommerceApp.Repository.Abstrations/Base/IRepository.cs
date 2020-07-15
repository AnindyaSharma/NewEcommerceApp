using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NewEcommerceApp.Repository.Abstrations.Base
{
    public interface IRepository<T> where T:class
    {
        bool Add(T entity);
        bool Update(T entity);

        bool Remove(T entity);

        ICollection<T> GetAll();

        T GetFirstOrDefault(Expression<Func<T, bool>> predicate);
    }
}
