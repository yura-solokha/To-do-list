using DAL.DataContext;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class CategoryRepository
    {
        private readonly TodoListContext _context;

        public CategoryRepository(TodoListContext context)
        {
            _context = context;
        }
        public IQueryable<Category> FindAll()
        {
            return _context.Categories;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            Category category = _context.Categories.Find(id);

            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
