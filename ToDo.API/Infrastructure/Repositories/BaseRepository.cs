using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using ToDo.API.Domain.Entities.Generics;
using ToDo.API.Domain.Interfaces.Repositories;
using ToDo.API.Domain.Utilities;
using ToDo.API.Infrastructure.Persistence.AppDbContext;

namespace ToDo.API.Infrastructure.Repositories
{
    /// <summary>
    /// Base Repository Interface implementation
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        #region Public Methods

        /// <summary>Gets the List of TEntity between dates.</summary>
        /// <param name="start">The start date.</param>
        /// <param name="end">The end date.</param>
        /// <param name="paginationParameters">The pagination parameters.</param>
        /// <returns>List of TEntity.</returns>
        public async Task<IEnumerable<TEntity>> GetBetweenDates(DateTime start, DateTime end, PaginationParameters paginationParameters)
        {
            return await _context.Set<TEntity>()
                                 .Where(e => e.CreatedDate <= end && e.CreatedDate >= start)
                                 .OrderBy(e => e.CreatedDate)
                                 .Skip(paginationParameters.PageIndex - 1)
                                 .Take(paginationParameters.PageSize)
                                 .ToListAsync();
        }

        /// <summary>Gets a List of TEntity by date.</summary>
        /// <param name="date">The date.</param>
        /// <param name="paginationParameters">The pagination parameters.</param>
        /// <returns>List of TEntity.</returns>
        public async Task<IEnumerable<TEntity>> GetByDate(DateTime date, PaginationParameters paginationParameters)
        {
            return await _context.Set<TEntity>()
                                 .Where(e => e.CreatedDate == date)
                                 .OrderBy(e => e.CreatedDate)
                                 .Skip(paginationParameters.PageIndex - 1)
                                 .Take(paginationParameters.PageSize)
                                 .ToListAsync();
        }

        /// <summary>Gets the TEntity by Id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TEntity.</returns>
        public async Task<TEntity> GetBydId(Guid id)
        {
            return await _context.Set<TEntity>()
                                 .Where(e => e.Id == id)
                                 .FirstOrDefaultAsync();
        }

        /// <summary>Gets a List of TEntity by the given expression.</summary>
        /// <param name="expression">The expression.</param>
        /// <param name="paginationParameters">The pagination parameters.</param>
        /// <returns>List of TEntity.</returns>
        public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> expression, PaginationParameters paginationParameters)
        {
            return await _context.Set<TEntity>()
                                 .Where(expression)
                                 .OrderBy(e => e.CreatedDate)
                                 .Skip(paginationParameters.PageIndex - 1)
                                 .Take(paginationParameters.PageSize)
                                 .ToListAsync();
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public async Task Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);

            await _context.SaveChangesAsync();
        }

        /// <summary>Updates the specified entity.</summary>
        /// <param name="entity">The entity to update.</param>
        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public async Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        #endregion Public Methods
    }
}