using Microsoft.EntityFrameworkCore;
using API.Models;
using Task = API.Models.Task;

namespace API;

public class TasksContext : DbContext {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Task> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        List<Category> categoriesInit = new List<Category>(){
            new Category(){
                IdCategory = Guid.Parse("bb400eef-eb06-4eed-90ac-cae351c8e3e5"),
                Name = "Actividades Pendientes",
                Impact = 20
            },
            new Category(){
                IdCategory = Guid.Parse("d8682463-0c22-4356-960c-2a25d3a961ac"),
                Name = "Actividades Personales",
                Impact = 50
            },
            new Category(){
                IdCategory = Guid.Parse("785f1edd-0a8f-4384-9f21-9d210692e685"),
                Name = "Actividades Grupales",
                Impact = 30
            }
        };

        modelBuilder.Entity<Category>(category => {
            category.ToTable("Category");
            category.HasKey(p => p.IdCategory);

            category.Property(p => p.Name).IsRequired().HasMaxLength(150);
            category.Property(p => p.Description).IsRequired(false);
            category.Property(p => p.Impact);

            category.HasData(categoriesInit);
        });


        List<Task> tasksInit = new List<Task>(){
            new Task(){
                IdTask = Guid.Parse("0c59ab0f-737b-4f62-8bc4-2eb725f3046d"),
                IdCategory = Guid.Parse("bb400eef-eb06-4eed-90ac-cae351c8e3e5"),
                Title = "Pago de Servicios Publicos",
                Priority = Priority.Medium,
                CreationDate = DateTime.Now,
            },
            new Task(){
                IdTask = Guid.Parse("55d8ca55-2764-4ecf-b15b-e17ed218dd7e"),
                IdCategory = Guid.Parse("d8682463-0c22-4356-960c-2a25d3a961ac"),
                Title = "Terminar de ver pelicula en Netflix",
                Priority = Priority.Low,
                CreationDate = DateTime.Now,
            },
            new Task(){
                IdTask = Guid.Parse("c20458e1-beeb-42f5-83d1-b5e12bb487b3"),
                IdCategory = Guid.Parse("785f1edd-0a8f-4384-9f21-9d210692e685"),
                Title = "Pichanga del Viernes",
                Priority = Priority.Hight,
                CreationDate = DateTime.Now,
            }
        };
        modelBuilder.Entity<Task>(task => {
            task.ToTable("Task");
            task.HasKey(p => p.IdTask);
            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.IdCategory);

            task.Property(p => p.Title).IsRequired().HasMaxLength(200);
            task.Property(p => p.Description).IsRequired(false);
            task.Property(p => p.Priority);
            task.Property(p => p.CreationDate);
            task.Property(p => p.CulminationDate).IsRequired(false);
            task.Ignore(p => p.Resume);

            task.HasData(tasksInit);
        });
    }
}