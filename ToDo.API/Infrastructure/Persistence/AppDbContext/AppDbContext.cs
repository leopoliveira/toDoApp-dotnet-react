using Microsoft.EntityFrameworkCore;
using ToDo.API.Domain.Entities;

namespace ToDo.API.Infrastructure.Persistence.AppDbContext
{
    /// <summary>
    /// Application DbContext
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext"/>
    public class AppDbContext : DbContext
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        /// <remarks>
        /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration,
        /// and initialization</see> and
        /// <see href="https://aka.ms/efcore-docs-dbcontext-options">Using DbContextOptions</see>
        /// for more information and examples.
        /// </remarks>
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        #endregion Public Constructors



        #region Public Properties

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public DbSet<Category> CATEGORY { get; set; }

        /// <summary>
        /// Gets or sets the todo list.
        /// </summary>
        /// <value>The todo list.</value>
        public DbSet<Todo> TODO { get; set; }

        #endregion Public Properties
    }
}