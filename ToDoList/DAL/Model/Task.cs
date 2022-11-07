namespace DAL.Model
{
    public partial class Task
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Is_done { get; set; }
        public int Priority { get; set; }
        public int Category_id { get; set; }

        public virtual Category Category { get; set; }
    }
}
