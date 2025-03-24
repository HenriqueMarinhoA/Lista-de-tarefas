using ListaTarefasAPI.Dominio;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefasAPI.Infraestrutura
{
    public class AppDbContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
