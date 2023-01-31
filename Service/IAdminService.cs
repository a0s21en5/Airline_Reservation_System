using Airline_Reservation_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Airline_Reservation_System.Service
{
    public interface IAdminService
    {
        List<Admin> GetAllAdmin();
        bool AddAdmin(Admin admin);
        bool Delete(int id);
        void Edit(Admin admin);
        Admin GetAdminbyId(int id);
        Admin checkEdit(int id);
        Admin Details(int id);
    }
}
