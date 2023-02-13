using Airline_Reservation_System.Context;
using Airline_Reservation_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Airline_Reservation_System.Repository
{
    public class AdminRepository: IAdminRepository
    {
        readonly AirlineReservationSystemContextDb _airlineReservationSystemContextDb;
        public AdminRepository(AirlineReservationSystemContextDb airlineReservationSystemContextDb)
        {
            _airlineReservationSystemContextDb = airlineReservationSystemContextDb;
        }

        //Show All Admin
        public List<Admin> GetAllAdmin()
        {
            return _airlineReservationSystemContextDb.admins.ToList();
        }

        //Add Admin
        public bool AddAdmin(Admin admin)
        {
            _airlineReservationSystemContextDb.admins.Add(admin);
            return _airlineReservationSystemContextDb.SaveChanges() == 1?true:false;
        }

        //Delete Admin
        public bool Delete(int id)
        {
            _airlineReservationSystemContextDb.admins.Remove(GetAdminbyId(id));
            return _airlineReservationSystemContextDb.SaveChanges()==1?false:true;
        }

        //Get Product By Id
        public Admin GetAdminbyId(int id)
        {
            return _airlineReservationSystemContextDb.admins.Where(A=>A.adminId == id).FirstOrDefault();
        }

        //Edit Admin
        public void Edit(Admin admin)
        {
            Admin editSearch = GetAdminbyId(admin.adminId);
            editSearch.adminEmail=admin.adminEmail;
            editSearch.adminPassword=admin.adminPassword;
            _airlineReservationSystemContextDb.SaveChanges();
        }

        //checkEdit
        public Admin checkEdit(int id)
        {
            return _airlineReservationSystemContextDb.admins.Where(A=>A.adminId==id).FirstOrDefault();  
        }

        //Admin Details
        public Admin Details(int id)
        {
            Admin searchAdmin = GetAdminbyId(id);
            return searchAdmin;
        }
    }
}
