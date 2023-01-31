using Airline_Reservation_System.Models;
using Airline_Reservation_System.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Airline_Reservation_System.Controllers
{
    public class AdminController : Controller
    {
        readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        //Show All Admin
        public ActionResult GetAllAdmin()
        {
            List<Admin> AllAdmin = _adminService.GetAllAdmin();
            return View(AllAdmin);
        }

        //Add Admin
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult AddAdmin(Admin admin)
        {
            _adminService.AddAdmin(admin);
            return RedirectToAction("GetAllAdmin");
        }

        //Edit User
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Admin editSearch = _adminService.checkEdit(id);
            return View(editSearch);
        }

        [HttpPost]
        public ActionResult Edit(Admin admin)
        {
            _adminService.Edit(admin);
            return RedirectToAction("GetAllUser");
        }

        //Delete Admin
        public ActionResult Delete(int id)
        {
            _adminService.Delete(id);
            return RedirectToAction("GetAllAdmin");
        }

        //Details User
        public ActionResult Details(int id)
        {
            Admin adminDetails = _adminService.Details(id);
            return View(adminDetails);
        }
    }
}

