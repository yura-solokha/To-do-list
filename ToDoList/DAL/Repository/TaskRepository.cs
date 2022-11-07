using DAL.DataContext;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class TaskRepository
    {
        private readonly TodoListContext _context;

        public TaskRepository(TodoListContext context)
        {
            _context = context;
        }
        public IQueryable<Task> FindAll()
        {
            return _context.Tasks;
        }

        public void Add(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            Task task = _context.Tasks.Find(id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
