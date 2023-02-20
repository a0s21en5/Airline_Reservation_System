using Airline_Reservation_System.Models;
using System.Collections.Generic;

namespace Airline_Reservation_System.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User checkEdit(int id);
        void Edit(User user);
        List<User> GetAllUser();
        User GetUserByName(string name);

        User GetUserById(int id);
        bool Delete(int id);
        User Details(int id);
        User Login(UserLogin userLogin);
        List<Plain> UserGetAllPlains();
        Ticket FindIdFromTicket(int userId, int id);
        bool BookTicket(Ticket ticket);
        List<Ticket> BookingHistory(int userId);
    }
}
