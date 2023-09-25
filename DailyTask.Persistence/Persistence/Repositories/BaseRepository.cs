using DailyTasks.Persistence.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTask.Persistence.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly TarefaContext _context;
        public BaseRepository(TarefaContext context)
        {
            _context = context;
        }
    }
}
