using Airline_Reservation_System.Models;
using System.Collections.Generic;

namespace Airline_Reservation_System.Service
{
    public interface IUserService
    {
        bool AddUser(User user);
        User checkEdit(int id);
        void Edit(User user);
        List<User> GetAllUser();
        bool Delete(int id);
        User Details(int id);
        User Login(UserLogin userLogin);
        List<Plain> UserGetAllPlains();
        User FindUser(string userName);
        Ticket FindIdFromTicket(int userId, int id);
        bool BookTicket(Ticket ticket);
        List<Ticket> BookingHistory(int userId);
    }
}
