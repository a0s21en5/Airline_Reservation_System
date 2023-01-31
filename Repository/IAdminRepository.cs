using Airline_Reservation_System.Models;
using System.Collections.Generic;

namespace Airline_Reservation_System.Repository
{
    public interface IAdminRepository
    {
        List<Admin> GetAllAdmin();
        bool AddAdmin(Admin admin);
        bool Delete(int id);
        Admin GetAdminbyId(int id);
        void Edit(Admin admin);
        Admin checkEdit(int id);
        Admin Details(int id);
    }
}
