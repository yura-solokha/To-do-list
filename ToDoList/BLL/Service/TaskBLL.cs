using DAL.DataContext;
using DAL.Model;
using DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Service
{
    public class TaskBLL
    {
        private readonly TaskRepository taskRepository;

        public TaskBLL(TodoListContext todoListContext)
        {
            taskRepository = new TaskRepository(todoListContext);
        }

        public void Add(string name, int priority, Category category)
        {
            Task task = new Task();
            task.Name = name;
            task.Priority = priority;
            task.Is_done = false;
            
            if (category != null)
            {
                task.Category_id = category.Id;
            }

            taskRepository.Add(task);
        }
        public List<Task> FindAll()
        {
            return taskRepository.FindAll().ToList();
        }

        public Task FindById(int id)
        {
            return taskRepository.FindAll().FirstOrDefault(task => task.Id == id);
        }

        public void Remove(int id)
        {
            taskRepository.Remove(id);
        }
    }
}
