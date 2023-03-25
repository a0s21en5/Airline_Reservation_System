using User_API_for_Airline_Reservation_System.Models;

namespace User_API_for_Airline_Reservation_System.Service
{
    public interface IUserService
    {
        List<User> GetAllUser();
        bool AddUser(User user);
        bool Delete(int id);
        User Details(int id);
        User Login(UserLogin userLogin);
        User GetUserById(int id);
        bool EditUser(int id, User user);
    }
}
