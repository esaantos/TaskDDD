using DailyTask.Domain.Interfaces.Repositories;
using DailyTasks.Persistence.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTask.Persistence.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TarefaContext _context;

        public UnitOfWork(TarefaContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
