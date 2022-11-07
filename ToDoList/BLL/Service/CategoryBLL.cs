using DAL.DataContext;
using DAL.Model;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Service
{
    public class CategoryBLL
    {
        private readonly CategoryRepository categoryRepository;

        public CategoryBLL(TodoListContext todoListContext)
        {
            categoryRepository = new CategoryRepository(todoListContext);
        }

        public List<Category> FindAll()
        {
            return categoryRepository.FindAll().ToList();
        }

        public Category FindById(int id)
        {
            return categoryRepository.FindAll().FirstOrDefault(category => category.Id == id);
        }

        public void Remove(int id)
        {
            categoryRepository.Remove(id);
        }
    }
}
