using APIDailyTasks.Domain.Entities;

namespace DailyTask.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> ToListAsync();
        Task AddAsync(Tarefa tarefa);
        Task<Tarefa> FindByIdAsync(int id);
        Task<IEnumerable<Tarefa>> RecuperaTarefaNaoFinalizada();
        Task<IEnumerable<Tarefa>> RecuperaTarefaFinalizada();
        void Update(Tarefa tarefa);
        void Remove(Tarefa tarefa);

    }
}
