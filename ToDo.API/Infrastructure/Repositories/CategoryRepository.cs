using ToDo.API.Domain.Entities;
using ToDo.API.Domain.Interfaces.Repositories;
using ToDo.API.Infrastructure.Persistence.AppDbContext;

namespace ToDo.API.Infrastructure.Repositories
{
    /// <summary>
    /// Category Repository Implementation
    /// </summary>
    /// <seealso cref="ToDo.API.Infrastructure.Repositories.BaseRepository&lt;ToDo.API.Domain.Entities.Category&gt;" />
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CategoryRepository(AppDbContext context) : base(context) { }
    }
}
