using Airline_Reservation_System.Models;
using System.Collections.Generic;

namespace Airline_Reservation_System.Service
{
    public interface IUserService
    {
        bool AddUser(User user);
        User checkEdit(int id);
        bool Delete(int id);
        User Details(int id);
        void Edit(User user);
        List<User> GetAllUser();
    }
}
