using ToDo.API.Domain.Entities;
using ToDo.API.Domain.Interfaces.Repositories;
using ToDo.API.Infrastructure.Persistence.AppDbContext;

namespace ToDo.API.Infrastructure.Repositories
{
    /// <summary>
    /// Todo Repository Implementation
    /// </summary>
    /// <seealso cref="ToDo.API.Infrastructure.Repositories.BaseRepository&lt;ToDo.API.Domain.Entities.Todo&gt;" />
    public class TodoRepository : BaseRepository<Todo>, ITodoRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TodoRepository(AppDbContext context) : base(context) { }
    }
}
