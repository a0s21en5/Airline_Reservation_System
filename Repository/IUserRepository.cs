using Airline_Reservation_System.Models;
using System.Collections.Generic;

namespace Airline_Reservation_System.Repository
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        void AddUser(User user);
        bool Delete(int id);
        void Edit(User user);
        User Details(int id);
        User checkEdit(int id);
        User GetUserById(int id);
        User GetUserByName(string name);
    }
}
