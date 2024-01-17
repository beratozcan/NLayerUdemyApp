using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class TodoRepository : GenericRepository<TodoItem>, ITodoRepository
    {
        public TodoRepository(AppDbContext context) : base(context) { 
        }

        public async Task<IEnumerable<TodoItem>> GetTodoWithGroupByIdAsync()
        {
            return await _context.TodoItems.Include(x => x.TodoGroup).ToListAsync();
        }
    }
}
