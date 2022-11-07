using DAL.DataContext;
using DAL.Model;
using DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Service
{
    public class UserBLL
    {
        private readonly UserRepository userRepository;

        public UserBLL(TodoListContext todoListContext)
        {
            userRepository = new UserRepository(todoListContext);
        }

        public List<User> FindAll()
        {
            return userRepository.FindAll().ToList();
        }

        public User FindById(int id)
        {
            return userRepository.FindAll().FirstOrDefault(user => user.Id == id);
        }

        public void RegisterUser(string email, string password)
        {
            var user = new User
            {
                Email = email,
                Password = password
            };

            userRepository.Add(user);
        }

        public bool LoginUser(string email, string password)
        {
            var user = userRepository.FindAll().FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return false;
            }

            return password == user.Password;
        }

        public void Remove(int id)
        {
            userRepository.Remove(id);
        }
    }
}
