using APIDailyTasks.Domain.Entities;
using DailyTask.Domain.Communication;

namespace DailyTask.Domain.Interfaces.Services
{
    public interface ITarefaService
    {
        Task<IEnumerable<Tarefa>> RecuperaTarefa();
        Task<Response<Tarefa>> AdicionaTarefa(Tarefa tarefa);
        Task<Tarefa> RecuperaTarefaPorId(int id);
        Task<IEnumerable<Tarefa>> RecuperaTarefaNaoFinalizada();
        Task<IEnumerable<Tarefa>> RecuperaTarefaFinalizada();
        Task<Response<Tarefa>> AtualizaTarefa(int id, Tarefa tarefa);
        Task<Response<Tarefa>> DeletaTarefa(int id);
    }
}
