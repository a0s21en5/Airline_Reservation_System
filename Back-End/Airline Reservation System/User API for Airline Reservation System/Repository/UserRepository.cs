using User_API_for_Airline_Reservation_System.Context;
using User_API_for_Airline_Reservation_System.Models;

namespace User_API_for_Airline_Reservation_System.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly UserDbContext _userDbContext;
        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        //GetAllUser
        public List<User> GetAllUser()
        {
            return _userDbContext.users.ToList();
        }

        //AddUser
        public void AddUser(User user)
        {
            _userDbContext.users.Add(user);
            _userDbContext.SaveChanges();
        }

        //Get User By Name
        public User GetUserByName(string name)
        {
            return _userDbContext.users.Where(u => u.Name == name).FirstOrDefault();
        }

        //Delete User
        public bool Delete(int id)
        {
            _userDbContext.users.Remove(GetUserById(id));
            return _userDbContext.SaveChanges() == 1 ? false : true;
        }

        //Get User By Id
        public User GetUserById(int id)
        {
            return _userDbContext.users.Where(u => u.Id == id).FirstOrDefault();
        }

        //Details
        public User Details(int id)
        {
            User searchUser = GetUserById(id);
            return searchUser;
        }

        //Login
        public User Login(UserLogin userLogin)
        {
            return _userDbContext.users.Where(u => u.Email == userLogin.Email && u.Password == userLogin.Password).FirstOrDefault();
        }

        //Edit User
        public int EditUser(User user)
        {
            _userDbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _userDbContext.SaveChanges();
        }
    }
}

