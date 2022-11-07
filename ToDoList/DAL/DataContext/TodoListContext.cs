using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace DAL.DataContext
{
    public class TodoListContext : DbContext
    {
        public TodoListContext()
        {
        }

        public TodoListContext(DbContextOptions<TodoListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;port=5432;user id=postgres;password=123;database=todo;";
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("users_pk");

                entity.ToTable("users");

                entity.HasIndex(e => e.Email).HasName("uemail").IsUnique();

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(8)
                    .HasColumnName("password");

                entity.Property(e => e.Email)
                    .HasMaxLength(126)
                    .HasColumnName("email");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("tasks_pk");

                entity.ToTable("tasks");

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(126)
                    .HasColumnName("name");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.Is_done).HasColumnName("is_done");

                entity.Property(e => e.Category_id).HasColumnName("category_id");

                entity.HasOne(d => d.Category).WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.Category_id)
                    .HasConstraintName("fc_category");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(56)
                    .HasColumnName("name");
            });
        }
    }
}
