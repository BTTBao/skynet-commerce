// Repositories/IRepository.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Skynet_Ecommerce.DAL.Repositories.Seller
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}