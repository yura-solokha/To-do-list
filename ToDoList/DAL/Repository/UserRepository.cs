using DAL.DataContext;
using DAL.Model;
using System.Linq;

namespace DAL.Repository
{
    public class UserRepository
    {
        private readonly TodoListContext _context;

        public UserRepository(TodoListContext context)
        {
            _context = context;
        }
        public IQueryable<User> FindAll()
        {
            return _context.Users;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            User user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

    }
}
