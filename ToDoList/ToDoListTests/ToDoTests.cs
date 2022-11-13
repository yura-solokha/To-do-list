using BLL.Service;
using DAL.DataContext;
using DAL.Model;
using DAL.Repository;

namespace ToDoListTests
{
    [TestClass]
    public class ToDoTests
    {
        [TestMethod]
        public void User_IsValid_Registration()
        {
            var testEmail = "test@gmail.com";
            var testPassword = "test1234";

            var context = new TodoListContext();

            UserBLL user = new UserBLL(context);

            user.RegisterUser(testEmail, testPassword);

            Assert.AreEqual(testEmail, user.FindByEmail(testEmail).Email, "Not valid registration");
            
            user.Remove(user.FindByEmail(testEmail).Id);
        }

        [TestMethod]
        public void User_IsTrue_Login()
        {
            var testEmail = "logTest@gmail.com";
            var testPassword = "logTest";

            var context = new TodoListContext();

            UserBLL user = new UserBLL(context);

            user.RegisterUser(testEmail, testPassword);

            Assert.IsTrue(user.LoginUser(testEmail, testPassword), "Not valid registration");

            user.Remove(user.FindByEmail(testEmail).Id);
        }
        [TestMethod]
        public void User_IsFalse_Login()
        {
            var testEmail = "logTest@gmail.com";
            var testPassword = "logTest";

            var context = new TodoListContext();

            UserBLL user = new UserBLL(context);

            Assert.IsFalse(user.LoginUser(testEmail, testPassword), "Not valid registration");
        }
    }
}