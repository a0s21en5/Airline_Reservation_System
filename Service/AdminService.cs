using Airline_Reservation_System.Context;
using Airline_Reservation_System.Models;
using Airline_Reservation_System.Repository;
using System;
using System.Collections.Generic;

namespace Airline_Reservation_System.Service
{
    public class AdminService: IAdminService
    {
        readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        //Show All Admin
        public List<Admin> GetAllAdmin()
        {
            return _adminRepository.GetAllAdmin();
        }

        //Add Admin
        public bool AddAdmin(Admin admin)
        {
            var AdminExistsStatus = _adminRepository.GetAdminbyId(admin.adminId);
            if (AdminExistsStatus == null)
            {
                _adminRepository.AddAdmin(admin);
            }
            return false;
        }

        //Delete Admin
        public bool Delete(int id)
        {
            var AdminExistsStatus = _adminRepository.GetAdminbyId(id);
            if(AdminExistsStatus != null)
            {
                return _adminRepository.Delete(id);
            }
            return false;
        }

        //Get Admin By Id
        public Admin GetAdminbyId(int id)
        {
            return _adminRepository.GetAdminbyId(id);
        }

        //Edit Admin
        public void Edit(Admin admin)
        {
            _adminRepository.Edit(admin);
        }

        //checkEdit
        public Admin checkEdit(int id)
        {
            return _adminRepository.checkEdit(id);
        }

        public Admin Details(int id)
        {
            return _adminRepository.Details(id);
        }
    }
}
