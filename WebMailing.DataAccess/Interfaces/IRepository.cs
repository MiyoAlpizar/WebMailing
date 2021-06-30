using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebMailing.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets Entity of Type <typeparamref name="T"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> Get(int id);

        /// <summary>
        /// Gets a List of <typeparamref name="T"/>
        /// </summary>
        /// <param name="filter">Filter to apply in the search</param>
        /// <param name="ascending">Order Ascending, if false will order Descending</param>
        /// <param name="orderBy">Params array to order by Properties</param>
        /// <returns>IEnumeralbe<typeparamref name="T"/></returns>
        Task<IEnumerable<T>> GetList(Func<T, bool> filter = null);
        
        /// <summary>
        /// Adds new Entity of type <typeparamref name="T"/> To de DataStore
        /// </summary>
        /// <param name="entity">Entyty to add</param>
        /// <returns><typeparamref name="T"/></returns>
        Task<T> Add(T entity);

        /// <summary>
        /// Removes an Entity from DataStore
        /// </summary>
        /// <param name="id">Id of Entity to Remove</param>
        /// <returns></returns>
        Task<bool> Remove(int id);

        /// <summary>
        /// Removes an Entity from DataStore
        /// </summary>
        /// <param name="entity">Entity to Remove</param>
        /// <returns></returns>
        Task<bool> Remove(T entity);
    }
}
