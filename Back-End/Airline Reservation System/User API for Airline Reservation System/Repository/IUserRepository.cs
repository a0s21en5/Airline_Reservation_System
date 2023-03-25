using User_API_for_Airline_Reservation_System.Models;

namespace User_API_for_Airline_Reservation_System.Repository
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        void AddUser(User user);
        User GetUserByName(string name);
        bool Delete(int id);
        User GetUserById(int id);
        User Details(int id);
        User Login(UserLogin userLogin);
        int EditUser(User user);
    }
}
