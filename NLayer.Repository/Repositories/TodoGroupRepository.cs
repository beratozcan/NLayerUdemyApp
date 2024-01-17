using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class TodoGroupRepository : GenericRepository<TodoGroup> , ITodoGroupRepository
    {

        public TodoGroupRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<TodoGroup>> GetTodoGroupWithTodosByIdAsync(int todoGroupId)
        {
            return await _context.TodoGroups.Include(x => x.TodoItems).Where(x => x.Id == todoGroupId).ToListAsync();
        }
    }
}
