using System.Linq.Expressions;

using ToDo.API.Domain.Entities.Generics;
using ToDo.API.Domain.Utilities;

namespace ToDo.API.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Base Repository Interface
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        #region Public Methods

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task Create(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task Delete(TEntity entity);

        /// <summary>
        /// Gets the List of TEntity between dates.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="paginationParameters">The pagination parameters.</param>
        /// <returns>
        /// List of TEntity.
        /// </returns>
        Task<IEnumerable<TEntity>> GetBetweenDates(DateTime start, DateTime end, PaginationParameters paginationParameters);

        /// <summary>
        /// Gets a List of TEntity by date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="paginationParameters">The pagination parameters.</param>
        /// <returns>
        /// List of TEntity.
        /// </returns>
        Task<IEnumerable<TEntity>> GetByDate(DateTime date, PaginationParameters paginationParameters);

        /// <summary>
        /// Gets the TEntity by Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// TEntity.
        /// </returns>
        Task<TEntity> GetBydId(Guid id);

        /// <summary>
        /// Gets a List of TEntity by the given expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="paginationParameters">The pagination parameters.</param>
        /// <returns>
        /// List of TEntity.
        /// </returns>
        Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> expression, PaginationParameters paginationParameters);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task Update(TEntity entity);

        #endregion Public Methods
    }
}