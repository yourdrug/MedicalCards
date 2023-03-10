using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories
{
    interface IRepository<T> : IDisposable 
        where T : class
    {
        Task<IEnumerable<T>> GetAll (); // получение всех объектов
        Task<T> GetById(int id); // получение одного объекта по id
        Task<T> Create(T item); // создание объекта
        Task<T> Update(T item); // обновление объекта
        Task<T> Delete(int id); // удаление объекта по id
        Task<IEnumerable<T>> GetAllByPredicate(Expression<Func<T, bool>> predicate);
    }
}
