using APIDailyTasks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyTasks.Persistence.Persistence.Context
{
    public class TarefaContext: DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> opts): base(opts)
        {

        }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
