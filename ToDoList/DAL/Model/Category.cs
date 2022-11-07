using System.Collections.Generic;

namespace DAL.Model
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; } = new List<Task>();
    }
}
