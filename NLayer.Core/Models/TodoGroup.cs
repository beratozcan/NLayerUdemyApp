using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class TodoGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TodoItem> TodoItems { get; set; }
        
        public User User { get; set; }

        public int UserId { get; set; }




    }
}
