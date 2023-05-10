using System.ComponentModel.DataAnnotations.Schema;
using ToDo.API.Domain.Entities.Generics;

namespace ToDo.API.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
    }
}
