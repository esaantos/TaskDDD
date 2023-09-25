using APIDailyTasks.Domain.Entities;
using DailyTask.Domain.Interfaces.Repositories;
using DailyTasks.Persistence.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DailyTask.Persistence.Persistence.Repositories
{
    public class TarefaRepository : BaseRepository, ITarefaRepository
    {
        public TarefaRepository(TarefaContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Tarefa>> ToListAsync()
        {
            return await _context.Tarefas.ToListAsync();
        }
        public async Task AddAsync(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
        }

        public async Task<Tarefa> FindByIdAsync(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public void Update(Tarefa tarefa)
        {
            _context.Update(tarefa);
        }
        public void Remove(Tarefa tarefa)
        {
            _context.Remove(tarefa);
        }

        public async Task<IEnumerable<Tarefa>> RecuperaTarefaFinalizada()
        {
            return await _context.Tarefas.Where(tarefa => tarefa.Finalizado).ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> RecuperaTarefaNaoFinalizada()
        {
            return await _context.Tarefas.Where(tarefa => !tarefa.Finalizado).ToListAsync();
        }

    }
}
