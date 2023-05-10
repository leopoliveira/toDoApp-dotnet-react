using System.ComponentModel.DataAnnotations.Schema;
using ToDo.API.Domain.Entities.Generics;
using ToDo.API.Domain.Enumerators;

namespace ToDo.API.Domain.Entities
{
    public class Todo : BaseEntity
    {
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }

        public EnumYesNo IsCompleted { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
